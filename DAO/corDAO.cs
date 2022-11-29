using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO
{
    public class corDAO
    {

        public void CadastrarCor(tb_cor objCor)
        {
            banco objbanco = new banco();
            objbanco.tb_cor.Add(objCor);
            objbanco.SaveChanges();
        }

        public List<tb_cor> CarregarCor(int empresaID)
        {
            banco objbanco = new banco();
            List<tb_cor> ret = objbanco.tb_cor.Where(c => c.empresa_id == empresaID).ToList();
            return ret;
        }

        public void AlterarCor(tb_cor objCor)
        {
            banco objBanco = new banco();
            tb_cor objCorAlterada = objBanco.tb_cor.Where(c => c.id_cor == objCor.id_cor).FirstOrDefault();
            objCorAlterada.nome_cor = objCor.nome_cor;
            objBanco.SaveChanges();
        }

        public void ExcluirCor(tb_cor objCor)
        {
            banco objBanco = new banco();
            tb_cor corExcluir = objBanco.tb_cor.Where(c => c.id_cor == objCor.id_cor).FirstOrDefault();
            objBanco.tb_cor.Remove(corExcluir);
            objBanco.SaveChanges();
        }

        public List<tb_cor> Pesquisar(string objCor, int empresaID)
        {
            banco objBanco = new banco();
            List<tb_cor> lstCor = objBanco.tb_cor.Where(c => c.nome_cor == objCor && c.empresa_id == empresaID).ToList();
            return lstCor;
        }
    }
}
