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
using DAO.VO;

namespace VendasGaragem
{
    public partial class FrmModelo : Form
    {
        public FrmModelo()
        {
            InitializeComponent();
            ControlarTela(estadoTela.inicial);
            LimparCampos();
        }

        #region eventos
        private void btnNovo_Click(object sender, EventArgs e)
        {
            if (ValidarCampos())
            {
                modeloDAO modeloDAO = new modeloDAO();
                tb_modelo objModelo = new tb_modelo();

                objModelo.nome_modelo = txtModelo.Text.Trim();
                objModelo.marca_id = (int)cbMarca.SelectedValue;
                objModelo.empresa_id = Usuario.CodigoLogado;

                try
                {
                    modeloDAO.CadastrarModelo(objModelo);
                    LimparCampos();
                    CarregarGrid();
                    MostrarMensagem(mensagem.sucesso);                }
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
                modeloDAO modeloDAO = new modeloDAO();
                tb_modelo objModelo = new tb_modelo();

                objModelo.id_modelo = Convert.ToInt32(txtCod.Text);
                objModelo.nome_modelo = txtModelo.Text;
                objModelo.marca_id = (int)cbMarca.SelectedValue;

                try
                {
                    modeloDAO.AlterarModelo(objModelo);
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
        private void btnExcluir_Click(object sender, EventArgs e)
        {
            if (ValidarCampos())
            {
                modeloDAO objDao = new modeloDAO();
                tb_modelo objModelo = new tb_modelo();
                objModelo = (tb_modelo)GrdModelos.CurrentRow.DataBoundItem;
                try
                {
                    objDao.Excluir(objModelo.id_modelo);
                    LimparCampos();
                    CarregarGrid();
                    ControlarTela(estadoTela.inicial);
                    MostrarMensagem(mensagem.sucesso);

                }
                catch
                {
                    MostrarMensagem(mensagem.erro);
                }
            }
        }

        private void FrmModelo_Load(object sender, EventArgs e)
        {
            CarregarGrid();
            CarregarMarca();
            LimparCampos();
            ControlarTela(estadoTela.inicial);
        }

       
        private void GrdModelos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (GrdModelos.RowCount > 0)
            {
                ModeloVO vo = (ModeloVO)GrdModelos.CurrentRow.DataBoundItem;
                tb_modelo objLinha = vo.ObjModelo;

                txtCod.Text = objLinha.empresa_id.ToString();
                txtModelo.Text = objLinha.nome_modelo;
                cbMarca.SelectedValue = objLinha.marca_id;

                ControlarTela(estadoTela.edicao);
            }
        }

        private void btnLimpar_Click(object sender, EventArgs e)
        {
            txtCod.Clear();
            txtModelo.Clear();
            cbMarca.SelectedIndex = -1;
            ControlarTela(estadoTela.inicial);
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
                    txtModelo.Focus();
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


        private bool ValidarCampos()
        {
            bool ret = true;
            campos = "";

            if(cbMarca.SelectedIndex == -1)
            {
                ret = false;
                campos = "- Marca\n";
            }

            if (txtModelo.Text.Trim() == "")
            {
                ret = false;
                campos += "- Modelo";
            }

            if (!ret)
            {
                 MostrarMensagem(mensagem.verificarCampos);
            }

            return ret;
        }

        private void CarregarMarca()
        {
            marcaDAO objDao = new marcaDAO();
            List<tb_marca> lstMarcas = objDao.ConsultarMarca(Usuario.CodigoLogado);

            cbMarca.DisplayMember = "nome_marca";
            cbMarca.ValueMember = "id_marca";

            cbMarca.DataSource = lstMarcas;
        }
       
        private void CarregarGrid()
        {
            modeloDAO objDao = new modeloDAO();
            List<ModeloVO> lst = objDao.ConsultarModelos(Usuario.CodigoLogado);

            GrdModelos.DataSource = lst;

            GrdModelos.Columns["objModelo"].Visible = false;
            
        }

        private void LimparCampos()
        {
            txtModelo.Clear();
            txtCod.Clear();
            cbMarca.SelectedIndex = -1;
            ControlarTela(estadoTela.inicial);
        }


        #endregion


    }
}
