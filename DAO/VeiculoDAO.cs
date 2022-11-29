using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAO.VO;

namespace DAO
{
    public class VeiculoDAO
    {
        banco objBanco = new banco();
        public void CadastrarVeiculo(tb_veiculo objVeiculo)
        {
            objBanco.tb_veiculo.Add(objVeiculo);
            objBanco.SaveChanges();
        }

        public void ExcluirVeiculo(tb_veiculo objVeiculo)
        {
            tb_veiculo objVeiculoExcluir = objBanco.tb_veiculo.Where(v => v.id_veiculo == objVeiculo.id_veiculo).FirstOrDefault();
            objBanco.tb_veiculo.Remove(objVeiculoExcluir);
            objBanco.SaveChanges();
        }

        public void AlterarVeiculo(tb_veiculo objVeiculo)
        {
            tb_veiculo objVeiculoAlterar = objBanco.tb_veiculo.Where(v => v.id_veiculo == objVeiculo.id_veiculo).FirstOrDefault();
            objVeiculoAlterar.placa = objVeiculo.placa;
            objVeiculoAlterar.ano_fab = objVeiculo.ano_fab;
            objVeiculoAlterar.ano_modelo = objVeiculo.ano_modelo;
            objVeiculoAlterar.km = objVeiculo.km;
            objVeiculoAlterar.cor_id = objVeiculo.cor_id;
            objVeiculoAlterar.n_portas = objVeiculo.n_portas;
            objVeiculoAlterar.airbag = objVeiculo.airbag;
            objVeiculoAlterar.ar = objVeiculo.ar;
            objVeiculoAlterar.situacao = objVeiculo.situacao;
            objVeiculoAlterar.valor_compra = objVeiculo.valor_compra;
            objVeiculoAlterar.valor_venda = objVeiculo.valor_venda;
            objVeiculoAlterar.direcao = objVeiculo.direcao;
            objVeiculoAlterar.obs = objVeiculo.obs;
            objBanco.SaveChanges();
        }

        public void AlterarVeiculoVendido(int veiculoID, short situacao)
        {
            tb_veiculo objVeiculoAlterar = objBanco.tb_veiculo.Where(v => v.id_veiculo == veiculoID).FirstOrDefault();
            objVeiculoAlterar.situacao = situacao;

            objBanco.SaveChanges();
        }

        public List<tb_modelo> CarregarVeiculos(int empresaID)
        {
            List <tb_modelo> lstVeiculos = objBanco.tb_modelo.Where(v => v.empresa_id == empresaID).ToList();
            return lstVeiculos;
        }

        public VeiculoVO DetalharVeiculo(int veiculoID)
        {
            banco objBanco = new banco();
            VeiculoVO lstRet = new VeiculoVO();
            tb_veiculo objVeiculo = new tb_veiculo();

            objVeiculo = objBanco.tb_veiculo.Include("tb_cor").Include("tb_modelo").Include("tb_modelo.tb_marca").Where(v => v.id_veiculo == veiculoID).FirstOrDefault();


            VeiculoVO vo = new VeiculoVO();
            vo.marca = objVeiculo.tb_modelo.tb_marca.nome_marca;
            vo.modelo = objVeiculo.tb_modelo.nome_modelo;
            vo.valor_compra = objVeiculo.valor_compra;
            vo.valor_venda = objVeiculo.valor_venda;
            vo.cor = objVeiculo.tb_cor.nome_cor;
            vo.direcao = MostrarDirecao(objVeiculo.direcao);
            vo.airbag = objVeiculo.airbag;
            vo.ar = objVeiculo.ar;
            vo.situacao = MostrarSituacao(objVeiculo.situacao);
            vo.ano_fab = objVeiculo.ano_fab;
            vo.ano_modelo = objVeiculo.ano_modelo;
            vo.km = objVeiculo.km;
            vo.n_portas = objVeiculo.n_portas;
            vo.placa = objVeiculo.placa;
            vo.obs = objVeiculo.obs;
            vo.veiculoid = objVeiculo.id_veiculo;
            vo.ObjVeiculo = objVeiculo;

            return vo;
        }

