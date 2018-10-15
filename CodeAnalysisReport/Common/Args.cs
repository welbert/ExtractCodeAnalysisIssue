using CommandLine;
using CommandLine.Text;

namespace CodeAnalysisReport.Common
{
  class Args
  {
    [Option('p', "project", Required = true,
    HelpText = "Nome do projeto que será analisado.Ex: Sagres Acadêmico")]
    public string Projeto { get; set; }

    [Option('s', "solution", Required = true,
    HelpText = "Nome da solução que será analisada.Ex: WebApp")]
    public string Solution { get; set; }

    [Option('x', "xmlfile", Required = true,
    HelpText = "Arquivo xml a ser interpretado.")]
    public string XMLFile { get; set; }

    [HelpOption]
    public string GetUsage()
    {
      return HelpText.AutoBuild(this,
        (HelpText current) => HelpText.DefaultParsingErrorsHandler(this, current));
    }
  }
}
