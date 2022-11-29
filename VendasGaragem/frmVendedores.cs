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
    public partial class frmVendedores : Form
        
    {
        public frmVendedores()
        {
            InitializeComponent();
            CarregarFuncionario();
            ControlarTela(estadoTela.inicial);
        }

        #region eventos
        private void frmVendedores_Load(object sender, EventArgs e)
        {
            ControlarTela(estadoTela.inicial);
            CarregarFuncionario();
        }

        private void btnNovo_Click(object sender, EventArgs e) 
        {
            if (ValidarCampos())
            {
                vendedoresDAO objDao = new vendedoresDAO();
                tb_vendedores objVendedor = new tb_vendedores();
                objVendedor.nome = txtNome.Text.Trim();
                objVendedor.email = txtEmail.Text.Trim();
                objVendedor.telefone = txtTelefone.Text.Trim();
                objVendedor.senha = txtSenha.Text.Trim();
                objVendedor.endereco = txtEndereco.Text.Trim();
                objVendedor.empresa_id = Usuario.CodigoLogado;
                objVendedor.status = chkAtivo.Checked;

                try
                {
                    objDao.CadastrarVendedor(objVendedor);
                    MostrarMensagem(Mensagem.sucesso);
                    CarregarFuncionario();
                    LimparCampos();
                    ControlarTela(estadoTela.inicial);
                }
                catch
                {
                    MostrarMensagem(Mensagem.erro);
                    CarregarFuncionario();
                }
            }
        }

       

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Deseja excluir o vendedor?", "Atenção", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    new vendedoresDAO().ExcluirCadastro(Convert.ToInt32(txtCod.Text));
                    MostrarMensagem(Mensagem.sucesso);
                    CarregarFuncionario();
                    LimparCampos();
                    ControlarTela(estadoTela.inicial);
                }
                catch
                {
                    MostrarMensagem(Mensagem.erro);
                }
            }
        }

        private void btnAlterar_Click(object sender, EventArgs e)
        {
            if (ValidarCampos())
            {
                vendedoresDAO objDAO = new vendedoresDAO();
                tb_vendedores objVendedores = new tb_vendedores();

                objVendedores.nome = txtNome.Text;
                objVendedores.email = txtEmail.Text;
                objVendedores.status = chkAtivo.Checked;
                objVendedores.telefone = txtTelefone.Text;
                objVendedores.endereco = txtEndereco.Text;
                objVendedores.senha = txtSenha.Text;
                objVendedores.id_vendedor = Convert.ToInt16(txtCod.Text);

                if (MessageBox.Show("Você deseja realizar essa alteração?", "Atenção", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    try
                    {
                        objDAO.AlterarCadastro(objVendedores);
                        MostrarMensagem(Mensagem.sucesso);
                        CarregarFuncionario();
                        LimparCampos();
                        ControlarTela(estadoTela.inicial);

                    }
                    catch
                    {
                        MostrarMensagem(Mensagem.erro);
                    }
                }
            }
        }

        private void btnLimpar_Click(object sender, EventArgs e)
        {
            LimparCampos();
            ControlarTela(estadoTela.inicial);
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (grdVendedores.RowCount > 0)
            {
                tb_vendedores objVendedores = (tb_vendedores)grdVendedores.CurrentRow.DataBoundItem;

                txtNome.Text = objVendedores.nome.ToString();
                txtEmail.Text = objVendedores.email.ToString();
                txtCod.Text = objVendedores.id_vendedor.ToString();
                txtEndereco.Text = objVendedores.endereco.ToString();
                txtSenha.Text = objVendedores.senha.ToString();
                txtTelefone.Text = objVendedores.telefone.ToString();
                chkAtivo.Checked = Convert.ToBoolean(objVendedores.status);

                ControlarTela(estadoTela.edicao);
            }
        }

        private void txtFiltro_TextChanged(object sender, EventArgs e)
        {
            CarregarFuncionario();
        }
        #endregion

        #region funcoes

        private enum Mensagem
        {
            sucesso,
            erro,
            confirmar,
            verificarCampos,
        }

        private enum estadoTela
        {
            inicial,
            edicao,
        }

        string campos = "";

        private void LimparCampos()
        {
            txtEmail.Clear();
            txtEndereco.Clear();
            txtNome.Clear();
            txtSenha.Clear();
            txtTelefone.Clear();
            txtCod.Clear();
            chkAtivo.Checked = true;
        }
        private void ControlarTela(estadoTela estado)
        {
            switch (estado)
            {
                case estadoTela.inicial:
                    btnExcluir.Enabled = false;
                    btnAlterar.Enabled = false;
                    btnNovo.Enabled = true;

                    btnExcluir.BackColor = Color.Gray;
                    btnAlterar.BackColor = Color.Gray;
                    btnNovo.BackColor = SystemColors.Window;
                    break;
                case estadoTela.edicao:
                    btnExcluir.Enabled = true;
                    btnAlterar.Enabled = true;
                    btnNovo.Enabled = false;

                    btnExcluir.BackColor = SystemColors.Window;
                    btnAlterar.BackColor = SystemColors.Window;
                    btnNovo.BackColor = Color.Gray;

                    break;
                
            }

        }

        private void MostrarMensagem(Mensagem mensagem)
        {
        switch (mensagem)
            {
                case Mensagem.sucesso:
                    MessageBox.Show("Ação realilzada com sucesso", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    break;
                case Mensagem.erro:
                    MessageBox.Show("Ocorreu um erro na operação", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    break;
                case Mensagem.confirmar:
                    MessageBox.Show("Você deseja executar essa operação?", "Atenção", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    break;
                case Mensagem.verificarCampos:
                    MessageBox.Show("Preencher os campos: " + campos, "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    break;
            }
        }

        
        private bool ValidarCampos()
        {
            bool ret = true;
            campos = "";
            if (txtNome.Text.Trim() == "")
            {
                ret = false;
                campos += "\n -Nome";
            }
            if (txtEmail.Text.Trim() == "")
            {
                ret = false;
                campos = "\n -Email";
            }
            if(txtEndereco.Text.Trim() == "")
            {
                ret = false;
                campos += "\n -Endereço";
            }
            if (txtTelefone.Text.Trim() == "")
            {
                ret = false;
                campos += "\n -Telefone";
            }
            if (txtSenha.Text.Trim() == "")
            {
                ret = false;
                campos += "\n -Senha";
            }

            if (!ret)
            {
                MostrarMensagem(Mensagem.verificarCampos);
            }

            return ret;
        }

        private void CarregarFuncionario()
        {
            grdVendedores.DataSource = new vendedoresDAO().ConsultarFuncionario(Usuario.CodigoLogado, txtFiltro.Text.Trim());

            grdVendedores.Columns["id_vendedor"].Visible = false;
            grdVendedores.Columns["empresa_id"].Visible = false;
            grdVendedores.Columns["tb_empresa"].Visible = false;
            grdVendedores.Columns["tb_venda"].Visible = false;
            grdVendedores.Columns["senha"].Visible = false;
            grdVendedores.Columns["status"].Visible = false;

            grdVendedores.Columns["nome"].HeaderText = "Nome";
            grdVendedores.Columns["email"].HeaderText = "E-Mail";
            grdVendedores.Columns["endereco"].HeaderText = "Endereço";
            grdVendedores.Columns["telefone"].HeaderText = "Telefone";
        }
        
        #endregion

        
    }
}
