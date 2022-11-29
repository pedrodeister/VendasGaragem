using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DAO;
using System.Web.UI.WebControls;
using DAO.VO;

namespace Web.Controllers
{
    public class VendaController : _base
    {
        // GET: Venda

        public ActionResult MinhasVendas()
        {
            MontarTitulo(tipoTela.MinhasVendas);
            ListarVendas();
            return View();
        }

        public void ListarVendas()
        {
            ViewBag.Vendas = new VendaDAO().ListarVendas(CodigoVendedorLogado, QuantidadeUltimasVendas);
        }
        public ActionResult FiltrarVendas(DateTime dataInicial, DateTime dataFinal)
        {
            ViewBag.Vendas = new VendaDAO().ConsultarVendas(CodigoVendedorLogado, dataInicial, dataFinal);
            return View("MinhasVendas");
        }

        public ActionResult FiltrarVeiculo(int? modeloID)
        {
            MontarTitulo(tipoTela.SelecionarVeiculo);
            SelecionarModelos();
            MontarTitulo(tipoTela.SelecionarVeiculo);
            if (modeloID > 0)
            {
                ViewBag.modeloID = modeloID;
                MontarTitulo(tipoTela.SelecionarVeiculo);
                MontarVbFIltroVeiculo((int)modeloID);
            }
            return View();
        }

        private void MontarVbFIltroVeiculo(int modeloID)
        {
            ViewBag.Veiculos = new VeiculoDAO().ListarVeiculos((int)modeloID);
        }

        public ActionResult FinalizarVenda(int veiculoID)
        {
            ListarClientes(CodigoVendedorLogado);
            MontarTitulo(tipoTela.FinalizarVenda);
            return View(new VeiculoDAO().DetalharVeiculo(veiculoID));
        }

        public ActionResult GravarVenda(int veiculo_id, DateTime data, decimal valor, short forma_pagamento, int clienteID, string descricao)
        {
            MontarTitulo(tipoTela.FinalizarVenda);
            tb_venda objVenda = new tb_venda();
            objVenda.data = data;
            objVenda.veiculo_id = veiculo_id;
            objVenda.valor = valor;
            objVenda.forma_pagamento = forma_pagamento;
            objVenda.id_cliente = clienteID;
            objVenda.descricao = descricao;
            objVenda.vendedor_id = CodigoVendedorLogado;

            try
            {
                new VendaDAO().GravarVenda(objVenda);
                SelecionarModelos();
                ViewBag.Ret = 1;
                return View("FiltrarVeiculo");
            }
            catch
            {
                ViewBag.Ret = -1;
                return View("FinalizarVenda" + veiculo_id);
            }
        }

        public void ListarClientes(int vendedorID)
        {
            ViewBag.Clientes = new ClienteDAO().ListarClientes(vendedorID);
        }

        public void SelecionarModelos()
        {
            ViewBag.Modelos = new modeloDAO().ConsultarModelosCombo(CodigoEmpresaVendedorLogado);
        }


        private void MontarTitulo(tipoTela tipo)
        {
            switch (tipo)
            {
                case tipoTela.Cadastrar:
                    ViewBag.Titulo = "Cadastrar Cliente";
                    ViewBag.SubTitulo = "Aqui você cadastro seus clientes";
                    break;
                case tipoTela.Alterar:
                    ViewBag.Titulo = "Alterar Cliente";
                    ViewBag.SubTitulo = "Aqui você altera seu cliente";
                    break;
                case tipoTela.Consultar:
                    ViewBag.Titulo = "Consultar Cliente";
                    ViewBag.SubTitulo = "Aqui você consulta seus clientes";
                    break;
                case tipoTela.SelecionarVeiculo:
                    ViewBag.Titulo = "Selecionar Veicuo";
                    ViewBag.SubTitulo = "Aqui você consulta selecionar seu veiculo";
                    break;
                case tipoTela.FinalizarVenda:
                    ViewBag.Titulo = "Finalizar venda";
                    ViewBag.SubTitulo = "Aqui você finaliza sua venda";
                    break;
                case tipoTela.MinhasVendas:
                    ViewBag.Titulo = "Minhas Vendas";
                    ViewBag.SubTitulo = "Aqui você verifica suas vendas";
                    break;

                default:
                    break;
            }
        }


    }
}