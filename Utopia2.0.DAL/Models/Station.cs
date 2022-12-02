using System.Collections.Generic;

namespace Utopia2._0.Models
{
    public class Station
    {
        public int Id { get; set; }
        public double X { get; set; }
        public double Y { get; set; }

        public ICollection<Building> Buildings { get; set; }

    }
}
