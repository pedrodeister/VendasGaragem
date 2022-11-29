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
    public partial class FrmMarcas : Form
    {

        public FrmMarcas()
        {
            InitializeComponent();
        }


        #region eventos

        private void FrmMarcas_Load(object sender, EventArgs e)
        {
            ControlarTela(estadoTela.inicial);
            CarregarGrid();
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            if (ValidarCampos())
            {
                tb_marca objMarca = new tb_marca();
                marcaDAO objDao = new marcaDAO();
                objMarca = (tb_marca)GrdMarcasCadastradas.CurrentRow.DataBoundItem;
                try
                {
                    objDao.ExcluirMarca(objMarca);
                    CarregarGrid();
                    ControlarTela(estadoTela.inicial);
                    LimparCampos();
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
                marcaDAO objDao = new marcaDAO();
                tb_marca objMarca = new tb_marca();
                objMarca.nome_marca = txtMarca.Text.Trim();
                objMarca.id_marca = Convert.ToInt32(txtCod.Text);

                try
                {
                    MostrarMensagem(mensagem.confirmar);
                    objDao.AlterarMarca(objMarca);
                    CarregarGrid();
                    ControlarTela(estadoTela.inicial);
                    LimparCampos();
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
            CarregarGrid();
        }

        private void btnNovo_Click(object sender, EventArgs e)
        {
            if (ValidarCampos())
            {
                marcaDAO objDAO = new marcaDAO();
                tb_marca objMarca = new tb_marca();

                objMarca.nome_marca = txtMarca.Text;
                objMarca.empresa_id = Usuario.CodigoLogado;

                try
                {
                    objDAO.CadastrarMarca(objMarca);
                    LimparCampos();
                    CarregarGrid();
                    MostrarMensagem(mensagem.sucesso);
                }
                catch
                {
                    MostrarMensagem(mensagem.erro);
                }
            }
        }

        private void btnPesquisar_Click(object sender, EventArgs e)
        {
            marcaDAO objDao = new marcaDAO();
            List<tb_marca> lstPesquisa = objDao.PesquisarMarca(txtMarca.Text.Trim(), Usuario.CodigoLogado);

            if (lstPesquisa.Count == 0)
            {
                MostrarMensagem(mensagem.naoEncontrado);
            }
            else
            {
                GrdMarcasCadastradas.DataSource = lstPesquisa;

                GrdMarcasCadastradas.Columns["id_cor"].Visible = false;
                GrdMarcasCadastradas.Columns["empresa_id"].Visible = false;
                GrdMarcasCadastradas.Columns["tb_empresa"].Visible = false;
                GrdMarcasCadastradas.Columns["tb_modelo"].Visible = false;
                GrdMarcasCadastradas.Columns["nome_marca"].HeaderText = "Marca";
            }
        }

        private void GrdMarcasCadastradas_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (GrdMarcasCadastradas.RowCount > 0)
            {
                tb_marca objMarca = (tb_marca)GrdMarcasCadastradas.CurrentRow.DataBoundItem;
                txtMarca.Text = objMarca.nome_marca;
                txtCod.Text = Convert.ToString(objMarca.id_marca);
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
        }

        private string campos = "";

        private void MostrarMensagem(mensagem mensagem)
        {
            switch (mensagem)
            {
                case mensagem.sucesso:
                    MessageBox.Show("Ação realizada com sucesso", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
            }
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

                btnAlterar.BackColor = SystemColors.Window;
                btnExcluir.BackColor = SystemColors.Window;
                btnNovo.BackColor = Color.Gray;
                break;
            }

        }

        private void LimparCampos()
        {
            txtMarca.Clear();
            txtCod.Clear();
            ControlarTela(estadoTela.inicial);
        }

        private bool ValidarCampos()
        {
            bool ret;
            string campos = "";
            ret = true;
            if (txtMarca.Text.Trim() == "")
            {
                ret = false;
                campos = "\n -Marca";
                ControlarTela(estadoTela.inicial);
            }

            if (!ret)
            {
                    MessageBox.Show("Preencher os campos: " + campos, "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            
            return ret;
        }

        private void CarregarGrid()
        {
            marcaDAO objDao = new marcaDAO();
            List<tb_marca> lstMarca = objDao.ConsultarMarca(Usuario.CodigoLogado);

            GrdMarcasCadastradas.DataSource = lstMarca;

            GrdMarcasCadastradas.Columns["id_marca"].Visible = false;
            GrdMarcasCadastradas.Columns["empresa_id"].Visible = false;
            GrdMarcasCadastradas.Columns["tb_empresa"].Visible = false;
            GrdMarcasCadastradas.Columns["tb_modelo"].Visible = false;
            GrdMarcasCadastradas.Columns["nome_marca"].HeaderText = "Marca";
        }

        #endregion

    }
}
