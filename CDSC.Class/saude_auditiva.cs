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
    
    public partial class saude_auditiva
    {
        public int sau_id_crianca { get; set; }
        public int sau_id_saude_auditiva { get; set; }
        public Nullable<int> sau_nr_idade { get; set; }
        public byte[] sau_st_audiometria_tonal { get; set; }
        public byte[] sau_st_imitanciometria { get; set; }
        public string sau_ds_local { get; set; }
        public Nullable<System.DateTime> sau_dt_data { get; set; }
        public byte[] sau_st_resultado_od { get; set; }
        public byte[] sau_st_resultado_oe { get; set; }
        public string sau_ds_encaminhamento { get; set; }
        public byte[] sau_st_nessidade_monitoramento_audicao { get; set; }
    
        public virtual crianca crianca { get; set; }
    }
}
