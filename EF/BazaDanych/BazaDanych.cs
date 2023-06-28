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
    }
}
