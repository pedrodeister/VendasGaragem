//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DAO
{
    using System;
    using System.Collections.Generic;
    
    public partial class tb_venda
    {
        public int id_venda { get; set; }
        public System.DateTime data { get; set; }
        public decimal valor { get; set; }
        public string descricao { get; set; }
        public short forma_pagamento { get; set; }
        public int veiculo_id { get; set; }
        public int vendedor_id { get; set; }
        public int id_cliente { get; set; }
    
        public virtual tb_cliente tb_cliente { get; set; }
        public virtual tb_veiculo tb_veiculo { get; set; }
        public virtual tb_vendedores tb_vendedores { get; set; }
    }
}