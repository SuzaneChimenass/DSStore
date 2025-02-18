using DSStore.Models;
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

        #region Popular Categorias
        List<Categoria> categorias = new(){
            new(){
                Id = 1,
                Nome = "Eletrônicos",

            },
            new(){
                Id = 2,
                Nome = "Celulares",
            }
        };
        builder.Entity<Categoria>().HasData(categorias);
        #endregion

        #region Popular Usuario
        Usuario usuario = new(){
            Id = Guid.NewGuid().ToString(),
            UserName = "SuzaneMartins",
            NormalizedUserName = "SUZANEMARTINS",
            Email = "dayannesuzane@gmail.com",
            NormalizedEmail = "DAYANNESUZANE@GMAIL.COM",
            EmailConfirmed = true,
            Nome = "Suzane Martins",
            DataNascimento = DateTime.Parse("17/02/2000"),
            LockoutEnabled = true
        };
        PasswordHasher<Usuario> password = new();
        password.HashPassword(usuario, "123456");
        builder.Entity<Usuario>().HasData(usuario);
        #endregion

        #region Popular Perfil
        List<IdentityRole> perfis = new() {
            new() {
                Id = Guid.NewGuid().ToString(),
                Name = "Administrador",
                NormalizedName = "ADMINISTRADOR"
            },
            new(){
                Id= Guid.NewGuid().ToString(),
                Name = "Funcionario",
                NormalizedName = "FUNCIONARIO"
            },
            new(){
                Id= Guid.NewGuid().ToString(),
                Name = "Cliente",
                NormalizedName = "CLIENTE"
            }
        };
        builder.Entity<IdentityRole>().HasData(perfis);
        #endregion

        #region Popular Usuario-Perfil
        List<IdentityUserRole<string>> userRoles = new ()
        {
            new(){
                UserId = usuario.Id,
                RoleId = perfis[0].Id
            }
        };
        builder.Entity<IdentityUserRole<string>>().HasData(userRoles);

        #endregion
    }
}
