using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutokolcsonzoLibrary.Models
{
    public class Berles
    {
        public int Id { get; set; }
        public Auto Auto { get; set; }
        public int AutoId { get; set; }
        public int UgyfelId { get; set; }
        public Ugyfel Ugyfel { get; set; }
        public DateOnly Kezdete { get; set; }
        public DateOnly Hatarido { get; set; }
        public DateOnly? Visszahozva { get; set; }

        public int KesesNapok(DateOnly datum)
        {
            if (datum < Hatarido)
                return 0;
            else
                return datum.Day - Hatarido.Day;
        }
        public bool Aktiv()
        {
            return Visszahozva == null;
        }
    }
}
