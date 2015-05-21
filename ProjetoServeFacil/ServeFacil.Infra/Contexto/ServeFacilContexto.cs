using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using ServeFacil.Dominio.Entidades;
using ServeFacil.Infra.EntityConfig;

namespace ServeFacil.Infra.Contexto
{
    public class ServeFacilContexto : DbContext
    {

        public ServeFacilContexto()
            : base("ProjetoServeFacil")
        {

        }

        
        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<Imagen> Imagens { get; set; }
        public DbSet<Plano> Planos  {get; set;}
        public DbSet<Portifolio> Portifolios {get; set;}
        public DbSet<PortifolioPromovido> PortPromovidos {get; set;}
        public DbSet<Usuario> Usuarios { get; set; }


        
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
                //Nao permite que o banco coloque "S" nos nomes das tabelas
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
                //Nao permite que ele delete em cascata quando tiver relacao de um pra muitos
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();
                //Nao permite que ele delete em cascata quando tiver relacao de um pra um

            //modelBuilder.Properties().Where(p => p.Name == p.ReflectedType.Name + "Id")
            //    .Configure(p => p.IsKey());
            //    // Arthur:  Aqui força ele criar a PK caso ele não crie 
            modelBuilder.Properties<string>().Configure(p => p.HasColumnType("varchar"));
            // Arthur: Aqui ele cria todas as propriedades do Banco de Dados como varchar 
            // e não NVARCHAR que ocupa mas espaço no banco de dados 

            modelBuilder.Properties<string>().Configure(p => p.HasMaxLength(100));
            // Arthur: define o tamanho padrão de 100 para strings 

            modelBuilder.Entity<Usuario>().MapToStoredProcedures();
            modelBuilder.Entity<Categoria>().MapToStoredProcedures();
            modelBuilder.Entity<Imagen>().MapToStoredProcedures();
            modelBuilder.Entity<Plano>().MapToStoredProcedures();
            modelBuilder.Entity<Portifolio>().MapToStoredProcedures();
            modelBuilder.Entity<PortifolioPromovido>().MapToStoredProcedures();

            modelBuilder.Configurations.Add(new UsuarioConfiguration());
            modelBuilder.Configurations.Add(new CategoriaConfiguration());
            modelBuilder.Configurations.Add(new ImagensConfiguration());
            modelBuilder.Configurations.Add(new PlanosConfiguration());
            modelBuilder.Configurations.Add(new PortifolioConfiguratio());
            modelBuilder.Configurations.Add(new PortPromovidosConfiguration());
            // Arthur: Os itens acima adicionam as cofigurações de cada classe especifica
        }

       
      

      

       

    }
}
