using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Mysqlx;

namespace DSStore.Models;

[Table("produto_foto")]
public class ProdutoFoto
{
    [Key]
    public int Id {get; set; }

    [Required(ErrorMessage = "Por favor, informe o produto")]
    public int ProdutoId {get; set; }

    [ForeignKey("ProdutoId")]
    public Produto Produto {get; set; }

    [Display(Name = "Arquivo")]
    [Required(ErrorMessage = "Por favor, informe o Arquivo")]
    [StringLength(300)]
    public string ArquivoFoto { get; set; }

    [Display(Name ="Descrição")]
    [StringLength(100, ErrorMessage = "Por favor, informe a descrição")]
    public string Descricao { get; set; }
}
