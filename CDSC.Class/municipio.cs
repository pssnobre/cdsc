//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace CDSC.Class
{
    using System;
    using System.Collections.Generic;
    
    public partial class municipio
    {
        public municipio()
        {
            this.crianca = new HashSet<crianca>();
            this.endereco = new HashSet<endereco>();
            this.nascimento = new HashSet<nascimento>();
        }
    
        public int mun_id_municipio { get; set; }
        public string mun_ds_municipio { get; set; }
        public Nullable<int> mun_id_uf { get; set; }
    
        public virtual ICollection<crianca> crianca { get; set; }
        public virtual ICollection<endereco> endereco { get; set; }
        public virtual uf uf { get; set; }
        public virtual ICollection<nascimento> nascimento { get; set; }
    }
}
