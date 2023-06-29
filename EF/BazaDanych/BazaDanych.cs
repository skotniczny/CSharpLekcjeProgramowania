using Microsoft.EntityFrameworkCore;

namespace EF.BazaDanych
{
    class BazaDanychOsóbDbContext : DbContext
    {
        public DbSet<Osoba> Osoby { get; set; }
        public DbSet<Adres> Adresy { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlite("Data Source=osoby.db");
        }
    }

    public class BazaDanychOsób : IDisposable
    {
        private BazaDanychOsóbDbContext dbc = new BazaDanychOsóbDbContext();

        public BazaDanychOsób()
        {
            dbc.Database.EnsureCreated();
        }

        public void Dispose()
        {
            dbc.Dispose();
        }

        #region Debugowanie
#if DEBUG
        public Osoba[] Osoby => dbc.Osoby.ToArray();
        public Adres[] Adresy => dbc.Adresy.ToArray();
#endif
        #endregion

        public Osoba PobierzOsobę(int idOsoby)
        {
            return dbc.Osoby.FirstOrDefault(o => o.Id == idOsoby);
        }

        public Osoba this[int idOsoby] => PobierzOsobę(idOsoby);

        public int[] IdentyfikatoryOsób => dbc.Osoby.Select(o => o.Id).ToArray();

        public int DodajOsobę(Osoba osoba)
        {
            if (osoba == null) throw new ArgumentNullException("Podano pustą referencję jako argument");
            if (osoba.Adres == null) throw new ArgumentException("Brak adresu zameldowania");

            if (dbc.Osoby.Any(o =>  o.Id == osoba.Id))
            {
                osoba.Id = dbc.Osoby.Max(o => o.Id) + 1;
            }
            else
            {
                if (dbc.Osoby.Any(o => o.Id == osoba.Id))
                {
                    osoba.Id = dbc.Osoby.Max(o => o.Id) + 1;
                }
            }

            // unikanie dublowania adresów
            Adres adres = dbc.Adresy.ToArray().FirstOrDefault(a => a.Equals(osoba.Adres));
            if (adres != null) osoba.Adres = adres; // adres już jest, biorę z bazy danych

            // zmiany w bazie
            dbc.Osoby.Add(osoba);
            dbc.SaveChanges();

            return osoba.Id;
        }

        #region Usuwanie
        private int[] pobierzIdentyfikatoryUżywanychAdresów()
        {
            return dbc.Osoby.Select(o => o.Adres.Id).Distinct().ToArray();
        }

        private Adres[] pobierzNieużywaneAdresy()
        {
            int[] używaneIdentyfiaktoryAdresów = pobierzIdentyfikatoryUżywanychAdresów();
            List<Adres> nieużywaneAdresy = new List<Adres>();
            foreach (Adres adres in dbc.Adresy)
            {
                if (!używaneIdentyfiaktoryAdresów.Contains(adres.Id))
                {
                    nieużywaneAdresy.Add(adres);
                }
            }
            return nieużywaneAdresy.ToArray();
        }

        private void usuńNieużywaneAdresy()
        {
            dbc.Adresy.RemoveRange(pobierzNieużywaneAdresy());
            dbc.SaveChanges();
        }

        public void UsuńOsobę(int idOsoby)
        {
            Osoba osoba = PobierzOsobę(idOsoby);
            if (osoba != null)
            {
                dbc.Osoby.Remove(osoba);
                dbc.SaveChanges();
                usuńNieużywaneAdresy();
            }
        }
        #endregion
    }
}
