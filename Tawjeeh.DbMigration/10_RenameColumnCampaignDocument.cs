using FluentMigrator;

namespace Tawjeeh.DbMigration
{
    [DbTawjeehMigration(author: "Moises B. Bas", branchNumber: 01, year: 2018, month: 4, day: 22)]
    public class _10_RenameColumnCampaignDocument: Migration
    {
        public override void Up()
        {
            Rename.Column("InitiativeId").OnTable("tblCampaignDocument").To("CampaignDetailsId");
        }

        public override void Down()
        {
            Rename.Column("CampaignDetailsId").OnTable("tblCampaignDocument").To("InitiativeId");
        }
    }
}
