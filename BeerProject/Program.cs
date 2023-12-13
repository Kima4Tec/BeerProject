namespace BeerProject
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Opretter liste med øl
            List<Beer> beer = new List<Beer>();
            beer.Add(new Beer("Paulaner Brauerei", "Münchner Lager", BeerType.MÜNCHENER, 50, 8.6m));
            beer.Add(new Beer("Tuborg", "Grøn", BeerType.PILSNER, 33, 4.6m));
            beer.Add(new Beer("Bad Seed Brewing", "Vienna Lager", BeerType.LAGER, 33, 5.0m));
            beer.Add(new Beer("Carlsberg", "Porter", BeerType.PORTER, 33, 7.8m));

            Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Udskrivning af liste med øl inden sortering og blanding");
            Console.ResetColor();
            foreach (var item in beer)
            {
                Console.WriteLine(item);
            }

            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Liste sorteret på antal genstande");
            Console.ResetColor();
            beer.Sort();
            foreach (var item in beer)
            {
                Console.WriteLine(item);
            }

            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"Mix1: {beer[1].BeerName} tilføjet til {beer[0].BeerName} ");
            Console.ResetColor();
            beer[0].Add(beer[1]);
            Console.WriteLine($"{beer[0]:F2}");

            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"Mix2: Et mix af {beer[1].BeerName} og {beer[2].BeerName}");
            Console.ResetColor();
            Console.WriteLine($"{(beer[1].NewBeerMix(beer[2])):F2}");

            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"Mix3: Et mix af {beer[2].BeerName} og {beer[3].BeerName}");
            Console.ResetColor();
            Console.WriteLine($"{(Beer.AnotherBeerMix(beer[2], beer[3])):F2}");

            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Liste sorteret på antal genstande med IComparer interface og enums");
            Console.ResetColor();
            beer.Sort(new SortingBeerBy(SortBy.UNIT));
            foreach (var item in beer)
            {
                Console.WriteLine(item);
            }

            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Liste sorteret på volume med IComparer interface og enums. Hvis volumen er ens, så sorteres på procenter");
            Console.ResetColor();
            beer.Sort(new SortingBeerBy(SortBy.VOLUME));
            foreach (var item in beer)
            {
                Console.WriteLine(item);
            }

            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Liste sorteret på alkoholprocent med IComparer interface og enums");
            Console.ResetColor();
            beer.Sort(new SortingBeerBy(SortBy.PERCENT));
            foreach (var item in beer)
            {
                Console.WriteLine(item);
            }
        }
    }
}
