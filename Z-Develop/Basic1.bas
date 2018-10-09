'Ausg�nge werden mit OP_ benannt und Eing�nge mit IP_
'FS sind die 4 Rollenbahnen der Europalleten, der Ausgang startet den Motor, die Eingang ist ein Kontakt, wenn eine Palette auf der Rollenbahn steht
'Beim Palettenmagazin gibt es die Funktionen Heben und Senken, die nicht zusammen aktiviert werden d�rfen, und den Greifer �ber Pneumatikzylinder
'Der Controllersimulator hat als EIng�nge leider nicht die sp�teren Werte des ZIO, deswegen f�r die Test abweichende Eing�nge

dim Simul 'Wenn 1, dann andere Eing�nge,  wird sp�ter alles auskommentiert
Simul = 1

if (simul) then

dim OP_FS(4)
OP_FS(0, 41,42,43,44) 
dim IP_FS(4)
IP_FS(0, 8,9,10,11)    '******  IP_FS(0, 41,42,43,44)
dim Error_FS(4)      'Fehlerstatus 0 ok, 1 f�rdert, 2 Fehler aufgetreten z.B. Timeout
Error_FS(0, 0,0,0,0)

dim IP_PalOK  'Eingang zum Palettenstreckenentst�ren
IP_PalOK = 7   '****** IP_PalOK = 33

dim IP_MagOben, IP_MagUnten, OP_MagHeben, OP_MagSenken, IP_MagGreifen, OP_MagGreifen, IP_MagOffen, IP_MagNopush, OP_MagPush
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

dim OP_FS(4)
OP_FS(0, 41,42,43,44)
dim IP_FS(4)
IP_FS(0, 41,42,43,44)
dim Error_FS(4)      'Fehlerstatus 0 ok, 1 f�rdert, 2 Fehler aufgetreten z.B. Timeout
Error_FS(0, 0,0,0,0)

dim IP_PalOK  'Eingang zum Palettenstreckenentst�ren
IP_PalOK = 33

dim IP_MagOben, IP_MagUnten, OP_MagHeben, OP_MagSenken, IP_MagGreifen, OP_MagGreifen, IP_MagOffen, IP_MagNopush, OP_MagPush
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

dim IP_FS_MASKE, FS_MAX_ZEIT
IP_FS_MASKE = 0   'mit 1 Eing�nge umkehren
FS_MAX_ZEIT = 30000   'max Zeit f�rdern der Palette in Millisekunden

dim PalAbTime, PalAbZeit 'Zeitpunkt, ab der FS3 wieder befahren werden darf, Abstand in Sekunden
PalAbZeit = 60  '60 Sekunden zwischen jeder Palette
PalAbTime = TIME  'zum Start generell freigeben

dim XStapel(100)
dim YStapel(100)
dim ZStapel(100)
dim TStapel(100)


'Testspielereien
'AVSE0,92
'AVSE1,1
'AXSE0,270
'AYSE0,155
'AZSE0,190

XStapel(0,  1200,1200,1200,1200,1200,930,930,930,775,620,465,310,155,775,620,465,310,155,775,620,465,310,155)
XStapel(23,1200,1200,1200,1045,1045,1045,890,890,890,735,735,735,735,735,465,465,465,310,310,310,155,155,155)
XStapel(46,1200,1200,1200,1045,1045,1045,890,890,890,735,735,735,580,580,580,425,425,425,270,270,270,270,270)
XStapel(60,1200,1200,1200,1200,1200,930,930,930,775,620,465,310,155,775,620,465,310,155,775,620,465,310,155)
YStapel(0,  0,162,323,484,645,-6,264,534,-6,-6,-6,-6,-6,264,264,264,264,264,534,534,534,534,534)
YStapel(23,-6,264,534,-6,264,534,-6,264,534,0,162,323,484,645,-6,264,534,-6,264,534,-6,264,534)
YStapel(46,-6,264,534,-6,264,534,-6,264,534,-6,264,534,-6,264,534,-6,264,534,0,162,323,484,645)
YStapel(69,0,162,323,484,645,-6,264,534,-6,-6,-6,-6,-6,264,264,264,264,264,534,534,534,534,534)
ZStapel(0,  1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1)
ZStapel(23,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2)
ZStapel(46,3,3,3,3,3,3,3,3,3,3,3,3,3,3,3,3,3,3,3,3,3,3,3)
ZStapel(69,4,4,4,4,4,4,4,4,4,4,4,4,4,4,4,4,4,4,4,4,4,4,4)
TStapel(0,  0,0,0,0,0,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1)
TStapel(23,1,1,1,1,1,1,1,1,1,0,0,0,0,0,1,1,1,1,1,1,1,1,1)
TStapel(46,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,0,0,0,0,0)
TStapel(69,0,0,0,0,0,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1)

PRINT XStapel(46)
PRINT XStapel(22)


ERRSWITCH = 3
base (0) '0 select shaft

atype = 1 'pulse stepper or servo
dpos = 0
units = 100 'pulse equivalent per pulse mm100
speed = 200
accel = 50
decel = 50

MagInit()

while 1 'cyclic motion
	
	if IN(IP_PalOK) = on then  'Palettenentst�rtaste gedr�ckt
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


'Move the subroutine call
sub testmove (distance)
	trace "testmove entered, distance =" distance 'debugging output
	move (distance)
end sub

'F�rderstreckenvorschub
sub foerdern (FSNr)
  'Falls der Palettenplatz belegt ist und der Folgeplatz frei ist und kein Fehlerstatus, dann f�rdern
  if ((IN(IP_FS(FSNr)) XOR IP_FS_MASKE) = on) _ 
      and ((IN(IP_FS(FSNr)+1) XOR IP_FS_MASKE) = off) _
	  and Error_FS(FSNr) = 0 and Error_FS(FSNr+1) = 0 _
	  and (FSNr <> 2 or PalAbTime < TIME) then  'Den Endplatz nur anfahren, wenn Zeit abgelaufen
    OP(OP_FS(FSNr),1)
	OP(OP_FS(FSNr+1),1)
	Error_FS(FSNr) = 1  'F�rdern aktiv
	TICKS = FS_MAX_ZEIT    ' 30 Sekunden
	while  (IN(IP_FS(FSNr)+1) XOR IP_FS_MASKE) = off and Error_FS(FSNr) < 2 
		if TICKS < 0 then
			PRINT "FEHLER Timeout F�rderstrecke"
			Error_FS(FSNr) = 2
		end if
	 wend
    OP(OP_FS(FSNr),0)
	OP(OP_FS(FSNr+1),0)
	if Error_FS(FSNr) =1 then 'F�rdern ist ohne Fehler beendet
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
   
   if ((IN(IP_FS(0)) XOR IP_FS_MASKE) = off)  then ' keine Palette auf dem Best�ckungsplatz, dann Pushen
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