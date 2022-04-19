using System;
using MySql.Data.MySqlClient;

namespace WebApi.Controllers {
  public class MySqlDatabase : IDisposable {
    public MySqlConnection Connection;
    public MySqlDatabase(string connectionString) {
      Connection = new MySqlConnection(connectionString);
      Connection.Open();
    }

    public void Dispose() { Connection.Close(); }
  }
}
