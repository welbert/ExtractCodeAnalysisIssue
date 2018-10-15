using CodeAnalysisReport.Common;
using CodeAnalysisReport.Properties;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace CodeAnalysisReport.lib
{
  class SaveCodeAnalysisInfo
  {

    public SqlConnection Context { get => DBTransaction.Instance.Connection; }
    public DateTime? idtDataAtual { get; set; }

    public bool Insert(CodeAnalysisInfo loInfo)
    {
      var loQueryInsertCas = Context.CreateCommand();
      loQueryInsertCas.CommandText = Queries.InsertCasCodeAnalysis;
      loQueryInsertCas.Parameters.AddWithValue("@nmProjeto", loInfo.Project);
      loQueryInsertCas.Parameters.AddWithValue("@nmSolution", loInfo.Solution);
      loQueryInsertCas.Parameters.AddWithValue("@nmSeveridade", loInfo.Severity);
      loQueryInsertCas.Parameters.AddWithValue("@cdCodigo", loInfo.Code);
      loQueryInsertCas.Parameters.AddWithValue("@dsDescricao", loInfo.Description);
      loQueryInsertCas.Parameters.AddWithValue("@nmDll", loInfo.Dll);
      loQueryInsertCas.Parameters.AddWithValue("@nmCaminhoArquivo", loInfo.File);
      loQueryInsertCas.Parameters.AddWithValue("@nuLinhaCodigo", loInfo.Line);
      loQueryInsertCas.Parameters.AddWithValue("@dtExecucao", GetDataAtual());
      loQueryInsertCas.CommandType = CommandType.Text;

      Context.Open();
      loQueryInsertCas.ExecuteNonQuery();
      Context.Close();

      return true;
    }

    public bool InsertList(List<CodeAnalysisInfo> loInfos)
    {
      loInfos.ForEach((info) =>
      {
        this.Insert(info);
      });

      return true;
    }

    public DateTime? GetDataAtual()
    {
      if (idtDataAtual == null)
      {
        DateTime? ldtDataAtual = null;
        try
        {
          Context.Open();
          var loQueryDataAtual = Context.CreateCommand();
          loQueryDataAtual.CommandText = Queries.DataAtual;

          loQueryDataAtual.CommandType = CommandType.Text;
          using (var reader = loQueryDataAtual.ExecuteReader())
          {
            reader.Read();
            ldtDataAtual = reader.GetDateTime(0);
          }

          Context.Close();
        }
        catch (Exception e)
        {
          ldtDataAtual = DateTime.Now;
        }
        idtDataAtual = ldtDataAtual;
      }

      return idtDataAtual;
    }
  }
}
