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
    public partial class frmConsultarVeiculo : Form
    {
        FrmVeiculo f;
        public frmConsultarVeiculo(FrmVeiculo frmveiculo)
        {
            InitializeComponent();
            f = frmveiculo;
        }

        private void btnPesquisar_Click(object sender, EventArgs e)
        {
            PesquisarVeiculos();
        }

        private void PesquisarVeiculos()
        {
            if(cbSituacao.SelectedIndex != -1)
            {
                VeiculoDAO objDao = new VeiculoDAO();
                List<VeiculoVO> lstVeiculo = objDao.ConsultarVeiculosFiltro(Usuario.CodigoLogado, txtPlaca.Text.Trim(), cbSituacao.SelectedIndex);
                grdVeiculos.DataSource = lstVeiculo;

                grdVeiculos.Columns["objveiculo"].Visible = false;
                grdVeiculos.Columns["direcao"].HeaderText = "Direção";
                grdVeiculos.Columns["airbag"].HeaderText = "AirBag";
                grdVeiculos.Columns["ar"].HeaderText = "Ar";
                grdVeiculos.Columns["ano_fab"].HeaderText = "Ano fabricação";
                grdVeiculos.Columns["ano_modelo"].HeaderText = "Ano modelo";
                grdVeiculos.Columns["km"].HeaderText = "Km";
                grdVeiculos.Columns["n_portas"].HeaderText = "Portas";
                grdVeiculos.Columns["valor_compra"].HeaderText = "Valor compra";
                grdVeiculos.Columns["placa"].HeaderText = "Placa";
                grdVeiculos.Columns["valor_venda"].HeaderText = "Valor venda";
                grdVeiculos.Columns["obs"].HeaderText = "Observação";
                grdVeiculos.Columns["situacao"].HeaderText = "Situação";
                grdVeiculos.Columns["modelo"].HeaderText = "Modelo";
                grdVeiculos.Columns["cor"].HeaderText = "Cor";
                grdVeiculos.Columns["marca"].HeaderText = "Marca";


                if(grdVeiculos.RowCount == 0)
                {
                    MessageBox.Show("Nenhum veículo encontrado", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            else
            {
                MessageBox.Show("Selecionar situação do veículo", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            
        }

      

        private void grdVeiculos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
        if (grdVeiculos.RowCount > 0)
            {
                VeiculoVO objLinhaClicada = (VeiculoVO)grdVeiculos.CurrentRow.DataBoundItem;
                f.PreencherVeiculo(objLinhaClicada);
                this.Close();
            }
        }
    }
}
