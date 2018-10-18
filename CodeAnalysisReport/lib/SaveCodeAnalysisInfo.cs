using CodeAnalysisReport.Common;
using CodeAnalysisReport.Database;
using CodeAnalysisReport.Database.Model;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace CodeAnalysisReport.lib
{
  class SaveCodeAnalysisInfo
  {
    ReportDbContext _dbContext;
    DateTime _dataAtual = DateTime.Now;

    public SaveCodeAnalysisInfo(ReportDbContext dbContext)
    {
      _dbContext = dbContext;
    }

    private void Insert(CodeAnalysisInfo loInfo)
    {
      _dbContext.CodeAnalysis.Add(new CodeAnalysis
      {
        Projeto = loInfo.Project,
        Solution = loInfo.Solution,
        Severidade = loInfo.Severity,
        Codigo = loInfo.Code,
        Descricao = loInfo.Description,
        Dll = loInfo.Dll,
        CaminhoArquivo = loInfo.File,
        LinhaCodigo = loInfo.Line,
        DataExecucao = _dataAtual
      });
    }

    public void InsertList(List<CodeAnalysisInfo> loInfos)
    {
      loInfos.ForEach((info) =>
      {
        this.Insert(info);
      });

      _dbContext.SaveChanges();
    }
  }
}
