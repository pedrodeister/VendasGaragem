using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAO.VO;

namespace DAO
{
    public class modeloDAO
    {
        public void CadastrarModelo(tb_modelo objModelo)
        {
            banco objbanco = new banco();
            objbanco.tb_modelo.Add(objModelo);
            objbanco.SaveChanges();
        }

        public List<tb_marca> CbMarca(int empresaID)
        {
            using (banco objBanco = new banco())
            {
                return objBanco.tb_marca.Where(m => m.empresa_id == empresaID).ToList();
            }   
        }

        public List<tb_modelo> ConsultarModelosCombo(int empresaID)
        {
            return new banco().tb_modelo.Include("tb_veiculo").Where(m => m.empresa_id == empresaID && m.tb_veiculo.FirstOrDefault().situacao == 1).ToList();
        }

        public void AlterarModelo(tb_modelo objModelo)
        {
            banco objBanco = new banco();
            tb_modelo objAlterado = objBanco.tb_modelo.Where(m => m.id_modelo == objModelo.id_modelo).FirstOrDefault();

            objAlterado.nome_modelo = objModelo.nome_modelo;
            objAlterado.marca_id = objModelo.marca_id;

            objBanco.SaveChanges();
        }

        public List<ModeloVO> ConsultarModelos(int empresaID)
        {
            banco objBanco = new banco();
            List<ModeloVO> lstRetorno = new List<ModeloVO>();
            List<tb_modelo> lstModelo = objBanco.tb_modelo.Include("tb_marca")
                                        .Where(m => m.empresa_id == empresaID).ToList();

            for (int i = 0; i < lstModelo.Count; i++)
            {
                ModeloVO objVoDaVez = new ModeloVO();

                objVoDaVez.Modelo = lstModelo[i].nome_modelo;
                objVoDaVez.Marca = lstModelo[i].tb_marca.nome_marca;
                objVoDaVez.ObjModelo = lstModelo[i];

                //add na lista
                lstRetorno.Add(objVoDaVez);
            }

                return lstRetorno;
        }

       
        public void Excluir(int id)
        {
            banco objBanco = new banco();
            tb_modelo objExcluir = objBanco.tb_modelo.Where(m => m.id_modelo == id).FirstOrDefault();
            objBanco.tb_modelo.Remove(objExcluir);
            objBanco.SaveChanges();
        }

        public List<tb_modelo> FiltrarModelo(int marcaID)
        {
            banco objbanco = new banco();
            List<tb_modelo> lstModelos = objbanco.tb_modelo.Where(m => m.marca_id == marcaID).ToList();
            return lstModelos;
        }

        public List<tb_modelo> CarregarModelos(int marcaID)
        {
            banco objBanco = new banco();
            List<tb_modelo> lstModelos = objBanco.tb_modelo.Where(m => m.marca_id == marcaID).ToList();
            return lstModelos;
        }
    }
}
