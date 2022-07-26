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

        private void button1_Click(object sender, EventArgs e)
        {

            var listaProdutos = new Produtos().GetAll();
            //LinqFiltrar(listaProdutos);
            //LinqFiltrarClassificar(listaProdutos);
            LinqAgrupar(listaProdutos);


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
    }
}