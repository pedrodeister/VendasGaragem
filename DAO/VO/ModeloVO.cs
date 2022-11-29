using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO.VO
{
    public class ModeloVO
    {
        //Mostrar na grid
        public string Marca { get; set; }
        public string Modelo { get; set; }

        //propriedade para edição
        public tb_modelo ObjModelo { get; set; }
    }
}
