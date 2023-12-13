using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeerProject
{
        enum BeerType
        {
            LAGER, PILSNER, MÜNCHENER, WIENERDORTMUNDER, BOCK, DOBBELBOCK, PORTER, MIX
        }
    internal class Beer : IComparable<Beer>
    {

        //· _brewery – navnet på bryggeriet som tekst
        string _brewery;

        //· _beerName – navnet på øllen som tekst
        string _beerName;
        //· _beerType – enum BeerType
        BeerType _beerType;
        //· _volume – antal centiliter som heltal
        int _volume;

        //· _percent – alkoholprocent som decimal
        decimal _percent;

        //properties - generet af Intellisense
        public string Brewery { get => _brewery; set => _brewery = value; }
        public string BeerName { get => _beerName; set => _beerName = value; }
        public BeerType BeerType { get => _beerType; set => _beerType = value; }
        public int Volume { get => _volume; set => _volume = value; }
        public decimal Percent { get => _percent; set => _percent = value; }

        //constructor uden parametre
        public Beer()
        {
        }

        //Constructor med 5 parametre.
        public Beer(string brewery, string beerName, BeerType beerType, int volume, decimal percent)
        {
            Brewery = brewery;
            BeerName = beerName;
            BeerType = beerType;
            Volume = volume;
            Percent = percent;
        }

        //Metoder
        //· GetUnits – returnerer antal genstande som decimal. En genstand er 15 ml alkohol. (Kan beregnes som: volumen* procent / 150)
        public decimal GetUnits(int volume, decimal percent)
        {
            decimal unit = _volume * _percent / 150;
            return unit; 
        }


        //· ToString
        public override string? ToString()
        {
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.Write(" Bryggeri: ");
            Console.ResetColor();
            Console.Write(Brewery +"\n");

            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.Write(" Ølnavn: ");
            Console.ResetColor();
            Console.Write(BeerName + "\n");

            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.Write(" Øltype: ");
            Console.ResetColor();
            Console.Write(BeerType + "\n");

            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.Write(" Volume: ");
            Console.ResetColor();
            Console.Write(Volume + "\n");

            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.Write(" Alkoholprocent: ");
            Console.ResetColor();
            Console.Write($"{Percent:F2}%\n");

            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.Write(" Antal genstande:");
            Console.ResetColor();
            Console.Write($"{GetUnits(Volume, Percent):F2} \n");

            return  string.Empty;
        }

        //· En metode der kan blande to Beer-objekter. Laves i tre udgaver.
        //1. add() – en metode der kan hælde en øl oven i en anden. Kaldet vil være beer1.add(beer2), som gør at beer1 nu indeholder begge øl hældt sammen.
        public void Add(Beer newBeer)
        {
            Volume += newBeer.Volume;
            Percent = (Percent * Volume + newBeer.Percent * newBeer.Volume) / (Volume + newBeer.Volume);
        }

        //2. mix() – en metode der returnerer en ny øl bestående af de to hældt sammen. Kaldet vil være beer3 = beer1.mix(beer2), som gør at beer3 nu indeholder begge øl hældt sammen, uden at ændre beer1 og beer2.
        public Beer NewBeerMix(Beer beerSecond)
        {
            return new Beer
            {
                Brewery = "Mit hjemmebrænderi",
                BeerName = "Wonderful Mix",
                BeerType = BeerType.MIX,
                Volume = Volume + beerSecond.Volume,
                Percent = (Percent * Volume + beerSecond.Percent * beerSecond.Volume) / (Volume + beerSecond.Volume)
            };
        }
        //Procenten for to blandede beers fås som (volume1 * pct1 + volume2 * pct2)/(volume1+volume2)).
        //Volume på de blandede øl er summen af de to. Navnene på henholdsvis bryggeriet og øllen sammensættes
        //af de to blandede øls navne.

        //3. mix() – en metode der returnerer en ny øl bestående af de to hældt sammen. Kaldet vil være beer3 = Beer.mix(beer1, beer2).
        public static Beer AnotherBeerMix(Beer beer1, Beer beer2)
        {
            return new Beer
            {
                Brewery = beer1.Brewery + "/" + beer2.Brewery,
                BeerName = beer1.BeerName + "/" + beer2.BeerName,
                BeerType = BeerType.MIX,
                Volume = beer1.Volume + beer2.Volume,
                Percent = (beer1.Percent * beer1.Volume + beer2.Percent * beer2.Volume) / (beer1.Volume + beer2.Volume)
            };
        }

        public int CompareTo(Beer? obj)
        {
            int beerSort = this.GetUnits(Volume, Percent).CompareTo(((Beer)obj).GetUnits(Volume, Percent));
            return beerSort;
        }
    }
}
