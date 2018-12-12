//Grundplatte für ZIO 1616
plaenge=142.49;  // Platinenlänge
pbreite=107;   // Platinenbreite
llaenge=132.31;  // Lochabstand in Längsrichtung
lbreite=96.72;   // Lochabstand in Querrichtung
pbohrung=4;    // Lochdurchmesser in Platine

daufnahme=8;   // Aussendm Schraubenaufnahme
haufnahme=5;   // Höhe der Schraubenaufnahme
boden=3;

schraubendm=3.5;

$fn=50;

%translate([0,0,haufnahme]) cube([plaenge,pbreite,2]);

module platte_add() {
cube([plaenge,pbreite,boden]);
for (x=[0:1])
    for (y=[0:1])
        translate([(plaenge-llaenge)/2+x*llaenge,(pbreite-lbreite)/2+y*lbreite,0]) cylinder(d=daufnahme,h=haufnahme);
}

module platte_sub() {
for (x=[0:1])
    for (y=[0:1])
        translate([(plaenge-llaenge)/2+x*llaenge,(pbreite-lbreite)/2+y*lbreite,0]) cylinder(d=schraubendm,h=haufnahme);
}

difference() {
    platte_add();
    platte_sub();
}
