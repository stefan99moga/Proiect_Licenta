using System;
using System.Collections.Generic;
using System.Text;

namespace Moga_Stefan_Proiect.Models
{
    public class NewOrder
    {
        public int Id { get; set; }

        public string User_ID { get; set; }

        public int Adress_ID { get; set; }

        public int Tip_Plata_ID { get; set; }

        public decimal Total_Plata { get; set; }
        public string Total_Plata_Str { get { return String.Format("{0:0.00} lei", this.Total_Plata); } }

        public DateTime Data_Comanda { get; set; } = DateTime.Now;

        public int Stare_Comanda_ID { get; set; }

        public bool Is_Deprecated { get; set; }

        public Adrese Adrese { get; set; }

        public Tip_Plata Tip_plata { get; set; }

        public Stare_Comanda Stare_Comanda { get; set; }
    }

    public class Stare_Comanda
    {
        public int Id { get; set; }
        public string Nume { get; set; }
    }

    public class Tip_Plata
    {
        public int Id { get; set; }
        public string Tipul_Platii { get; set; }
    }

    public class Adrese
    {
        public int Id { get; set; }

        public string User_ID { get; set; }

        public string Oras { get; set; }

        public string Strada { get; set; }

        public string Numar { get; set; }

        public string Bloc
        {
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
