using System.Collections.Generic;

namespace Utopia2._0.Models
{
    public class Building
    {
        public int Id { get; set; }
        public string GraduateProgram { get; set; }
        public int LineId { get; set; }
        public int StationId { get; set; }

        public Line Line { get; set; }
        public Station Station { get; set; }

        public ICollection<Question> Questions { get; set; }
    }
}
