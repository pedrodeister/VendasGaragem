using DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;
using static Web.Controllers._base;

namespace Web.Controllers
{
    public class ClienteController : _base
    {

        // GET: Cliente
        public ActionResult Cadastro()
        {
            MontarTitulo(tipoTela.Cadastrar);
            return View();
        }
        public ActionResult Excluir(int id_cliente)
        {
            try
            {
                new ClienteDAO().Excluir(id_cliente);
                ViewBag.Ret = 1;
            }
            catch (Exception)
            {
                ViewBag.Ret = -1;
            }

            CarregarCliente();
            MontarTitulo(tipoTela.Consultar);
            return View("Consultar");
        }
        public ActionResult Consultar()
        {
            CarregarCliente();
            MontarTitulo(tipoTela.Consultar);
            return View();
        }
        public ActionResult Alterar(int id_cliente)
        {
            MontarTitulo(tipoTela.Alterar);
            return View(new ClienteDAO().DetalharCliente(id_cliente));
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
                default:
                    break;
            }
        }
        private void LimparCampos()
        {
            ViewBag.nome_cliente = "";
            ViewBag.end_cliente = "";
            ViewBag.tel_cliente = "";
            ViewBag.email_cliente = "";
        }
        public ActionResult GravarCliente(tb_cliente objCliente, int? btn)
        {
            string retView = "";
            PopularCampos(objCliente);

            if (objCliente.id_cliente == 0)
                MontarTitulo(tipoTela.Cadastrar);
            else if (btn == 2)
                MontarTitulo(tipoTela.Consultar);
            else
                MontarTitulo(tipoTela.Alterar);

            if (btn == 2)
            {
                retView = "Consultar";
                try
                {
                    new ClienteDAO().Excluir(objCliente.id_cliente);
                    ViewBag.Ret = 1;
                }
                catch
                {
                    ViewBag.Ret = -1;
                }
                CarregarCliente();
            }

            else
            {
                ViewBag.Ret = -1;
            }

            if (string.IsNullOrEmpty(objCliente.nome_cliente) || string.IsNullOrEmpty(objCliente.end_cliente)
                || string.IsNullOrEmpty(objCliente.email_cliente) || string.IsNullOrEmpty(objCliente.tel_cliente))
                ViewBag.Ret = 0;

            else
            {
                try
                {
                    if (objCliente.id_cliente == 0)
                    {
                        objCliente.id_vendedor = CodigoVendedorLogado;
                        new ClienteDAO().CadastrarCliente(objCliente);
                        LimparCampos();
                        retView = "Cadastro";
                    }

                    else if (btn == 1)
                    {
                        new ClienteDAO().Alterar(objCliente);
                        retView = "Alterar";
                    }
                    ViewBag.Ret = 1;
                }
                catch
                {
                    ViewBag.Ret = -1;
                }
            }

            return View(retView, objCliente);
        }

        public ActionResult AlterarCliente(tb_cliente objCliente)
        {
            if (string.IsNullOrEmpty(objCliente.nome_cliente) || string.IsNullOrEmpty(objCliente.end_cliente)
                || string.IsNullOrEmpty(objCliente.email_cliente) || string.IsNullOrEmpty(objCliente.tel_cliente))
            {
                ViewBag.Ret = 0;
            }
            else
            {
                try
                {
                    ClienteDAO objDao = new ClienteDAO();
                    objDao.Alterar(objCliente);
                    ViewBag.Ret = 1;
                    LimparCampos();

                }
                catch (Exception ex)
                {
                    ViewBag.Ret = -1;
                }
            }

            CarregarCliente();
            MontarTitulo(tipoTela.Alterar);
            return View("Alterar");
        }

        public void PopularCampos(tb_cliente objCliente)
        {
            ViewBag.nome_cliente = objCliente.nome_cliente;
            ViewBag.end_cliente = objCliente.end_cliente;
            ViewBag.tel_cliente = objCliente.tel_cliente;
            ViewBag.email_cliente = objCliente.email_cliente;

            if (objCliente.id_cliente != 0)
            {
                ViewBag.id_cliente = objCliente.id_cliente;
            }

        }
        private void CarregarCliente()
        {
            ViewBag.Clientes = new ClienteDAO().ListarClientes(CodigoVendedorLogado);
            MontarTitulo(tipoTela.Consultar);
        }

    }
}