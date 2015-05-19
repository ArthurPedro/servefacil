namespace ServeFacil.Infra.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class atual : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Categoria",
                c => new
                    {
                        categoriaID = c.Int(nullable: false, identity: true),
                        nomeCategoria = c.String(),
                    })
                .PrimaryKey(t => t.categoriaID);
            
            CreateTable(
                "dbo.Imagen",
                c => new
                    {
                        imagensId = c.Int(nullable: false, identity: true),
                        caminho = c.String(),
                        portId_portfolioId = c.Int(),
                        usuarioId_UsuarioId = c.Int(),
                    })
                .PrimaryKey(t => t.imagensId)
                .ForeignKey("dbo.Portifolio", t => t.portId_portfolioId)
                .ForeignKey("dbo.Usuario", t => t.usuarioId_UsuarioId)
                .Index(t => t.portId_portfolioId)
                .Index(t => t.usuarioId_UsuarioId);
            
            CreateTable(
                "dbo.Portifolio",
                c => new
                    {
                        portfolioId = c.Int(nullable: false, identity: true),
                        titulo = c.String(),
                        descricao = c.String(),
                        dataCriacao = c.DateTime(nullable: false),
                        categoriaId_categoriaID = c.Int(),
                        usuarioId_UsuarioId = c.Int(),
                    })
                .PrimaryKey(t => t.portfolioId)
                .ForeignKey("dbo.Categoria", t => t.categoriaId_categoriaID)
                .ForeignKey("dbo.Usuario", t => t.usuarioId_UsuarioId)
                .Index(t => t.categoriaId_categoriaID)
                .Index(t => t.usuarioId_UsuarioId);
            
            CreateTable(
                "dbo.Usuario",
                c => new
                    {
                        UsuarioId = c.Int(nullable: false, identity: true),
                        Nome = c.String(),
                        SobreNome = c.String(),
                        email = c.String(),
                        Senha = c.String(),
                        ConfirmarSenha = c.String(),
                        cpf = c.String(),
                        cep = c.String(),
                        endereco = c.String(),
                        numero = c.String(),
                        cidade = c.String(),
                        estado = c.String(),
                    })
                .PrimaryKey(t => t.UsuarioId);
            
            CreateTable(
                "dbo.Plano",
                c => new
                    {
                        planosId = c.Int(nullable: false, identity: true),
                        tipo = c.String(),
                        duracao = c.Int(nullable: false),
                        valorPlano = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.planosId);
            
            CreateTable(
                "dbo.PortifolioPromovido",
                c => new
                    {
                        portPromovidosId = c.Int(nullable: false, identity: true),
                        dataInicio = c.DateTime(nullable: false),
                        dataFim = c.DateTime(nullable: false),
                        planoId_planosId = c.Int(),
                        portifolioId_portfolioId = c.Int(),
                    })
                .PrimaryKey(t => t.portPromovidosId)
                .ForeignKey("dbo.Plano", t => t.planoId_planosId)
                .ForeignKey("dbo.Portifolio", t => t.portifolioId_portfolioId)
                .Index(t => t.planoId_planosId)
                .Index(t => t.portifolioId_portfolioId);
            
            CreateStoredProcedure(
                "dbo.Categoria_Insert",
                p => new
                    {
                        nomeCategoria = p.String(),
                    },
                body:
                    @"INSERT [dbo].[Categoria]([nomeCategoria])
                      VALUES (@nomeCategoria)
                      
                      DECLARE @categoriaID int
                      SELECT @categoriaID = [categoriaID]
                      FROM [dbo].[Categoria]
                      WHERE @@ROWCOUNT > 0 AND [categoriaID] = scope_identity()
                      
                      SELECT t0.[categoriaID]
                      FROM [dbo].[Categoria] AS t0
                      WHERE @@ROWCOUNT > 0 AND t0.[categoriaID] = @categoriaID"
            );
            
            CreateStoredProcedure(
                "dbo.Categoria_Update",
                p => new
                    {
                        categoriaID = p.Int(),
                        nomeCategoria = p.String(),
                    },
                body:
                    @"UPDATE [dbo].[Categoria]
                      SET [nomeCategoria] = @nomeCategoria
                      WHERE ([categoriaID] = @categoriaID)"
            );
            
            CreateStoredProcedure(
                "dbo.Categoria_Delete",
                p => new
                    {
                        categoriaID = p.Int(),
                    },
                body:
                    @"DELETE [dbo].[Categoria]
                      WHERE ([categoriaID] = @categoriaID)"
            );
            
            CreateStoredProcedure(
                "dbo.Imagen_Insert",
                p => new
                    {
                        caminho = p.String(),
                        portId_portfolioId = p.Int(),
                        usuarioId_UsuarioId = p.Int(),
                    },
                body:
                    @"INSERT [dbo].[Imagen]([caminho], [portId_portfolioId], [usuarioId_UsuarioId])
                      VALUES (@caminho, @portId_portfolioId, @usuarioId_UsuarioId)
                      
                      DECLARE @imagensId int
                      SELECT @imagensId = [imagensId]
                      FROM [dbo].[Imagen]
                      WHERE @@ROWCOUNT > 0 AND [imagensId] = scope_identity()
                      
                      SELECT t0.[imagensId]
                      FROM [dbo].[Imagen] AS t0
                      WHERE @@ROWCOUNT > 0 AND t0.[imagensId] = @imagensId"
            );
            
            CreateStoredProcedure(
                "dbo.Imagen_Update",
                p => new
                    {
                        imagensId = p.Int(),
                        caminho = p.String(),
                        portId_portfolioId = p.Int(),
                        usuarioId_UsuarioId = p.Int(),
                    },
                body:
                    @"UPDATE [dbo].[Imagen]
                      SET [caminho] = @caminho, [portId_portfolioId] = @portId_portfolioId, [usuarioId_UsuarioId] = @usuarioId_UsuarioId
                      WHERE ([imagensId] = @imagensId)"
            );
            
            CreateStoredProcedure(
                "dbo.Imagen_Delete",
                p => new
                    {
                        imagensId = p.Int(),
                        portId_portfolioId = p.Int(),
                        usuarioId_UsuarioId = p.Int(),
                    },
                body:
                    @"DELETE [dbo].[Imagen]
                      WHERE ((([imagensId] = @imagensId) AND (([portId_portfolioId] = @portId_portfolioId) OR ([portId_portfolioId] IS NULL AND @portId_portfolioId IS NULL))) AND (([usuarioId_UsuarioId] = @usuarioId_UsuarioId) OR ([usuarioId_UsuarioId] IS NULL AND @usuarioId_UsuarioId IS NULL)))"
            );
            
            CreateStoredProcedure(
                "dbo.Portifolio_Insert",
                p => new
                    {
                        titulo = p.String(),
                        descricao = p.String(),
                        dataCriacao = p.DateTime(),
                        categoriaId_categoriaID = p.Int(),
                        usuarioId_UsuarioId = p.Int(),
                    },
                body:
                    @"INSERT [dbo].[Portifolio]([titulo], [descricao], [dataCriacao], [categoriaId_categoriaID], [usuarioId_UsuarioId])
                      VALUES (@titulo, @descricao, @dataCriacao, @categoriaId_categoriaID, @usuarioId_UsuarioId)
                      
                      DECLARE @portfolioId int
                      SELECT @portfolioId = [portfolioId]
                      FROM [dbo].[Portifolio]
                      WHERE @@ROWCOUNT > 0 AND [portfolioId] = scope_identity()
                      
                      SELECT t0.[portfolioId]
                      FROM [dbo].[Portifolio] AS t0
                      WHERE @@ROWCOUNT > 0 AND t0.[portfolioId] = @portfolioId"
            );
            
            CreateStoredProcedure(
                "dbo.Portifolio_Update",
                p => new
                    {
                        portfolioId = p.Int(),
                        titulo = p.String(),
                        descricao = p.String(),
                        dataCriacao = p.DateTime(),
                        categoriaId_categoriaID = p.Int(),
                        usuarioId_UsuarioId = p.Int(),
                    },
                body:
                    @"UPDATE [dbo].[Portifolio]
                      SET [titulo] = @titulo, [descricao] = @descricao, [dataCriacao] = @dataCriacao, [categoriaId_categoriaID] = @categoriaId_categoriaID, [usuarioId_UsuarioId] = @usuarioId_UsuarioId
                      WHERE ([portfolioId] = @portfolioId)"
            );
            
            CreateStoredProcedure(
                "dbo.Portifolio_Delete",
                p => new
                    {
                        portfolioId = p.Int(),
                        categoriaId_categoriaID = p.Int(),
                        usuarioId_UsuarioId = p.Int(),
                    },
                body:
                    @"DELETE [dbo].[Portifolio]
                      WHERE ((([portfolioId] = @portfolioId) AND (([categoriaId_categoriaID] = @categoriaId_categoriaID) OR ([categoriaId_categoriaID] IS NULL AND @categoriaId_categoriaID IS NULL))) AND (([usuarioId_UsuarioId] = @usuarioId_UsuarioId) OR ([usuarioId_UsuarioId] IS NULL AND @usuarioId_UsuarioId IS NULL)))"
            );
            
            CreateStoredProcedure(
                "dbo.Usuario_Insert",
                p => new
                    {
                        Nome = p.String(),
                        SobreNome = p.String(),
                        email = p.String(),
                        Senha = p.String(),
                        ConfirmarSenha = p.String(),
                        cpf = p.String(),
                        cep = p.String(),
                        endereco = p.String(),
                        numero = p.String(),
                        cidade = p.String(),
                        estado = p.String(),
                    },
                body:
                    @"INSERT [dbo].[Usuario]([Nome], [SobreNome], [email], [Senha], [ConfirmarSenha], [cpf], [cep], [endereco], [numero], [cidade], [estado])
                      VALUES (@Nome, @SobreNome, @email, @Senha, @ConfirmarSenha, @cpf, @cep, @endereco, @numero, @cidade, @estado)
                      
                      DECLARE @UsuarioId int
                      SELECT @UsuarioId = [UsuarioId]
                      FROM [dbo].[Usuario]
                      WHERE @@ROWCOUNT > 0 AND [UsuarioId] = scope_identity()
                      
                      SELECT t0.[UsuarioId]
                      FROM [dbo].[Usuario] AS t0
                      WHERE @@ROWCOUNT > 0 AND t0.[UsuarioId] = @UsuarioId"
            );
            
            CreateStoredProcedure(
                "dbo.Usuario_Update",
                p => new
                    {
                        UsuarioId = p.Int(),
                        Nome = p.String(),
                        SobreNome = p.String(),
                        email = p.String(),
                        Senha = p.String(),
                        ConfirmarSenha = p.String(),
                        cpf = p.String(),
                        cep = p.String(),
                        endereco = p.String(),
                        numero = p.String(),
                        cidade = p.String(),
                        estado = p.String(),
                    },
                body:
                    @"UPDATE [dbo].[Usuario]
                      SET [Nome] = @Nome, [SobreNome] = @SobreNome, [email] = @email, [Senha] = @Senha, [ConfirmarSenha] = @ConfirmarSenha, [cpf] = @cpf, [cep] = @cep, [endereco] = @endereco, [numero] = @numero, [cidade] = @cidade, [estado] = @estado
                      WHERE ([UsuarioId] = @UsuarioId)"
            );
            
            CreateStoredProcedure(
                "dbo.Usuario_Delete",
                p => new
                    {
                        UsuarioId = p.Int(),
                    },
                body:
                    @"DELETE [dbo].[Usuario]
                      WHERE ([UsuarioId] = @UsuarioId)"
            );
            
            CreateStoredProcedure(
                "dbo.Plano_Insert",
                p => new
                    {
                        tipo = p.String(),
                        duracao = p.Int(),
                        valorPlano = p.Double(),
                    },
                body:
                    @"INSERT [dbo].[Plano]([tipo], [duracao], [valorPlano])
                      VALUES (@tipo, @duracao, @valorPlano)
                      
                      DECLARE @planosId int
                      SELECT @planosId = [planosId]
                      FROM [dbo].[Plano]
                      WHERE @@ROWCOUNT > 0 AND [planosId] = scope_identity()
                      
                      SELECT t0.[planosId]
                      FROM [dbo].[Plano] AS t0
                      WHERE @@ROWCOUNT > 0 AND t0.[planosId] = @planosId"
            );
            
            CreateStoredProcedure(
                "dbo.Plano_Update",
                p => new
                    {
                        planosId = p.Int(),
                        tipo = p.String(),
                        duracao = p.Int(),
                        valorPlano = p.Double(),
                    },
                body:
                    @"UPDATE [dbo].[Plano]
                      SET [tipo] = @tipo, [duracao] = @duracao, [valorPlano] = @valorPlano
                      WHERE ([planosId] = @planosId)"
            );
            
            CreateStoredProcedure(
                "dbo.Plano_Delete",
                p => new
                    {
                        planosId = p.Int(),
                    },
                body:
                    @"DELETE [dbo].[Plano]
                      WHERE ([planosId] = @planosId)"
            );
            
            CreateStoredProcedure(
                "dbo.PortifolioPromovido_Insert",
                p => new
                    {
                        dataInicio = p.DateTime(),
                        dataFim = p.DateTime(),
                        planoId_planosId = p.Int(),
                        portifolioId_portfolioId = p.Int(),
                    },
                body:
                    @"INSERT [dbo].[PortifolioPromovido]([dataInicio], [dataFim], [planoId_planosId], [portifolioId_portfolioId])
                      VALUES (@dataInicio, @dataFim, @planoId_planosId, @portifolioId_portfolioId)
                      
                      DECLARE @portPromovidosId int
                      SELECT @portPromovidosId = [portPromovidosId]
                      FROM [dbo].[PortifolioPromovido]
                      WHERE @@ROWCOUNT > 0 AND [portPromovidosId] = scope_identity()
                      
                      SELECT t0.[portPromovidosId]
                      FROM [dbo].[PortifolioPromovido] AS t0
                      WHERE @@ROWCOUNT > 0 AND t0.[portPromovidosId] = @portPromovidosId"
            );
            
            CreateStoredProcedure(
                "dbo.PortifolioPromovido_Update",
                p => new
                    {
                        portPromovidosId = p.Int(),
                        dataInicio = p.DateTime(),
                        dataFim = p.DateTime(),
                        planoId_planosId = p.Int(),
                        portifolioId_portfolioId = p.Int(),
                    },
                body:
                    @"UPDATE [dbo].[PortifolioPromovido]
                      SET [dataInicio] = @dataInicio, [dataFim] = @dataFim, [planoId_planosId] = @planoId_planosId, [portifolioId_portfolioId] = @portifolioId_portfolioId
                      WHERE ([portPromovidosId] = @portPromovidosId)"
            );
            
            CreateStoredProcedure(
                "dbo.PortifolioPromovido_Delete",
                p => new
                    {
                        portPromovidosId = p.Int(),
                        planoId_planosId = p.Int(),
                        portifolioId_portfolioId = p.Int(),
                    },
                body:
                    @"DELETE [dbo].[PortifolioPromovido]
                      WHERE ((([portPromovidosId] = @portPromovidosId) AND (([planoId_planosId] = @planoId_planosId) OR ([planoId_planosId] IS NULL AND @planoId_planosId IS NULL))) AND (([portifolioId_portfolioId] = @portifolioId_portfolioId) OR ([portifolioId_portfolioId] IS NULL AND @portifolioId_portfolioId IS NULL)))"
            );
            
        }
        
        public override void Down()
        {
            DropStoredProcedure("dbo.PortifolioPromovido_Delete");
            DropStoredProcedure("dbo.PortifolioPromovido_Update");
            DropStoredProcedure("dbo.PortifolioPromovido_Insert");
            DropStoredProcedure("dbo.Plano_Delete");
            DropStoredProcedure("dbo.Plano_Update");
            DropStoredProcedure("dbo.Plano_Insert");
            DropStoredProcedure("dbo.Usuario_Delete");
            DropStoredProcedure("dbo.Usuario_Update");
            DropStoredProcedure("dbo.Usuario_Insert");
            DropStoredProcedure("dbo.Portifolio_Delete");
            DropStoredProcedure("dbo.Portifolio_Update");
            DropStoredProcedure("dbo.Portifolio_Insert");
            DropStoredProcedure("dbo.Imagen_Delete");
            DropStoredProcedure("dbo.Imagen_Update");
            DropStoredProcedure("dbo.Imagen_Insert");
            DropStoredProcedure("dbo.Categoria_Delete");
            DropStoredProcedure("dbo.Categoria_Update");
            DropStoredProcedure("dbo.Categoria_Insert");
            DropForeignKey("dbo.PortifolioPromovido", "portifolioId_portfolioId", "dbo.Portifolio");
            DropForeignKey("dbo.PortifolioPromovido", "planoId_planosId", "dbo.Plano");
            DropForeignKey("dbo.Imagen", "usuarioId_UsuarioId", "dbo.Usuario");
            DropForeignKey("dbo.Imagen", "portId_portfolioId", "dbo.Portifolio");
            DropForeignKey("dbo.Portifolio", "usuarioId_UsuarioId", "dbo.Usuario");
            DropForeignKey("dbo.Portifolio", "categoriaId_categoriaID", "dbo.Categoria");
            DropIndex("dbo.PortifolioPromovido", new[] { "portifolioId_portfolioId" });
            DropIndex("dbo.PortifolioPromovido", new[] { "planoId_planosId" });
            DropIndex("dbo.Portifolio", new[] { "usuarioId_UsuarioId" });
            DropIndex("dbo.Portifolio", new[] { "categoriaId_categoriaID" });
            DropIndex("dbo.Imagen", new[] { "usuarioId_UsuarioId" });
            DropIndex("dbo.Imagen", new[] { "portId_portfolioId" });
            DropTable("dbo.PortifolioPromovido");
            DropTable("dbo.Plano");
            DropTable("dbo.Usuario");
            DropTable("dbo.Portifolio");
            DropTable("dbo.Imagen");
            DropTable("dbo.Categoria");
        }
    }
}
