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
    public partial class FrmVeiculo : Form
    {
        public FrmVeiculo()
        {
            InitializeComponent();
        }
        #region eventos

        private void btnNovo_Click(object sender, EventArgs e)
        {
            if (ValidarCampos())
            {
                tb_veiculo objVeiculo = new tb_veiculo();
                VeiculoDAO objDao = new VeiculoDAO();

                objVeiculo.placa = txtPlaca1.Text.Trim() + txtPlaca2.Text.Trim();
                objVeiculo.direcao = Convert.ToInt16(cbDirecao.SelectedValue);
                objVeiculo.airbag = checkAirBag.Checked;
                objVeiculo.ar = checkAr.Checked;
                objVeiculo.situacao = Convert.ToInt16(cbSituacao.SelectedIndex);
                objVeiculo.ano_fab = txtAnoFab.Text.Trim();
                objVeiculo.ano_modelo = txtAnoModelo.Text.Trim();
                objVeiculo.km = txtKm.Text.Trim();
                objVeiculo.n_portas = Convert.ToInt16(cbNumeroPortas.SelectedValue);
                objVeiculo.valor_compra = Convert.ToDecimal(txtValorCompra.Text.Trim());
                objVeiculo.valor_venda = Convert.ToDecimal(txtValorVenda.Text.Trim());
                objVeiculo.obs = txtObservacao.Text.Trim();
                objVeiculo.empresa_id = Convert.ToInt16(Usuario.CodigoLogado);
                objVeiculo.modelo_id = Convert.ToInt32(cbModelo.SelectedValue);
                objVeiculo.cor_id = Convert.ToInt32(cbCor.SelectedValue);

                try
                {
                    objDao.CadastrarVeiculo(objVeiculo);
                    LimparCampos();
                    MostrarMensagem(mensagem.sucesso);
                }
                catch
                {
                    MostrarMensagem(mensagem.erro);
                }

            }
        }

        private void cbMarca_SelectedIndexChanged(object sender, EventArgs e)
        {
            CarregarModelos(Convert.ToInt32(cbMarca.SelectedValue));
        }

        private void FrmVeiculo_Load(object sender, EventArgs e)
        {
            CarregarMarcas();
            CarregarCor();
            ControlarTela(estadoTela.inicial);
            LimparCampos();
        }
        private void btnLimpar_Click(object sender, EventArgs e)
        {
            LimparCampos();
            ControlarTela(estadoTela.inicial);
        }

        private void btnAlterar_Click(object sender, EventArgs e)
        {
            if (ValidarCampos())
            {
                tb_veiculo objVeiculo = new tb_veiculo();
                VeiculoDAO objDao = new VeiculoDAO();

                objVeiculo.placa = txtPlaca1.Text.Trim() + txtPlaca2.Text.Trim();
                objVeiculo.direcao = Convert.ToInt16(cbDirecao.SelectedValue);
                objVeiculo.airbag = checkAirBag.Checked;
                objVeiculo.ar = checkAr.Checked;
                objVeiculo.situacao = Convert.ToInt16(cbSituacao.SelectedIndex);
                objVeiculo.ano_fab = txtAnoFab.Text.Trim();
                objVeiculo.ano_modelo = txtAnoModelo.Text.Trim();
                objVeiculo.km = txtKm.Text.Trim();
                objVeiculo.n_portas = Convert.ToInt16(cbNumeroPortas.SelectedValue);
                objVeiculo.valor_compra = Convert.ToDecimal(txtValorCompra.Text.Trim());
                objVeiculo.valor_venda = Convert.ToDecimal(txtValorVenda.Text.Trim());
                objVeiculo.obs = txtObservacao.Text.Trim();
                objVeiculo.modelo_id = Convert.ToInt32(cbModelo.SelectedValue);
                objVeiculo.cor_id = Convert.ToInt32(cbCor.SelectedValue);
                objVeiculo.id_veiculo = Convert.ToInt32(txtCod.Text);

                try
                {
                    objDao.AlterarVeiculo(objVeiculo);
                    MostrarMensagem(mensagem.sucesso);
                    LimparCampos();
                }
                catch (Exception)
                {
                    MostrarMensagem(mensagem.erro);
                }



            }
        }

        #endregion

        #region funcoes

        private enum estadoTela
        {
            inicial,
            edicao
        }
        private enum mensagem
        {
            sucesso,
            erro
        }
        private void MostrarMensagem(mensagem msg)
        {
            switch (msg)
            {
                case mensagem.sucesso:
                    MessageBox.Show("Operação realizada com sucesso", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    break;
                case mensagem.erro:
                    MessageBox.Show("Operação não realizada", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    break;
            }

        }
        private void LimparCampos()
        {
            txtPlaca1.Clear();
            txtPlaca2.Clear();
            txtAnoFab.Clear();
            txtAnoModelo.Clear();
            txtKm.Clear();
            txtObservacao.Clear();
            txtValorCompra.Clear();
            txtValorVenda.Clear();
            txtCod.Clear();
            checkAirBag.Checked = false;
            checkAr.Checked = false;
            cbCor.SelectedIndex = -1;
            cbDirecao.SelectedIndex = -1;
            cbMarca.SelectedIndex = -1;
            cbModelo.SelectedIndex = -1;
            cbNumeroPortas.SelectedIndex = -1;
            cbSituacao.SelectedIndex = -1;
        }
        private bool ValidarCampos()
        {
            string campos = "";
            bool ret = true;
            if(txtPlaca1.Text.Trim() == "" || txtPlaca2.Text.Trim() == "")
            {
                campos = "- Placa\n";
                ret = false;
            }
            if(cbMarca.SelectedIndex == -1)
            {
                campos += "- Marca\n";
                ret = false;
            }
            if(cbModelo.SelectedIndex == -1)
            {
                campos += "-Modelo\n";
                ret = false;
            }
            if(txtAnoFab.Text.Trim() == "")
            {
                campos += "- Ano fabricação\n";
                ret = false;
            }
            if(txtAnoModelo.Text.Trim() == "")
            {
                campos += "-Ano modelo\n";
                ret = false;
            }
            if(txtKm.Text.Trim() == "")
            {
                campos += "- Km\n";
                ret = false;
            }
            if(cbCor.SelectedIndex == 1)
            {
                campos += "- Cor\n";
                ret = false;
            }
            if (cbNumeroPortas.SelectedIndex == -1)
            {
                campos += "- Número de portas\n";
                ret = false;
            }
            if(cbDirecao.SelectedIndex == -1)
            {
                campos += "- Direção\n";
                ret = false;
            }
            if(cbSituacao.SelectedIndex == -1)
            {
                campos += "- Situação\n";
                ret = false;
            }
            if(txtValorCompra.Text.Trim() == "")
            {
                campos += "- Valor de compra\n";
                ret = false;
            }
            if(txtValorVenda.Text.Trim() == "")
            {
                campos += "- Valor de venda\n";
                ret = false;
            }
            if (!ret)
            {
                MessageBox.Show("Você deve preencher todos os campos: \n" + campos, "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            return ret;
        }
        private void ControlarTela(estadoTela estado)
        {
            switch (estado)
            {
                case estadoTela.inicial:
                    btnExcluir.Enabled = false;
                    btnAlterar.Enabled = false;
                    btnNovo.Enabled = true;
                    btnPesquisar.Enabled = true;

                    btnExcluir.BackColor = Color.Gray;
                    btnAlterar.BackColor = Color.Gray;
                    btnNovo.BackColor = SystemColors.Window;
                    btnPesquisar.BackColor = SystemColors.Window;
                    break;
                case estadoTela.edicao:
                    btnExcluir.Enabled = true;
                    btnAlterar.Enabled = true;
                    btnNovo.Enabled = false;
                    btnPesquisar.Enabled = false;

                    btnExcluir.BackColor = SystemColors.Window;
                    btnAlterar.BackColor = SystemColors.Window;
                    btnNovo.BackColor = Color.Gray;
                    btnPesquisar.BackColor = Color.Gray;
                    break;
            }
                
            
        }
        private void CarregarModelos(int idMarca)
        {
            cbModelo.ValueMember = "id_modelo";
            cbModelo.DisplayMember = "nome_modelo";

            cbModelo.DataSource = new modeloDAO().FiltrarModelo(idMarca);

        }
        private void CarregarCor()
        {
            cbCor.DisplayMember = "nome_cor";
            cbCor.ValueMember = "id_cor";
            cbCor.DataSource = new corDAO().CarregarCor(Usuario.CodigoLogado);
        }
        private void CarregarMarcas()
        {
            marcaDAO objMarca = new marcaDAO();
            List<tb_marca> lstMarcas = new List<tb_marca>();
            lstMarcas = objMarca.ConsultarMarca(Usuario.CodigoLogado);

            cbMarca.ValueMember = "id_marca";
            cbMarca.DisplayMember = "nome_marca";

            cbMarca.DataSource = lstMarcas;
        }



        #endregion


        private void btnPesquisar_Click(object sender, EventArgs e)
        {
            frmConsultarVeiculo frmConsultarVeiculo = new frmConsultarVeiculo(this);
            frmConsultarVeiculo.Show();
        }

        public void PreencherVeiculo(VeiculoVO objVeiculoLinha)
        {
            tb_veiculo objVeiculo = objVeiculoLinha.ObjVeiculo;
            
            txtCod.Text = Convert.ToString(objVeiculo.id_veiculo);
            txtPlaca1.Text = Convert.ToString(objVeiculo.placa.Substring(0, 3));
            txtPlaca2.Text = Convert.ToString(objVeiculo.placa.Substring(objVeiculo.placa.Length - 4));
            cbDirecao.SelectedIndex = objVeiculo.direcao;
            checkAirBag.Checked = objVeiculo.airbag;
            checkAr.Checked = objVeiculo.ar;
            cbSituacao.SelectedIndex = objVeiculo.situacao;
            txtAnoFab.Text = objVeiculo.ano_fab;
            txtAnoModelo.Text = objVeiculo.ano_modelo;
            txtKm.Text = objVeiculo.km;
            cbNumeroPortas.SelectedIndex = objVeiculo.n_portas;
            txtValorCompra.Text = Convert.ToString(objVeiculo.valor_compra);
            txtValorVenda.Text = Convert.ToString(objVeiculo.valor_venda);
            txtObservacao.Text = objVeiculo.obs;
            cbCor.SelectedValue = objVeiculo.cor_id;
            cbModelo.SelectedValue = objVeiculo.modelo_id;
            cbMarca.SelectedValue = objVeiculo.tb_modelo.marca_id;

            ControlarTela(estadoTela.edicao);
        }

    }
}
