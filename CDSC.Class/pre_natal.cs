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
    
    public partial class pre_natal
    {
        public int prn_id_pre_natal { get; set; }
        public int prn_id_crianca { get; set; }
        public Nullable<int> prn_nr_inicio_pre_natal { get; set; }
        public Nullable<int> prn_numero_consultas { get; set; }
        public string prn_st_z21_status { get; set; }
        public Nullable<int> prn_nr_z21_periodo { get; set; }
        public string prn_st_a53_status { get; set; }
        public Nullable<int> prn_nr_a53_periodo { get; set; }
        public string prn_st_b18_status { get; set; }
        public Nullable<int> prn_nr_b18_periodo { get; set; }
        public string prn_st_b58_status { get; set; }
        public Nullable<int> prn_nr_b58_periodo { get; set; }
        public string prn_st_imunização_dupla_adulto { get; set; }
        public string prn_st_suplementação_ferro { get; set; }
    
        public virtual crianca crianca { get; set; }
    }
}
