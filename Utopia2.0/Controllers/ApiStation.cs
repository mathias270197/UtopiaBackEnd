using System.Collections.Generic;

namespace Utopia2._0.Controllers
{
    public class ApiStation
    {

        public int Id { get; set; }
        public List<ApiCoordinates> Coordinates { get; set; }

        public string Color { get; set; }


    }
}
