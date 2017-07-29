using SistemaGerencia.BaseModel.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Core.Metadata.Edm;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.Infrastructure;

namespace SistemaGerencia.BaseModel.Context
{
    public class MySQLContext : DbContext
    {
        public MySQLContext(string conn) : base(conn)
        {
            Database.SetInitializer<MySQLContext>(null);
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            modelBuilder.Entity<Cliente>().Map(x => x.Requires("Discriminator1").HasValue("C"));
            modelBuilder.Entity<Fornecedor>().Map(x => x.Requires("Discriminator1").HasValue("F"));
            modelBuilder.Entity<PrestadorServico>().Map(x => x.Requires("Discriminator1").HasValue("P"));
            modelBuilder.Conventions.Add<DiscriminatorToTipoPessoa>();


            modelBuilder.Entity<ServidorTerceirizado>().Map(x => x.Requires("Discriminator2").HasValue("T"));
            modelBuilder.Entity<Colaborador>().Map(x => x.Requires("Discriminator2").HasValue("C"));
            modelBuilder.Conventions.Add<DiscriminatorToTipoPrestadorServico>();

            modelBuilder.Entity<Funcionario>().Map(x => x.Requires("Discriminator3").HasValue("F"));
            modelBuilder.Entity<Socio>().Map(x => x.Requires("Discriminator3").HasValue("S"));
            modelBuilder.Conventions.Add<DiscriminatorToTipoColaborador>();

        }


        protected class DiscriminatorToTipoPessoa : IStoreModelConvention<EdmProperty>
        {
            public void Apply(EdmProperty item, DbModel model)
            {
                if (item.Name == "Discriminator1")
                {
                    item.Name = "Tipo_Pessoa";
                }
            }
        }


        protected class DiscriminatorToTipoPrestadorServico : IStoreModelConvention<EdmProperty>
        {
            public void Apply(EdmProperty item, DbModel model)
            {
                if (item.Name == "Discriminator2")
                {
                    item.Name = "Tipo_Prestador_Serv";
                }
            }
        }


        protected class DiscriminatorToTipoColaborador : IStoreModelConvention<EdmProperty>
        {
            public void Apply(EdmProperty item, DbModel model)
            {
                if (item.Name == "Discriminator3")
                {
                    item.Name = "Tipo_Colaborador";
                }
            }
        }

        public virtual DbSet<Pessoa> Pessoa { get; set; }
        public virtual DbSet<Endereco> Endereco { get; set; }
        public virtual DbSet<Cliente> Cliente { get; set; }
        public virtual DbSet<Fornecedor> Fornecedor { get; set; }
        public virtual DbSet<PrestadorServico> PrestadorServico { get; set; }
        public virtual DbSet<ServidorTerceirizado> ServidorTerceirizado { get; set; }
        public virtual DbSet<Colaborador> Colaborador { get; set; }
        public virtual DbSet<Socio> Socio { get; set; }
        public virtual DbSet<Funcionario> Funcionario { get; set; }
        public virtual DbSet<SolicitacaoOrcamento> SolicitacaoOrcamento { get; set; }
        public virtual DbSet<Orcamento> Orcamento { get; set; }
    }
}
