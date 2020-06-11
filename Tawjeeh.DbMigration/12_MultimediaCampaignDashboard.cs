using FluentMigrator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tawjeeh.DbMigration
{
    [DbTawjeehMigration(author: "Moises B. Bas", branchNumber: 01, year: 2018, month: 4, day: 28)]
    public class _12_MultimediaCampaignDashboard : Migration
    {
        public override void Up()
        {
            Execute.EmbeddedScript("Dashboard28042018.sql");
            Execute.EmbeddedScript("spGetMultimediaCampaign28042018.sql");
        }
        public override void Down()
        {
            Execute.EmbeddedScript("Dashboard.sql");
            Execute.EmbeddedScript("spGetMultimediaCampaign.sql");
        }
    }
}
