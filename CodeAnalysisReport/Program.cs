using CodeAnalysisReport.Common;
using CodeAnalysisReport.lib;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
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
        if (options.XMLFile == null && options.XMLPath == null)
        {
          Console.Write("É necessário informar o xml ou a pasta que contem o xml a ser interpretado. Verifique em --help");
          Environment.Exit(0);
        }

        List<CodeAnalysisInfo> loCodeAnalysisInfo = GetListCodeAnalysisInfo(options);

        InitConfigFile(options);


        DBTransaction.Instance.CreateConnection(ConfigFile.Instance.GetConnectionString());

        new SaveCodeAnalysisInfo().InsertList(loCodeAnalysisInfo);
      }
    }

    private static void InitConfigFile(Args options)
    {
      if (options.ConfigFile == null)
        options.ConfigFile = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), @"AppSettings.json");

      ConfigFile.Instance.Init(options.ConfigFile);
    }

    private static List<CodeAnalysisInfo> GetListCodeAnalysisInfo(Args options)
    {
      List<string> lsXmlFiles = new List<string>();

      if (options.XMLPath != null)
        lsXmlFiles = Directory.GetFiles(options.XMLPath, "*CodeAnalysisLog.xml", SearchOption.AllDirectories).ToList();

      if (options.XMLFile != null)
        lsXmlFiles.Add(options.XMLFile);

      List<CodeAnalysisInfo> loCodeAnalysisInfo = new List<CodeAnalysisInfo>();
      lsXmlFiles.ForEach((lsXmlFile) =>
      {
        loCodeAnalysisInfo.AddRange(ReadCodeAnalysisXML.ParseXML(options.Projeto, options.Solution, lsXmlFile));
      });

      return loCodeAnalysisInfo;
    }
  }

}
