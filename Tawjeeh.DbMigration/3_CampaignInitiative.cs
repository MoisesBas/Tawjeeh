using FluentMigrator;
using System;

namespace Tawjeeh.DbMigration
{
    [DbTawjeehMigration(author: "Moises B. Bas", branchNumber: 01, year: 2018, month: 4, day: 14)]
    public class _3_CampaignInitiative : ForwardOnlyMigration
    {
        public override void Up()
        {
            Execute.DropTableIfExists("tblCampaign");
            Execute.DropTableIfExists("tblGoal");
            
            this.CreateTableIfNotExists("tblCampaignDocument",
                 table => table.InSchema("dbo")
                .WithColumn("Id").AsInt64().Identity().NotNullable().PrimaryKey()
                .WithColumn("CampaignId").AsInt64().Nullable()
                .WithColumn("InitiativeId").AsInt64().Nullable()
                .WithColumn("DocumentTitle").AsString(Int32.MaxValue).Nullable()
                .WithColumn("DocumentPath").AsString(Int32.MaxValue).Nullable()
                .WithColumn("IsActive").AsBoolean().Nullable()
                .WithColumn("IsDeleted").AsBoolean().Nullable()
                .WithColumn("CreatedOn").AsDateTime().Nullable()
                .WithColumn("CreatedBy").AsInt64().Nullable()
                .WithColumn("UpdatedOn").AsDateTime().Nullable()
                .WithColumn("UpdatedBy").AsInt64().Nullable());

            this.CreateTableIfNotExists("tblInitiative",
           table => table.InSchema("dbo")
               .WithColumn("Id").AsInt64().Identity().NotNullable().PrimaryKey()
               .WithColumn("InitiativeTypeId").AsInt64().Nullable()
               .WithColumn("Title").AsString(150).Nullable()
               .WithColumn("Description").AsString(Int32.MaxValue).Nullable()
               .WithColumn("IsActive").AsBoolean().Nullable()
               .WithColumn("IsDeleted").AsBoolean().Nullable()
               .WithColumn("CreatedOn").AsDateTime().Nullable()
               .WithColumn("CreatedBy").AsInt64().Nullable()
               .WithColumn("UpdatedOn").AsDateTime().Nullable()
               .WithColumn("UpdatedBy").AsInt64().Nullable());

            this.CreateTableIfNotExists("tblInitiativeCampaign",
            table => table.InSchema("dbo")
                .WithColumn("Id").AsInt64().Identity().NotNullable().PrimaryKey()
                .WithColumn("CampaignId").AsInt64().Nullable()
                .WithColumn("InitiativeId").AsInt64().Nullable()
                .WithColumn("StartDate").AsDateTime().Nullable()
                .WithColumn("EndDate").AsDateTime().Nullable()
                .WithColumn("Description").AsString(Int32.MaxValue).Nullable()
                .WithColumn("Target").AsString(Int32.MaxValue).Nullable()
                .WithColumn("IsActive").AsBoolean().Nullable()
                .WithColumn("IsDeleted").AsBoolean().Nullable()
                .WithColumn("CreatedOn").AsDateTime().Nullable()
                .WithColumn("CreatedBy").AsInt64().Nullable()
                .WithColumn("UpdatedOn").AsDateTime().Nullable()
                .WithColumn("UpdatedBy").AsInt64().Nullable());

            this.CreateTableIfNotExists("tblInitiativeType",
            table => table.InSchema("dbo")
                .WithColumn("Id").AsInt64().Identity().NotNullable().PrimaryKey()
                .WithColumn("Description").AsString(150).Nullable()
                .WithColumn("IsActive").AsBoolean().Nullable()
                .WithColumn("IsDeleted").AsBoolean().Nullable()
                .WithColumn("CreatedOn").AsDateTime().Nullable()
                .WithColumn("CreatedBy").AsInt64().Nullable()
                .WithColumn("UpdatedOn").AsDateTime().Nullable()
                .WithColumn("UpdatedBy").AsInt64().Nullable());            

            this.CreateTableIfNotExists("tblCampaign",
                 table => table.InSchema("dbo")
                             .WithColumn("Id").AsInt64().Identity().NotNullable().PrimaryKey()
                             .WithColumn("Title").AsString(150).NotNullable()
                             .WithColumn("FromDate").AsDateTime().NotNullable()
                             .WithColumn("ToDate").AsDateTime().NotNullable()
                             .WithColumn("Target").AsInt32().NotNullable()
                             .WithColumn("CampaignStatus").AsInt32().NotNullable()
                             .WithColumn("Budget").AsInt64().Nullable()
                             .WithColumn("IsActive").AsBoolean().Nullable()
                             .WithColumn("IsDeleted").AsBoolean().Nullable()
                             .WithColumn("CreatedOn").AsDateTime().Nullable()
                             .WithColumn("CreatedBy").AsInt64().Nullable()
                             .WithColumn("UpdatedOn").AsDateTime().Nullable()
                             .WithColumn("UpdatedBy").AsInt64().Nullable());

            this.CreateTableIfNotExists("tblGoal",
           table => table.InSchema("dbo")
               .WithColumn("Id").AsInt64().Identity().NotNullable().PrimaryKey()
               .WithColumn("CampaignId").AsInt64().NotNullable()
               .WithColumn("Objective").AsString(Int32.MaxValue).Nullable()
               .WithColumn("Target").AsString(Int32.MaxValue).Nullable()
               .WithColumn("Actual").AsString(Int32.MaxValue).Nullable()
               .WithColumn("IsActive").AsBoolean().Nullable()
               .WithColumn("IsDeleted").AsBoolean().Nullable()
               .WithColumn("CreatedOn").AsDateTime().Nullable()
               .WithColumn("CreatedBy").AsInt64().Nullable()
               .WithColumn("UpdatedOn").AsDateTime().Nullable()
               .WithColumn("UpdatedBy").AsInt64().Nullable());

            //Alter Column Contact Type
            Alter.Column("Name").OnTable("tblContactType").AsString(50).Nullable();
            Alter.Column("Description").OnTable("tblContactType").AsString(50).Nullable();
            //drop stored procedure
            Execute.DropSPIfExists("Dashbord");
            Execute.DropSPIfExists("DeleteArticles");
            Execute.DropSPIfExists("DeleteArticlesTrans");
            Execute.DropSPIfExists("DeleteDecision");
            Execute.DropSPIfExists("DeleteDecisionTrans");
            Execute.DropSPIfExists("DeleteLaws");
            Execute.DropSPIfExists("spDeleteCampaign");
            Execute.DropSPIfExists("spDeleteInitiative");
            Execute.DropSPIfExists("spGetAllByLangId");
            Execute.DropSPIfExists("spGetAllCenters");
            Execute.DropSPIfExists("spGetAllCentersByEmiratesId");
            Execute.DropSPIfExists("spGetCentersAllByLangId");
            Execute.DropSPIfExists("spGetDecisionAll");
            Execute.DropSPIfExists("spGetDecisionByArticleId");
            Execute.DropSPIfExists("spGetDecisionByArticleIdAndLangId");
            Execute.DropSPIfExists("spGetDecisionLangIdAndId");
            //drop views
            Execute.DropViewsIfExists("vwSearchMobile");
            Execute.EmbeddedScript("Tawjeeh_StoredProcedure04142018.sql");
            Execute.EmbeddedScript("SearchMobile_04142018.sql");
        }        
    }
}
