using DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Web.Controllers
{
    public class VendedorController : _base
    {
        public ActionResult MeusDados()
        {
            MontarTitulo(tipoTela.MeusDados);
            return View(DetalharVendedor());
        }

        public tb_vendedores DetalharVendedor()
        {
            return new vendedoresDAO().DetalharVendedor(CodigoVendedorLogado);
        }

        public ActionResult AlterarMeusDadosVendedos(string nome, string endereco, string telefone, string email, int vendedorID)
        {
            if (CodigoVendedorLogado == 0)
            {
                return RedirectToAction("Login", "Vendedor");
            }

            MontarTitulo(tipoTela.MeusDados);
            tb_vendedores objVendedor = new tb_vendedores();
            objVendedor.id_vendedor = vendedorID;
            objVendedor.nome = nome;
            objVendedor.endereco = endereco;
            objVendedor.telefone = telefone;
            objVendedor.email = email;
            try
            {
                new vendedoresDAO().AlterarMeusDadosVendedos(objVendedor);
                ViewBag.Ret = 1;
            }
            catch
            {
                ViewBag.Ret = -1;
            }

            return View("MeusDados", objVendedor);
        }

        public ActionResult AlterarSenha()
        {
            if (CodigoVendedorLogado == 0)
            {
                return RedirectToAction("Login", "Vendedor");
            }

            MontarTitulo(tipoTela.AlterarSenha);    
            return View();
        }

        public ActionResult VerificarSenhaAtual(string senha)
        {
            MontarTitulo(tipoTela.AlterarSenha);

            if (senha == "")
            {
                ViewBag.Ret = 0;
            }
            else if (!new vendedoresDAO().VerificarSenha(senha, CodigoVendedorLogado))
            {
                ViewBag.Ret = -2;
            }
            else
            {
                ViewBag.SenhaVerificada = 1;
            }

            return View("AlterarSenha");
        }

        public ActionResult Login()
        {
            
            return View();
        }

        public ActionResult ValidarLogin(string email, string senha)
        {
            if(email == "" || senha == "")
            {
                ViewBag.Ret = 0;
            }
            else
            {
                tb_vendedores ret = new vendedoresDAO().VerificarLogin(email, senha);
                if(ret == null)
                {
                    ViewBag.Ret = -5;
                  
                }
                else
                {   
                    CodigoVendedorLogado = ret.id_vendedor;
                    MontarTitulo(tipoTela.MeusDados);
                    return View("MeusDados", ret);
                }

            }

            return View("Login");
        }

        public ActionResult AlterarSenhaAtual(string novasenha, string confirmarsenha)
        {
            MontarTitulo(tipoTela.AlterarSenha);

            if (novasenha == "" || confirmarsenha == "")
            {
                ViewBag.Ret = 0;
                ViewBag.SenhaVerificada = 1;
            }
            else if (novasenha != confirmarsenha)
            {
                ViewBag.Ret = -3;
                ViewBag.SenhaVerificada = 1;
            }
            else if (novasenha.Length < 6)
            {
                ViewBag.Ret = -4;
                ViewBag.SenhaVerificada = 1;
            }
            else
            {
                new vendedoresDAO().AlterarSenha(novasenha, CodigoVendedorLogado);
                ViewBag.Ret = 1;
            }
            return View("AlterarSenha");
        }

        public ActionResult Deslogar()
        {
            Session.RemoveAll();
            return View("Login");
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
                case tipoTela.MeusDados:
                    ViewBag.Titulo = "Meus Dados";
                    ViewBag.SubTitulo = "Aqui você alterar seus dados";
                    break;
                case tipoTela.AlterarSenha:
                    ViewBag.Titulo = "Alterar senha";
                    ViewBag.SubTitulo = "Aqui você alterar sua senha";
                    break;

                default:
                    break;
            }
        }
    }
}