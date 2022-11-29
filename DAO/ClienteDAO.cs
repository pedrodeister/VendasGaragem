using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO
{
    public class ClienteDAO
    {
        banco objBanco = new banco();
        public void CadastrarCliente(tb_cliente objCliente)
        {
            objBanco.tb_cliente.Add(objCliente);
            objBanco.SaveChanges();
        }

        public List<tb_cliente> ListarClientes(int vendedorID)
        {
            return new banco().tb_cliente.Where(v => v.id_vendedor == vendedorID).ToList();
             
        }

        public tb_cliente DetalharCliente(int idCliente)
        {
            return new banco().tb_cliente.FirstOrDefault(c => c.id_cliente == idCliente);
        }

        public void Alterar(tb_cliente objcliente)
        {
            banco objBanco = new banco();
            tb_cliente clienteUpdate = objBanco.tb_cliente.FirstOrDefault(c => c.id_cliente == objcliente.id_cliente);

            clienteUpdate.nome_cliente = objcliente.nome_cliente;
            clienteUpdate.email_cliente = objcliente.email_cliente;
            clienteUpdate.tel_cliente = objcliente.tel_cliente;
            clienteUpdate.end_cliente = objcliente.end_cliente;

            objBanco.SaveChanges();
        }

        public void Excluir(int idCliente)
        {
            banco objBanco = new banco();
            tb_cliente clienteDelete = objBanco.tb_cliente.Where(c => c.id_cliente == idCliente).FirstOrDefault();

            objBanco.tb_cliente.Remove(clienteDelete);
            objBanco.SaveChanges();
        }

    }
}
