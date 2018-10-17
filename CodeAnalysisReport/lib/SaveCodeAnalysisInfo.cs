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
    public DateTime? IdtDataAtual { get; set; }
    SqlTransaction ioTransaction;

    private bool Insert(CodeAnalysisInfo loInfo)
    {
      var loQueryInsertCas = Context.CreateCommand();
      loQueryInsertCas.Transaction = ioTransaction;
      loQueryInsertCas.CommandText = Queries.InsertCasCodeAnalysis;
      loQueryInsertCas.Parameters.AddWithValue("@nmProjeto", loInfo.Project);
      loQueryInsertCas.Parameters.AddWithValue("@nmSolution", loInfo.Solution);
      loQueryInsertCas.Parameters.AddWithValue("@nmSeveridade", loInfo.Severity);
      loQueryInsertCas.Parameters.AddWithValue("@cdCodigo", loInfo.Code);
      loQueryInsertCas.Parameters.AddWithValue("@dsDescricao", loInfo.Description);
      loQueryInsertCas.Parameters.AddWithValue("@nmDll", loInfo.Dll);
      loQueryInsertCas.Parameters.AddWithValue("@nmCaminhoArquivo", loInfo.File);
      loQueryInsertCas.Parameters.AddWithValue("@nuLinhaCodigo", loInfo.Line);
      loQueryInsertCas.Parameters.AddWithValue("@dtExecucao", DataAtual);
      loQueryInsertCas.CommandType = CommandType.Text;

      loQueryInsertCas.ExecuteNonQuery();

      return true;
    }

    public bool InsertList(List<CodeAnalysisInfo> loInfos)
    {
      Context.Open();
      ioTransaction = Context.BeginTransaction();
      try
      {
        loInfos.ForEach((info) =>
        {
          this.Insert(info);
        });
        ioTransaction.Commit();
      }
      catch (Exception e)
      {
        ioTransaction.Rollback();
        throw e;
      }
      finally
      {
        Context.Close();
      }

      return true;
    }

    public DateTime? DataAtual
    {
      get
      {
        if (IdtDataAtual == null)
        {
          DateTime? ldtDataAtual = null;
          try
          {
            var loQueryDataAtual = Context.CreateCommand();
            loQueryDataAtual.CommandText = Queries.DataAtual;

            loQueryDataAtual.CommandType = CommandType.Text;
            using (var reader = loQueryDataAtual.ExecuteReader())
            {
              reader.Read();
              ldtDataAtual = reader.GetDateTime(0);
            }

          }
          catch (Exception e)
          {
            ldtDataAtual = DateTime.Now;
          }
          IdtDataAtual = ldtDataAtual;
        }

        return IdtDataAtual;
      }
    }
  }
}
