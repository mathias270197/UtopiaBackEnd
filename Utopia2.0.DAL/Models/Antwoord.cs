namespace Utopia2._0.Models
{
    public class Antwoord
    {
        public int Id { get; set; }
        public int VraagId { get; set; } //ik denk dat we dit kunnen weg laten
        public int MeerKeuzeAntwoordId { get; set; }
        public int PersoonId { get; set; }
        public Vraag Vraag { get; set; } //ik denk dat we dit kunnen weg laten
        public MeerkeuzeAntwoord MeerkeuzeAntwoord { get; set; }
    }
}
