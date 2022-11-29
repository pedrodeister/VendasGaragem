using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VendasGaragem
{
    public partial class frmPrincipal : Form
    {
        public frmPrincipal()
        {
            InitializeComponent();
        }

        private void corToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new FrmCor().ShowDialog();
        }

        private void marcaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new FrmMarcas().ShowDialog();
        }

        private void modeloToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new FrmModelo().ShowDialog();
        }

        private void gerenciarVendedoresToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new frmVendedores().ShowDialog();
        }

        private void cadastrarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new FrmVeiculo().ShowDialog();
        }

        private void vendasPeríodoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new frmAcompanharVendas().ShowDialog();
        }

        private void vendasVendedorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new frmAcompanharVendasVendedor().ShowDialog();
        }

        private void sairToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
