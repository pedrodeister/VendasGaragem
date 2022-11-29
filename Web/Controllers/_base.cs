using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Web.Controllers
{
    public class _base : Controller
    {
        public enum tipoTela
        {
            Cadastrar,
            Alterar,
            Consultar,
            SelecionarVeiculo,
            FinalizarVenda,
            MinhasVendas,
            MeusDados,
            AlterarSenha,
        }

        public int CodigoVendedorLogado
        {
            get
            {
                return Session["cod"] == null ? 0 : (int)Session["cod"];  
            }
            set
            {
                Session.Add("cod", value);
            }
        }

        public int QuantidadeUltimasVendas
        {
            get
            {
                return 5;
            }
        }

        public int CodigoEmpresaVendedorLogado
        {
            get
            {
                return 1;
            }
        }

    }
}