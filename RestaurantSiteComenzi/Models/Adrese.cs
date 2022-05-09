using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RestaurantSiteComenzi.Models
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
        public string Bloc { 
            get
            {
                if (_bloc != null)
                    return _bloc;
                return string.Empty;
            } 
            set 
            {
                _bloc = value;
            } 
        }
        private string _bloc = string.Empty;

        [Display(Name = "Scara")]
        public string Scara
        {
            get
            {
                if (_scara != null)
                    return _scara;
                return string.Empty;
            }
            set
            {
                _scara = value;
            }
        }
        private string _scara = string.Empty;

        [Display(Name = "Apartament")]
        public string Apartament
        {
            get
            {
                if (_ap != null)
                    return _ap;
                return string.Empty;
            }
            set
            {
                _ap = value;
            }
        }
        private string _ap = string.Empty;

        public bool IsDeprecated { get; set; }
    }
}
