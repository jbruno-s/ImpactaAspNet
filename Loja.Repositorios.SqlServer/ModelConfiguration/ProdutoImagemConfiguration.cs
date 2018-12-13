using Loja.Dominio;
using System.Data.Entity.ModelConfiguration;

namespace Loja.Repositorios.SqlServer.ModelConfiguration
{
    internal class ProdutoImagemConfiguration : EntityTypeConfiguration<ProdutoImagem>
    {
        public ProdutoImagemConfiguration()
        {
            //ToTable("Watchatcha");
            HasKey(pi => pi.ProdutoId);

            Property(pi => pi.ProdutoId)
                .HasColumnName("Produto_Id");

            Property(pi => pi.ContentType)
                .IsRequired()
                .HasMaxLength(50);
        }
    }
}