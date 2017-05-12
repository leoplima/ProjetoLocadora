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
    public partial class frmPrincipal : Form
    {
        public frmPrincipal()
        {
            InitializeComponent();
        }

        private void categoriaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmCategoria tela = new frmCategoria();
            tela.MdiParent = this;
            tela.Show();
            
        }

        private void filmesESériesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmItem tela = new frmItem();
            tela.MdiParent = this;
            tela.Show();
        }

        private void gêneroToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmGenero tela = new frmGenero();
            tela.MdiParent = this;
            tela.Show();
        }

        private void artistasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmArtistas tela = new frmArtistas();
            tela.MdiParent = this;
            tela.Show();
        }
    }
}
