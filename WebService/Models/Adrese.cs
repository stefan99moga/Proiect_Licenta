using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebService.Models
{
    [Table("Adress")]
    public class Adrese
    {
        [Key]
        [Required]
        public int Id { get; set; }

        public string User_ID { get; set; }

        [Required, Display(Name = "Oras")]
        public string Oras { get; set; }

        [Required, Display(Name = "Strada")]
        public string Strada { get; set; }

        [Required, Display(Name = "Numar")]
        public string Numar { get; set; }

        [Display(Name = "Bloc")]
        public string Bloc { get; set; }

        [Display(Name = "Scara")]
        public string Scara { get; set; }

        [Display(Name = "Apartament")]
        public string Apartament { get; set; }
    }
}
