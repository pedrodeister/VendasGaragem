using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DAO;

namespace VendasGaragem
{
    public partial class FrmLogin : Form
    {
        public FrmLogin()
        {
            InitializeComponent();
        }

        private void btnAcessar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtCnpj.Text.Trim()) || string.IsNullOrEmpty(txtSenha.Text.Trim()))
            {
                MessageBox.Show("Preencher os campos", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                int ret = new UsuarioDAO().ValidarLogin(txtCnpj.Text.Trim(), txtSenha.Text.Trim());

                if(ret == -1)
                {
                    MessageBox.Show("Login inválido", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    Usuario.CodigoLogado = ret;
                    this.DialogResult = DialogResult.OK;
                }
            }
        }
    }
}
