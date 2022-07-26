using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqCSharp
{
    public class Produtos
    {
        public int? Id { get; set; }
        public string? Descricao { get; set; }
        public decimal? Unitario { get; set; }
        public string? Setor { get; set; }
        public Produtos() { 
        }
        public Produtos(int id, string descricao, decimal unitario, string setor)
        {
            Id = id;
            Descricao = descricao;
            Unitario = unitario;
            Setor = setor;
        }

        public List<Produtos> GetAll()
        { 
           var listaProdutos = new List<Produtos>();

           listaProdutos.Add(new Produtos(2, "Café", 10.83M, "Alimentos"));
           listaProdutos.Add(new Produtos(4, "Sabão em pó", 16.83M, "Limpeza"));
           listaProdutos.Add(new Produtos(7, "Óleo", 7.93M, "Alimentos"));
           listaProdutos.Add(new Produtos(13, "Café", 17.93M, "Alimentos"));
           listaProdutos.Add(new Produtos(18, "Café", 17.93M, "Alimentos"));
           listaProdutos.Add(new Produtos(21, "Sabão em pedra", 17.93M, "Limpeza"));
           listaProdutos.Add(new Produtos(27, "Suco de uva 350 ml", 17.93M, "Alimentos"));

           return listaProdutos;
        }
    }
}
