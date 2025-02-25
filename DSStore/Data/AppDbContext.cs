using DSStore.Models;
using GStore.Models;
using Microsoft.AspNetCore.Authorization.Infrastructure;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace DSStore.Data;

public class AppDbContext : IdentityDbContext<Usuario>
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {      
    }

    public DbSet<Categoria> Categorias {get; set;}
    public DbSet<Produto> Produtos {get; set;}
    public DbSet<ProdutoFoto> ProdutoFotos {get; set;}
    public DbSet<Usuario> Usuarios {get; set;}

    protected override void OnModelCreating(ModelBuilder builder)
    {
        #region Definição dos nomes do entity
        base.OnModelCreating(builder);
        builder.Entity<Usuario>().ToTable("usuario");
        builder.Entity<IdentityRole>().ToTable("perfil");
        builder.Entity<IdentityUserRole<string>>().ToTable("usuario_perfil");
        builder.Entity<IdentityUserClaim<string>>().ToTable("usuario_regra");
        builder.Entity<IdentityUserToken<string>>().ToTable("usuario_token");
        builder.Entity<IdentityUserLogin<string>>().ToTable("usuario_login");
        builder.Entity<IdentityRoleClaim<string>>().ToTable("perfil_regra");
        #endregion
        
        AppDbSeed seed = new(builder);
    }
}
