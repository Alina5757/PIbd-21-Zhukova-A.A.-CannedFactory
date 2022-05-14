using CannedFactoryDatabaseImplement.Models;
using Microsoft.EntityFrameworkCore;

namespace CannedFactoryDatabaseImplement
{
    public class CannedFactoryDatabase : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (optionsBuilder.IsConfigured == false)
            {
                optionsBuilder.UseSqlServer(@"Data Source=DESKTOP-H7FNSK3\SQLEXPRESS;Initial Catalog=CannedFactoryDatabase;Integrated Security=True;MultipleActiveResultSets=True;"); // Aln-Pc
            }
            base.OnConfiguring(optionsBuilder);
        }
        public virtual DbSet<Component> Components { set; get; }
        public virtual DbSet<Canned> Canneds { set; get; }
        public virtual DbSet<CannedComponent> CannedComponents { set; get; }
        public virtual DbSet<Order> Orders { set; get; }
        public virtual DbSet<Client> Clients { set; get; }
        public virtual DbSet<Implementer> Implementers { get; set; }
        public virtual DbSet<MessageInfo> MessagesInfo { get; set; }
    }
}
