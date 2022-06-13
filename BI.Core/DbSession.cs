using System;
using System.Data;
using System.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using Npgsql;

namespace BI.Core;

public class DbSession : IDisposable
{
    private Guid _id;
    public IDbConnection Connection { get; }
    public IDbTransaction Transaction { get; set; }

    private IConfiguration _configuration;
    public DbSession(IConfiguration configuration)
    {
        _id = Guid.NewGuid();
        _configuration = configuration;
        var conString = _configuration.GetSection("Connections:SqlCommandConnection").Value;
        Connection = new NpgsqlConnection(conString);
        Connection.Open();
    }

    public void Dispose() => Connection?.Dispose();
}