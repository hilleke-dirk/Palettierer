Imports System.Xml
Public Class Palettierer

    Public g_handle As Integer

    '    ' Create a jagged array of arrays that have different lengths. 
    '    Dim jaggedNumbers = {({1, 2, 3}), ({4, 5}), ({6}), ({7})}

    '    For indexA = 0 To jaggedNumbers.Length - 1
    '    For indexB = 0 To jaggedNumbers(indexA).Length - 1
    '        Debug.Write(jaggedNumbers(indexA)(indexB) & " ")
    '    Next
    '    Debug.WriteLine("")
    'Next

    '    ' Output: 
    '    '  1 2 3  
    '    '  4 5  
    '    '  6 
    '  7

    Dim ThreadR, ThreadM, ThreadS As System.Threading.Thread

    Public LedAus, LedAn As Bitmap

    Dim Statustexte() As String = {"Gestoppt", "Warte auf Palettenausfuhr", "Warte auf Palette", "Warte auf Karton", "Positionierfahrt", "Rückfahrt", "Referenzfahrt Start", "Referenzfahrt Lage", "Referenzfahrt klein"}
    Dim Status_Verbunden, Status_Aktiv, Status_Gestoppt, Status_Stapeln As Boolean

    Dim Aktuelles_Programm = 0, Aktueller_Karton = 0, Aktuelle_AnzKartons = 0, Aktuelle_Paletten = 0, Aktuelle_AnzPaletten = 0
    'Stapeltask solange bis Aktuelle_Anzkartons erreicht und Status_Stapeln = true
    Const T_normal = 0      'Postionswerte für die T-Achse
    Const T_gedreht = 7386



#Const simul = 1  'Simulationswerte

#If simul Then

    Dim OP_FS() As Integer = {41, 42, 43, 44}
    Dim IP_FS() As Integer = {8, 9, 10, 11}    '******  IP_FS(0, 41,42,43,44)
    Dim IP_PalOK = 7   '****** IP_PalOK = 33
    Dim IP_MagOben = 16    '******  IP_MagOben = 34 
    Dim IP_MagUnten = 17   '****** IP_MagUnten =  35
    Dim OP_MagHeben = 35
    Dim OP_MagSenken = 36
    Dim OP_MagGreifen = 37
    Dim IP_MagGreifen = 36
    Dim IP_MagOffen = 37
    Dim IP_MagNopush = 18  '****** IP_MagNopush = 47
    Dim OP_MagPush = 47
    Dim IP_KartonDa = 12
    Dim OP_KartonGreifen1 = 38
    Dim OP_KartonGreifen2 = 39
    Dim OP_KartonAnheben = 40
    Dim IP_KartonAnheben = 14
    Dim IP_KartonGreiferAuf = 15
    Dim IP_KartonGreiferZu = 16

#Else 'echte Projektwerte 
    Dim OP_FS() as integer = {41,42,43,44}
    Dim IP_FS() as integer = {41,42,43,44}
    Dim IP_PalOK = 33
    Dim IP_MagOben = 34 
    Dim IP_MagUnten =  35
    Dim OP_MagHeben = 35
    Dim OP_MagSenken = 36
    Dim OP_MagGreifen = 37
    Dim IP_MagGreifen = 36 
    Dim IP_MagOffen = 37
    Dim IP_MagNopush = 47
    Dim OP_MagPush = 47
    Dim IP_KartonDa = 40
    Dim OP_KartonGreifen1 = 38
    Dim OP_KartonGreifen2 = 39
    Dim OP_KartonAnheben = 40
    Dim IP_KartonAnheben = 45
    Dim IP_KartonGreiferAuf = 38
    Dim IP_KartonGreiferZu = 39
