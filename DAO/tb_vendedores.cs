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
    
    public partial class tb_vendedores
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tb_vendedores()
        {
            this.tb_venda = new HashSet<tb_venda>();
        }
    
        public int id_vendedor { get; set; }
        public string nome { get; set; }
        public string endereco { get; set; }
        public string senha { get; set; }
        public string email { get; set; }
        public string telefone { get; set; }
        public bool status { get; set; }
        public int empresa_id { get; set; }
    
        public virtual tb_empresa tb_empresa { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tb_venda> tb_venda { get; set; }
    }
}