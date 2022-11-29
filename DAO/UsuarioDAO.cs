using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;

namespace DAO
{
    public class UsuarioDAO
    {
        
        public int ValidarLogin(string cnpj, string senha)
        {
            banco objBanco = new banco();
            tb_empresa objEmpresa = objBanco.tb_empresa
                                    .Where(c => c.cnpj == cnpj && c.senha == senha && c.status == true)
                                    .FirstOrDefault();

            if(objEmpresa == null)
            {
                return -1;
            }

            return objEmpresa.id_empresa;
        }

    }
}
