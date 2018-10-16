﻿using Microsoft.Extensions.Configuration;
using System.Linq;

namespace CodeAnalysisReport.lib
{
  class ConfigFile
  {
    #region Instance
    private static ConfigFile instance;
    public static ConfigFile Instance
    {
      get
      {
        if (instance == null)
        {
          instance = new ConfigFile();
        }
        return instance;
      }
    }
    #endregion

    public IConfigurationRoot Configuration { get; internal set; }

    public void Init(string asConfigFilePath)
    {
      Configuration = new ConfigurationBuilder()
          .AddJsonFile(asConfigFilePath)
          .Build();
    }

    public string GetConnectionString()
    {
      string lsConnectionString = string.Empty;
      Configuration.GetSection("connection").GetChildren().ToList().ForEach((paramater) =>
      {
        lsConnectionString += paramater.Key + "='" + paramater.Value + "';";
      });
      return lsConnectionString;
    }

  }
}
