using System.Collections.Generic;

namespace Utopia2._0.Models
{
    public class Line
    {
        public int Id { get; set; }
        public string Color { get; set; }
        public string Faculty { get; set; }

        public ICollection<Building> Buildings { get; set; }
    }
}
