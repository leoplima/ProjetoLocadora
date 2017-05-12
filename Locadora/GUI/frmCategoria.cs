using DAL;
using Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI
{
    public partial class frmCategoria : Form
    {
        public frmCategoria()
        {
            InitializeComponent();
        }



        private void frmCategoria_Load(object sender, EventArgs e)
        {
            CarregarCategorias();
        }

        private void btnInserir_Click(object sender, EventArgs e)
        {
            Categoria cat = new Categoria();
            cat.Nome = textBox2.Text;

            CategoriaDAL catDAL = new CategoriaDAL();
            catDAL.InserirCategoria(cat);

            MessageBox.Show("Categoria cadastrada com Sucesso!");
            
            CarregarCategorias();
            LimpasCampos();

        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            LimpasCampos();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void CarregarCategorias()
        {
            CategoriaDAL catDAL = new CategoriaDAL();

            dataGridView1.DataSource = catDAL.SelecionarTodasCategorias();
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            int codigo = Convert.ToInt32(textBox1.Text);

            CategoriaDAL catDAL = new CategoriaDAL();

            Categoria cat = new Categoria();

            catDAL.ExcluirCategoria(codigo);
            CarregarCategorias();
            LimpasCampos();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            int codigo = Convert.ToInt32(textBox1.Text);

            CategoriaDAL catDAL = new CategoriaDAL();

            Categoria cat = catDAL.SelecionarCategoriaCodigo(codigo);

            if (cat == null)
            {
                MessageBox.Show("Categoria não encontrada!");
            }
            else
            {
                textBox2.Text = cat.Nome;


            }
        }

        private void LimpasCampos()
        {
            textBox1.Text = "";
            textBox2.Text = "";
        }
    }
}
