using System.Collections.Generic;

namespace Utopia2._0.Controllers
{
    public class ApiQuestion
    {
        public int Id { get; set; }
        public string TextualQuestion { get; set; }
        public ICollection<ApiMultipleChoiceAnswer> Ansers { get; set; }
}
}
