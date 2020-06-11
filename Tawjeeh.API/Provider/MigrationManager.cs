using FluentMigrator.Runner.Initialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Tawjeeh.Api.Provider
{
    public static class MigrationManager
    {
        public static bool Migrate()
        {
        //    var ctx = new RunnerContext(new FluentMigrator.Runner.Announcers.NullAnnouncer())
        //    {
        //        ApplicationContext = string.Empty,
        //        Database = "sqlite", // the database type as you would configure in msbuild.
        //        Connection = Constants.CONNECTION_STRING,
        //        Target = "Demo.Core" // the assembly name that contains your migrations.
        //    };

        //    try
        //    {
        //        var executor = new TaskExecutor(ctx);
        //        executor.Execute();
        //    }
        //    catch (Exception ex)
        //    {
        //        return false;
        //    }

           return true;
        }
    }
}