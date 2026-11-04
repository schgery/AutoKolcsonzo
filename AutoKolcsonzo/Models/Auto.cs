using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutokolcsonzoLibrary.Models
{
    public class Auto
    {
        public int Id { get; set; }
        public string Rendszam { get; set; } = "";
        public string Modell { get; set; } = "";
        public int GyartoId { get; set; }
        public Gyarto Gyarto { get; set; }
        public int KategoriaId { get; set; }
        public Kategoria Kategoria { get; set; }
        public int Evjarat { get; set; }
        public int NapiDij { get; set; }
        public List<Berles> Berlesek { get; set; }
        public bool Szabad()
        {
            return Berlesek.All(b => b.Visszahozva != null);
        }

    }
}
