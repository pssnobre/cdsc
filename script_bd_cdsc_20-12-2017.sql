-- --------------------------------------------------------
-- Servidor:                     localhost
-- Versão do servidor:           5.7.19-log - MySQL Community Server (GPL)
-- OS do Servidor:               Win64
-- HeidiSQL Versão:              9.3.0.4984
-- --------------------------------------------------------

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET NAMES utf8mb4 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;

-- Copiando estrutura para tabela cdsc.afericao_pressao_arterial
CREATE TABLE IF NOT EXISTS `afericao_pressao_arterial` (
  `apa_id_afericao` int(11) NOT NULL AUTO_INCREMENT,
  `apa_id_crianca` int(11) DEFAULT NULL,
  `apa_dt_data` date DEFAULT NULL,
  `apa_nr_idade` int(11) DEFAULT NULL,
  `apa_nr_pa_sistolica` int(11) DEFAULT NULL,
  `apa_nr_pa_distolica` int(11) DEFAULT NULL,
  `apa_ds_observacao` varchar(50) DEFAULT NULL,
  PRIMARY KEY (`apa_id_afericao`),
  KEY `apa_id_crianca` (`apa_id_crianca`),
  CONSTRAINT `afericao_pressao_arterial_ibfk_1` FOREIGN KEY (`apa_id_crianca`) REFERENCES `crianca` (`cri_id_crianca`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- Exportação de dados foi desmarcado.


-- Copiando estrutura para tabela cdsc.alimentacao_crianca
CREATE TABLE IF NOT EXISTS `alimentacao_crianca` (
  `alc_id_crianca` int(11) NOT NULL,
  `alc_id_alimentacao` int(11) NOT NULL AUTO_INCREMENT,
  `alc_dt_data` date DEFAULT NULL,
  `alc_ds_alimentacao` varchar(500) DEFAULT NULL,
  PRIMARY KEY (`alc_id_alimentacao`),
  KEY `alc_id_crianca` (`alc_id_crianca`),
  CONSTRAINT `alimentacao_crianca_ibfk_1` FOREIGN KEY (`alc_id_crianca`) REFERENCES `crianca` (`cri_id_crianca`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- Exportação de dados foi desmarcado.


-- Copiando estrutura para tabela cdsc.crianca
CREATE TABLE IF NOT EXISTS `crianca` (
  `cri_id_crianca` int(11) NOT NULL AUTO_INCREMENT,
  `cri_id_usuario_responsavel` int(11) NOT NULL,
  `cri_ds_nome` varchar(50) DEFAULT NULL,
  `cri_id_municipio_nascimento` int(11) NOT NULL,
  `cri_dt_nascimento` date DEFAULT NULL,
  `cri_nm_mae` varchar(50) DEFAULT NULL,
  `cri_nm_pai` varchar(50) DEFAULT NULL,
  `cri_ds_sexo` varchar(1) DEFAULT NULL,
  `cri_ds_etnia` varchar(1) DEFAULT NULL,
  `cri_nr_prontuario` varchar(20) DEFAULT NULL,
  `cri_nr_declaração_nascido_vivo` varchar(20) DEFAULT NULL,
  `cri_nr_registro_civil_nascimento` varchar(20) DEFAULT NULL,
  `cri_nr_cartao_sus` varchar(20) DEFAULT NULL,
  `cri_ds_foto` varchar(200) DEFAULT NULL,
  PRIMARY KEY (`cri_id_crianca`),
  KEY `cri_id_municipio_nascimento` (`cri_id_municipio_nascimento`),
  KEY `FK_crianca_usuario` (`cri_id_usuario_responsavel`),
  CONSTRAINT `FK_crianca_usuario` FOREIGN KEY (`cri_id_usuario_responsavel`) REFERENCES `usuario` (`usu_id_usuario`),
  CONSTRAINT `crianca_ibfk_1` FOREIGN KEY (`cri_id_municipio_nascimento`) REFERENCES `municipio` (`mun_id_municipio`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- Exportação de dados foi desmarcado.


-- Copiando estrutura para tabela cdsc.crianca_usuario
CREATE TABLE IF NOT EXISTS `crianca_usuario` (
  `cru_id_criança_usuario` int(11) NOT NULL AUTO_INCREMENT,
  `cru_id_usuario` int(11) NOT NULL,
  `cru_id_crianca` int(11) NOT NULL,
  PRIMARY KEY (`cru_id_criança_usuario`),
  KEY `cru_id_usuario` (`cru_id_usuario`),
  KEY `cru_id_crianca` (`cru_id_crianca`),
  CONSTRAINT `crianca_usuario_ibfk_1` FOREIGN KEY (`cru_id_usuario`) REFERENCES `usuario` (`usu_id_usuario`),
  CONSTRAINT `crianca_usuario_ibfk_2` FOREIGN KEY (`cru_id_crianca`) REFERENCES `crianca` (`cri_id_crianca`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- Exportação de dados foi desmarcado.


-- Copiando estrutura para tabela cdsc.dados_alta
CREATE TABLE IF NOT EXISTS `dados_alta` (
  `dda_id_alta` int(11) NOT NULL AUTO_INCREMENT,
  `ddai_id_crianca` int(11) NOT NULL,
  `dda_dt_alta` date DEFAULT NULL,
  `dda_nr_peso` float DEFAULT NULL,
  `dda_ds_alimentacao` varchar(20) DEFAULT NULL,
  `dda_ds_anotacoes` varchar(200) DEFAULT NULL,
  PRIMARY KEY (`dda_id_alta`),
  KEY `ddai_id_crianca` (`ddai_id_crianca`),
  CONSTRAINT `dados_alta_ibfk_1` FOREIGN KEY (`ddai_id_crianca`) REFERENCES `crianca` (`cri_id_crianca`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- Exportação de dados foi desmarcado.


-- Copiando estrutura para tabela cdsc.endereco
CREATE TABLE IF NOT EXISTS `endereco` (
  `end_id_endereco` int(11) NOT NULL AUTO_INCREMENT,
  `end_id_crianca` int(11) NOT NULL,
  `end_ds_endereco` varchar(50) DEFAULT NULL,
  `end_ds_ponto_referencia` varchar(20) DEFAULT NULL,
  `end_nr_telefone` varchar(11) DEFAULT NULL,
  `end_ds_bairro` varchar(20) DEFAULT NULL,
  `end_nr_cep` varchar(8) DEFAULT NULL,
  `end_id_municipio` int(11) DEFAULT NULL,
  `end_ds_unidade_basica_frequenta` varchar(50) DEFAULT NULL,
  `end_dt_data` date DEFAULT NULL,
  PRIMARY KEY (`end_id_endereco`),
  KEY `end_id_crianca` (`end_id_crianca`),
  KEY `end_id_municipio` (`end_id_municipio`),
  CONSTRAINT `endereco_ibfk_1` FOREIGN KEY (`end_id_crianca`) REFERENCES `crianca` (`cri_id_crianca`),
  CONSTRAINT `endereco_ibfk_2` FOREIGN KEY (`end_id_municipio`) REFERENCES `municipio` (`mun_id_municipio`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- Exportação de dados foi desmarcado.


-- Copiando estrutura para tabela cdsc.exames_triagem_neonatal
CREATE TABLE IF NOT EXISTS `exames_triagem_neonatal` (
  `etn_id_exames_neonatal` int(11) NOT NULL AUTO_INCREMENT,
  `etni_id_crianca` int(11) NOT NULL,
  `etn_st_manobra_ortolani` varchar(1) DEFAULT NULL,
  `etn_ds_conduta_ortolani` varchar(50) DEFAULT NULL,
  `etn_st_teste_reflexo_vermelho` varchar(1) DEFAULT NULL,
  `etn_ds_conduta_reflexo_vermelho` varchar(50) DEFAULT NULL,
  `etn_st_teste_pezinho` varchar(1) DEFAULT NULL,
  `etn_dt_teste_pezinho` date DEFAULT NULL,
  `etn_st_fenilcitonuria` varchar(1) DEFAULT NULL,
  `etn_st_hipotireoidismo` varchar(1) DEFAULT NULL,
  `etn_st_anemia_falciforme` varchar(1) DEFAULT NULL,
  `etn_ds_outros` varchar(50) DEFAULT NULL,
  `etn_st_triagem_auditiva` varchar(1) DEFAULT NULL,
  `etn_dt_triagem_auditiva` date DEFAULT NULL,
  `etn_ds_testes_realizados_auditivos` varchar(1) DEFAULT NULL,
  `etn_st_resultado_od` varchar(1) DEFAULT NULL,
  `etn_st_resultado_oe` varchar(1) DEFAULT NULL,
  `etn_ds_conduta_triagem_auditiva` varchar(50) DEFAULT NULL,
  `etn_st_reteste` varchar(1) DEFAULT NULL,
  `etn_dt_reteste` date DEFAULT NULL,
  `etn_ds_testes_realizados_auditivos_reteste` varchar(1) DEFAULT NULL,
  `etn_st_resultado_od_reteste` varchar(1) DEFAULT NULL,
  `etn_st_resultado_oe_reteste` varchar(1) DEFAULT NULL,
  `etn_ds_conduta_triagem_auditiva_reteste` varchar(50) DEFAULT NULL,
  PRIMARY KEY (`etn_id_exames_neonatal`),
  KEY `etni_id_crianca` (`etni_id_crianca`),
  CONSTRAINT `exames_triagem_neonatal_ibfk_1` FOREIGN KEY (`etni_id_crianca`) REFERENCES `crianca` (`cri_id_crianca`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- Exportação de dados foi desmarcado.


-- Copiando estrutura para tabela cdsc.intercorrencias
CREATE TABLE IF NOT EXISTS `intercorrencias` (
  `int_id_crianca` int(11) NOT NULL,
  `int_id_intercorrencia` int(11) NOT NULL AUTO_INCREMENT,
  `int_dt_data` date DEFAULT NULL,
  `int_ds_intercorrencia` varchar(200) DEFAULT NULL,
  `int_ds_observacoes` varchar(500) DEFAULT NULL,
  PRIMARY KEY (`int_id_intercorrencia`),
  KEY `int_id_crianca` (`int_id_crianca`),
  CONSTRAINT `intercorrencias_ibfk_1` FOREIGN KEY (`int_id_crianca`) REFERENCES `crianca` (`cri_id_crianca`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- Exportação de dados foi desmarcado.


-- Copiando estrutura para tabela cdsc.marcador_desenvolvimento
CREATE TABLE IF NOT EXISTS `marcador_desenvolvimento` (
  `mdv_id_marcador` int(11) NOT NULL AUTO_INCREMENT,
  `mdv_ds_marcador` varchar(200) DEFAULT NULL,
  `mdv_ds_como_investigar` varchar(200) DEFAULT NULL,
  PRIMARY KEY (`mdv_id_marcador`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- Exportação de dados foi desmarcado.


-- Copiando estrutura para tabela cdsc.marcador_desenvolvimento_crianca
CREATE TABLE IF NOT EXISTS `marcador_desenvolvimento_crianca` (
  `mdc_id_marcador_crianca` int(11) NOT NULL AUTO_INCREMENT,
  `mdc_id_marcador` int(11) NOT NULL,
  `mdc_id_crianca` int(11) NOT NULL,
  `mdc_nr_idade` int(11) DEFAULT NULL,
  `mdc_ds_status` varchar(1) DEFAULT NULL,
  PRIMARY KEY (`mdc_id_marcador_crianca`),
  KEY `mdc_id_marcador` (`mdc_id_marcador`),
  KEY `mdc_id_crianca` (`mdc_id_crianca`),
  CONSTRAINT `marcador_desenvolvimento_crianca_ibfk_1` FOREIGN KEY (`mdc_id_marcador`) REFERENCES `marcador_desenvolvimento` (`mdv_id_marcador`),
  CONSTRAINT `marcador_desenvolvimento_crianca_ibfk_2` FOREIGN KEY (`mdc_id_crianca`) REFERENCES `crianca` (`cri_id_crianca`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- Exportação de dados foi desmarcado.


-- Copiando estrutura para tabela cdsc.menu
CREATE TABLE IF NOT EXISTS `menu` (
  `men_id_menu` int(11) NOT NULL AUTO_INCREMENT,
  `men_ds_menu` varchar(50) NOT NULL,
  `men_ds_url` varchar(50) NOT NULL,
  PRIMARY KEY (`men_id_menu`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- Exportação de dados foi desmarcado.


-- Copiando estrutura para tabela cdsc.municipio
CREATE TABLE IF NOT EXISTS `municipio` (
  `mun_id_municipio` int(11) NOT NULL AUTO_INCREMENT,
  `mun_ds_municipio` varchar(50) DEFAULT NULL,
  `mun_id_uf` int(11) DEFAULT NULL,
  PRIMARY KEY (`mun_id_municipio`),
  KEY `mun_id_uf` (`mun_id_uf`),
  CONSTRAINT `municipio_ibfk_1` FOREIGN KEY (`mun_id_uf`) REFERENCES `uf` (`uff_id_uf`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- Exportação de dados foi desmarcado.


-- Copiando estrutura para tabela cdsc.nascimento
CREATE TABLE IF NOT EXISTS `nascimento` (
  `nas_id_nascimento` int(11) NOT NULL AUTO_INCREMENT,
  `nas_id_crianca` int(11) NOT NULL,
  `nas_dt_nascimento` date DEFAULT NULL,
  `nas_ds_maternidade` varchar(50) DEFAULT NULL,
  `nas_id_municipio` int(11) NOT NULL,
  `nas_nr_peso` float DEFAULT NULL,
  `nas_nr_comprimento` float DEFAULT NULL,
  `nas_nr_perimetro_encefalico` float DEFAULT NULL,
  `nas_ds_sexo` varchar(1) DEFAULT NULL,
  `nas_ds_apagar_1_min` varchar(20) DEFAULT NULL,
  `nas_ds_apagar_5_min` varchar(20) DEFAULT NULL,
  `nas_nr_idade_gestacional_semanas` int(11) DEFAULT NULL,
  `nas_nr_idade_gestacional_dias` int(11) DEFAULT NULL,
  `nas_ds_metodo_avaliacao_ig` varchar(1) DEFAULT NULL,
  `nas_ds_tipo_sanguineo` varchar(2) DEFAULT NULL,
  `nas_ds_tipo_sanguineo_mae` varchar(2) DEFAULT NULL,
  `nas_st_aleitamento_primeira_hora` varchar(1) DEFAULT NULL,
  `nas_ds_profissional_assistiu` varchar(20) DEFAULT NULL,
  `nas_nr_hora_nascimento` varchar(5) DEFAULT NULL,
  PRIMARY KEY (`nas_id_nascimento`),
  KEY `nas_id_crianca` (`nas_id_crianca`),
  KEY `nas_id_municipio` (`nas_id_municipio`),
  CONSTRAINT `nascimento_ibfk_1` FOREIGN KEY (`nas_id_crianca`) REFERENCES `crianca` (`cri_id_crianca`),
  CONSTRAINT `nascimento_ibfk_2` FOREIGN KEY (`nas_id_municipio`) REFERENCES `municipio` (`mun_id_municipio`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- Exportação de dados foi desmarcado.


-- Copiando estrutura para tabela cdsc.outras_observacoes
CREATE TABLE IF NOT EXISTS `outras_observacoes` (
  `obs_id_crianca` int(11) NOT NULL,
  `obs_id_observacoes` int(11) NOT NULL AUTO_INCREMENT,
  `obs_dt_data` date DEFAULT NULL,
  `obs_ds_anotacao` varchar(999) DEFAULT NULL,
  PRIMARY KEY (`obs_id_observacoes`),
  KEY `obs_id_crianca` (`obs_id_crianca`),
  CONSTRAINT `outras_observacoes_ibfk_1` FOREIGN KEY (`obs_id_crianca`) REFERENCES `crianca` (`cri_id_crianca`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- Exportação de dados foi desmarcado.


-- Copiando estrutura para tabela cdsc.parto
CREATE TABLE IF NOT EXISTS `parto` (
  `par_id_parto` int(11) NOT NULL AUTO_INCREMENT,
  `par_id_crianca` int(11) NOT NULL,
  `par_ds_local` varchar(1) DEFAULT NULL,
  `par_tp_parto` varchar(1) DEFAULT NULL,
  `par_ds_indicacao` varchar(50) DEFAULT NULL,
  `par_st_z21_status` varchar(1) DEFAULT NULL,
  `par_nr_z21_periodo` int(11) DEFAULT NULL,
  `par_st_a53_status` varchar(1) DEFAULT NULL,
  `par_st_a53_periodo` int(11) DEFAULT NULL,
  `par_st_megadose_vitamina_a` varchar(1) DEFAULT NULL,
  `par_ds_intercorrencias_clinicas` varchar(200) DEFAULT NULL,
  PRIMARY KEY (`par_id_parto`),
  KEY `par_id_crianca` (`par_id_crianca`),
  CONSTRAINT `parto_ibfk_1` FOREIGN KEY (`par_id_crianca`) REFERENCES `crianca` (`cri_id_crianca`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- Exportação de dados foi desmarcado.


-- Copiando estrutura para tabela cdsc.perfil
CREATE TABLE IF NOT EXISTS `perfil` (
  `per_id_perfil` int(11) NOT NULL AUTO_INCREMENT,
  `per_ds_perfil` varchar(20) DEFAULT NULL,
  PRIMARY KEY (`per_id_perfil`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- Exportação de dados foi desmarcado.


-- Copiando estrutura para tabela cdsc.pre_natal
CREATE TABLE IF NOT EXISTS `pre_natal` (
  `prn_id_pre_natal` int(11) NOT NULL AUTO_INCREMENT,
  `prn_id_crianca` int(11) NOT NULL,
  `prn_nr_inicio_pre_natal` int(11) DEFAULT NULL,
  `prn_numero_consultas` int(11) DEFAULT NULL,
  `prn_st_z21_status` varchar(1) DEFAULT NULL,
  `prn_nr_z21_periodo` int(11) DEFAULT NULL,
  `prn_st_a53_status` varchar(1) DEFAULT NULL,
  `prn_nr_a53_periodo` int(11) DEFAULT NULL,
  `prn_st_b18_status` varchar(1) DEFAULT NULL,
  `prn_nr_b18_periodo` int(11) DEFAULT NULL,
  `prn_st_b58_status` varchar(1) DEFAULT NULL,
  `prn_nr_b58_periodo` int(11) DEFAULT NULL,
  `prn_st_imunização_dupla_adulto` varchar(1) DEFAULT NULL,
  `prn_st_suplementação_ferro` varchar(1) DEFAULT NULL,
  PRIMARY KEY (`prn_id_pre_natal`),
  KEY `prn_id_crianca` (`prn_id_crianca`),
  CONSTRAINT `pre_natal_ibfk_1` FOREIGN KEY (`prn_id_crianca`) REFERENCES `crianca` (`cri_id_crianca`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- Exportação de dados foi desmarcado.


-- Copiando estrutura para tabela cdsc.registro_medidas_antropometricas
CREATE TABLE IF NOT EXISTS `registro_medidas_antropometricas` (
  `rma_id_registro_medidas` int(11) NOT NULL AUTO_INCREMENT,
  `rma_id_crianca` int(11) NOT NULL,
  `rma_dt_registro` date DEFAULT NULL,
  `rma_nr_idade` int(11) DEFAULT NULL,
  `rma_nr_peso` int(11) DEFAULT NULL,
  `rma_nr_estatura` int(11) DEFAULT NULL,
  `rma_nr_perimetro_cefalico` int(11) DEFAULT NULL,
  `rma_nr_imc` int(11) DEFAULT NULL,
  PRIMARY KEY (`rma_id_registro_medidas`),
  KEY `rma_id_crianca` (`rma_id_crianca`),
  CONSTRAINT `registro_medidas_antropometricas_ibfk_1` FOREIGN KEY (`rma_id_crianca`) REFERENCES `crianca` (`cri_id_crianca`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- Exportação de dados foi desmarcado.


-- Copiando estrutura para tabela cdsc.saude_auditiva
CREATE TABLE IF NOT EXISTS `saude_auditiva` (
  `sau_id_crianca` int(11) NOT NULL,
  `sau_id_saude_auditiva` int(11) NOT NULL AUTO_INCREMENT,
  `sau_nr_idade` int(11) DEFAULT NULL,
  `sau_st_audiometria_tonal` blob,
  `sau_st_imitanciometria` blob,
  `sau_ds_local` varchar(50) DEFAULT NULL,
  `sau_dt_data` date DEFAULT NULL,
  `sau_st_resultado_od` blob,
  `sau_st_resultado_oe` blob,
  `sau_ds_encaminhamento` varchar(50) DEFAULT NULL,
  `sau_st_nessidade_monitoramento_audicao` blob,
  PRIMARY KEY (`sau_id_saude_auditiva`),
  KEY `sau_id_crianca` (`sau_id_crianca`),
  CONSTRAINT `saude_auditiva_ibfk_1` FOREIGN KEY (`sau_id_crianca`) REFERENCES `crianca` (`cri_id_crianca`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- Exportação de dados foi desmarcado.


-- Copiando estrutura para tabela cdsc.saude_ocular
CREATE TABLE IF NOT EXISTS `saude_ocular` (
  `sao_id_crianca` int(11) NOT NULL,
  `sao_id_saude_ocular` int(11) NOT NULL AUTO_INCREMENT,
  `sao_nr_periodo` int(11) DEFAULT NULL,
  `sao_st_resultado_tav` varchar(1) DEFAULT NULL,
  `sao_st_consulta_oftamologica` blob,
  `sao_st_disturbio_visual` blob,
  `sao_st_prescricao_oculos` blob,
  PRIMARY KEY (`sao_id_saude_ocular`),
  KEY `sao_id_crianca` (`sao_id_crianca`),
  CONSTRAINT `saude_ocular_ibfk_1` FOREIGN KEY (`sao_id_crianca`) REFERENCES `crianca` (`cri_id_crianca`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- Exportação de dados foi desmarcado.


-- Copiando estrutura para tabela cdsc.suplementacao_ferro
CREATE TABLE IF NOT EXISTS `suplementacao_ferro` (
  `suf_id_crianca` int(11) NOT NULL,
  `suf_id_suplementacao_ferro` int(11) NOT NULL AUTO_INCREMENT,
  `suf_dt_suplementacao` date DEFAULT NULL,
  `suf_ds_local` varchar(50) DEFAULT NULL,
  PRIMARY KEY (`suf_id_suplementacao_ferro`),
  KEY `suf_id_crianca` (`suf_id_crianca`),
  CONSTRAINT `suplementacao_ferro_ibfk_1` FOREIGN KEY (`suf_id_crianca`) REFERENCES `crianca` (`cri_id_crianca`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- Exportação de dados foi desmarcado.


-- Copiando estrutura para tabela cdsc.suplementacao_vitamina_a
CREATE TABLE IF NOT EXISTS `suplementacao_vitamina_a` (
  `sva_id_crianca` int(11) NOT NULL,
  `sva_id_suplementacao_vitamina_a` int(11) NOT NULL AUTO_INCREMENT,
  `sva_dt_data` date DEFAULT NULL,
  `sva_ds_local` varchar(50) DEFAULT NULL,
  PRIMARY KEY (`sva_id_suplementacao_vitamina_a`),
  KEY `sva_id_crianca` (`sva_id_crianca`),
  CONSTRAINT `suplementacao_vitamina_a_ibfk_1` FOREIGN KEY (`sva_id_crianca`) REFERENCES `crianca` (`cri_id_crianca`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- Exportação de dados foi desmarcado.


-- Copiando estrutura para tabela cdsc.uf
CREATE TABLE IF NOT EXISTS `uf` (
  `uff_id_uf` int(11) NOT NULL AUTO_INCREMENT,
  `uff_ds_uf` varchar(50) DEFAULT NULL,
  `uff_ds_sigla` varchar(2) DEFAULT NULL,
  PRIMARY KEY (`uff_id_uf`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- Exportação de dados foi desmarcado.


-- Copiando estrutura para tabela cdsc.usuario
CREATE TABLE IF NOT EXISTS `usuario` (
  `usu_id_usuario` int(11) NOT NULL AUTO_INCREMENT,
  `usu_nr_cpf` varchar(11) DEFAULT NULL,
  `usu_ds_nome` varchar(50) DEFAULT NULL,
  `usu_nr_telefone` varchar(11) DEFAULT NULL,
  `usu_ds_email` varchar(50) DEFAULT NULL,
  `usu_ds_senha` varchar(20) DEFAULT NULL,
  `usu_id_perfil` int(11) NOT NULL,
  PRIMARY KEY (`usu_id_usuario`),
  KEY `usu_id_perfil` (`usu_id_perfil`),
  CONSTRAINT `usuario_ibfk_1` FOREIGN KEY (`usu_id_perfil`) REFERENCES `perfil` (`per_id_perfil`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- Exportação de dados foi desmarcado.


-- Copiando estrutura para tabela cdsc.vacina
CREATE TABLE IF NOT EXISTS `vacina` (
  `vac_id_vacina` int(11) NOT NULL AUTO_INCREMENT,
  `vac_ds_vacina` varchar(50) DEFAULT NULL,
  PRIMARY KEY (`vac_id_vacina`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- Exportação de dados foi desmarcado.


-- Copiando estrutura para tabela cdsc.vacinas_crianca
CREATE TABLE IF NOT EXISTS `vacinas_crianca` (
  `vcc_id_vacina_crianca` int(11) NOT NULL AUTO_INCREMENT,
  `vcc_id_vacina` int(11) NOT NULL,
  `vcc_id_crianca` int(11) NOT NULL,
  `vcc_dt_data` date DEFAULT NULL,
  `vcc_nr_dose` varchar(1) DEFAULT NULL,
  `vcc_nr_lote` varchar(20) DEFAULT NULL,
  `vcc_ds_unidade` varchar(50) DEFAULT NULL,
  PRIMARY KEY (`vcc_id_vacina_crianca`),
  KEY `vcc_id_vacina` (`vcc_id_vacina`),
  KEY `vcc_id_crianca` (`vcc_id_crianca`),
  CONSTRAINT `vacinas_crianca_ibfk_1` FOREIGN KEY (`vcc_id_vacina`) REFERENCES `vacina` (`vac_id_vacina`),
  CONSTRAINT `vacinas_crianca_ibfk_2` FOREIGN KEY (`vcc_id_crianca`) REFERENCES `crianca` (`cri_id_crianca`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- Exportação de dados foi desmarcado.
/*!40101 SET SQL_MODE=IFNULL(@OLD_SQL_MODE, '') */;
/*!40014 SET FOREIGN_KEY_CHECKS=IF(@OLD_FOREIGN_KEY_CHECKS IS NULL, 1, @OLD_FOREIGN_KEY_CHECKS) */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
