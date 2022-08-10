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
        public decimal Unitario { get; set; }
        public string? Setor { get; set; }
        public int Quantidade { get; set; }
        public Produtos() { 
        }
        public Produtos(int id, string descricao, decimal unitario, int quantidade, string setor)
        {
            Id = id;
            Descricao = descricao;
            Unitario = unitario;
            Setor = setor;
        }

        public List<Produtos> GetAll()
        { 
           var listaProdutos = new List<Produtos>();

           listaProdutos.Add(new Produtos(2, "Café", 10.83M, 15, "Alimentos"));
           listaProdutos.Add(new Produtos(4, "Sabão em pó", 16.83M, 12, "Limpeza"));
           listaProdutos.Add(new Produtos(7, "Óleo", 7.93M, 26, "Alimentos"));
           listaProdutos.Add(new Produtos(13, "Café", 17.93M, 8,  "Alimentos"));
           listaProdutos.Add(new Produtos(18, "Café", 17.93M, 32, "Alimentos"));
           listaProdutos.Add(new Produtos(21, "Sabão em pedra", 17.93M, 63, "Limpeza"));
           listaProdutos.Add(new Produtos(27, "Suco de uva 350 ml", 17.93M, 79, "Alimentos"));

           return listaProdutos;
        }


        public List<Produtos> GetAll2()
        {
            var listaProdutos = new List<Produtos>();

            listaProdutos.Add(new Produtos(2, "Café", 10.83M, 15, "Alimentos"));
            listaProdutos.Add(new Produtos(5, "Sabão em pó 1KG", 30.83M, 10, "Limpeza"));
            listaProdutos.Add(new Produtos(7, "Óleo", 7.93M, 26, "Alimentos"));
            listaProdutos.Add(new Produtos(18, "Café", 17.93M, 32, "Alimentos"));
            listaProdutos.Add(new Produtos(21, "Sabão em pedra", 17.93M, 63, "Limpeza"));
            listaProdutos.Add(new Produtos(27, "Suco de uva 350 ml", 17.93M, 79, "Alimentos"));
            listaProdutos.Add(new Produtos(30, "Suco de uva 500 ml", 5.89M, 40, "Alimentos"));

            return listaProdutos;
        }
    }

    public class ProdutosComparer : IEqualityComparer<Produtos>
    {
        public bool Equals(Produtos? x, Produtos? y)
        {
            if (object.ReferenceEquals(x, y)) return true;

            if (x is null || y is null) return false;

            return x.Id == y.Id && x.Descricao.ToLower() == y.Descricao.ToLower() && x.Unitario == y.Unitario &&
                x.Quantidade == y.Quantidade && x.Setor.ToLower() == y.Setor.ToLower();
           // return x.Id == y.Id;
        }

        public int GetHashCode(Produtos obj)
        {
            if (obj is null) return 0;

            int IdHashCode = obj.Id.GetHashCode();
            return IdHashCode;
        }


    }


}
