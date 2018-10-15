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

    public void CreateConnection(string asServer, string asDatabaseName, string asUser, string asPassword)
    {
      SqlConnection loConnection = new SqlConnection(
        String.Format("Data Source='{0}';Database='{1}';User ID='{2}';Password={3}",
                                    asServer, asDatabaseName, asUser, asPassword));
      loConnection.Open();
      loConnection.Close();
      this.Connection = loConnection;
    }

    public void CreateConnection(string asConnectionString)
    {
      SqlConnection loConnection = new SqlConnection(asConnectionString);
      loConnection.Open();
      loConnection.Close();
      this.Connection = loConnection;
    }
  }
}
