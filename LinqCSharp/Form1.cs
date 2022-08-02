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
            //LinqFiltrar(listaProdutos);
            //LinqFiltrarClassificar(listaProdutos);
            //LinqAgrupar(listaProdutos);
            //LinqSingle(1, listaProdutos);
            //SingleOrDefault(1, listaProdutos);
            //var minimo = LinqMin(listaProdutos);
            //MessageBox.Show("Menor preço: " + minimo.ToString("N0"));
            // var lista = LinqSkip(listaProdutos, 3);
            //dataGridView1.DataSource = lista;
            dataGridView1.DataSource = LinqTakeWhile(listaProdutos, 18);


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
    }
}