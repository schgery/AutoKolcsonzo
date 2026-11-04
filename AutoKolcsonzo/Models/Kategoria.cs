using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutokolcsonzoLibrary.Models
{
    public class Kategoria
    {
        public int Id { get; set; }
        public string Nev { get; set; } = "";
        public List<Auto> Autok { get; set; } = new List<Auto>();
    }
}
