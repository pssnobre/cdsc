﻿//------------------------------------------------------------------------------
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
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class cdscEntities : DbContext
    {
        public cdscEntities()
            : base("name=cdscEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public DbSet<afericao_pressao_arterial> afericao_pressao_arterial { get; set; }
        public DbSet<alimentacao_crianca> alimentacao_crianca { get; set; }
        public DbSet<crianca> crianca { get; set; }
        public DbSet<crianca_usuario> crianca_usuario { get; set; }
        public DbSet<endereco> endereco { get; set; }
        public DbSet<intercorrencias> intercorrencias { get; set; }
        public DbSet<marcador_desenvolvimento> marcador_desenvolvimento { get; set; }
        public DbSet<marcador_desenvolvimento_crianca> marcador_desenvolvimento_crianca { get; set; }
        public DbSet<menu> menu { get; set; }
        public DbSet<municipio> municipio { get; set; }
        public DbSet<outras_observacoes> outras_observacoes { get; set; }
        public DbSet<parto> parto { get; set; }
        public DbSet<perfil> perfil { get; set; }
        public DbSet<pre_natal> pre_natal { get; set; }
        public DbSet<registro_medidas_antropometricas> registro_medidas_antropometricas { get; set; }
        public DbSet<saude_auditiva> saude_auditiva { get; set; }
        public DbSet<saude_ocular> saude_ocular { get; set; }
        public DbSet<suplementacao_ferro> suplementacao_ferro { get; set; }
        public DbSet<suplementacao_vitamina_a> suplementacao_vitamina_a { get; set; }
        public DbSet<uf> uf { get; set; }
        public DbSet<usuario> usuario { get; set; }
        public DbSet<vacina> vacina { get; set; }
        public DbSet<vacinas_crianca> vacinas_crianca { get; set; }
        public DbSet<exames_triagem_neonatal> exames_triagem_neonatal { get; set; }
        public DbSet<dados_alta> dados_alta { get; set; }
        public DbSet<nascimento> nascimento { get; set; }
    }
}
