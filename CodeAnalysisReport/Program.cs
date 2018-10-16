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

        if (options.ConfigFile == null)
          options.ConfigFile = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), @"AppSettings.json");

        ConfigFile.Instance.Init(options.ConfigFile);

        DBTransaction.Instance.CreateConnection(ConfigFile.Instance.GetConnectionString());

        new SaveCodeAnalysisInfo().InsertList(loCodeAnalysisInfo);
      }
    }
  }

}
