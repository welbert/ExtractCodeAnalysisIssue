using CodeAnalysisReport.Common;
using CodeAnalysisReport.lib;
using System.Collections.Generic;
using System.IO;
using System.Reflection;

namespace CodeAnalysisReport
{
  class Program
  {
    static void Main(string[] args)
    {
      var options = new Args();
      if (CommandLine.Parser.Default.ParseArguments(args, options))
      {
        List<CodeAnalysisInfo> loCodeAnalysisInfo = ReadCodeAnalysisXML.ParseXML(options.Projeto, options.Solution, options.XMLFile);


        //DBTransaction.Instance.CreateConnection("trendsdb01\\desenv2", "pubs", "sagresadm", "sagresadm");
        //TODO: Pegando o caminho errado do projeto
        LoadConfigFile.Instance.Init(Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), @"Settings.config"));
        DBTransaction.Instance.CreateConnection(LoadConfigFile.Instance.GetConnectionString());

        new SaveCodeAnalysisInfo().InsertList(loCodeAnalysisInfo);
      }
    }
  }

}
