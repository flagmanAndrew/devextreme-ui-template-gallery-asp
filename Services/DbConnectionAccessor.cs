using DevExtremeVSTemplateMVC.Utils;
using Microsoft.Data.Sqlite;

namespace DevExtremeVSTemplateMVC.Services
{
    public interface IDbConnectionAccessor
    {
        SqliteConnection GetConnection();
    }

    public class DbConnectionAccessor : IDbConnectionAccessor
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public DbConnectionAccessor(IHttpContextAccessor accessor) {
            _httpContextAccessor = accessor;
        }

        public SqliteConnection GetConnection() {
            SqliteConnection mainConnection = _httpContextAccessor.HttpContext?.Items["SqliteConnection"] as SqliteConnection;
            return new SqliteConnection(mainConnection.ConnectionString);
        }
    }
}
