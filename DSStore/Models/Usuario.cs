using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;
using Mysqlx;

namespace DSStore.Models;

public class Usuario :IdentityUser
{

    [Required(ErrorMessage = "Por favor, informe o nome")]
    [StringLength(60, ErrorMessage ="O nome deve possuir no máximo 60 caracteres")]
    public string Nome { get; set; }

    [Display(Name ="Data de Nascimento")]
    [DataType(DataType.Date)]
    public DateTime? DataNascimento { get; set; }

    [StringLength(300)]
    public string Foto { get; set; }

    
}
