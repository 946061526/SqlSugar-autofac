using SqlSugar;

namespace SqlSugarDao
{
    public class DbFactory
    {
        private static SqlSugarClient _db = null;

        public static SqlSugarClient GetSqlSugarClient()
        {
            _db = new SqlSugarClient(
              new ConnectionConfig()
              {
                  ConnectionString = "Data Source=.;Initial Catalog=hy;Persist Security Info=True;User ID=sa;Password=sa123!@#;",
                  DbType = DbType.SqlServer,
                  IsAutoCloseConnection = true
              }
          );
            return _db;
        }
    }
}
