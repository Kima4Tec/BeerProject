using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeerProject
{

    internal class SortingBeerBy : IComparer<Beer>
    {
        private SortBy sortBy;

        public SortingBeerBy(SortBy sortBy)
        {
            this.sortBy = sortBy;
        }

        public int Compare(Beer x, Beer y)
        {
            Beer beer = new Beer();
            switch (sortBy)
            {
                case SortBy.UNIT:
                    return x.GetUnits(beer.Volume, beer.Percent).CompareTo(y.GetUnits(beer.Volume, beer.Percent));
                case SortBy.PERCENT:
                    return x.Percent.CompareTo(y.Percent);
                case SortBy.VOLUME:
                    if (x.Volume.CompareTo(y.Volume)!=0)
                    {
                        return x.Volume.CompareTo(y.Volume);
                    }
                    else
                        return x.Percent.CompareTo(y.Percent);

                default:
                    throw new ArgumentException("Det kan du ikke sortere på.");
            }

        }
    }
}
