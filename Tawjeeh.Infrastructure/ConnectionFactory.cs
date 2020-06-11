using StackExchange.Profiling;
using System.Configuration;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;

namespace Tawjeeh.Infrastructure
{
    public class ConnectionFactory : IConnectionFactory
    {

        private readonly string connectionString = ConfigurationManager.ConnectionStrings["TawjeehConnection"].ConnectionString;
        public IDbConnection GetConnection
        {
            get
            {
                var factory = DbProviderFactories.GetFactory("System.Data.SqlClient");
                var conn = factory.CreateConnection();
                conn.ConnectionString = connectionString;
                conn.Open();
                return conn;
               // return new StackExchange.Profiling.Data.ProfiledDbConnection(conn,MiniProfiler.Current);
            }
        }

        #region IDisposable Support
        private bool disposedValue = false; 

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    
                }               

                disposedValue = true;
            }
        }
               
        public void Dispose()
        {           
            Dispose(true);           
        }
        #endregion

    }
}
