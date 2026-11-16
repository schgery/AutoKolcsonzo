using AutokolcsonzoLibrary.Models;

namespace AutokolcsonzoLibrary.Services;


public interface IAutokolcsonzoService
{
    List<Auto> Autok();
    List<Auto> SzabadAutok();
    List<Ugyfel> Ugyfelek();
	
    //Az ügyfél egyedi email címmel rendelkezik!
    bool UjUgyfel(Ugyfel ugy);
    public List<Gyarto> Gyartok();
    public List<Kategoria> Kategoriak();

    //ÁTÍRHATÓ: autó és ügyfél objektumokra
    bool UjBerles(int autoId, int ugyfelId, DateOnly kezdet, int napok);
    bool UjGyarto(Gyarto gy);
    bool UjKategoria(Kategoria kat);
    bool Visszahozatal(int berlesId, DateOnly datum);

    List<Berles> AktivBerlesek();

    List<Berles> Kesesek(DateOnly datum);

    //Minden bérlés (lezárt és folyamatban lévő összesen), kategóriánként
    List<(string Kategoria, int Darab)> KategoriaStatisztika();

    //BŐVÍTHETŐ...


}
