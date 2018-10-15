using CommandLine;
using CommandLine.Text;

namespace CodeAnalysisReport.Common
{
  class Args
  {
    [Option('p', "project", Required = true,
    HelpText = "Nome do projeto que será analisado.")]
    public string Projeto { get; set; }

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
