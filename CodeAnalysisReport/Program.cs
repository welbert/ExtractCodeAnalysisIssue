using CodeAnalysisReport.Common;
using CodeAnalysisReport.Database;
using CodeAnalysisReport.lib;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
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
        
        var services = new ServiceCollection();


        /* Configuração */
        var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile(options.ConfigFile ?? "appsettings.json", optional: true, reloadOnChange: true);

        IConfiguration configuration = builder.Build();

        //Para adicionar a configuração como serviço
        //Por ex: Colocar um IConfiguration no construtor de SaveCodeAnalysisInfo
        //services.AddSingleton(configuration);

        /* Contexto do EF Core */
        services.AddDbContext<ReportDbContext>(o => o.UseSqlServer(configuration.GetConnectionString("Default")));

        /* O próprio SaveCodeAnalysisInfo */
        services.AddTransient<SaveCodeAnalysisInfo>();

        var serviceProvider = services.BuildServiceProvider();

        //Get issues
        List<CodeAnalysisInfo> loCodeAnalysisInfo = GetListCodeAnalysisInfo(options);

        //Insert Issues
        serviceProvider.GetService<SaveCodeAnalysisInfo>()
          .InsertList(loCodeAnalysisInfo);
      }
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
