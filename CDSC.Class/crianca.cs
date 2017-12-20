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
    
    public partial class crianca
    {
        public crianca()
        {
            this.afericao_pressao_arterial = new HashSet<afericao_pressao_arterial>();
            this.alimentacao_crianca = new HashSet<alimentacao_crianca>();
            this.crianca_usuario = new HashSet<crianca_usuario>();
            this.intercorrencias = new HashSet<intercorrencias>();
            this.marcador_desenvolvimento_crianca = new HashSet<marcador_desenvolvimento_crianca>();
            this.outras_observacoes = new HashSet<outras_observacoes>();
            this.parto = new HashSet<parto>();
            this.pre_natal = new HashSet<pre_natal>();
            this.registro_medidas_antropometricas = new HashSet<registro_medidas_antropometricas>();
            this.saude_auditiva = new HashSet<saude_auditiva>();
            this.saude_ocular = new HashSet<saude_ocular>();
            this.suplementacao_ferro = new HashSet<suplementacao_ferro>();
            this.suplementacao_vitamina_a = new HashSet<suplementacao_vitamina_a>();
            this.vacinas_crianca = new HashSet<vacinas_crianca>();
            this.exames_triagem_neonatal = new HashSet<exames_triagem_neonatal>();
            this.dados_alta = new HashSet<dados_alta>();
            this.nascimento = new HashSet<nascimento>();
            this.endereco = new HashSet<endereco>();
        }
    
        public int cri_id_crianca { get; set; }
        public int cri_id_usuario_responsavel { get; set; }
        public string cri_ds_nome { get; set; }
        public int cri_id_municipio_nascimento { get; set; }
        public Nullable<System.DateTime> cri_dt_nascimento { get; set; }
        public string cri_nm_mae { get; set; }
        public string cri_nm_pai { get; set; }
        public string cri_ds_sexo { get; set; }
        public string cri_ds_etnia { get; set; }
        public string cri_nr_prontuario { get; set; }
        public string cri_nr_declaração_nascido_vivo { get; set; }
        public string cri_nr_registro_civil_nascimento { get; set; }
        public string cri_nr_cartao_sus { get; set; }
        public string cri_ds_foto { get; set; }
    
        public virtual ICollection<afericao_pressao_arterial> afericao_pressao_arterial { get; set; }
        public virtual ICollection<alimentacao_crianca> alimentacao_crianca { get; set; }
        public virtual municipio municipio { get; set; }
        public virtual ICollection<crianca_usuario> crianca_usuario { get; set; }
        public virtual usuario usuario { get; set; }
        public virtual ICollection<intercorrencias> intercorrencias { get; set; }
        public virtual ICollection<marcador_desenvolvimento_crianca> marcador_desenvolvimento_crianca { get; set; }
        public virtual ICollection<outras_observacoes> outras_observacoes { get; set; }
        public virtual ICollection<parto> parto { get; set; }
        public virtual ICollection<pre_natal> pre_natal { get; set; }
        public virtual ICollection<registro_medidas_antropometricas> registro_medidas_antropometricas { get; set; }
        public virtual ICollection<saude_auditiva> saude_auditiva { get; set; }
        public virtual ICollection<saude_ocular> saude_ocular { get; set; }
        public virtual ICollection<suplementacao_ferro> suplementacao_ferro { get; set; }
        public virtual ICollection<suplementacao_vitamina_a> suplementacao_vitamina_a { get; set; }
        public virtual ICollection<vacinas_crianca> vacinas_crianca { get; set; }
        public virtual ICollection<exames_triagem_neonatal> exames_triagem_neonatal { get; set; }
        public virtual ICollection<dados_alta> dados_alta { get; set; }
        public virtual ICollection<nascimento> nascimento { get; set; }
        public virtual ICollection<endereco> endereco { get; set; }
    }
}
