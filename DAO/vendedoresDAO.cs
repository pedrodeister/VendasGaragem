using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using DAO.VO;

namespace DAO
{
    public class vendedoresDAO
    {
        public List<tb_vendedores> ConsultarFuncionario(int empresaID, string filtro)
        {
            banco objBanco = new banco();
            List<tb_vendedores> lstVendedores = new List<tb_vendedores>();

            if (string.IsNullOrEmpty(filtro))
            {
                lstVendedores = objBanco.tb_vendedores.Where(c => c.empresa_id == empresaID).ToList();
            }
            else
            {
                lstVendedores = objBanco.tb_vendedores.Where(c => c.empresa_id == empresaID && c.nome.Contains(filtro)).ToList();
                
            }
            return lstVendedores;
        }

        public void CadastrarVendedor(tb_vendedores objVendedor)
        {
            banco objBanco = new banco();
            objBanco.tb_vendedores.Add(objVendedor);
            objBanco.SaveChanges();
        }

        public void ExcluirCadastro(int id)
        {
            banco objBanco = new banco();
            tb_vendedores objVendedorExcluir = objBanco.tb_vendedores.Where(c => c.id_vendedor == id).FirstOrDefault();

            objBanco.tb_vendedores.Remove(objVendedorExcluir);
            objBanco.SaveChanges();
        }

        public tb_vendedores DetalharVendedor(int vendedorID)
        {
            banco objBanco = new banco();
            tb_vendedores objVendedor = objBanco.tb_vendedores.Where(c => c.id_vendedor == vendedorID).FirstOrDefault();
            objVendedor.email = objVendedor.email;
            objVendedor.status = objVendedor.status;
            objVendedor.telefone = objVendedor.telefone;
            objVendedor.nome = objVendedor.nome;
            objVendedor.senha = objVendedor.senha;
            objVendedor.endereco = objVendedor.endereco;

            return objVendedor;
        }

        public void AlterarCadastro(tb_vendedores objVendedor)
        {
            banco objBanco = new banco();
            tb_vendedores objVendedorAlterado = objBanco.tb_vendedores.Where(c => c.id_vendedor == objVendedor.id_vendedor).FirstOrDefault();
            objVendedorAlterado.email = objVendedor.email;
            objVendedorAlterado.status = objVendedor.status;
            objVendedorAlterado.telefone = objVendedor.telefone;
            objVendedorAlterado.nome = objVendedor.nome;
            objVendedorAlterado.senha = objVendedor.senha;
            objVendedorAlterado.endereco = objVendedor.endereco;
            objBanco.SaveChanges();
        }

        public void AlterarMeusDadosVendedos(tb_vendedores objVendedor)
        {
            banco objBanco = new banco();
            tb_vendedores objVendedorAlterado = objBanco.tb_vendedores.Where(c => c.id_vendedor == objVendedor.id_vendedor).FirstOrDefault();
            objVendedorAlterado.email = objVendedor.email;
            objVendedorAlterado.telefone = objVendedor.telefone;
            objVendedorAlterado.nome = objVendedor.nome;
            objVendedorAlterado.endereco = objVendedor.endereco;
            objBanco.SaveChanges();
        }

        public tb_vendedores VerificarLogin(string email, string senha)
        {
            banco objBanco = new banco();
            return  objBanco.tb_vendedores.Where(v => v.email == email && v.senha == senha && v.status == true).FirstOrDefault();
        }

        public bool VerificarSenha(string senha, int vendedorID)
        {


            //return new banco().tb_vendedores.Where(v => v.id_vendedor == vendedorID && v.senha == senha).FirstOrDefault() == null ? false : true;


            bool ret = false;
            tb_vendedores objVendedor = new banco().tb_vendedores.Where(v => v.id_vendedor == vendedorID && v.senha == senha).FirstOrDefault();
            if(objVendedor != null)
            {
                ret = true;
            }

            return ret;
        }

        public void AlterarSenha(string novasSenha, int vendedorID)
        {
            banco objBanco = new banco();
            tb_vendedores objvendedor = objBanco.tb_vendedores.Where(v => v.id_vendedor == vendedorID).FirstOrDefault();
            objvendedor.senha = novasSenha;
            objBanco.SaveChanges();
            
        }

    }
}
