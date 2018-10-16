using CommandLine;
using CommandLine.Text;

namespace CodeAnalysisReport.Common
{
  class Args
  {
    [Option('p', "project", Required = true,
    HelpText = "Nome do projeto que será analisado. Ex: Sagres Acadêmico")]
    public string Projeto { get; set; }

    [Option('s', "solution", Required = true,
    HelpText = "Nome da solução que será analisada. Ex: WebApp")]
    public string Solution { get; set; }

    [Option('x', "xmlfile", Required = false,
    HelpText = "Arquivo xml a ser interpretado.")]
    public string XMLFile { get; set; }

    [Option('d', "xmlpath", Required = false,
    HelpText = "Pasta da solução que contem os xml's a serem interpretados.")]
    public string XMLPath { get; set; }

    [Option('c', "configfile", Required = false,
    HelpText = "Caminho do arquivo de configuração que será usado pela aplicação. " +
      "Caso nenhum seja especificado, será utilizado o AppSettings.json da raiz o .exe")]
    public string ConfigFile { get; set; }

    [HelpOption]
    public string GetUsage()
    {
      return HelpText.AutoBuild(this,
        (HelpText current) => HelpText.DefaultParsingErrorsHandler(this, current));
    }
  }
}
