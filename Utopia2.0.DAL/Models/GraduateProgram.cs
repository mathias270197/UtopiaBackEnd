using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utopia2._0.DAL.Models
{
    public class GraduateProgram
    {
        // Attributes
        public int Id { get; set; }
        [Required]
        [MinLength(2)]
        public string Name { get; set; }
        [Required]
        public bool Active { get; set; }
        [Required]
        public int FacultyId { get; set; }

        // Navigation properties
        public Faculty Faculty { get; set; }
        public ICollection<Question> Questions { get; set; }
    }
}
