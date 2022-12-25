using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utopia2._0.DAL.Models
{
    public class Faculty
    {
        // Attributes
        public int Id { get; set; }
        [Required]
        [MinLength(2)]
        public string Name { get; set; }
        [Required]
        public bool Active { get; set; }

        // Navigation properties
        public ICollection<GraduateProgram> GraduatePrograms { get; set; }

    }
}
