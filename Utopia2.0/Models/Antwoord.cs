namespace Utopia2._0.Models
{
    public class Antwoord
    {
        public int AntwoordID { get; set; }
        public int VraagID { get; set; }
        public int MeerKeuzeAntwoordID { get; set; }

        public Vraag Vraag { get; set; }
        public MeerkeuzeAntwoord MeerkeuzeAntwoord { get; set; }
    }
}
