using CodeAnalysisReport.Common;
using CodeAnalysisReport.lib;
using System.Collections.Generic;

namespace CodeAnalysisReport
{
  class Program
  {
    static void Main(string[] args)
    {
      var options = new Args();
      if (CommandLine.Parser.Default.ParseArguments(args, options))
      {
        List<CodeAnalysisInfo> loCodeAnalysisInfo = ReadCodeAnalysisXML.ParseXML(options.Projeto, options.XMLFile);

        DBTransaction.Instance.CreateConnection("trendsdb01\\desenv2", "sagresadm", "sagresadm");

        new SaveCodeAnalysisInfo().InsertList(loCodeAnalysisInfo);
      }
    }
  }

}
