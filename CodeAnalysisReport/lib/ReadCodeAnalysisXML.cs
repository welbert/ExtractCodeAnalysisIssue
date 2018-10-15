using CodeAnalysisReport.Common;
using System;
using System.Collections.Generic;
using System.IO;
using System.Xml;

namespace CodeAnalysisReport.lib
{
  class ReadCodeAnalysisXML
  {
    public static List<CodeAnalysisInfo> ParseXML(string asProjeto, string asSolution, string asXMLFilePath)
    {
      List<CodeAnalysisInfo> loCodeAnalysisInfo = new List<CodeAnalysisInfo>();
      XmlDocument CodeAnalysisXML = new XmlDocument();
      CodeAnalysisXML.LoadXml(File.ReadAllText(asXMLFilePath));
      XmlNodeList nodeList = CodeAnalysisXML.GetElementsByTagName("Issue");
      foreach (XmlNode node in nodeList)
      {
        loCodeAnalysisInfo.Add(
          new CodeAnalysisInfo(
            asProjeto,
            asSolution,
            node.Attributes["Level"].Value,
            node.ParentNode.Attributes["CheckId"].Value,
            node.InnerText,
            CodeAnalysisXML.GetElementsByTagName("Module")[0].Attributes["Name"].Value,
            node.Attributes["Path"] != null ? node.Attributes["Path"].Value + "\\" + node.Attributes["File"].Value : "--",
            node.Attributes["Line"] != null ? Convert.ToInt32(node.Attributes["Line"].Value) : 0
           )
         );
      }

      return loCodeAnalysisInfo;
    }
  }
}
