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
    
    public partial class tb_veiculo
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tb_veiculo()
        {
            this.tb_venda = new HashSet<tb_venda>();
        }
    
        public int id_veiculo { get; set; }
        public string placa { get; set; }
        public short direcao { get; set; }
        public bool airbag { get; set; }
        public bool ar { get; set; }
        public short situacao { get; set; }
        public string ano_fab { get; set; }
        public string ano_modelo { get; set; }
        public string km { get; set; }
        public short n_portas { get; set; }
        public decimal valor_compra { get; set; }
        public decimal valor_venda { get; set; }
        public string obs { get; set; }
        public int empresa_id { get; set; }
        public int modelo_id { get; set; }
        public int cor_id { get; set; }
    
        public virtual tb_cor tb_cor { get; set; }
        public virtual tb_empresa tb_empresa { get; set; }
        public virtual tb_modelo tb_modelo { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tb_venda> tb_venda { get; set; }
    }
}