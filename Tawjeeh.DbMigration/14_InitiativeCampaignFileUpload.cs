using FluentMigrator;
using System;

namespace Tawjeeh.DbMigration
{
    [DbTawjeehMigration(author: "Moises B. Bas", branchNumber: 01, year: 2018, month: 5, day: 03)]
    public class _14_InitiativeCampaignFileUpload : Migration
    {
        public override void Down()
        {
            Delete.Column("Result").FromTable("tblInitiativeCampaign").InSchema("dbo");
            Delete.Column("EvidenceResult").FromTable("tblInitiativeCampaign").InSchema("dbo");
            Delete.Column("EvidenceName").FromTable("tblInitiativeCampaign").InSchema("dbo");
        }
        public override void Up()
        {
            Create.Column("Result").OnTable("tblInitiativeCampaign").AsString(Int32.MaxValue).Nullable();
            Create.Column("EvidenceResult").OnTable("tblInitiativeCampaign").AsString(Int32.MaxValue).Nullable();
            Create.Column("EvidenceName").OnTable("tblInitiativeCampaign").AsString(Int32.MaxValue).Nullable();
        }
    }
}
