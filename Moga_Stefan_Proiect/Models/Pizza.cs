using System;

namespace Moga_Stefan_Proiect.Models
{
    public class Pizza
    {
        public Pizza(string Denumire, decimal Pret)
        {
            this.Denumire = Denumire;
            this.Pret = Pret;
        }
        public int ID { get; set; }

        public string Denumire { get; set; }
        public string Incrediente { get; set; }

        public decimal Pret { get; set; }

       public DateTime DataPlasareComanda { get; set; }

        public int PizzerieID { get; set; }
        public Object Pizzerie { get; set; }
    } 
}

