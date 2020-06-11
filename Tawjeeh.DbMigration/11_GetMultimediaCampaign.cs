namespace Tawjeeh.DbMigration
{
    [DbTawjeehMigration(author: "Moises B. Bas", branchNumber: 01, year: 2018, month: 4, day: 24)]
    public  class _11_GetMultimediaCampaign:FluentMigrator.ForwardOnlyMigration
    {
        public override void Up()
        {
            Execute.EmbeddedScript("spGetMultimediaCampaign.sql");
        }
    }
}
