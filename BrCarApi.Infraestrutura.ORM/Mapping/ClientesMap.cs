using BrCarApi.Dominio.Entidades.Clientes;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;


namespace BrCarApi.Infraestrutura.ORM.Mapeamentos
{
    public class ClientesMap : EntityTypeConfiguration<Clientes>
    {
        public ClientesMap()
        {
            ToTable("CAD_CLIENTES");
            HasKey(x => x.ClienteID)
                .Property(x => x.ClienteID)
                .HasColumnName("CLIENTE_ID")
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            Property(x => x.CliCPF)
                .HasColumnName("CLI_CPF");

            Property(x => x.CliEmail)
                .HasColumnName("CLI_EMAIL")
                .HasColumnType("varchar")
                .HasMaxLength(100);

            Property(x => x.CliNome)
                .HasColumnName("CLI_NOME")
                .HasMaxLength(100)
                .HasColumnType("varchar");

            Property(x => x.CliTelefone)
                .HasColumnName("CLI_TELEFONE");

            Property(x => x.CliSenha)
                .HasColumnName("CLI_SENHA")
                .HasMaxLength(100)
                .HasColumnType("varchar");
        }
    }
}