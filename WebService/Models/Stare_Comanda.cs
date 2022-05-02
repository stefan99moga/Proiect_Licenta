using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebService.Models
{
    public class Stare_Comanda
    {
        [Key]
        public int Id { get; set; }
        public string Nume { get; set; }
    }
}
