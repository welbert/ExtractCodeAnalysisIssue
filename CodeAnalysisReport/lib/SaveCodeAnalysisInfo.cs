using CodeAnalysisReport.Common;
using CodeAnalysisReport.Properties;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace CodeAnalysisReport.lib
{
  class SaveCodeAnalysisInfo
  {

    public SqlConnection Context { get => DBTransaction.Instance.Connection; }

    public bool Insert(CodeAnalysisInfo loInfo)
    {
      Context.Open();
      var loQueryInsertCas = Context.CreateCommand();
      loQueryInsertCas.CommandText = Queries.InsertCasCodeAnalysis;
      loQueryInsertCas.Parameters.AddWithValue("@nmProjeto", loInfo.Project);
      loQueryInsertCas.Parameters.AddWithValue("@nmSeveridade", loInfo.Severity);
      loQueryInsertCas.Parameters.AddWithValue("@cdCodigo", loInfo.Code);
      loQueryInsertCas.Parameters.AddWithValue("@dsDescricao", loInfo.Description);
      loQueryInsertCas.Parameters.AddWithValue("@nmDll", loInfo.Dll);
      loQueryInsertCas.Parameters.AddWithValue("@nmCaminhoArquivo", loInfo.File);
      loQueryInsertCas.Parameters.AddWithValue("@nuLinhaCodigo", loInfo.Line);

      loQueryInsertCas.CommandType = CommandType.Text;
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
  }
}
