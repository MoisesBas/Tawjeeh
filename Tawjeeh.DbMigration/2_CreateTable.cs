using FluentMigrator;

namespace Tawjeeh.DbMigration
{
    
    //[DbTawjeehMigration(author: "Moises B. Bas", branchNumber: 01, year: 2018, month: 4, day: 13)]
    public class _2_CreateTable : ForwardOnlyMigration
    {
        public override void Up()
        {

            //#region Create Table
            //this.CreateTableIfNotExists("tblAccessControls",
            //        table => table.InSchema("dbo")
            //                  .WithColumn("Id").AsInt64().Identity().NotNullable().PrimaryKey()
            //                  .WithColumn("UserId").AsInt64().Nullable()
            //                  .WithColumn("MenuId").AsInt64().Nullable()
            //                  .WithColumn("IsActive").AsBoolean().Nullable()
            //                  .WithColumn("IsDeleted").AsBoolean().Nullable()
            //                  .WithColumn("IsAllowed").AsBoolean().Nullable()
            //                  .WithColumn("CreatedOn").AsDateTime().Nullable()
            //                  .WithColumn("CreatedBy").AsInt64().Nullable()
            //                  .WithColumn("UpdatedOn").AsDateTime().Nullable()
            //                  .WithColumn("UpdatedBy").AsInt64().Nullable());

            //this.CreateTableIfNotExists("tblArticle",
            //        table => table.InSchema("dbo")
            //                  .WithColumn("Id").AsInt64().Identity().NotNullable().PrimaryKey()
            //                  .WithColumn("Name").AsString(150).Nullable()
            //                  .WithColumn("Description").AsCustom("NTEXT").Nullable()
            //                  .WithColumn("LawId").AsInt64().Nullable()
            //                  .WithColumn("ArticleNo").AsString(100).Nullable()
            //                  .WithColumn("IsActive").AsBoolean().Nullable()
            //                  .WithColumn("IsDeleted").AsBoolean().Nullable()
            //                  .WithColumn("CreatedOn").AsDateTime().Nullable()
            //                  .WithColumn("CreatedBy").AsInt64().Nullable()
            //                  .WithColumn("UpdatedOn").AsDateTime().Nullable()
            //                  .WithColumn("UpdatedBy").AsInt64().Nullable());

            //this.CreateTableIfNotExists("tblArticleMultimedia",
            //        table => table.InSchema("dbo")
            //                  .WithColumn("Id").AsInt64().Identity().NotNullable().PrimaryKey()
            //                  .WithColumn("ArticleId").AsInt64().Nullable()
            //                  .WithColumn("LangId").AsInt32().Nullable()
            //                  .WithColumn("FileName").AsString(150).Nullable()
            //                  .WithColumn("FileUrl").AsString(Int32.MaxValue).Nullable()
            //                  .WithColumn("VideoUrl").AsString(Int32.MaxValue).Nullable()
            //                  .WithColumn("FileType").AsInt32().Nullable()
            //                  .WithColumn("CntLikes").AsInt64().Nullable()
            //                  .WithColumn("CntDisLikes").AsInt64().Nullable()
            //                  .WithColumn("CntViews").AsInt64().Nullable()
            //                  .WithColumn("Description").AsCustom("TEXT").Nullable()
            //                  .WithColumn("IsMobile").AsBoolean().Nullable()
            //                  .WithColumn("IsActive").AsBoolean().Nullable()
            //                  .WithColumn("IsDeleted").AsBoolean().Nullable()
            //                  .WithColumn("CreatedOn").AsDateTime().Nullable()
            //                  .WithColumn("CreatedBy").AsInt64().Nullable()
            //                  .WithColumn("UpdatedOn").AsDateTime().Nullable()
            //                  .WithColumn("UpdatedBy").AsInt64().Nullable());

            //this.CreateTableIfNotExists("tblArticleTrans",
            //        table => table.InSchema("dbo")
            //                  .WithColumn("Id").AsInt64().Identity().NotNullable().PrimaryKey()
            //                  .WithColumn("Name").AsString(150).Nullable()
            //                  .WithColumn("Description").AsCustom("NTEXT").Nullable()
            //                  .WithColumn("ArticleId").AsInt64().Nullable()
            //                  .WithColumn("ArticleNo").AsString(100).Nullable()
            //                  .WithColumn("LangId").AsInt32().Nullable()
            //                  .WithColumn("IsActive").AsBoolean().Nullable()
            //                  .WithColumn("IsDeleted").AsBoolean().Nullable()
            //                  .WithColumn("CreatedOn").AsDateTime().Nullable()
            //                  .WithColumn("CreatedBy").AsInt64().Nullable()
            //                  .WithColumn("UpdatedOn").AsDateTime().Nullable()
            //                  .WithColumn("UpdatedBy").AsInt64().Nullable());

            //this.CreateTableIfNotExists("tblCampaign",
            //     table => table.InSchema("dbo")
            //                 .WithColumn("Id").AsInt64().Identity().NotNullable().PrimaryKey()
            //                 .WithColumn("Title").AsString(150).NotNullable()
            //                 .WithColumn("FromDate").AsDateTime().NotNullable()
            //                 .WithColumn("ToDate").AsDateTime().NotNullable()
            //                 .WithColumn("Target").AsInt32().NotNullable()
            //                 .WithColumn("CampaignStatus").AsInt32().NotNullable()
            //                 .WithColumn("Budget").AsInt64().Nullable()
            //                 .WithColumn("IsActive").AsBoolean().Nullable()
            //                 .WithColumn("IsDeleted").AsBoolean().Nullable()
            //                 .WithColumn("CreatedOn").AsDateTime().Nullable()
            //                 .WithColumn("CreatedBy").AsInt64().Nullable()
            //                 .WithColumn("UpdatedOn").AsDateTime().Nullable()
            //                 .WithColumn("UpdatedBy").AsInt64().Nullable());

            //this.CreateTableIfNotExists("tblCampaignDetails",
            //     table => table.InSchema("dbo")
            //    .WithColumn("Id").AsInt64().Identity().NotNullable().PrimaryKey()
            //    .WithColumn("CampaignId").AsInt64().Nullable()
            //    .WithColumn("Type").AsInt32().Nullable()
            //    .WithColumn("SubTypeId").AsInt64().Nullable()
            //    .WithColumn("MultimediaId").AsInt64().Nullable()
            //    .WithColumn("Others").AsString(Int32.MaxValue).Nullable()
            //    .WithColumn("IsActive").AsBoolean().Nullable()
            //    .WithColumn("IsDeleted").AsBoolean().Nullable()
            //    .WithColumn("CreatedOn").AsDateTime().Nullable()
            //    .WithColumn("CreatedBy").AsInt64().Nullable()
            //    .WithColumn("UpdatedOn").AsDateTime().Nullable()
            //    .WithColumn("UpdatedBy").AsInt64().Nullable());

            //this.CreateTableIfNotExists("tblCampaignDocument",
            //     table => table.InSchema("dbo")         
            //    .WithColumn("Id").AsInt64().Identity().NotNullable().PrimaryKey()
            //    .WithColumn("CampaignId").AsInt64().Nullable()
            //    .WithColumn("InitiativeId").AsInt64().Nullable()
            //    .WithColumn("DocumentTitle").AsString(Int32.MaxValue).Nullable()
            //    .WithColumn("DocumentPath").AsString(Int32.MaxValue).Nullable()
            //    .WithColumn("IsActive").AsBoolean().Nullable()
            //    .WithColumn("IsDeleted").AsBoolean().Nullable()
            //    .WithColumn("CreatedOn").AsDateTime().Nullable()
            //    .WithColumn("CreatedBy").AsInt64().Nullable()
            //    .WithColumn("UpdatedOn").AsDateTime().Nullable()
            //    .WithColumn("UpdatedBy").AsInt64().Nullable());


            //this.CreateTableIfNotExists("tblCenterContacts",
            //     table => table.InSchema("dbo")
            //    .WithColumn("Id").AsInt64().Identity().NotNullable().PrimaryKey()
            //    .WithColumn("CenterId").AsInt64().Nullable()
            //    .WithColumn("UserId").AsInt64().Nullable()
            //    .WithColumn("ContactTypeId").AsInt32().Nullable()
            //    .WithColumn("IsActive").AsBoolean().Nullable()
            //    .WithColumn("IsDeleted").AsBoolean().Nullable()
            //    .WithColumn("CreatedOn").AsDateTime().Nullable()
            //    .WithColumn("CreatedBy").AsInt64().Nullable()
            //    .WithColumn("UpdatedOn").AsDateTime().Nullable()
            //    .WithColumn("UpdatedBy").AsInt64().Nullable());


            //this.CreateTableIfNotExists("tblCenters",
            //     table => table.InSchema("dbo")
            //    .WithColumn("Id").AsInt64().Identity().NotNullable().PrimaryKey()
            //    .WithColumn("Name").AsString(100).Nullable()
            //    .WithColumn("LocationAddress").AsString(100).Nullable()
            //    .WithColumn("EmiratesId").AsInt64().Nullable()
            //    .WithColumn("TradeLicense").AsString(100).Nullable()
            //    .WithColumn("TradeLicenseExpiryDate").AsDateTime().Nullable()
            //    .WithColumn("FaxNo").AsString(50).Nullable()
            //    .WithColumn("PhoneNo").AsString(50).Nullable()
            //    .WithColumn("WebSite").AsString(50).Nullable()
            //    .WithColumn("Email").AsString(50).Nullable()
            //    .WithColumn("Longitude").AsFloat().Nullable()
            //    .WithColumn("Latitude").AsFloat().Nullable()
            //    .WithColumn("IsActive").AsBoolean().Nullable()
            //    .WithColumn("IsDeleted").AsBoolean().Nullable()
            //    .WithColumn("CreatedOn").AsDateTime().Nullable()
            //    .WithColumn("CreatedBy").AsInt64().Nullable()
            //    .WithColumn("UpdatedOn").AsDateTime().Nullable()
            //    .WithColumn("UpdatedBy").AsInt64().Nullable());

            //this.CreateTableIfNotExists("tblCenterTrans",
            //     table => table.InSchema("dbo")
            //    .WithColumn("Id").AsInt64().Identity().NotNullable().PrimaryKey()
            //    .WithColumn("Name").AsString(100).Nullable()
            //    .WithColumn("LocationAddress").AsString(100).Nullable()
            //    .WithColumn("CenterId").AsInt64().Nullable()
            //    .WithColumn("LangId").AsInt32().Nullable()
            //    .WithColumn("EmiratesId").AsInt64().Nullable()
            //    .WithColumn("TradeLicense").AsString(100).Nullable()
            //    .WithColumn("TradeLicenseExpiryDate").AsDateTime().Nullable()
            //    .WithColumn("FaxNo").AsString(50).Nullable()
            //    .WithColumn("PhoneNo").AsString(50).Nullable()
            //    .WithColumn("WebSite").AsString(50).Nullable()
            //    .WithColumn("Email").AsString(50).Nullable()
            //    .WithColumn("Longitude").AsFloat().Nullable()
            //    .WithColumn("Latitude").AsFloat().Nullable()
            //    .WithColumn("IsActive").AsBoolean().NotNullable()
            //    .WithColumn("IsDeleted").AsBoolean().Nullable()
            //    .WithColumn("CreatedOn").AsDateTime().Nullable()
            //    .WithColumn("CreatedBy").AsInt64().Nullable()
            //    .WithColumn("UpdatedOn").AsDateTime().Nullable()
            //    .WithColumn("UpdatedBy").AsInt64().Nullable());

            //this.CreateTableIfNotExists("tblContactType",
            //     table => table.InSchema("dbo")
            //    .WithColumn("Id").AsInt32().Identity().NotNullable().PrimaryKey()
            //    .WithColumn("Name").AsAnsiString(50).Nullable()
            //    .WithColumn("Description").AsAnsiString(50).Nullable()
            //    .WithColumn("IsActive").AsBoolean().Nullable()
            //    .WithColumn("IsDeleted").AsBoolean().Nullable()
            //    .WithColumn("CreatedOn").AsDateTime().Nullable()
            //    .WithColumn("CreatedBy").AsInt64().Nullable()
            //    .WithColumn("UpdatedOn").AsDateTime().Nullable()
            //    .WithColumn("UpdatedBy").AsInt64().Nullable());

            //this.CreateTableIfNotExists("tblDecision",
            //     table => table.InSchema("dbo")           
            //    .WithColumn("Id").AsInt64().Identity().NotNullable().PrimaryKey()
            //    .WithColumn("Name").AsString(50).Nullable()
            //    .WithColumn("Description").AsCustom("NTEXT").Nullable()
            //    .WithColumn("DecisionNo").AsString(100).Nullable()
            //    .WithColumn("ArticleId").AsInt64().Nullable()
            //    .WithColumn("IsActive").AsBoolean().Nullable()
            //    .WithColumn("IsDeleted").AsBoolean().Nullable()
            //    .WithColumn("CreatedOn").AsDateTime().Nullable()
            //    .WithColumn("CreatedBy").AsInt32().Nullable()
            //    .WithColumn("UpdatedOn").AsDateTime().Nullable()
            //    .WithColumn("UpdatedBy").AsInt32().Nullable());

            //this.CreateTableIfNotExists("tblDecisionMultimedia",
            //table => table.InSchema("dbo")
            //    .WithColumn("Id").AsInt64().Identity().NotNullable().PrimaryKey()
            //    .WithColumn("DecisionId").AsInt64().Nullable()
            //    .WithColumn("LangId").AsInt32().Nullable()
            //    .WithColumn("FileName").AsString(150).Nullable()
            //    .WithColumn("VideoUrl").AsString(Int32.MaxValue).Nullable()
            //    .WithColumn("FileUrl").AsString(Int32.MaxValue).Nullable()
            //    .WithColumn("FileType").AsInt32().Nullable()
            //    .WithColumn("CntLikes").AsInt64().Nullable()
            //    .WithColumn("CntDisLikes").AsInt64().Nullable()
            //    .WithColumn("CntViews").AsInt64().Nullable()
            //    .WithColumn("Description").AsCustom("NTEXT").Nullable()
            //    .WithColumn("IsMobile").AsBoolean().Nullable()
            //    .WithColumn("IsActive").AsBoolean().Nullable()
            //    .WithColumn("IsDeleted").AsBoolean().Nullable()
            //    .WithColumn("CreatedOn").AsDateTime().Nullable()
            //    .WithColumn("CreatedBy").AsInt64().Nullable()
            //    .WithColumn("UpdatedOn").AsDateTime().Nullable()
            //    .WithColumn("UpdatedBy").AsInt64().Nullable());

            //this.CreateTableIfNotExists("tblDecisionTrans",
            //table => table.InSchema("dbo")
            //    .WithColumn("Id").AsInt64().Identity().NotNullable().PrimaryKey()
            //    .WithColumn("Name").AsString(50).Nullable()
            //    .WithColumn("Description").AsCustom("NTEXT").Nullable()
            //    .WithColumn("DecisionId").AsInt64().Nullable()
            //    .WithColumn("DecisionNo").AsString(100).Nullable()
            //    .WithColumn("ArticleId").AsInt64().Nullable()
            //    .WithColumn("LangId").AsInt32().Nullable()
            //    .WithColumn("IsActive").AsBoolean().Nullable()
            //    .WithColumn("IsDeleted").AsBoolean().Nullable()
            //    .WithColumn("CreatedOn").AsDateTime().Nullable()
            //    .WithColumn("CreatedBy").AsInt64().Nullable()
            //    .WithColumn("UpdatedOn").AsDateTime().Nullable()
            //    .WithColumn("UpdatedBy").AsInt64().Nullable());

            //this.CreateTableIfNotExists("tblEmailSMSTemplate",
            //table => table.InSchema("dbo")           
            //    .WithColumn("Id").AsInt32().Identity().NotNullable().PrimaryKey()
            //    .WithColumn("TemplateType").AsInt32().Nullable()
            //    .WithColumn("Template").AsString(Int32.MaxValue).Nullable()
            //    .WithColumn("IsActive").AsBoolean().Nullable()
            //    .WithColumn("IsDeleted").AsBoolean().Nullable()
            //    .WithColumn("CreatedOn").AsDateTime().Nullable()
            //    .WithColumn("CreatedBy").AsInt64().Nullable()
            //    .WithColumn("UpdatedOn").AsDateTime().Nullable()
            //    .WithColumn("UpdatedBy").AsInt64().Nullable());


            //this.CreateTableIfNotExists("tblEmirates",
            //table => table.InSchema("dbo")
            //    .WithColumn("Id").AsInt32().Identity().NotNullable().PrimaryKey()
            //    .WithColumn("Name").AsString(100).Nullable()
            //    .WithColumn("IsActive").AsBoolean().Nullable()
            //    .WithColumn("IsDeleted").AsBoolean().Nullable()
            //    .WithColumn("CreatedOn").AsDateTime().Nullable()
            //    .WithColumn("CreatedBy").AsInt32().Nullable()
            //    .WithColumn("UpdatedOn").AsDateTime().Nullable()
            //    .WithColumn("UpdatedBy").AsInt32().Nullable());

            //this.CreateTableIfNotExists("tblEmiratesTrans",
            //table => table.InSchema("dbo")          
            //    .WithColumn("Id").AsInt32().Identity().NotNullable().PrimaryKey()
            //    .WithColumn("EmiratesId").AsInt64().NotNullable()
            //    .WithColumn("LawId").AsInt64().NotNullable()
            //    .WithColumn("Name").AsString(100).Nullable()
            //    .WithColumn("IsActive").AsBoolean().Nullable()
            //    .WithColumn("IsDeleted").AsBoolean().Nullable()
            //    .WithColumn("CreatedOn").AsDateTime().Nullable()
            //    .WithColumn("CreatedBy").AsInt32().Nullable()
            //    .WithColumn("UpdatedOn").AsDateTime().Nullable()
            //    .WithColumn("UpdatedBy").AsInt32().Nullable());


            //this.CreateTableIfNotExists("tblGoal",
            //table => table.InSchema("dbo")
            //    .WithColumn("Id").AsInt64().Identity().NotNullable().PrimaryKey()
            //    .WithColumn("CampaignId").AsInt64().NotNullable()
            //    .WithColumn("Objective").AsString(Int32.MaxValue).Nullable()
            //    .WithColumn("Target").AsString(Int32.MaxValue).Nullable()
            //    .WithColumn("Actual").AsString(Int32.MaxValue).Nullable()
            //    .WithColumn("IsActive").AsBoolean().Nullable()
            //    .WithColumn("IsDeleted").AsBoolean().Nullable()
            //    .WithColumn("CreatedOn").AsDateTime().Nullable()
            //    .WithColumn("CreatedBy").AsInt64().Nullable()
            //    .WithColumn("UpdatedOn").AsDateTime().Nullable()
            //    .WithColumn("UpdatedBy").AsInt64().Nullable());

            //this.CreateTableIfNotExists("tblInitiative",
            //table => table.InSchema("dbo")            
            //    .WithColumn("Id").AsInt64().Identity().NotNullable().PrimaryKey()
            //    .WithColumn("InitiativeTypeId").AsInt64().Nullable()
            //    .WithColumn("Title").AsString(150).Nullable()
            //    .WithColumn("Description").AsString(Int32.MaxValue).Nullable()
            //    .WithColumn("IsActive").AsBoolean().Nullable()
            //    .WithColumn("IsDeleted").AsBoolean().Nullable()
            //    .WithColumn("CreatedOn").AsDateTime().Nullable()
            //    .WithColumn("CreatedBy").AsInt64().Nullable()
            //    .WithColumn("UpdatedOn").AsDateTime().Nullable()
            //    .WithColumn("UpdatedBy").AsInt64().Nullable());

            //this.CreateTableIfNotExists("tblInitiativeCampaign",
            //table => table.InSchema("dbo")
            //    .WithColumn("Id").AsInt64().Identity().NotNullable().PrimaryKey()
            //    .WithColumn("CampaignId").AsInt64().Nullable()
            //    .WithColumn("InitiativeId").AsInt64().Nullable()
            //    .WithColumn("StartDate").AsDateTime().Nullable()
            //    .WithColumn("EndDate").AsDateTime().Nullable()
            //    .WithColumn("Description").AsString(Int32.MaxValue).Nullable()
            //    .WithColumn("Target").AsString(Int32.MaxValue).Nullable()
            //    .WithColumn("IsActive").AsBoolean().Nullable()
            //    .WithColumn("IsDeleted").AsBoolean().Nullable()
            //    .WithColumn("CreatedOn").AsDateTime().Nullable()
            //    .WithColumn("CreatedBy").AsInt64().Nullable()
            //    .WithColumn("UpdatedOn").AsDateTime().Nullable()
            //    .WithColumn("UpdatedBy").AsInt64().Nullable());

            //this.CreateTableIfNotExists("tblInitiativeType",
            //table => table.InSchema("dbo")
            //    .WithColumn("Id").AsInt64().Identity().NotNullable().PrimaryKey()
            //    .WithColumn("Description").AsString(150).Nullable()
            //    .WithColumn("IsActive").AsBoolean().Nullable()
            //    .WithColumn("IsDeleted").AsBoolean().Nullable()
            //    .WithColumn("CreatedOn").AsDateTime().Nullable()
            //    .WithColumn("CreatedBy").AsInt64().Nullable()
            //    .WithColumn("UpdatedOn").AsDateTime().Nullable()
            //    .WithColumn("UpdatedBy").AsInt64().Nullable());


            //this.CreateTableIfNotExists("tblLang",
            //table => table.InSchema("dbo")
            //    .WithColumn("Id").AsInt32().Identity().NotNullable().PrimaryKey()
            //    .WithColumn("Name").AsString(90).Nullable()
            //    .WithColumn("Code").AsString(3).Nullable()
            //    .WithColumn("IsActive").AsBoolean().Nullable()
            //    .WithColumn("IsDeleted").AsBoolean().Nullable()
            //    .WithColumn("CreatedOn").AsDateTime().Nullable()
            //    .WithColumn("CreatedBy").AsInt64().Nullable()
            //    .WithColumn("UpdatedOn").AsDateTime().Nullable()
            //    .WithColumn("UpdatedBy").AsInt64().Nullable());

            //this.CreateTableIfNotExists("tblLaw",
            //table => table.InSchema("dbo")
            //    .WithColumn("Id").AsInt64().Identity().NotNullable().PrimaryKey()
            //    .WithColumn("Name").AsString(Int32.MaxValue).Nullable()
            //    .WithColumn("Description").AsCustom("NTEXT").Nullable()
            //    .WithColumn("IsActive").AsBoolean().Nullable()
            //    .WithColumn("IsDeleted").AsBoolean().Nullable()
            //    .WithColumn("CreatedOn").AsDateTime().Nullable()
            //    .WithColumn("CreatedBy").AsInt64().Nullable()
            //    .WithColumn("UpdatedOn").AsDateTime().Nullable()
            //    .WithColumn("UpdatedBy").AsInt64().Nullable());

            //this.CreateTableIfNotExists("tblLawTrans",
            //table => table.InSchema("dbo")
            //    .WithColumn("Id").AsInt64().Identity().NotNullable().PrimaryKey()
            //    .WithColumn("Name").AsString(Int32.MaxValue).Nullable()
            //    .WithColumn("Description").AsCustom("NTEXT").Nullable()
            //    .WithColumn("LangId").AsInt32().Nullable()
            //    .WithColumn("LawId").AsInt64().Nullable()
            //    .WithColumn("IsActive").AsBoolean().Nullable()
            //    .WithColumn("IsDeleted").AsBoolean().Nullable()
            //    .WithColumn("CreatedOn").AsDateTime().Nullable()
            //    .WithColumn("CreatedBy").AsInt64().Nullable()
            //    .WithColumn("UpdatedOn").AsDateTime().Nullable()
            //    .WithColumn("UpdatedBy").AsInt64().Nullable());

            //this.CreateTableIfNotExists("tblMenu",
            //table => table.InSchema("dbo")
            //    .WithColumn("Id").AsInt64().Identity().NotNullable().PrimaryKey()
            //    .WithColumn("Name").AsString(100).Nullable()
            //    .WithColumn("Description").AsString(150).Nullable()
            //    .WithColumn("IsActive").AsBoolean().Nullable()
            //    .WithColumn("IsDeleted").AsBoolean().Nullable()
            //    .WithColumn("CreatedOn").AsDateTime().Nullable()
            //    .WithColumn("CreatedBy").AsInt64().Nullable()
            //    .WithColumn("UpdatedOn").AsDateTime().Nullable()
            //    .WithColumn("UpdatedBy").AsInt64().Nullable());

            //this.CreateTableIfNotExists("tblMultimediaType",
            //table => table.InSchema("dbo")
            //    .WithColumn("Id").AsInt64().Identity().NotNullable().PrimaryKey()
            //    .WithColumn("Name").AsString(100).Nullable()
            //    .WithColumn("Description").AsString(Int32.MaxValue).Nullable()
            //    .WithColumn("IsActive").AsBoolean().Nullable()
            //    .WithColumn("IsDelete").AsBoolean().Nullable()
            //    .WithColumn("CreatedOn").AsDateTime().Nullable()
            //    .WithColumn("CreatedBy").AsInt64().Nullable()
            //    .WithColumn("UpdatedOn").AsDateTime().Nullable()
            //    .WithColumn("UpdatedBy").AsInt64().Nullable());

            //this.CreateTableIfNotExists("tblUser",
            //table => table.InSchema("dbo")          
            //    .WithColumn("Id").AsInt64().Identity().NotNullable().PrimaryKey()
            //    .WithColumn("UserTypeId").AsInt64().Nullable()
            //    .WithColumn("UserName").AsAnsiString(100).Nullable()
            //    .WithColumn("Password").AsString(100).Nullable()
            //    .WithColumn("FullName").AsString(100).Nullable()
            //    .WithColumn("OfficeNo").AsString(100).Nullable()
            //    .WithColumn("Department").AsString(100).Nullable()
            //    .WithColumn("JobTitle").AsString(100).Nullable()
            //    .WithColumn("MobileNo").AsString(15).Nullable()
            //    .WithColumn("Photo").AsCustom("IMAGE").Nullable()
            //    .WithColumn("Email").AsString(100).Nullable()
            //    .WithColumn("IsActive").AsBoolean().Nullable()
            //    .WithColumn("IsDeleted").AsBoolean().Nullable()
            //    .WithColumn("CreatedOn").AsDateTime().Nullable()
            //    .WithColumn("CreatedBy").AsInt64().Nullable()
            //    .WithColumn("UpdatedOn").AsDateTime().Nullable()
            //    .WithColumn("UpdatedBy").AsInt64().Nullable());

            //this.CreateTableIfNotExists("tblUserType",
            //table => table.InSchema("dbo")
            //    .WithColumn("Id").AsInt64().Identity().NotNullable().PrimaryKey()
            //    .WithColumn("Name").AsString(100).Nullable()
            //    .WithColumn("Description").AsString(Int32.MaxValue).Nullable()
            //    .WithColumn("IsActive").AsBoolean().Nullable()
            //    .WithColumn("IsDeleted").AsBoolean().Nullable()
            //    .WithColumn("CreatedOn").AsDateTime().Nullable()
            //    .WithColumn("CreatedBy").AsInt64().Nullable()
            //    .WithColumn("UpdatedOn").AsDateTime().Nullable()
            //    .WithColumn("UpdatedBy").AsInt64().Nullable());

            //this.CreateTableIfNotExists("tblUserTypeTrans",
            //table => table.InSchema("dbo")
            //    .WithColumn("Id").AsInt64().Identity().NotNullable().PrimaryKey()
            //    .WithColumn("UserTypeId").AsInt64().NotNullable()
            //    .WithColumn("LangId").AsInt64().NotNullable()
            //    .WithColumn("Name").AsAnsiString(150).Nullable()
            //    .WithColumn("Description").AsAnsiString(Int32.MaxValue).Nullable()
            //    .WithColumn("IsActive").AsBoolean().Nullable()
            //    .WithColumn("IsDeleted").AsBoolean().Nullable()
            //    .WithColumn("CreatedOn").AsDateTime().Nullable()
            //    .WithColumn("CreatedBy").AsInt64().Nullable()
            //    .WithColumn("UpdatedOn").AsDateTime().Nullable()
            //    .WithColumn("UpdatedBy").AsInt64().Nullable());
            //#endregion
        }
    }
}
