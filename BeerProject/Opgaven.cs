



//Metoder

//· GetUnits – returnerer antal genstande som decimal. En genstand er 15 ml alkohol. (Kan beregnes som: volumen* procent / 150)

//· ToString fortsættes på næste side…

//· En metode der kan blande to Beer-objekter. Laves i tre udgaver.

//1. add() – en metode der kan hælde en øl oven i en anden. Kaldet vil være beer1.add(beer2), som gør at beer1 nu indeholder begge øl hældt sammen.

//2. mix() – en metode der returnerer en ny øl bestående af de to hældt sammen. Kaldet vil være beer3 = beer1.mix(beer2), som gør at beer3 nu indeholder begge øl hældt sammen, uden at ændre beer1 og beer2.

//3. mix() – en metode der returnerer en ny øl bestående af de to hældt sammen. Kaldet vil være beer3 = Beer.mix(beer1, beer2).

//NB! Procenten for to blandede beers fås som (volume1 * pct1 + volume2 * pct2)/(volume1+volume2)). Volume på de blandede øl er summen af de to. Navnene på henholdsvis bryggeriet og øllen sammensættes af de to blandede øls navne. Benyt BeerType.Mix til den nye blandede øl.

//Sortering



//Ekstra klasse SortingBeerBy

//Opret først en enum SortBy i sin egen fil med betegnelserne UNIT, PERCENT og VOLUME. Det skal bruges til at vælge hvad der skal sorteres på.

//Opret en klasse af af navnet SortingBeerBy, som implementerer interface IComparer med metoden Compare(). Klassen skal benyttes til at sortere beers på forskellige parametre. Opret en constructor, som modtager en parameter af typen SortBy som afgør om klassen skal sammenligne Beer-objekter på Units, Percent eller Volume, når dens metode compare() kaldes.

//Klasssen kan benyttes på følgende måde: Array.Sort(beers, new SortingBeerBy(SortBy.UNIT))

//Afprøv det hele i Main()