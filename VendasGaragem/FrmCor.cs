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
    public partial class FrmCor : Form
    {
        public FrmCor()
        {
            InitializeComponent();
            CarregarCampos();
            ControlarTela(estadoTela.inicial);
        }


        #region eventos
        private void btnNovo_Click(object sender, EventArgs e)
        {
            if (ValidarCampos())
            {
                corDAO objDao = new corDAO();
                tb_cor objCor = new tb_cor();
                objCor.nome_cor = txtNome.Text;
                objCor.empresa_id = Usuario.CodigoLogado;

                try
                {
                    objDao.CadastrarCor(objCor);
                    LimparCampos();
                    CarregarCampos();
                    MostrarMensagem(mensagem.sucesso);
                    ControlarTela(estadoTela.inicial);
                }
                catch
                {
                    MostrarMensagem(mensagem.erro);
                }
            }
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            if (ValidarCampos())
            {
                corDAO objDao = new corDAO();
                tb_cor objCor = new tb_cor();
                objCor = (tb_cor)grdCor.CurrentRow.DataBoundItem;
                try
                {
                    MostrarMensagem(mensagem.confirmar);
                    objDao.ExcluirCor(objCor);
                    LimparCampos();
                    CarregarCampos();
                    ControlarTela(estadoTela.inicial);
                    MostrarMensagem(mensagem.sucesso);

                }
                catch
                {
                    MostrarMensagem(mensagem.erro);
                }
            }

        }

        private void btnAlterar_Click(object sender, EventArgs e)
        {
            if (ValidarCampos())
            {
                corDAO objDao = new corDAO();
                tb_cor objCor = new tb_cor();
                objCor.nome_cor = txtNome.Text;
                objCor.id_cor = Convert.ToInt32(txtCod.Text.Trim());

                try
                {
                    MostrarMensagem(mensagem.confirmar);
                    objDao.AlterarCor(objCor);
                    LimparCampos();
                    CarregarCampos();
                    ControlarTela(estadoTela.inicial);
                    MostrarMensagem(mensagem.sucesso);
                }
                catch
                {
                    MostrarMensagem(mensagem.erro);
                }
            }
        }

        private void btnLimpar_Click(object sender, EventArgs e)
        {
            LimparCampos();
            ControlarTela(estadoTela.inicial);
            CarregarCampos();
        }

        private void btnPesquisar_Click(object sender, EventArgs e)
        {
            corDAO objDao = new corDAO();
            string cor = txtNome.Text.Trim();

            List<tb_cor> lstRet = objDao.Pesquisar(cor, Usuario.CodigoLogado);

            if (lstRet.Count == 0)
            {
                MostrarMensagem(mensagem.naoEncontrado);
            }
            else
            {
                grdCor.DataSource = lstRet;

                grdCor.Columns["id_cor"].Visible = false;
                grdCor.Columns["empresa_id"].Visible = false;
                grdCor.Columns["tb_empresa"].Visible = false;
                grdCor.Columns["tb_veiculo"].Visible = false;
                grdCor.Columns["nome_cor"].HeaderText = "Nome da cor";
            }
        }

        private void grdCor_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (grdCor.RowCount > 0)
            {
                tb_cor objCor = new tb_cor();
                objCor = (tb_cor)grdCor.CurrentRow.DataBoundItem;
                txtCod.Text = objCor.id_cor.ToString();
                txtNome.Text = objCor.nome_cor;
                ControlarTela(estadoTela.edicao);
            }
        }

        #endregion

        #region funcoes

        private enum estadoTela
        {
            inicial,
            edicao,
        }

        private enum mensagem
        {
            sucesso,
            erro,
            confirmar,
            naoEncontrado,
            verificarCampos,
        }

        private string campos = "";
        private bool ValidarCampos()
        {
            bool ret = true;
            
            if (txtNome.Text.Trim() == "")
            {
                ret = false;
                campos = "\n- Nome";
            }

            if (!ret)
            {
                MostrarMensagem(mensagem.verificarCampos);
                campos = "";
            }
            return ret;
        }

        private void ControlarTela(estadoTela estado)
        {
            switch (estado) 
            {
                case estadoTela.inicial:
                    btnAlterar.Enabled = false;
                    btnExcluir.Enabled = false;
                    btnNovo.Enabled = true;

                    btnAlterar.BackColor = Color.Gray;
                    btnExcluir.BackColor = Color.Gray;
                    btnNovo.BackColor = SystemColors.Window;
                    break;
                case estadoTela.edicao:
                    btnAlterar.Enabled = true;
                    btnExcluir.Enabled = true;
                    btnNovo.Enabled = false;

                    btnAlterar.BackColor = SystemColors.Window;
                    btnExcluir.BackColor = SystemColors.Window;
                    btnNovo.BackColor = Color.Gray;
                    break;
            }
        }

        private void MostrarMensagem(mensagem mensagem)
        {
            switch (mensagem)
            {
                case mensagem.sucesso:
                    MessageBox.Show("Ação realilzada com sucesso", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    break;
                case mensagem.erro:
                    MessageBox.Show("Ocorreu um erro na operação", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    break;
                case mensagem.confirmar:
                    MessageBox.Show("Você deseja executar essa operação?", "Atenção", MessageBoxButtons.YesNo, MessageBoxIcon.Question); 
                    break;
                case mensagem.naoEncontrado:
                    MessageBox.Show("Nenhum dado encontrado", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    break;
                case mensagem.verificarCampos:
                    MessageBox.Show("Preencher os campos: " + campos, "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    break;
            }
        }

        private void LimparCampos()
            {
            txtNome.Clear();
            txtCod.Clear();
            txtNome.Focus();
            }

        private void CarregarCampos()
        {
            corDAO objDao = new corDAO();
            List<tb_cor> lstRet = objDao.CarregarCor(Usuario.CodigoLogado);

            grdCor.DataSource = lstRet;

            grdCor.Columns["id_cor"].Visible = false;
            grdCor.Columns["empresa_id"].Visible = false;
            grdCor.Columns["tb_empresa"].Visible = false;
            grdCor.Columns["tb_veiculo"].Visible = false;
            grdCor.Columns["nome_cor"].HeaderText = "Nome da cor";
        }

        #endregion

    }
}
