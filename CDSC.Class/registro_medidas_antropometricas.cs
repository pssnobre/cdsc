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
    
    public partial class registro_medidas_antropometricas
    {
        public int rma_id_registro_medidas { get; set; }
        public int rma_id_crianca { get; set; }
        public Nullable<System.DateTime> rma_dt_registro { get; set; }
        public Nullable<int> rma_nr_idade { get; set; }
        public Nullable<int> rma_nr_peso { get; set; }
        public Nullable<int> rma_nr_estatura { get; set; }
        public Nullable<int> rma_nr_perimetro_cefalico { get; set; }
        public Nullable<int> rma_nr_imc { get; set; }
    
        public virtual crianca crianca { get; set; }
    }
}