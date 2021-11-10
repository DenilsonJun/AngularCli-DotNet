using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace EntityFramework
{
    public partial class BaseContext : DbContext
    {
        public BaseContext()
            : base("name=Loja")
        {
        }

        public virtual DbSet<ClienteEntity> Clientes { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ClienteEntity>()
                .Property(e => e.nome_cliente)
                .IsUnicode(false);

            modelBuilder.Entity<ClienteEntity>()
                .Property(e => e.endereco)
                .IsUnicode(false);

            modelBuilder.Entity<ClienteEntity>()
                .Property(e => e.bairro)
                .IsUnicode(false);

            modelBuilder.Entity<ClienteEntity>()
                .Property(e => e.cidade)
                .IsUnicode(false);

            modelBuilder.Entity<ClienteEntity>()
                .Property(e => e.estado)
                .IsUnicode(false);
        }
    }
}
