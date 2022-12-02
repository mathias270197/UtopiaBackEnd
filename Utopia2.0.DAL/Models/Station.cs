using System.Collections.Generic;

namespace Utopia2._0.Models
{
    public class Station
    {
        public int Id { get; set; }
<<<<<<< HEAD
        public double X { get; set; }
        public double Y { get; set; }

        public ICollection<Building> Buildings { get; set; }
=======
        public double XCoordinaat { get; set; }
        public double YCoordinaat { get; set; }

        public ICollection<Gebouw> Gebouwen { get; set; }
>>>>>>> 3ae2c814f4640dcc084fc5068c1ed36fa7571798
    }
}
