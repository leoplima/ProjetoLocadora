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
    public partial class frmArtistas : Form
    {
        public frmArtistas()
        {
            InitializeComponent();
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            int codigo = Convert.ToInt32(txtCodigo.Text);

            ArtistaDAL artDAL = new ArtistaDAL();

            Artista art = new Artista();

            artDAL.ExcluirArtista(codigo);
            CarregarArtistas();
            LimparCampos();
        }

        private void LimparCampos()
        {
            txtCodigo.Text = "";
            txtNome.Text = "";
        }


        private void btnInserir_Click(object sender, EventArgs e)
        {
            Artista art = new Artista();
            art.Nome = txtNome.Text;
            art.DataNasc = dtpData.Value.ToString();
            art.Pais = txtPais.Text;
            art.Foto = pictureBox1.ImageLocation;

            ArtistaDAL artDAL = new ArtistaDAL();
            artDAL.InserirArtista(art);

            MessageBox.Show("Artista cadastrado com Sucesso!");

            CarregarArtistas();
            LimparCampos();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                                
                pictureBox1.ImageLocation = openFileDialog1.FileName;

            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            int codigo = Convert.ToInt32(txtCodigo.Text);

            ArtistaDAL artDAL = new ArtistaDAL();

            Artista art = artDAL.SelecionarArtistaCodigo(codigo);

            if (art == null)
            {
                MessageBox.Show("Artista não encontrado!");
            }
            else
            {
                txtNome.Text = art.Nome;
                dtpData.Value =  Convert.ToDateTime(art.DataNasc);
                txtPais.Text = art.Pais;
                pictureBox1.ImageLocation = art.Foto;
                
            }
        }

        private void btnAtualizar_Click(object sender, EventArgs e)
        {
            Artista art = new Artista();
            art.Codigo = Convert.ToInt32(txtCodigo.Text);
            art.Nome = txtNome.Text;
            art.DataNasc = dtpData.Value.ToString();
            art.Pais = txtPais.Text;
            art.Foto = pictureBox1.ImageLocation.ToString();

            ArtistaDAL artDAL = new ArtistaDAL();
            artDAL.AtualizarArtista(art);

            LimparCampos();

            CarregarArtistas();

            MessageBox.Show("Artista atualizado com sucesso!");
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            LimparCampos();
        }

        private void frmArtistas_Load(object sender, EventArgs e)
        {
            CarregarArtistas();
        }

        private void CarregarArtistas()
        {
            ArtistaDAL artDAL = new ArtistaDAL();

            dataGridView1.DataSource = artDAL.SelecionarTodosArtistas();
        }

        


    }
}
