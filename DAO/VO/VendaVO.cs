using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO.VO
{
    public class VendaVO
    {
        [Display(Name = "Data")]
        [DataType(DataType.Date)]
        [DisplayFormat (DataFormatString = "{0:d}",ApplyFormatInEditMode = false)]
        public DateTime Data { get; set; }


        [DisplayFormat(DataFormatString = "{0:D}", ApplyFormatInEditMode = false)]
        public decimal Valor { get; set; }

        public string Descricao { get; set; }
        public string FormaPagamento { get; set; }
        public string Marca { get; set; }
        public string Modelo { get; set; }
        public string Vendedor { get; set; }
        public string NomeCliente { get; set; }
        public tb_venda objVenda { get; set; }

    }
}
