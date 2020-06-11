using FluentMigrator;
using System;

namespace Tawjeeh.DbMigration
{
    [DbTawjeehMigration(author: "Moises B. Bas", branchNumber: 01, year: 2018, month: 4, day: 18)]
    public class _7_CreateCampaignAndGoal : ForwardOnlyMigration
    {
        public override void Up()
        {              

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
        }        
    }
}
