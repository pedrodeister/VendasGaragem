using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO
{
    public  class marcaDAO
    {
        public void CadastrarMarca(tb_marca objMarca)
        {
            banco objBanco = new banco();
            objBanco.tb_marca.Add(objMarca);
            objBanco.SaveChanges();
        }

        public List<tb_marca> ConsultarMarca(int empresaID)
        {
            banco banco = new banco();
            List<tb_marca> objList = new List<tb_marca>();
            objList = banco.tb_marca.Where(c => c.empresa_id == empresaID).ToList();

            return objList;
        }

        public void AlterarMarca(tb_marca objMarca)
        {
            banco objBanco = new banco();
            tb_marca marcaAlterada = objBanco.tb_marca.Where(c => c.id_marca == objMarca.id_marca).FirstOrDefault();
            marcaAlterada.nome_marca = objMarca.nome_marca;
            objBanco.SaveChanges();
        }

        public void ExcluirMarca(tb_marca objMarca)
        {
            banco objBanco = new banco();
            tb_marca marcaExcluir = new tb_marca();
            marcaExcluir = (tb_marca)objBanco.tb_marca.Where(c => c.id_marca == objMarca.id_marca).FirstOrDefault();
            objBanco.tb_marca.Remove(marcaExcluir);
            objBanco.SaveChanges();
        }

        public List<tb_marca> PesquisarMarca(string marca, int empresaID)
        {
            banco objBanco = new banco();
            List<tb_marca> objList = objBanco.tb_marca.Where(c => c.nome_marca == marca && c.empresa_id == empresaID).ToList();

            return objList;
        }

        public List<tb_marca> FiltrarMarca(int empresaID)
        {
            banco objBanco = new banco();
            List<tb_marca> objList = objBanco.tb_marca.Where(c => c.empresa_id == empresaID).ToList();

            return objList;
        }
    }
}
