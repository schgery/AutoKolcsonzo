using AutokolcsonzoLibrary.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutokolcsonzoLibrary.Services
{
    public class AutokolcsonzoService : IAutokolcsonzoService
    {
        private AutokolcsonzoDbContext c;

        public AutokolcsonzoService()
        {
            c = new AutokolcsonzoDbContext();
        }
        public List<Berles> AktivBerlesek()
        {
            return c.berlesek.Where(b => b.Visszahozva == null).Include(b => b.Auto).Include(b => b.Ugyfel).ToList();
        }

        public List<Auto> Autok()
        {
            return c.autok.OrderBy(x=>x.Rendszam).Include(a => a.Berlesek).Include(a => a.Gyarto).Include(a => a.Kategoria).ToList();
        }

        public List<(string Kategoria, int Darab)> KategoriaStatisztika()
        {
            throw new NotImplementedException();
        }

        public List<Berles> Kesesek(DateOnly datum)
        {
            return c.berlesek
                .Where(b => b.Visszahozva == null && b.Hatarido < datum)
                .Include(b => b.Auto)
                .Include(b => b.Ugyfel)
                .ToList();
        }

        public List<Auto> SzabadAutok()
        {
            return Autok().Where(x=>x.Szabad).ToList();
        }

        public List<Ugyfel> Ugyfelek()
        {
            return c.ugyfelek.OrderBy(u=>u.Nev).ToList();
        }

        public bool UjBerles(int autoId, int ugyfelId, DateOnly kezdet, int napok)
        {
            Berles b = new Berles() {
            AutoId = autoId,
            UgyfelId = ugyfelId,
            Kezdete = kezdet,
            Hatarido = kezdet.AddDays(napok)
            };
            c.berlesek.Add(b);
            c.SaveChanges();
            return true;

        }

        public bool UjUgyfel(string nev, string email)
        {
            if (c.ugyfelek.Any(u => u.Email == email) && !email.Contains("@"))
            {
                return false;
            }  
            Ugyfel u = new Ugyfel() { Nev = nev, Email = email};
            c.ugyfelek.Add(u);
            c.SaveChanges();
            return true;
        }

        public bool Visszahozatal(int berlesId, DateOnly datum)
        {
            Berles? b = c.berlesek.FirstOrDefault(x=>x.Id==berlesId);
            if ((b == null || b.Visszahozva != null)&& datum>b.Kezdete)
            {
                return false;
            }
            b.Visszahozva = datum;
            return true;
        }
    }
}
