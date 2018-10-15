namespace CodeAnalysisReport.Common
{
  class CodeAnalysisInfo
  {
    public string Project { get; set; }
    public string Solution { get; set; }
    public string Severity { get; set; }
    public string Code { get; set; }
    public string Description { get; set; }
    public string Dll { get; set; }
    public string File { get; set; }
    public int Line { get; set; }

    public CodeAnalysisInfo(string project, string solution, string severity, string code, string description, string dll, string file, int line)
    {
      Project = project;
      Solution = solution;
      Severity = severity;
      Code = code;
      Description = description;
      Dll = dll;
      File = file;
      Line = line;
    }
  }
}
