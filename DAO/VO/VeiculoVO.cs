using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO.VO
{
    public class VeiculoVO
    {
        public string marca { get; set; }
        public string modelo { get; set; }
        public decimal valor_compra { get; set; }
        public decimal valor_venda { get; set; }
        public string cor { get; set; }
        public string direcao { get; set; }
        public bool airbag { get; set; }
        public bool ar { get; set; }
        public string situacao { get; set; }
        public string ano_fab { get; set; }
        public string ano_modelo { get; set; }
        public string km { get; set; }
        public int n_portas { get; set; }
        public string placa { get; set; }
        public string obs { get; set; }
        public int veiculoid { get; set; }

        public tb_veiculo ObjVeiculo { get; set; }



    }
}
