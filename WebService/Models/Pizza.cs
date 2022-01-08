using System;

namespace WebService.Models
{
    public class Pizza
    {
        public int ID { get; set; }

        public string Denumire { get; set; }
        public string Incrediente { get; set; }

        public decimal Pret { get; set; }

       public DateTime DataPlasareComanda { get; set; }

        public int PizzerieID { get; set; }
    } 
}

