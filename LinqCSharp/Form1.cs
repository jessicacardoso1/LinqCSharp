namespace LinqCSharp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            var listaProdutos = new Produtos().GetAll();

            //sintaxe consulta
            //var listaProdutosClassificada = from produto in listaProdutos
            //                                orderby produto.Setor ascending, produto.Descricao ascending
            //                                select produto;

            //sintaxe médoto
            var listaProdutosClassificada = listaProdutos
                                                .OrderBy(x => x.Setor)
                                                .ThenBy(x => x.Descricao)
                                                .ToList();
            //Inverte a ordem da lista
            listaProdutosClassificada.Reverse();

            var msg = "";
            foreach (var produto in listaProdutosClassificada)
            {
                msg += "\n" + produto.Setor + "-->" + produto.Descricao + produto.Id;
            }

            MessageBox.Show(msg);


        }


        //Último da lista com o id informado
        public void LinqLast(int id, List<Produtos> produtos)
        {
            try
            {
                var produto = produtos.Last(p => p.Id == id);
                MessageBox.Show(produto.Id + " - " + produto.Descricao);

            }
            catch (Exception ex)
            {
                if (ex.HResult == -2146233079)
                    MessageBox.Show("ID não encontrado ou encontrado mais de um produto");
                MessageBox.Show(ex.HResult + ex.Message);
            }

        }

        //Primeiro da lista com o id informado
        public void LinqFirst(int id, List<Produtos> produtos)
        {
            try
            {
                var produto = produtos.First(p => p.Id == id);
                MessageBox.Show(produto.Id + " - " + produto.Descricao);

            }
            catch (Exception ex)
            {
                if (ex.HResult == -2146233079)
                    MessageBox.Show("ID não encontrado ou encontrado mais de um produto");
                MessageBox.Show(ex.HResult + ex.Message);
            }

        }
        public void LinqFirstOrDefault(int id, List<Produtos> produtos)
        {
            var produto = produtos.First(p => p.Id == id);
            MessageBox.Show(produto.Id + " - " + produto.Descricao);

            if (produto != null)
                MessageBox.Show(produto.Id + " - " + produto.Descricao);
            else
                MessageBox.Show("Produto não encontrado");

        }
        public void LinqLastOrDefault(int id, List<Produtos> produtos)
        {
            var produto = produtos.Last(p => p.Id == id);
            MessageBox.Show(produto.Id + " - " + produto.Descricao);

            if (produto != null)
                MessageBox.Show(produto.Id + " - " + produto.Descricao);
            else
                MessageBox.Show("Produto não encontrado");

        }
        public void LinqSingle(int id, List<Produtos> produtos)
        {
            try
            {
                var produto = produtos.Single(p => p.Id == id);
                MessageBox.Show(produto.Id + " - " + produto.Descricao);
            }
            catch (Exception ex)
            {
                if (ex.HResult == -2146233079)
                    MessageBox.Show("ID não encontrado ou encontrado mais de um produto");
                MessageBox.Show(ex.HResult + ex.Message);
            }

        }

        public void SingleOrDefault(int id, List<Produtos> produtos)
        {
            var produto = produtos.SingleOrDefault(p => p.Id >= id);

            try
            {
                if (produto != null)
                    MessageBox.Show(produto.Id + " - " + produto.Descricao);
                else
                    MessageBox.Show("Produto não encontrado");

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.HResult + ex.Message);
            }

        }

        //Consulta
        private void LinqFiltrar(List<Produtos> produtos)
        {
            var listaProdutosFiltrada =
            from produto in produtos
            where produto.Id < 14
            select produto;

            foreach (var prod in listaProdutosFiltrada)
            {
                MessageBox.Show(prod.Descricao);
            }
        }
        private void LinqFiltrarClassificar(List<Produtos> produtos)
        {
            var listaProdutosFiltrada =
            from produto in produtos
            orderby produto.Descricao ascending
            select produto;

            foreach (var prod in listaProdutosFiltrada)
            {
                MessageBox.Show(prod.Descricao);
            }
        }

        private void LinqAgrupar(List<Produtos> produtos)
        {
            var listaProdutosAgrupadas =
            from produto in produtos
            group produto by produto.Setor into setorGrupo
            orderby setorGrupo.Key ascending
            select setorGrupo;

            foreach (var grupo in listaProdutosAgrupadas)
            {
                var nomeGrupo = "Grupo: " + grupo.Key;

                foreach (var produto in grupo)
                {
                    MessageBox.Show(nomeGrupo + ": " + produto.Id + " " + produto.Descricao);
                }
            }
        }

        //Maximo
        private decimal LinqMax(List<Produtos> produtos)
        {
            decimal result = (from produto in produtos
                              select produto.Unitario).Max();
            return result;
        }
        //Minimo
        private decimal LinqMin(List<Produtos> produtos)
        {
            decimal result = (from produto in produtos
                        where produto.Setor == "Limpeza"
                        select produto.Unitario).Min();
            return result;
        }
        //Contar
        private int LinqCount(List<Produtos> produtos)
        {
            int result = (from produto in produtos
                          where produto.Setor == "Alimentos"
                          select produto).Count();
            return result;
        }
        //Somar
        private decimal LinqSum(List<Produtos> produtos)
        {
            decimal result = (from produto in produtos
                              select (produto.Quantidade * produto.Unitario)).Sum();
            return result;
        }

        //Média
        private double LinqAverage(List<Produtos> produtos)
        {
            double result = (from produto in produtos
                             select produto.Quantidade).Average();
            return result;
        }
        //Pular a qtd de itens passados
        private List<Produtos> LinqSkip(List<Produtos> produtos, int qqtdeItens)
        {
            return (from produto in produtos
                    select produto).Skip(qqtdeItens).ToList();
        }

        //Pegar a qtd de itens passados
        private List<Produtos> LinqTake(List<Produtos> produtos, int qtdItens)
        {
            var lista = (from produto in produtos
                         select produto).Take(qtdItens).ToList();
            return lista;
        }
        //Pegar os itens enquanto a condição for verdadeira.
        private List<Produtos> LinqTakeWhile(List<Produtos> produtos, int id)
        { 
            var lista = (from produto in produtos
                         select produto).TakeWhile(p => p.Id < id).ToList();
            return lista;
        }
        //Contains e a IEqualiyuComparer
        private bool LinqContains(List<Produtos> produtos, Produtos produto1)
        {
            ProdutosComparer produtosComparer = new ProdutosComparer();
            return (from produto in produtos
                    select produto).Contains(produto1, produtosComparer);
        }

        //Pegar os itens que tem na lista1 e não tem na lista2 pela descrição
        private List<String> LinqExcept(List<Produtos> produtos, List<Produtos> produtos2)
        {
            var lista = (from produto in produtos
                         select produto.Descricao).
                         Except(produtos2.Select(p =>
                         p.Descricao)).ToList();
            return lista;
        }


        //Pegar os itens que tem na lista1 e não tem na lista2 pelo ID
        private List<int?> LinqExcept2(List<Produtos> produtos, List<Produtos> produtos2)
        {
            var lista = (from produto in produtos
                         select produto.Id).
                         Except(produtos2.Select(p =>
                         p.Id)).ToList();
            return lista;
        }
        //Usando a interface IEqualityComparer para Comparar os valores através do Equals
        private List<Produtos> LinqExcept3(List<Produtos> produtos, List<Produtos> produtos2)
        {
            ProdutosComparer produtosComparer = new ProdutosComparer();
            var lista = (from produto in produtos
                         select produto).Except(produtos2, produtosComparer).ToList();
            return lista;
        }

        //Unindo uma lista com outra.
        public List<Produtos> LinqUnion(List<Produtos> produtos1, List<Produtos> produtos2)
        {
            ProdutosComparer produtosComparer = new ProdutosComparer();
            var lista = (from produto in produtos1
                         select produto)
                                .Union(produtos2, produtosComparer).ToList();

            return lista;
        }
        //Exibindo uma lista sem repetições
        public List<Produtos> LinqDistinct(List<Produtos> produtos)
        {
            ProdutosComparer produtosComparer = new ProdutosComparer();
            var listaDistinct = (from produto in produtos
                                 select produto)
                                .Distinct(produtosComparer).ToList();

            return listaDistinct;
        }
        public List<Produtos> LinqIntersect(List<Produtos> produtos1, List<Produtos> produtos2)
        {
            ProdutosComparer produtosComparer = new ProdutosComparer();
            var listaDistinct = (from produto in produtos1
                                 select produto)
                                .Intersect(produtos2, produtosComparer).ToList();

            return listaDistinct;
        }


        //var listaProdutos = new Produtos().GetAll();
        //var listaProdutos2 = new Produtos().GetAll2();


        //var listaProdutosFaltantes = LinqExcept3(listaProdutos, listaProdutos2);

        //foreach (var produto in listaProdutosFaltantes)
        //{
        //    MessageBox.Show(produto.Id +  "- " + produto.Descricao + "- " +
        //        produto.Unitario.ToString("N2"));
        //}   

        //var paises = new List<string>() { "Argentina", "França", "Brasil", "Chile", "Alemanha", "Paraguai", "Itália", "Japão", "França" };

        //var listapaises = paises.Distinct(StringComparer.OrdinalIgnoreCase);

        //foreach (var pais in listapaises) {
        //    MessageBox.Show(pais);

        //var produtos = new Produtos().GetAll();
        //var listaDistinct = LinqDistinct(produtos);

        //foreach (var pais in listaDistinct)
        //    MessageBox.Show(pais.Descricao);

        //var paises1 = new List<String>() { "Argentina", "França", "Brasil", "Chile", "Alemanha", "Paraguai", "Itália", "Japão" };
        //var paises2 = new List<String>() { "Argentina","Brasil", "Alemanha", "japão", "China" };

        ////sintaxe de método
        ////var paises3 = paises1.Union(paises2, StringComparer.OrdinalIgnoreCase).ToList();

        ////Sintaxe de Query(consulta)
        //var paises3 = (from pais in paises1
        //               select pais)
        //               .Union(paises2, StringComparer.OrdinalIgnoreCase).ToList();

        //var listaProdutos1 = new Produtos().GetAll();
        //var listaProdutos2 = new Produtos().GetAll2();

        ////Sintaxe de Método
        ////var listaProdutos3 = listaProdutos1.Select(x => x.Descricao)
        ////                     .Union(listaProdutos2.Select(y => y.Descricao));

        ////var listaproduto3 = (from produto in listaProdutos1
        ////                    select produto).Union(listaProdutos2).ToList();

        //var listaProduto3 = LinqUnion(listaProdutos1, listaProdutos2);

        //var msg = "";
        //foreach (var produto in listaProduto3)
        //    msg += "\n" + produto.Id + " " + produto.Descricao;

        //MessageBox.Show(msg);
    }
}