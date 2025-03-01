using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DSStore.Models;

namespace DSStore.ViewModels;

public class ProdutoVM
{
    public Produto Produto { get; set; }
    public List<Produto> Produtos { get; set; }
}
