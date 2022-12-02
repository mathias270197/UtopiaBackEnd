using System.Collections.Generic;

namespace Utopia2._0.Models
{
    public class Gebouw
    {
        public int Id { get; set; }
        public string Studierichting { get; set; }
        public int LijnId { get; set; }
        public int StationId { get; set; }

        public Lijn Lijn { get; set; }
        public Station Station { get; set; }

        public ICollection<Vraag> Vragen { get; set; }
    }
}
