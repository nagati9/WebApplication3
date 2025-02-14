namespace WebApplication3.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Personne
    {
        public int Id { get; set; }

        [Required]
        public string Nom { get; set; }

        [Required]
        public string Prenom { get; set; }

        [Required]
        public DateTime DateNaissance { get; set; }

        public ICollection<Emploi> Emplois { get; set; } = new List<Emploi>();
    }

}