        public List<VeiculoVO> ListarVeiculos(int modeloID)
        {
            banco objBanco = new banco();
            List<VeiculoVO> lstRet = new List<VeiculoVO>();
            List<tb_veiculo> lstVeiculo = new List<tb_veiculo>();

            lstVeiculo = objBanco.tb_veiculo.Include("tb_cor")
                                                                  .Include("tb_modelo")
                                                                  .Include("tb_modelo.tb_marca")
                                                                  .Where(v => v.modelo_id == modeloID && v.situacao == 1).ToList();

            for (int i = 0; i < lstVeiculo.Count; i++)
            {
                VeiculoVO vo = new VeiculoVO();
                vo.marca = lstVeiculo[i].tb_modelo.tb_marca.nome_marca;
                vo.modelo = lstVeiculo[i].tb_modelo.nome_modelo;
                vo.valor_compra = lstVeiculo[i].valor_compra;
                vo.valor_venda = lstVeiculo[i].valor_venda;
                vo.cor = lstVeiculo[i].tb_cor.nome_cor;
                vo.direcao = MostrarDirecao(lstVeiculo[i].direcao);
                vo.airbag = lstVeiculo[i].airbag;
                vo.ar = lstVeiculo[i].ar;
                vo.situacao = MostrarSituacao(lstVeiculo[i].situacao);
                vo.ano_fab = lstVeiculo[i].ano_fab;
                vo.ano_modelo = lstVeiculo[i].ano_modelo;
                vo.km = lstVeiculo[i].km;
                vo.n_portas = lstVeiculo[i].n_portas;
                vo.placa = lstVeiculo[i].placa;
                vo.obs = lstVeiculo[i].obs;
                vo.veiculoid = lstVeiculo[i].id_veiculo;

                vo.ObjVeiculo = lstVeiculo[i];
                lstRet.Add(vo);
            }

            return lstRet;
        }


        public List<VeiculoVO> ConsultarVeiculosFiltro(int empresaID, string filtro, int situacao)
        {
            banco objBanco = new banco();
            List<VeiculoVO> lstRet = new List<VeiculoVO>();
            List<tb_veiculo> lstVeiculo = new List<tb_veiculo>();

            if (filtro == "" && situacao == 3)
            {
                lstVeiculo = objBanco.tb_veiculo.Include("tb_cor")
                                                                 .Include("tb_modelo")
                                                                 .Include("tb_modelo.tb_marca")
                                                                 .Where(v => v.empresa_id == empresaID).ToList();

            }
            else if (filtro == "" && situacao <= 2)
            {
               lstVeiculo = objBanco.tb_veiculo.Include("tb_cor")
                                                                 .Include("tb_modelo")
                                                                 .Include("tb_modelo.tb_marca")
                                                                 .Where(v => v.empresa_id == empresaID && v.situacao == situacao).ToList();

            }
            else if (filtro != "" && situacao == 3)
            {
                lstVeiculo = objBanco.tb_veiculo.Include("tb_cor")
                                                                 .Include("tb_modelo")
                                                                 .Include("tb_modelo.tb_marca")
                                                                 .Where(v => v.empresa_id == empresaID && v.placa.Contains(filtro)).ToList();

            }
            else if (filtro != "" && situacao <= 2)
            {
               lstVeiculo = objBanco.tb_veiculo.Include("tb_cor")
                                                                 .Include("tb_modelo")
                                                                 .Include("tb_modelo.tb_marca")
                                                                 .Where(v => v.empresa_id == empresaID && v.situacao == situacao && v.placa.Contains(filtro)).ToList();


            }
           
            
            for (int i = 0; i < lstVeiculo.Count; i++)
            {
                VeiculoVO vo = new VeiculoVO();
                vo.marca = lstVeiculo[i].tb_modelo.tb_marca.nome_marca;
                vo.modelo = lstVeiculo[i].tb_modelo.nome_modelo;
                vo.valor_compra = lstVeiculo[i].valor_compra;
                vo.valor_venda = lstVeiculo[i].valor_venda;
                vo.cor = lstVeiculo[i].tb_cor.nome_cor;
                vo.direcao = MostrarDirecao(lstVeiculo[i].direcao);
                vo.airbag = lstVeiculo[i].airbag;
                vo.ar = lstVeiculo[i].ar;
                vo.situacao = MostrarSituacao(lstVeiculo[i].situacao);
                vo.ano_fab = lstVeiculo[i].ano_fab;
                vo.ano_modelo = lstVeiculo[i].ano_modelo;
                vo.km = lstVeiculo[i].km;
                vo.n_portas = lstVeiculo[i].n_portas;
                vo.placa = lstVeiculo[i].placa;
                vo.obs = lstVeiculo[i].obs;

                vo.ObjVeiculo = lstVeiculo[i];
                lstRet.Add(vo);
            }
            return lstRet;
        }

        private string MostrarSituacao(int indexSituacao)
        {
            string situacao = "";
            switch (indexSituacao)
            {
                case 0:
                    situacao = "Inativo";
                    break;
                case 1:
                    situacao = "Ativo";
                    break;
                case 2:
                    situacao = "Vendido";
                    break;
                    
            }
            return situacao;
        }

        private string MostrarDirecao(int indexDirecao)
        {
            string direcao = "";
            switch (indexDirecao)
            {
                case 0:
                    direcao = "Manual";
                    break;
                case 1:
                    direcao = "Hidraulica";
                    break;
                case 2:
                    direcao = "Elétrica";
                    break;

            }
            return direcao;
        }

                
        
    }
}
