using System;
using System.ComponentModel.DataAnnotations;

namespace CodeAnalysisReport.Database.Model
{
  public class CodeAnalysis
  {
    public long CodeAnalysisId { get; set; }

    [MaxLength(100)]
    [Required]
    public string Projeto { get; set; }

    [MaxLength(100)]
    [Required]
    public string Solution { get; set; }

    [MaxLength(20)]
    public string Severidade { get; set; }

    [MaxLength(10)]
    [Required]
    public string Codigo { get; set; }

    public string Descricao { get; set; }

    [MaxLength(70)]
    public string Dll { get; set; }

    [MaxLength(255)]
    public string CaminhoArquivo { get; set; }

    public int LinhaCodigo { get; set; }

    [Required]
    public DateTime DataExecucao { get; set; }

  }
}
