using System.Collections.Generic;

namespace Utopia2._0.Models
{
    public class Station
    {
        public int StationID { get; set; }
        public double XCoordinaat { get; set; }
        public double YCoordinaat { get; set; }

        public ICollection<Gebouw> Gebouwen { get; set; }
    }
}
