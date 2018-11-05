global Simul 'Wenn 1, dann andere Eingänge,  wird später alles auskommentiert
Simul = 1

dim OP_FS(4)
dim IP_FS(4)
dim Error_FS(4)      'Fehlerstatus 0 ok, 1 fördert, 2 Fehler aufgetreten z.B. Timeout
global IP_PalOK  'Eingang zum Palettenstreckenentstören
global IP_MagOben, IP_MagUnten, OP_MagHeben, OP_MagSenken, IP_MagGreifen, OP_MagGreifen, IP_MagOffen, IP_MagNopush, OP_MagPush

if (simul) then
OP_FS(0, 41,42,43,44) 
IP_FS(0, 8,9,10,11)    '******  IP_FS(0, 41,42,43,44)
Error_FS(0, 0,0,0,0)
IP_PalOK = 7   '****** IP_PalOK = 33
IP_MagOben = 16    '******  IP_MagOben = 34 
IP_MagUnten =  17   '****** IP_MagUnten =  35
OP_MagHeben = 35
OP_MagSenken = 36
OP_MagGreifen = 37
IP_MagGreifen = 36 
IP_MagOffen = 37
IP_MagNopush = 18  '****** IP_MagNopush = 47
OP_MagPush = 47
else 'echte Projektwerte 
OP_FS(0, 41,42,43,44)
IP_FS(0, 41,42,43,44)
Error_FS(0, 0,0,0,0)
IP_PalOK = 33
IP_MagOben = 34 
IP_MagUnten =  35
OP_MagHeben = 35
OP_MagSenken = 36
OP_MagGreifen = 37
IP_MagGreifen = 36 
IP_MagOffen = 37
IP_MagNopush = 47
OP_MagPush = 47
end if

' IP_FS_MASKE, FS_MAX_ZEIT
CONST IP_FS_MASKE = 0   'mit 1 Eingänge umkehren
CONST FS_MAX_ZEIT = 30000   'max Zeit fördern der Palette in Millisekunden

'PalAbTime, PalAbZeit 'Zeitpunkt, ab der FS3 wieder befahren werden darf, Abstand in Sekunden
CONST PalAbZeit = 60  '60 Sekunden zwischen jeder Palette
global PalAbTime
PalAbTime = TIME  'zum Start generell freigeben

MagInit()

while 1 'cyclic motion
	if IN(IP_PalOK) = on then  'Palettenentstörtaste gedrückt
		for i = 0 to 3 step 1
			if Error_FS(i) = 2 then
				Error_FS(i) = 0
			end if
		next
		PalAbTime = TIME  'sofortige Freigabe
	end if
	foerdern(1)
	foerdern(2)
wend
end

'Förderstreckenvorschub
sub foerdern (FSNr)
  'Falls der Palettenplatz belegt ist und der Folgeplatz frei ist und kein Fehlerstatus, dann fördern
  if ((IN(IP_FS(FSNr)) XOR IP_FS_MASKE) = on) _ 
      and ((IN(IP_FS(FSNr)+1) XOR IP_FS_MASKE) = off) _
	  and Error_FS(FSNr) = 0 and Error_FS(FSNr+1) = 0 _
	  and (FSNr <> 2 or PalAbTime < TIME) then  'Den Endplatz nur anfahren, wenn Zeit abgelaufen
    OP(OP_FS(FSNr),1)
	OP(OP_FS(FSNr+1),1)
	Error_FS(FSNr) = 1  'Fördern aktiv
	TICKS = FS_MAX_ZEIT    ' 30 Sekunden
	while  (IN(IP_FS(FSNr)+1) XOR IP_FS_MASKE) = off and Error_FS(FSNr) < 2 
		if TICKS < 0 then
			PRINT "FEHLER Timeout Förderstrecke"
			Error_FS(FSNr) = 2
		end if
	 wend
    OP(OP_FS(FSNr),0)
	OP(OP_FS(FSNr+1),0)
	if Error_FS(FSNr) =1 then 'Fördern ist ohne Fehler beendet
		Error_FS(FSNr) = 0
		if (FSNr = 2) then
			PalAbTime = TIME + PalAbZeit
		end if
	end if	 
  end if
end sub 

'Palettenmagazin
sub MagInit ()
   if  (IN(IP_MagOben) = off) and (IN(IP_MagUnten) = off) then ' Magazin steht irgendwo
		if (IN(IP_MagOffen) = off) then  ' Der Vereinzelner ist nicht komplett offen -> lieber gezielt hochfahren
			OP(OP_MagGreifen,1)  'Greifer an
			MagHoch()
		end if
   end if
   
   OP(OP_MagPush, 0)   'Pusher definiert einfahren
   PRINT "Warte auf Pushereinfahrt"
   while (IN(IP_MagNopush) = off)  'Pusher sollte ganz eingefahren sein
   
   wend
   PRINT "Pusher eingefahren"
   
   if ((IN(IP_FS(0)) XOR IP_FS_MASKE) = off)  then ' keine Palette auf dem Bestückungsplatz, dann Pushen
		if (IN(IP_MagOben) = off) then
			OP(OP_MagGreifen,1)  'Greifer an
			MagHoch()
		end if
		MagPush()
   end if

	if (IN(IP_MagUnten) = off) then
			MagRunter()
		end if
   
end sub

sub MagHoch()
		OP(OP_MagSenken,0)
		OP(OP_MagHeben,1)
		while( IN(IP_MagOben) = OFF)
		
		wend
		OP(OP_MagHeben,0)
end sub

sub MagRunter()
		OP(OP_MagHeben,0)
		OP(OP_MagSenken,1)
		while( IN(IP_MagUnten) = OFF)
		
		wend
		OP(OP_MagSenken,0)
		OP(OP_MagGreifen,0)  'Greifer aus
end sub

sub MagPush()
		OP(OP_MagPush,1)
		while((IN(IP_FS(0)) XOR IP_FS_MASKE) = off)
		
		wend
		Warte(2)
		while((IN(IP_FS(0)) XOR IP_FS_MASKE) = off)
		
		wend
		
		OP(OP_MagPush,0)
		while( IN(IP_MagNopush) = OFF)
		
		wend
		Warte(2)
		while( IN(IP_MagNopush) = OFF)
		
		wend
end sub

sub Warte(Sekunden)
	local Timerhelp
	Timerhelp = TIME + Sekunden
	while TIME < Timerhelp
	wend
end sub