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
    public partial class frmGenero : Form
    {
        public frmGenero()
        {
            InitializeComponent();
        }
        

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            int codigo = Convert.ToInt32(txtCodigo.Text);

            GeneroDAL genDAL = new GeneroDAL();

            Genero gen = genDAL.SelecionarGeneroCodigo(codigo);

            if (gen == null)
            {
                MessageBox.Show("Genero não encontrada!");
            }
            else
            {
                txtNome.Text = gen.Nome;


            }
        }

        private void LimparCampos()
        {
            txtCodigo.Text = "";
            txtNome.Text = "";
        }

        private void btnAtualizar_Click(object sender, EventArgs e)
        {
            Genero gen = new Genero();
            gen.Codigo = Convert.ToInt32(txtCodigo.Text);
            gen.Nome = txtNome.Text;

            GeneroDAL genDAL = new GeneroDAL();
            genDAL.AtualizarGenero(gen);

            LimparCampos();

            CarregarGeneros();

            MessageBox.Show("Genero atualizada com sucesso!");
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            LimparCampos();
        }

        private void CarregarGeneros()
        {
            GeneroDAL genDAL = new GeneroDAL();

            dataGridView1.DataSource = genDAL.SelecionarTodosGeneros();
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            int codigo = Convert.ToInt32(txtCodigo.Text);

            GeneroDAL genDAL = new GeneroDAL();

            Genero gen = new Genero();

            genDAL.ExcluirGenero(codigo);
            CarregarGeneros();
            LimparCampos();
        }

        private void btnInserir_Click(object sender, EventArgs e)
        {
            Genero gen = new Genero();
            gen.Nome = txtNome.Text;

            GeneroDAL genDAL = new GeneroDAL();
            genDAL.InserirGenero(gen);

            MessageBox.Show("Genero cadastrado com Sucesso!");

            CarregarGeneros();
            LimparCampos();
        }

        private void frmGenero_Load(object sender, EventArgs e)
        {
            CarregarGeneros();
        }
    }
}
