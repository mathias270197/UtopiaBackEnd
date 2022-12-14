using System.Collections.Generic;

namespace Utopia2._0.Models
{
    public class Station
    {
        public int Id { get; set; }
        public int X { get; set; }
        public int Y { get; set; }

        public ICollection<Building> Buildings { get; set; }

    }
}
