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
    
    public partial class endereco
    {
        public int end_id_endereço { get; set; }
        public int end_id_crianca { get; set; }
        public string end_ds_endereco { get; set; }
        public string end_ds_ponto_referencia { get; set; }
        public string end_nr_telefone { get; set; }
        public string end_ds_bairro { get; set; }
        public string end_nr_cep { get; set; }
        public Nullable<int> end_id_municipio { get; set; }
        public string end_ds_unidade_basica_frequenta { get; set; }
        public Nullable<System.DateTime> end_dt_data { get; set; }
    
        public virtual crianca crianca { get; set; }
        public virtual municipio municipio { get; set; }
    }
}