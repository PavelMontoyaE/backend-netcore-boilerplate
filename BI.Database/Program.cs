using System;
using System.IO;
using System.Reflection;
using DbUp;
using DbUp.Postgresql;
using Microsoft.Extensions.Configuration;

namespace BI.Database;

class Program {
    private static string _schema = "database";

    static int Main(string[] args)
    {
        var env = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");
        var config = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json")
            .AddJsonFile($"appsettings.{env}.json")
            .Build();

        var connectionString = config["Connections:SqlCommandConnection"];

        var builder = DeployChanges.To
            .PostgresqlDatabase(connectionString)
            .WithScriptsEmbeddedInAssembly(Assembly.GetExecutingAssembly())
            .WithTransactionPerScript()
            .WithExecutionTimeout(TimeSpan.FromMinutes(10))
            .LogToConsole();
        
        builder.Configure(c => c.Journal = new PostgresqlTableJournal(() => c.ConnectionManager, () => c.Log, _schema, "schemaversions"));
        var upgrader = builder.Build();

#if DEBUG
        EnsureDatabase.For.PostgresqlDatabase(connectionString);
#endif

        var result = upgrader.PerformUpgrade();

        if (!result.Successful)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(result.Error);
            Console.ResetColor();
                
#if DEBUG
            Console.ReadLine();
#endif
                
            return -1;
        }
        
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine(result.Successful);
        Console.ResetColor();
                
#if DEBUG
        Console.ReadLine();
#endif

        return 0;
    }
}