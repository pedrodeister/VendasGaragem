using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAO.VO;
using System.Transactions;

namespace DAO
{
    public class VendaDAO
    {
        public List<VendaVO> ConsultarVendas(int vendedorID, DateTime dataInicial, DateTime dataFinal)
        {
            banco objBanco = new banco();
            List<VendaVO> lstRetorno = new List<VendaVO>();
            List<tb_venda> lstVenda = new List<tb_venda>();


            lstVenda = objBanco.tb_venda.Include("tb_veiculo")
                                        .Include("tb_veiculo.tb_modelo")
                                        .Include("tb_veiculo.tb_modelo.tb_marca")
                                        .Include("tb_vendedores").Include("tb_cliente")
                                        .Where(d => d.vendedor_id == vendedorID && d.data >= dataInicial.Date && d.data <= dataFinal.Date && d.tb_veiculo.situacao == 2).ToList();


            for (int i = 0; i < lstVenda.Count; i++)
            {
                VendaVO objVoDaVez = new VendaVO();

                objVoDaVez.Data = lstVenda[i].data;
                objVoDaVez.Vendedor = lstVenda[i].tb_vendedores.nome;
                objVoDaVez.Marca = lstVenda[i].tb_veiculo.tb_modelo.tb_marca.nome_marca;
                objVoDaVez.Modelo = lstVenda[i].tb_veiculo.tb_modelo.nome_modelo;
                objVoDaVez.Valor = lstVenda[i].valor;
                objVoDaVez.FormaPagamento = MostrarPagamento(lstVenda[i].forma_pagamento);
                objVoDaVez.NomeCliente = lstVenda[i].tb_cliente.nome_cliente;
                objVoDaVez.Descricao = lstVenda[i].descricao;
                objVoDaVez.objVenda = lstVenda[i];

                lstRetorno.Add(objVoDaVez);
            }


            return lstRetorno;
        }

        public List<VendaVO> ListarVendas(int vendedorID, int qtd)
        {
            banco objBanco = new banco();
            List<VendaVO> lstRetorno = new List<VendaVO>();
            List<tb_venda> lstVenda = new List<tb_venda>();

            lstVenda = objBanco.tb_venda.Include("tb_veiculo")
                                        .Include("tb_veiculo.tb_modelo")
                                        .Include("tb_veiculo.tb_modelo.tb_marca")
                                        .Include("tb_cliente")
                                        .Where(d => d.vendedor_id == vendedorID && d.tb_veiculo.situacao == 2).OrderByDescending(d => d.id_venda).Take(qtd).ToList();

            for (int i = 0; i < lstVenda.Count; i++)
            {
                VendaVO objVoDaVez = new VendaVO();

                objVoDaVez.Data = lstVenda[i].data;
                objVoDaVez.Marca = lstVenda[i].tb_veiculo.tb_modelo.tb_marca.nome_marca;
                objVoDaVez.Modelo = lstVenda[i].tb_veiculo.tb_modelo.nome_modelo;
                objVoDaVez.Valor = lstVenda[i].valor;
                objVoDaVez.FormaPagamento = MostrarPagamento(lstVenda[i].forma_pagamento);
                objVoDaVez.NomeCliente = lstVenda[i].tb_cliente.nome_cliente;
                objVoDaVez.Descricao = lstVenda[i].descricao;
                objVoDaVez.objVenda = lstVenda[i];

                lstRetorno.Add(objVoDaVez);
            }


            return lstRetorno;


        }

        public void GravarVenda(tb_venda objVenda)
        {
            banco objbanco = new banco();

            using (TransactionScope tran = new TransactionScope())
            {
                objbanco.tb_venda.Add(objVenda);
                objbanco.SaveChanges();

                tb_veiculo objVeiculo = objbanco.tb_veiculo.Where(v => v.id_veiculo == objVenda.veiculo_id).FirstOrDefault();
                objVeiculo.situacao = 2;
                objbanco.SaveChanges();

                tran.Complete();
            }
        }

        private string MostrarPagamento(int indexSituacao)
        {
            string situacao = "";
            switch (indexSituacao)
            {
                case 0:
                    situacao = "Pix";
                    break;
                case 1:
                    situacao = "Cartão";
                    break;
                case 2:
                    situacao = "Financiamento";
                    break;
                case 3:
                    situacao = "Consorcio";
                    break;
            }
            return situacao;
        }

    }
}
