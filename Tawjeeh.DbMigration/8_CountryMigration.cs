using FluentMigrator;

namespace Tawjeeh.DbMigration
{
    [DbTawjeehMigration(author: "Moises B. Bas", branchNumber: 02, year: 2018, month: 4, day: 17)]
    public class _8_CountryMigration : Migration
    {
        public override void Down()
        {
            Delete.Table("tblCountry]");
        }

        public override void Up()
        {
            //Execute.DropTableIfExists("tblCountry]");
            Execute.EmbeddedScript("CountryMigrateData18042018.sql");
        }
    }
}