#End If

    Dim Prog_namen() As String = {"", "A-4-92", "C-4-72", "D-4-76", "E-3-40", "E-4-54", "E-4-60", "F-4-48", "H-4-48", "I-4-36", "K-4-40"}
    Dim Prog_lagen() As Integer = {0, 4, 4, 4, 3, 4, 4, 4, 4, 4, 4}
    Dim Prog_karton() As Integer = {0, 92, 72, 76, 40, 54, 60, 48, 48, 36, 40}
    Dim Prog_xl() As Integer = {0, 270, 270, 270, 270, 270, 270, 398, 398, 377, 377}
    Dim Prog_yl() As Integer = {0, 155, 195, 175, 220, 220, 220, 170, 190, 265, 240}
    Dim Prog_zl() As Integer = {0, 190, 190, 190, 190, 190, 190, 195, 192, 190, 190}

    Dim Prog_zfaktor() As Integer = {0, 172, 345, 517, 690, 862}  ' Faktor für die Kartonhöhe und Ebene, 1 = 0

    Dim Prog_queue_anz = 0 'Anzahl eingebener Stapelprogramme
    Dim Prog_xpos = {({0}),
                      ({1200, 1200, 1200, 1200, 1200, 930, 930, 930, 775, 620, 465, 310, 155, 775, 620, 465, 310, 155, 775, 620, 465, 310, 155,
                        1200, 1200, 1200, 1045, 1045, 1045, 890, 890, 890, 735, 735, 735, 735, 735, 465, 465, 465, 310, 310, 310, 155, 155, 155,
                        1200, 1200, 1200, 1045, 1045, 1045, 890, 890, 890, 735, 735, 735, 580, 580, 580, 425, 425, 425, 270, 270, 270, 270, 270,
                        1200, 1200, 1200, 1200, 1200, 930, 930, 930, 775, 620, 465, 310, 155, 775, 620, 465, 310, 155, 775, 620, 465, 310, 155}),
                      ({1200, 1200, 1200, 1200, 930, 930, 930, 930, 660, 660, 660, 660, 390, 390, 390, 195, 195, 195,
                        1200, 1200, 1200, 1005, 1005, 1005, 1005, 735, 735, 735, 540, 540, 540, 540, 270, 270, 270, 270,
                        1200, 1200, 1200, 1200, 930, 930, 930, 930, 660, 660, 660, 660, 390, 390, 390, 195, 195, 195,
                        1200, 1200, 1200, 1005, 1005, 1005, 1005, 735, 735, 735, 540, 540, 540, 540, 270, 270, 270, 270}),
                      ({1190, 1190, 1190, 1013, 1013, 1013, 834, 834, 834, 657, 657, 657, 480, 480, 480, 303, 303, 303, 303,
                        1190, 1190, 1190, 1190, 918, 918, 918, 741, 741, 741, 564, 564, 564, 387, 387, 387, 210, 210, 210,
                        1190, 1190, 1190, 1013, 1013, 1013, 836, 836, 836, 836, 564, 564, 564, 387, 387, 387, 210, 210, 210,
                        1190, 1190, 1190, 1013, 1013, 1013, 834, 834, 834, 657, 657, 657, 480, 480, 480, 303, 303, 303, 303}),
                      ({1185, 1185, 960, 960, 1185, 738, 738, 909, 516, 516, 633, 294, 294, 345,
                        1185, 1185, 1185, 912, 963, 963, 636, 363, 741, 741, 519, 519, 297, 297,
                        1185, 963, 1182, 1185, 741, 963, 741, 519, 297, 351, 519, 297}),
                      ({1185, 1185, 960, 960, 1185, 738, 738, 909, 516, 516, 633, 294, 294, 345,
                      1185, 1185, 1185, 912, 963, 963, 636, 363, 741, 741, 519, 519, 297, 297,
                      1185, 1185, 960, 960, 1185, 738, 738, 909, 516, 516, 633, 294, 294, 345,
                      1185, 963, 1182, 1185, 741, 963, 741, 519, 297, 351, 519, 297}),
                      ({1200, 981, 1158, 762, 936, 1197, 543, 717, 927, 273, 447, 657, 225, 438, 219,
1200, 930, 1170, 951, 1200, 981, 660, 729, 762, 441, 456, 543, 222, 234, 273,
1200, 981, 1158, 762, 936, 1200, 543, 717, 927, 273, 447, 657, 225, 438, 219,
1200, 930, 1170, 951, 1200, 981, 660, 729, 762, 441, 456, 543, 222, 234, 273}),
                      ({1180, 1180, 1000, 1000, 800, 800, 600, 600, 400, 400, 200, 200,
1200, 800, 400, 1200, 1000, 800, 600, 400, 200, 1200, 800, 400,
1180, 1180, 1000, 1000, 800, 800, 600, 600, 400, 400, 200, 200,
1200, 800, 400, 1200, 1000, 800, 600, 400, 200, 1200, 800, 400}),
                      ({1200, 1200, 1000, 1200, 795, 795, 600, 600, 400, 400, 195, 400,
1200, 1200, 1002, 1002, 807, 999, 600, 600, 387, 591, 189, 189,
1200, 1200, 1200, 1200, 798, 798, 798, 798, 399, 399, 399, 399,
1200, 1200, 1000, 1200, 795, 795, 600, 600, 400, 400, 195, 400}),
                      ({1191, 1188, 921, 918, 651, 648, 381, 381, 381,
1197, 1197, 1197, 816, 813, 543, 540, 276, 270,
1191, 1188, 924, 921, 657, 651, 390, 387, 387,
1197, 1197, 1197, 816, 813, 543, 540, 276, 270}),
                      ({1200, 1200, 960, 960, 720, 720, 480, 480, 240, 240,
1200, 1200, 960, 960, 720, 720, 480, 480, 240, 240,
1200, 1200, 960, 960, 720, 720, 480, 480, 240, 240,
1200, 1200, 960, 960, 720, 720, 480, 480, 240, 240}),
                      ({}),
                      ({})
    }

    Dim Prog_ypos = {({0}),
                      ({0, 162, 323, 484, 645, -6, 264, 534, -6, -6, -6, -6, -6, 264, 264, 264, 264, 264, 534, 534, 534, 534, 534,
                        -6, 264, 534, -6, 264, 534, -6, 264, 534, 0, 162, 323, 484, 645, -6, 264, 534, -6, 264, 534, -6, 264, 534,
                        -6, 264, 534, -6, 264, 534, -6, 264, 534, -6, 264, 534, -6, 264, 534, -6, 264, 534, 0, 162, 323, 484, 645,
                        0, 162, 323, 484, 645, -6, 264, 534, -6, -6, -6, -6, -6, 264, 264, 264, 264, 264, 534, 534, 534, 534, 534}),
                      ({3, 204, 405, 603, 3, 204, 405, 603, 3, 204, 405, 603, -3, 267, 537, -3, 267, 537,
                        -3, 267, 537, 3, 204, 405, 603, -3, 267, 537, 3, 204, 405, 603, 3, 204, 405, 603,
                        3, 204, 405, 603, 3, 204, 405, 603, 3, 204, 405, 603, -3, 267, 537, -3, 267, 537,
                        -3, 267, 537, 3, 204, 405, 603, -3, 267, 537, 3, 204, 405, 603, 3, 204, 405, 603}),
                      ({-3, 267, 537, -3, 267, 537, -3, 267, 537, -3, 267, 537, -3, 267, 537, 3, 200, 425, 622,
                        3, 200, 425, 622, -3, 267, 537, -3, 267, 537, -3, 267, 537, -3, 267, 537, -3, 267, 537,
                        -3, 267, 537, -3, 267, 537, 3, 200, 425, 622, -3, 267, 537, -3, 267, 537, -3, 267, 537,
                        -3, 267, 537, -3, 267, 537, -3, 267, 537, -3, 267, 537, -3, 267, 537, 3, 200, 425, 622}),
                      ({15, 288, 15, 288, 564, 15, 288, 564, 15, 288, 564, 15, 288, 564,
                        15, 237, 510, 15, 237, 510, 15, 15, 237, 510, 237, 510, 237, 510,
                        15, 15, 288, 510, 15, 510, 510, 15, 15, 288, 510, 510}),
                      ({15, 288, 15, 288, 564, 15, 288, 564, 15, 288, 564, 15, 288, 564,
                      15, 237, 510, 15, 237, 510, 15, 15, 237, 510, 237, 510, 237, 510,
                      15, 288, 15, 288, 564, 15, 288, 564, 15, 288, 564, 15, 288, 564,
                      15, 15, 288, 510, 15, 510, 510, 15, 15, 288, 510, 510}),
                      ({9, 9, 285, 9, 285, 561, 9, 288, 561, 9, 231, 510, 231, 510, 510,
9, 9, 234, 234, 510, 510, 9, 285, 510, 9, 285, 558, 9, 285, 558,
9, 9, 285, 9, 285, 561, 9, 288, 561, 9, 231, 510, 231, 510, 510,
9, 9, 234, 234, 510, 510, 9, 285, 510, 9, 285, 558, 9, 285, 558}),
                      ({0, 405, 0, 405, 0, 405, 0, 405, 0, 405, 0, 405,
12, 12, 12, 200, 200, 200, 200, 200, 200, 628, 628, 628,
0, 405, 0, 405, 0, 405, 0, 405, 0, 405, 0, 405,
12, 12, 12, 200, 200, 200, 200, 200, 200, 628, 628, 628}),
                      ({0, 200, 200, 606, 0, 402, 0, 402, 0, 203, 203, 605,
3, 405, 3, 195, 195, 606, 3, 195, 201, 612, 3, 405,
0, 213, 417, 612, 0, 210, 417, 612, 3, 210, 417, 612,
0, 200, 200, 606, 0, 402, 0, 402, 0, 203, 203, 605}),
                      ({9, 417, 9, 420, 12, 420, 3, 267, 531,
3, 267, 534, 6, 399, 9, 399, 9, 399,
9, 411, 9, 411, 12, 411, 3, 267, 531,
3, 267, 534, 6, 399, 9, 399, 9, 399}),
                      ({15, 405, 15, 405, 15, 405, 15, 405, 15, 405,
15, 405, 15, 405, 15, 405, 15, 405, 15, 405,
15, 405, 15, 405, 15, 405, 15, 405, 15, 405,
15, 405, 15, 405, 15, 405, 15, 405, 15, 405}),
                      ({}),
                      ({})
    }

    Dim Prog_zpos = {({0}),
                      ({1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1,
                        2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2,
                        3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3,
                        4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4}),
                      ({1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1,
                        2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2,
                        3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3,
                        4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4}),
                      ({1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1,
                        2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2,
                        3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3,
                        4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4}),
                      ({1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1,
                        2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2,
                        3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3}),
                      ({1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1,
                      2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2,
                      3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3,
                      4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4}),
                      ({1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1,
2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2,
3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3,
4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4}),
                      ({1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1,
2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2,
3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3,
4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4}),
                      ({1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1,
2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2,
3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3,
4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4}),
                      ({1, 1, 1, 1, 1, 1, 1, 1, 1,
2, 2, 2, 2, 2, 2, 2, 2, 2,
3, 3, 3, 3, 3, 3, 3, 3, 3,
4, 4, 4, 4, 4, 4, 4, 4, 4}),
                      ({1, 1, 1, 1, 1, 1, 1, 1, 1, 1,
                      2, 2, 2, 2, 2, 2, 2, 2, 2, 2,
                      3, 3, 3, 3, 3, 3, 3, 3, 3, 3,
                      4, 4, 4, 4, 4, 4, 4, 4, 4, 4}),
                      ({}),
                      ({})
    }

    Dim Prog_tpos = {({0}),
                      ({0, 0, 0, 0, 0, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1,
                        1, 1, 1, 1, 1, 1, 1, 1, 1, 0, 0, 0, 0, 0, 1, 1, 1, 1, 1, 1, 1, 1, 1,
                        1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 0, 0, 0, 0, 0,
                        0, 0, 0, 0, 0, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1}),
                      ({0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 1, 1, 1, 1, 1,
                        1, 1, 1, 0, 0, 0, 0, 1, 1, 1, 0, 0, 0, 0, 0, 0, 0, 0,
                        0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 1, 1, 1, 1, 1,
                        1, 1, 1, 0, 0, 0, 0, 1, 1, 1, 0, 0, 0, 0, 0, 0, 0, 0}),
                      ({1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 0, 0, 0, 0,
                        0, 0, 0, 0, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1,
                        1, 1, 1, 1, 1, 1, 0, 0, 0, 0, 1, 1, 1, 1, 1, 1, 1, 1, 1,
                        1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 0, 0, 0, 0}),
                      ({1, 1, 1, 1, 0, 1, 1, 0, 1, 1, 0, 1, 1, 0,
                      0, 1, 1, 0, 1, 1, 0, 0, 1, 1, 1, 1, 1, 1,
                      1, 1, 0, 1, 1, 1, 1, 1, 1, 0, 1, 1}),
                      ({1, 1, 1, 1, 0, 1, 1, 0, 1, 1, 0, 1, 1, 0,
                      0, 1, 1, 0, 1, 1, 0, 0, 1, 1, 1, 1, 1, 1,
                      1, 1, 1, 1, 0, 1, 1, 0, 1, 1, 0, 1, 1, 0,
                      1, 1, 0, 1, 1, 1, 1, 1, 1, 0, 1, 1}),
                      ({1, 1, 1, 1, 1, 0, 0, 0, 0, 0, 1, 1, 1, 1, 1,
0, 0, 1, 1, 1, 1, 1, 0, 1, 1, 1, 0, 1, 1, 0,
1, 1, 1, 1, 1, 0, 0, 0, 0, 0, 1, 1, 1, 1, 1,
0, 0, 1, 1, 1, 1, 1, 0, 1, 1, 1, 0, 1, 1, 0}),
                      ({1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1,
0, 0, 0, 1, 1, 1, 1, 1, 1, 0, 0, 0,
1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1,
0, 0, 0, 1, 1, 1, 1, 1, 1, 0, 0, 0}),
                      ({0, 1, 1, 0, 1, 1, 1, 1, 0, 1, 1, 0,
1, 1, 0, 1, 1, 0, 0, 1, 1, 0, 1, 1,
0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
0, 1, 1, 0, 1, 1, 1, 1, 0, 1, 1, 0}),
                      ({1, 1, 1, 1, 1, 1, 0, 0, 0,
0, 0, 0, 1, 1, 1, 1, 1, 1,
1, 1, 1, 1, 1, 1, 0, 0, 0,
0, 0, 0, 1, 1, 1, 1, 1, 1}),
                      ({1, 1, 1, 1, 1, 1, 1, 1, 1, 1,
                      1, 1, 1, 1, 1, 1, 1, 1, 1, 1,
                      1, 1, 1, 1, 1, 1, 1, 1, 1, 1,
                      1, 1, 1, 1, 1, 1, 1, 1, 1, 1}),
                      ({}),
                      ({})
    }

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Bt_1.Click
        'Lab_Status.Text = Statustexte(2)
        'Timer1.Interval = 1000
        'Timer1.Start()

        'Dim myPen As Pen

        'myPen = New Pen(Drawing.Color.DarkTurquoise, 5)
        'Dim myGraphics As Graphics = Me.CreateGraphics
        'myGraphics.DrawEllipse(myPen, 10, 10, 100, 100)
        'myGraphics.DrawImage(LedAn, 1, 1)
        If Status_Verbunden Then 'connection zum Controller beenden
            TimerAchsenstatus.Enabled = False
            ZMC_Close(g_handle)
            g_handle = 0
            Bt_1.BackColor = Color.Lime
            Bt_1.Text = "Verbinden"
            Status_Verbunden = False
            Bt_2.Visible = False
            Bt_3.Text = "Programm beenden"
            Bt_3.BackColor = Color.IndianRed
            Bt_3.Visible = True
        Else  'Verbindung herstellen
            g_handle = 0
            ZAux_OpenEth("127.0.0.1", g_handle)
            If g_handle = 0 Then
                Dim frm2 As New Verbindung
                frm2.Text = "Verbindungsdaten"
                Verbindung.ShowDialog()
            End If

            If g_handle <> 0 Then
                '    MsgBox("Connected Successfully！", vbOKOnly, "Connection Status")
                TimerAchsenstatus.Enabled = True
                TimerAchsenstatus.Interval = 1000
                'wenn erfolgreich
                Bt_1.BackColor = Color.LightSalmon
                Bt_1.Text = "Trennen"
                Status_Verbunden = True
                Bt_2.Visible = True
                Bt_2.Enabled = True
                Bt_2.Text = "System starten"
                Bt_3.Visible = True
                Bt_3.Enabled = True
                Bt_3.BackColor = SystemColors.Control
                Bt_3.Text = "manueller Modus"

                ZAux_Direct_SetAtype(g_handle, 0, 1) 'Modus des X Achse ist Pulse / Richtung
                ZAux_Direct_SetAtype(g_handle, 1, 1) 'Modus des Y Achse ist Pulse / Richtung
                ZAux_Direct_SetAtype(g_handle, 2, 1) 'Modus des Z Achse ist Pulse / Richtung
                ZAux_Direct_SetAtype(g_handle, 3, 1) 'Modus des T Achse ist Pulse / Richtung

                Dim postab As Single() = Xyzt_Pos_Absolute(2, 15)
                Bewege_absolut(0, postab(0), 20000, 10000, 10000)
                Bewege_absolut(1, postab(1), 20000, 10000, 10000)
                Bewege_absolut(2, postab(2), 40000, 30000, 30000) 'Z Bei Ref war 5000 speed
                Bewege_absolut(3, postab(3), 2000, 2000, 2000)    'T 3000 bei überprüfung, Position sind T_normal und T_gedreht

                'Dim date1 As Single
                'ZAux_Direct_GetVariablef(g_handle, "data1", date1)
                'Debug.WriteLine(date1)

                'Dim kong As String
                'kong = ""
                'ZAux_DirectCommand(g_handle, "date1=2", kong, 0)

            Else
                MsgBox("Keine Verbindung", vbOKOnly, "Verbindungs Status")

                End If
            End If
    End Sub

    Private Sub Bt_Pause_Click(sender As Object, e As EventArgs) Handles Bt_2.Click
        'Lab_Status.Text = Statustexte(4)
        'Timer1.Stop()
        If Bt_2.Text = "System starten" Then
            ThreadR = New System.Threading.Thread(AddressOf ThreadRollenbahn)
            ThreadR.Start()
            ThreadM = New System.Threading.Thread(AddressOf ThreadMagazin)
            ThreadM.Start()
            Status_Aktiv = True
            LB_P1.Enabled = True
            LB_P2.Enabled = True
            LB_P3.Enabled = True
            Bt_1.Visible = False
            Bt_2.Text = "System stoppen"
            Bt_3.Text = "Stapeln starten"
            Bt_3.Enabled = (Prog_queue_anz > 0)
        ElseIf Bt_2.Text = "System Stoppen" Then
            Try
                ThreadR.Abort()
            Catch ex As Exception
            End Try
            Try
                ThreadM.Abort()
            Catch ex As Exception
            End Try

            Status_Aktiv = False
            LB_P1.Enabled = False
            LB_P2.Enabled = False
            LB_P3.Enabled = False
            Bt_1.Visible = True
            Bt_2.Text = "System starten"
            Bt_3.Text = "manueller Modus"
            Bt_3.Enabled = True
        ElseIf Bt_2.Text = "Ende Stapeln" Then  'Palette ausfahren, Programm löschen
            If Lab_Status.Text <> "Warte auf Karton" Then

            Else
                Try
                    ThreadS.Abort()
                Catch ex As Exception
                End Try

                'Palette ausfahren und dann Programm purgen, falls etwas gestapelt wurde
                CB_P1_aktiv.Checked = False
                LB_P1.Enabled = True
                Nud_P1_Karton.Enabled = True
                Nud_P1_Lagen.Enabled = True
                Nud_P1_Pal_Soll.Enabled = True

                Bt_2.Text = "System stoppen"
                Bt_3.Text = "Stapeln starten"
                Bt_3.Enabled = (Prog_queue_anz > 0)
            End If
        ElseIf Bt_2.Text = "Abbruch" Then 'Programm stoppen, nicht ausfahren

                Try
                        ThreadS.Abort()
                    Catch ex As Exception
                    End Try

                    CB_P1_aktiv.Checked = False
                    LB_P1.Enabled = True
                    Nud_P1_Karton.Enabled = True
                    Nud_P1_Lagen.Enabled = True
                    Nud_P1_Pal_Soll.Enabled = True

                    Bt_2.Text = "System stoppen"
                    Bt_3.Text = "Stapeln starten"
                    Bt_3.Enabled = (Prog_queue_anz > 0)

        End If
    End Sub

    Sub Stapele(ProgIndex As Integer, AnzKartons As Integer, Anzpaletten As Integer, Startkarton As Integer, Startpalette As Integer)
        Aktuelles_Programm = ProgIndex
        Aktueller_Karton = Startkarton
        Aktuelle_AnzKartons = AnzKartons
        Aktuelle_AnzPaletten = Anzpaletten
        Status_Stapeln = True
    End Sub

    Private Sub Bt_Stopp_Click(sender As Object, e As EventArgs) Handles Bt_3.Click
        'Lab_Status.Text = Statustexte(0)
        If Bt_3.Text = "manueller Modus" Then

        ElseIf Bt_3.Text = "Stapeln starten" Then
            Debug.WriteLine("Stapeln beginnt")
            Programmpurge()
            LB_P1.Enabled = False
            Nud_P1_Karton.Enabled = False
            Nud_P1_Lagen.Enabled = False
            Nud_P1_Pal_Soll.Enabled = False
            CB_P1_aktiv.Checked = True
            ThreadS = New System.Threading.Thread(AddressOf ThreadStapeln)
            ThreadS.Start()

            Stapele(LB_P1.SelectedIndex, Nud_P1_Karton.Value, Nud_P1_Pal_Soll.Value, 1, 0)

            Bt_2.Text = "Ende Stapeln"
            Bt_3.Text = "Stopp"
            Bt_3.Enabled = True
        ElseIf Bt_3.Text = "Stopp" Then
            Status_Stapeln = False
            Bt_2.Text = "Abbruch"
            Bt_3.Text = "Weiter"
        ElseIf Bt_3.Text = "Weiter" Then 'weitermachen
            Status_Stapeln = True
            Bt_2.Text = "Ende Stapeln"
            Bt_3.Text = "Stopp"
        ElseIf Bt_3.Text = "Programm beenden" Then
            Me.Close()
        End If

    End Sub

    Private Sub loesche_Nud(ByRef Nud As NumericUpDown)
        Nud.Enabled = False
        Nud.Minimum = 0
        Nud.Value = 0
    End Sub

    Private Sub setze_Nud(ByRef Nud As NumericUpDown, min As Integer, max As Integer, wert As Integer)
        Nud.Enabled = False
        Nud.Value = min
        Nud.Maximum = max
        Nud.Value = wert
        Nud.Minimum = min
        Nud.Enabled = True
    End Sub

    Private Sub Palettierer_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        For Each Prognames As String In Prog_namen
            LB_P1.Items.Add(Prognames)
            LB_P2.Items.Add(Prognames)
            LB_P3.Items.Add(Prognames)
        Next
        La_P1_max_Lagen.Text = ""
        La_P1_max_Karton.Text = ""
        La_P1_Pal_Ist.Text = ""
        La_P2_max_Lagen.Text = ""
        La_P2_max_Karton.Text = ""
        La_P2_Pal_Ist.Text = ""
        La_P3_max_Lagen.Text = ""
        La_P3_max_Karton.Text = ""
        La_P3_Pal_Ist.Text = ""
        loesche_Nud(Nud_P1_Karton)
        loesche_Nud(Nud_P1_Lagen)
        loesche_Nud(Nud_P1_Pal_Soll)
        loesche_Nud(Nud_P2_Karton)
        loesche_Nud(Nud_P2_Lagen)
        loesche_Nud(Nud_P2_Pal_Soll)
        loesche_Nud(Nud_P3_Karton)
        loesche_Nud(Nud_P3_Lagen)
        loesche_Nud(Nud_P3_Pal_Soll)

        LedAn = Bitmap.FromFile("24x24_LED_An.bmp")
        LedAus = Bitmap.FromFile("24x24_LED_Aus.bmp")

        Bt_1.Text = "Verbinden"
        Bt_1.BackColor = Color.Lime
        Bt_3.Text = "Programm beenden"
        Bt_3.BackColor = Color.IndianRed
        Bt_2.Visible = False

        EventLog_Write("Programm gestartet", 100)
        EventLog_Read()
    End Sub

    Sub Programmpurge()
        For i = 1 To 2
            If (LB_P3.SelectedIndex > 0 And LB_P2.SelectedIndex < 1) Then
                LB_P2.SetSelected(LB_P3.SelectedIndex, True)
                Nud_P2_Karton.Value = Nud_P3_Karton.Value
                Nud_P2_Pal_Soll.Value = Nud_P3_Pal_Soll.Value
                LB_P3.SetSelected(0, True)
            End If
            If (LB_P2.SelectedIndex > 0 And LB_P1.SelectedIndex < 1) Then
                LB_P1.SetSelected(LB_P2.SelectedIndex, True)
                Nud_P1_Karton.Value = Nud_P2_Karton.Value
                Nud_P1_Pal_Soll.Value = Nud_P2_Pal_Soll.Value
                LB_P2.SetSelected(0, True)
            End If
        Next
    End Sub

    Sub Programmwechsel(LB As ListBox, ByRef Nud_Karton As NumericUpDown, ByRef Nud_Lagen As NumericUpDown, ByRef Nud_Pal_Soll As NumericUpDown, ByRef La_max_Lagen As Label, ByRef La_max_Karton As Label, ByRef La_Pal_Ist As Label)
        Dim ProgIndex As Integer
        ProgIndex = LB.SelectedIndex
        If (ProgIndex = 0) Then
            If Nud_Karton.Value > 1 Then Prog_queue_anz = Prog_queue_anz - 1
            loesche_Nud(Nud_Karton)
            loesche_Nud(Nud_Lagen)
            loesche_Nud(Nud_Pal_Soll)
            La_max_Lagen.Text = ""
            La_max_Karton.Text = ""
            La_Pal_Ist.Text = ""
        Else
            If Nud_Karton.Value = 0 Then Prog_queue_anz = Prog_queue_anz + 1
            setze_Nud(Nud_Karton, 1, Prog_karton(ProgIndex), Prog_karton(ProgIndex))
            setze_Nud(Nud_Lagen, 1, Prog_lagen(ProgIndex), Prog_lagen(ProgIndex))
            setze_Nud(Nud_Pal_Soll, 1, 99, 9)
            La_max_Lagen.Text = Prog_lagen(ProgIndex)
            La_max_Karton.Text = Prog_karton(ProgIndex)
            La_Pal_Ist.Text = "0"
        End If
        If Bt_3.Text = "Stapeln starten" Then
            Bt_3.Enabled = (Prog_queue_anz > 0)
        End If
    End Sub

    Private Sub LB_P1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles LB_P1.SelectedIndexChanged
        Programmwechsel(LB_P1, Nud_P1_Karton, Nud_P1_Lagen, Nud_P1_Pal_Soll, La_P1_max_Lagen, La_P1_max_Karton, La_P1_Pal_Ist)
    End Sub

    Private Sub LB_P2_SelectedIndexChanged(sender As Object, e As EventArgs) Handles LB_P2.SelectedIndexChanged
        Programmwechsel(LB_P2, Nud_P2_Karton, Nud_P2_Lagen, Nud_P2_Pal_Soll, La_P2_max_Lagen, La_P2_max_Karton, La_P2_Pal_Ist)
    End Sub

    Private Sub LB_P3_SelectedIndexChanged(sender As Object, e As EventArgs) Handles LB_P3.SelectedIndexChanged
        Programmwechsel(LB_P3, Nud_P3_Karton, Nud_P3_Lagen, Nud_P3_Pal_Soll, La_P3_max_Lagen, La_P3_max_Karton, La_P3_Pal_Ist)
    End Sub

    Private Sub Nud_P1_Lagen_ValueChanged(sender As Object, e As EventArgs) Handles Nud_P1_Lagen.ValueChanged
        Dim Zaehler As Integer
        If Nud_P1_Lagen.Enabled = True And LB_P1.SelectedIndex <> 0 Then
            For Zaehler = 0 To Prog_karton(LB_P1.SelectedIndex) - 1
                If Prog_zpos(LB_P1.SelectedIndex)(Zaehler) > Nud_P1_Lagen.Value Then
                    Exit For
                End If
            Next
            Nud_P1_Karton.Value = Zaehler
        End If
    End Sub

    Private Sub Nud_P1_Karton_ValueChanged(sender As Object, e As EventArgs) Handles Nud_P1_Karton.ValueChanged
        If Nud_P1_Karton.Enabled = True And LB_P1.SelectedIndex <> 0 Then
            Nud_P1_Lagen.Value = Prog_zpos(LB_P1.SelectedIndex)(Nud_P1_Karton.Value - 1)
        End If
    End Sub

    Private Sub Nud_P2_Lagen_ValueChanged(sender As Object, e As EventArgs) Handles Nud_P2_Lagen.ValueChanged
        Dim Zaehler As Integer
        If Nud_P2_Lagen.Enabled = True And LB_P2.SelectedIndex <> 0 Then
            For Zaehler = 0 To Prog_karton(LB_P2.SelectedIndex) - 1
                If Prog_zpos(LB_P2.SelectedIndex)(Zaehler) > Nud_P2_Lagen.Value Then
                    Exit For
                End If
            Next
            Nud_P2_Karton.Value = Zaehler
        End If
    End Sub

    Private Sub Nud_P2_Karton_ValueChanged(sender As Object, e As EventArgs) Handles Nud_P2_Karton.ValueChanged
        If Nud_P2_Karton.Enabled = True And LB_P2.SelectedIndex <> 0 Then
            Nud_P2_Lagen.Value = Prog_zpos(LB_P2.SelectedIndex)(Nud_P2_Karton.Value - 1)
        End If
    End Sub

    Private Sub Nud_P3_Lagen_ValueChanged(sender As Object, e As EventArgs) Handles Nud_P3_Lagen.ValueChanged
        Dim Zaehler As Integer
        If Nud_P3_Lagen.Enabled = True And LB_P3.SelectedIndex <> 0 Then
            For Zaehler = 0 To Prog_karton(LB_P3.SelectedIndex) - 1
                If Prog_zpos(LB_P3.SelectedIndex)(Zaehler) > Nud_P3_Lagen.Value Then
                    Exit For
                End If
            Next
            Nud_P3_Karton.Value = Zaehler
        End If
    End Sub

    Private Sub TimerAchsenstatus_Tick(sender As Object, e As EventArgs) Handles TimerAchsenstatus.Tick
        Dim m_idle As Long
        Dim m_pos As Single
        Dim m_vsp As Single

        ZAux_Direct_GetIfIdle(g_handle, 0, m_idle)
        ZAux_Direct_GetDpos(g_handle, 0, m_pos)
        ZAux_Direct_GetVpSpeed(g_handle, 0, m_vsp)
        CB_AX.Checked = (m_idle = 0)
        Tb_X_dpos.Text = Str(m_pos)
        Tb_X_speed.Text = Str(m_vsp)
        ZAux_Direct_GetIfIdle(g_handle, 1, m_idle)
        ZAux_Direct_GetDpos(g_handle, 1, m_pos)
        ZAux_Direct_GetVpSpeed(g_handle, 1, m_vsp)
        CB_AY.Checked = (m_idle = 0)
        Tb_Y_dpos.Text = Str(m_pos)
        Tb_Y_speed.Text = Str(m_vsp)
        ZAux_Direct_GetIfIdle(g_handle, 2, m_idle)
        ZAux_Direct_GetDpos(g_handle, 2, m_pos)
        ZAux_Direct_GetVpSpeed(g_handle, 2, m_vsp)
        CB_AZ.Checked = (m_idle = 0)
        Tb_Z_dpos.Text = Str(m_pos)
        Tb_Z_speed.Text = Str(m_vsp)
        ZAux_Direct_GetIfIdle(g_handle, 3, m_idle)
        ZAux_Direct_GetDpos(g_handle, 3, m_pos)
        ZAux_Direct_GetVpSpeed(g_handle, 3, m_vsp)
        CB_AR.Checked = (m_idle = 0)
        Tb_R_dpos.Text = Str(m_pos)
        Tb_R_speed.Text = Str(m_vsp)
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        Static Ist_An As Boolean
        Dim myGraphics As Graphics = Me.CreateGraphics
        'Debug.WriteLine(Ist_An.ToString)
        If (Not Ist_An) Then
            myGraphics.DrawImage(LedAn, 1, 1)
            Ist_An = True
        Else
            myGraphics.DrawImage(LedAus, 1, 1)
            Ist_An = False
        End If
    End Sub

    Private Sub Nud_P3_Karton_ValueChanged(sender As Object, e As EventArgs) Handles Nud_P3_Karton.ValueChanged
        If Nud_P3_Karton.Enabled = True And LB_P3.SelectedIndex <> 0 Then
            Nud_P3_Lagen.Value = Prog_zpos(LB_P3.SelectedIndex)(Nud_P3_Karton.Value - 1)
        End If
    End Sub

    '1 Wert erreicht, 0 Wert nicht erreicht und Wartezeit überschritten
    Function Warte_IP(ioNum As Integer, SollWert As Integer, Prellzeit As Integer, MaxWartezeit As Integer) As Integer
        Dim Wert, Prellen As Integer
        Dim stopwatch, prellwatch As Stopwatch
        Prellen = 0
        stopwatch = Stopwatch.StartNew
        prellwatch = Stopwatch.StartNew
        While (1)
            ZAux_Direct_GetIn(g_handle, ioNum, Wert)
            Debug.WriteLine("IO " & ioNum & " Soll " & SollWert & " Ist " & Wert & " " & stopwatch.ElapsedMilliseconds)
            If Wert <> SollWert Then
                If MaxWartezeit > 0 And stopwatch.ElapsedMilliseconds > MaxWartezeit Then
                    Return 0  'Zeitlimit überschritten, war wohl nichts
                End If
                If Prellen = 1 Then
                    Prellen = 0 'eventuelles Entprellen wieder beenden
                End If

            Else 'Wert ist jetzt ok
                If Prellzeit > 0 Then
                    If Prellen = 0 Then
                        Prellen = 1  'Wertewechsel -> Entprellen starten
                        prellwatch.Restart()
                    ElseIf prellwatch.ElapsedMilliseconds > Prellzeit Then
                        Return 1  'Sollwert erreicht und Entprellzeit verstrichen
                    End If
                Else
                    Return 1 'Sollwert erreicht und kein Entprellen gewünscht
                End If
            End If
        End While
    End Function

    'Achse 0 X, 1 Y, 2 Z, 3 T
    Sub Bewege_relativ(Achse As Integer, m_step As Single, m_speed As Single, m_acc As Single, m_dec As Single)
        'ZAux_Direct_SetUnits(g_handle, Achse, m_units)
        'ZAux_Direct_SetLspeed(g_handle, Achse, m_lspeed)
        ZAux_Direct_SetSpeed(g_handle, Achse, m_speed)
        ZAux_Direct_SetAccel(g_handle, Achse, m_acc)
        ZAux_Direct_SetDecel(g_handle, Achse, m_dec)
        ZAux_Direct_Singl_Move(g_handle, Achse, m_step)

    End Sub

    Sub Bewege_absolut(Achse As Integer, m_step As Single, m_speed As Single, m_acc As Single, m_dec As Single)
        'ZAux_Direct_SetUnits(g_handle, Achse, m_units)
        'ZAux_Direct_SetLspeed(g_handle, Achse, m_lspeed)
        ZAux_Direct_SetSpeed(g_handle, Achse, m_speed)
        ZAux_Direct_SetAccel(g_handle, Achse, m_acc)
        ZAux_Direct_SetDecel(g_handle, Achse, m_dec)
        ZAux_Direct_Singl_MoveAbs(g_handle, Achse, m_step)

    End Sub

    Sub Move_Aufnahme(Breite As Integer)
        Bewege_absolut(0, 100, 20000, 10000, 10000)
        Bewege_absolut(1, Breite * 40 + 1350, 20000, 10000, 10000)
        Bewege_absolut(3, T_normal, 2000, 2000, 2000)
    End Sub

    Sub Move_Zwischenwert(Vektor As Single())
        Bewege_absolut(0, 15000, 20000, 10000, 10000)
        Bewege_absolut(1, Vektor(1) + 5000, 20000, 10000, 10000)
        Bewege_absolut(2, Math.Max(Vektor(2) + 10000, 60000), 40000, 30000, 30000)
        Bewege_absolut(3, Vektor(3), 2000, 2000, 2000)
    End Sub

    Sub Move_Zielwert(Vektor As Single())
        Bewege_absolut(0, Vektor(0), 20000, 10000, 10000)
        Bewege_absolut(1, Vektor(1), 20000, 10000, 10000)
        Bewege_absolut(2, Vektor(2), 40000, 30000, 30000)
        Bewege_absolut(3, Vektor(3), 2000, 2000, 2000)
    End Sub

    Sub Warte_auf_Stillstand()
        Dim ok, sum As Integer
        Do  'Bewegung alle beendet ?
            sum = 0
            For i = 0 To 3
                ZAux_Direct_GetIfIdle(g_handle, i, ok)
                sum = sum + ok
            Next
        Loop Until sum = -4
    End Sub

    Private Sub ThreadStapeln()
        Dim Kartonda As Integer
        Dim postab As Single()
        While Aktuelle_Paletten < Aktuelle_AnzPaletten
            If Not Status_Stapeln Then
                Threading.Thread.Sleep(500)  ' Stapeln im Zustand STOPP
            End If
            While Status_Stapeln And Aktueller_Karton <= Aktuelle_AnzKartons
                'Move Aufnahme
                Lab_Status.BeginInvoke(Sub() Lab_Status.Text = "Fahrt Kartonaufnahme")
                Move_Aufnahme(Prog_yl(Aktuelles_Programm))
                postab = Xyzt_Pos_Absolute(Aktuelles_Programm, Aktueller_Karton)
                La_akt_Karton.BeginInvoke(Sub() La_akt_Karton.Text = Aktueller_Karton.ToString)
                La_akt_Lage.BeginInvoke(Sub() La_akt_Lage.Text = Prog_zpos(Aktuelles_Programm)(Aktueller_Karton - 1).ToString)
                'warte auf Karton 
                Kartonda = 0
                Lab_Status.BeginInvoke(Sub() Lab_Status.Text = "Warte auf Karton")
                While Status_Stapeln And Kartonda = 0
                    ZAux_Direct_GetIn(g_handle, IP_KartonDa, Kartonda)
                    Debug.WriteLine(Kartonda)
                    Threading.Thread.Sleep(500)
                    Kartonda = 1 'XXXX zum Test !!!
                End While
                If Kartonda <> 0 Then
                    'fahre Karton
                    Lab_Status.BeginInvoke(Sub() Lab_Status.Text = "Karton anheben")
                    Debug.WriteLine("Fahre Karton " & Aktueller_Karton)
                    ZAux_Direct_SetOp(g_handle, OP_KartonAnheben, 1)
                    Warte_IP(IP_KartonAnheben, 1, 100, 500)  'Warten, bis der Karton angehoben ist 'XXXX 500 Timeout zum TEST
                    Bewege_absolut(2, 17000, 40000, 30000, 30000)
                    Warte_auf_Stillstand()
                    Lab_Status.BeginInvoke(Sub() Lab_Status.Text = "Kartongreifer schließen")
                    ZAux_Direct_SetOp(g_handle, OP_KartonGreifen1, 1)
                    ZAux_Direct_SetOp(g_handle, OP_KartonGreifen2, 1)
                    Warte_IP(IP_KartonGreiferZu, 1, 100, 500)  'Warten, bis der Karton gegriffen ist  'XXXX 500 Timeout zum TEST
                    Warte_IP(IP_KartonGreiferAuf, 0, 0, 500) 'XXXX 500 Timeout zum TEST
                    Lab_Status.BeginInvoke(Sub() Lab_Status.Text = "Karton hoch")
                    Bewege_absolut(2, 52500, 40000, 30000, 30000)
                    Warte_auf_Stillstand()
                    'Move Zwischenwert
                    Lab_Status.BeginInvoke(Sub() Lab_Status.Text = "Zwischenposition")
                    Move_Zwischenwert(postab)
                    Warte_auf_Stillstand()
                    ZAux_Direct_SetOp(g_handle, OP_KartonAnheben, 0) 'kann schon wieder runter
                    'Move Ziel
                    Lab_Status.BeginInvoke(Sub() Lab_Status.Text = "Zielfahrt")
                    Move_Zielwert(postab)
                    Warte_auf_Stillstand()
                    'Lege ab
                    Lab_Status.BeginInvoke(Sub() Lab_Status.Text = "Karton abwerfen")
                    ZAux_Direct_SetOp(g_handle, OP_KartonGreifen1, 0)
                    ZAux_Direct_SetOp(g_handle, OP_KartonGreifen2, 0)
                    Warte_IP(IP_KartonGreiferAuf, 1, 100, 500)  'Warten, bis der Greifer wieder offen ist  'XXXX 500 Timeout zum TEST
                    Warte_IP(IP_KartonGreiferZu, 0, 0, 500)  'XXXX 500 Timeout zum TEST
                    Aktueller_Karton = Aktueller_Karton + 1
                    'Move Zwischenwert
                    Lab_Status.BeginInvoke(Sub() Lab_Status.Text = "Rückfahrt Zwischenposition")
                    Move_Zwischenwert(postab)
                    Warte_auf_Stillstand()
                End If
            End While

            If Status_Stapeln And Aktueller_Karton = Aktuelle_AnzKartons + 1 Then ' Palette voll
                'Palette ausfahren

                Aktuelle_Paletten = Aktuelle_Paletten + 1
                Aktueller_Karton = 1
            End If
        End While
    End Sub


    Private Sub ThreadRollenbahn()
        While True
            Threading.Thread.Sleep(500)
        End While

    End Sub

    Private Sub ThreadMagazin()
        While True
            Threading.Thread.Sleep(500)
        End While


    End Sub

    Private Sub Form1_FormClosing(ByVal sender As Object,
                               ByVal e As System.Windows.Forms.FormClosingEventArgs
                                     ) Handles Me.FormClosing

        If e.CloseReason = CloseReason.UserClosing Then
            If Status_Verbunden Then
                MsgBox("Bitte erst vom Controller trennen")
                e.Cancel = True
            ElseIf MsgBox("Wirklich beenden?",
                  MsgBoxStyle.Exclamation Or MsgBoxStyle.YesNo Or MsgBoxStyle.DefaultButton2,
                  "Anwendung beenden") = MsgBoxResult.No Then
                e.Cancel = True
            End If
        Else
            If Status_Aktiv Then
                Try
                    ThreadR.Abort()
                Catch ex As Exception
                End Try
                Try
                    ThreadM.Abort()
                Catch ex As Exception
                End Try
            End If
            If Status_Verbunden Then
                ZMC_Close(g_handle)
            End If
        End If
    End Sub


    Public Sub EventLog_Read()
        ' Name des Ereignisprotokolls
        Const logname As String = "Palettierer"
        ' Anzahl der auszugebenden Einträge
        Const Anzahl As Long = 10

        Dim log As EventLog
        Dim eintrag As EventLogEntry
        Dim Count As Long = 0

        ' -- Zugriff auf das Ereignisprotokoll
        log = New EventLog(logname)

        Debug.WriteLine("--- Letzte " & Anzahl &
        " Einträge von " & log.Entries.Count &
        " Einträgen aus dem Protokoll " &
        log.Log & " auf dem Computer " &
        log.MachineName)

        ' --- Schleife über alle Einträge
        For Each eintrag In log.Entries
            Count += 1
            If Count > log.Entries.Count - Anzahl Then
                Debug.WriteLine(eintrag.EntryType & ":" &
                eintrag.InstanceId & ":" &
                eintrag.Category & ":" &
                eintrag.Message & ":" &
                eintrag.Source & ":" &
                eintrag.TimeGenerated & ":" &
                eintrag.TimeWritten & ":" &
                eintrag.UserName & ":")
            End If
        Next

    End Sub

    Public Sub EventLog_Write(Nachricht As String, Nachrichttyp As Integer)
        Const logname As String = "Palettierer"
        Const source As String = "SuH"
        Dim log As New EventLog(logname)
        ' --- Dieser Block ist OPTIONAL ---
        If (Not log.SourceExists(source)) Then
            Try
                log.CreateEventSource(source, logname)
                Debug.WriteLine("Log Quelle angelegt!")
            Catch ex As Exception
                MessageBox.Show("Zum Erzeugen der Logtabelle bitte einmalig als Administrator starten")
                Me.Close()
            End Try
        End If
        ' ---- Eintrag schreiben
        log.WriteEntry(source, Nachricht, System.Diagnostics.EventLogEntryType.Information, Nachrichttyp)
        ' --- Bildschirmausgabe
        Debug.WriteLine("Log: " & Nachricht & " " & Nachrichttyp)
    End Sub

    Function Xyzt_Pos_Absolute(prognr As Integer, Karton As Integer) As Single()
        Dim postab As Single() = {0, 0, 0, 0}
        Karton = Karton - 1 'Nr 1 ist 0 im Index
        If Prog_tpos(prognr)(Karton) = 0 Then
            postab(0) = Prog_xpos(prognr)(Karton) * 40 - Prog_xl(prognr) * 20 + 20150 'X  = pos * 40 - xl/2 * 40 + 20150
            postab(1) = Prog_ypos(prognr)(Karton) * 40 - Prog_yl(prognr) * 40 - 4000  'Y  = pos * 40 - yl   * 40 - 4000
            postab(3) = T_normal
        Else
            postab(0) = Prog_xpos(prognr)(Karton) * 40 - Prog_yl(prognr) * 40 + 24400 'X  = pos * 40 - yl   * 40 + 24400
            postab(1) = Prog_ypos(prognr)(Karton) * 40 + Prog_xl(prognr) * 20 + 800   'Y  = pos * 40 + xl/2 * 40 + 800
            postab(3) = T_gedreht
        End If
        postab(2) = Prog_zfaktor(Prog_zpos(prognr)(Karton) - 1) * Prog_zl(prognr) 'Z  = Faktor(Ebene-1) * zl 
        Debug.WriteLine("Kartonpos Prog " & prognr & " Karton " & (Karton + 1) & " x " & postab(0) & " y " & postab(1) & " z " & postab(2) & " t " & postab(3))
        Return postab
    End Function

End Class
