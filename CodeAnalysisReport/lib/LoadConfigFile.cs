using System.IO;
using System.Xml;

namespace CodeAnalysisReport.lib
{
  class LoadConfigFile
  {
    #region Instance
    private static LoadConfigFile instance;
    public static LoadConfigFile Instance
    {
      get
      {
        if (instance == null)
        {
          instance = new LoadConfigFile();
        }
        return instance;
      }
    }
    #endregion

    public XmlDocument ConfigXML { get; internal set; }

    public void Init(string asConfigFilePath)
    {
      ConfigXML = new XmlDocument();
      ConfigXML.LoadXml(File.ReadAllText(asConfigFilePath));
    }

    public string GetConnectionString()
    {
      string lsConnectionString = string.Empty;
      XmlNodeList nodeList = ConfigXML.GetElementsByTagName("Connection");
      foreach (XmlNode item in nodeList[0].ChildNodes)
      {
        lsConnectionString += item.Attributes["Key"].Value + "='" + item.Value + "'";
      }

      return GetConnectionString();
    }

  }
}
