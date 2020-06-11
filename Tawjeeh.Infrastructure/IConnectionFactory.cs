using System;
using System.Data;
using System.Data.SqlClient;

namespace Tawjeeh.Infrastructure
{
    public interface IConnectionFactory 
    {
        IDbConnection GetConnection { get; }
    }
}
