using System;
using System.Data.SqlClient;

namespace CodeAnalysisReport.lib
{
  public class DBTransaction
  {
    #region Instance
    private static DBTransaction instance;
    public static DBTransaction Instance
    {
      get
      {
        if (instance == null)
        {
          instance = new DBTransaction();
        }
        return instance;
      }
    }
    #endregion

    public SqlConnection Connection { get; internal set; }

    public void CreateConnection(string asServer, string asUser, string asPassword)
    {
      SqlConnection loConnection = new SqlConnection(
        String.Format("Data Source='{0}';User ID='{1}';Password={2}",
                                    asServer, asUser, asPassword));
      loConnection.Open();
      loConnection.Close();
      this.Connection = loConnection;
    }
  }
}
