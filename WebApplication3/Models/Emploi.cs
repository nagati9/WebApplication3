using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication3.Models
{
    public class Emploi
    {
        public int Id { get; set; }
        public string Entreprise { get; set; }
        public string Poste { get; set; }
        public DateTime DateDebut { get; set; }
        public DateTime? DateFin { get; set; } 

        [ForeignKey("Personne")]
        public int PersonneId { get; set; }
       

       
        public bool EstActuel => DateFin == null;
    }
}
