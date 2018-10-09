# Palettierer
Neue Steuerung für Portalpalletierer mit Pallettenmagazin und Förderstrecke

Austausch der alten Schrittmotorsteuerung vom Typ SB214 des Herstellers ACSTech80
durch einen Controller von Z-Motion vom Typ ECI2400 mit einem ZIO1616 über CAN-Bus.

Der Controller soll im ersten Schritt die alte Steuerung ersetzen, d.h. mit den
alten Schrittmororen laufen und dann später, da es schwierig ist Ersatzmotoren
zu bekommen, nach und nach auf Servomotoren umgestellt werden.

Beide Controller lassen sich in einem speziellen Basis Dialect programmieren.
Der neue Controller hat durxh die ZIO Erweiterung mehr Ein- und Ausgaänge, sodass
einige Verbesserungen umgesetzt werden können.
