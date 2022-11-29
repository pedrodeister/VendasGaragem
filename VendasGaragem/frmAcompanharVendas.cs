using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Contracts;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DAO;
using DAO.VO;

namespace VendasGaragem
{
    public partial class frmAcompanharVendas : Form
    {
        #region Eventos
        public frmAcompanharVendas()
        {
            InitializeComponent();
        }



        private void frmAcompanharVendas_Load(object sender, EventArgs e)
        {
            ListarVendedor();
            LimparCampos();
        }



        private void btnPesquisar_Click(object sender, EventArgs e)
        {
            VendaDAO objDao = new VendaDAO();
            List<VendaVO> lstVenda = new List<VendaVO>();



            if (ValidarCampos())
            {
                lstVenda = objDao.ConsultarVendas(Convert.ToInt32(cbVendedor.SelectedValue), Convert.ToDateTime(dtInicial.Text), Convert.ToDateTime(dtFinal.Text));
                grdVendas.DataSource = lstVenda;
                
                if (lstVenda.Count == 0)
                {
                    MessageBox.Show("Nenhuma venda encontrada", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }

                grdVendas.Columns["objVenda"].Visible = false;

                grdVendas.Columns["FormaPagamento"].HeaderText = "Forma de pagamento";
                grdVendas.Columns["NomeCliente"].HeaderText = "Nome do Cliente";
                grdVendas.Columns["Descricao"].HeaderText = "Descrição";

                grdVendas.Columns["Data"].DisplayIndex = 1;
                grdVendas.Columns["Vendedor"].DisplayIndex = 2;
                grdVendas.Columns["Marca"].DisplayIndex = 3;
                grdVendas.Columns["Modelo"].DisplayIndex = 4;
                grdVendas.Columns["Valor"].DisplayIndex = 5;
                grdVendas.Columns["FormaPagamento"].DisplayIndex = 6;
                grdVendas.Columns["NomeCliente"].DisplayIndex = 7;
                grdVendas.Columns["Descricao"].DisplayIndex = 8;
            }

            

        }

        

        #endregion

        #region Funções

        private void ListarVendedor()
        {
            vendedoresDAO objDao = new vendedoresDAO();
            string filtro = "";
            List<tb_vendedores> lstVendedores = objDao.ConsultarFuncionario(Usuario.CodigoLogado, filtro);
            cbVendedor.DataSource = lstVendedores;

            cbVendedor.DisplayMember = "nome";
            cbVendedor.ValueMember = "id_vendedor";
        }
        private void LimparCampos()
        {
            cbVendedor.SelectedIndex = -1;
            dtFinal.Value = DateTime.Today;
            dtInicial.Value = DateTime.Today.AddDays(-dtFinal.Value.Day +1 );
        }
        private bool ValidarCampos()
        {
            string campos = "";
            bool ret = true;

            if (dtInicial.Value > dtFinal.Value)
            {
                campos += "- A data inicial não pode ser maior que a data final\n";
                ret = false;
            }

            if (cbVendedor.SelectedIndex == -1)
            {
                campos += "- Selecionar um vendedor\n";
                ret = false;
            }
            if (!ret)
            {
                MessageBox.Show("A pesquisa não pode ser concluída:\n\n" + campos, "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            return ret;

        }

        #endregion

    }
}
