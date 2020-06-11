using FluentMigrator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tawjeeh.DbMigration
{
    [DbTawjeehMigration(author: "Moises B. Bas", branchNumber: 01, year: 2018, month: 5, day: 05)]
    public class _15_Dashboard05052018: Migration
    {
        public override void Down()
        {
            Execute.EmbeddedScript("Dashboard28042018.sql");
        }
        public override void Up()
        {
            Execute.EmbeddedScript("Dashboard05052018.sql");
        }
    }
}
