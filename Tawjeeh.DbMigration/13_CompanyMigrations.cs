using FluentMigrator;

namespace Tawjeeh.DbMigration
{
    [DbTawjeehMigration(author: "Moises B. Bas", branchNumber: 01, year: 2018, month: 5, day: 02)]
    public class _13_CompanyMigrations : Migration
    {
        public override void Down()
        {
            Execute.EmbeddedScript("spDeleteInitiative.sql");
            Execute.DropTableIfExists("tblCompany");
            Delete.Column("CompanyId").FromTable("tblUser").InSchema("dbo");

        }

        public override void Up()
        {
            Execute.EmbeddedScript("spDeleteInitiative05022018.sql");
            Create.Column("CompanyId").OnTable("tblUser").AsInt64().Nullable();
            this.CreateTableIfNotExists("tblCompany",
                    table => table.InSchema("dbo")
                              .WithColumn("Id").AsInt64().Identity().NotNullable().PrimaryKey()
                              .WithColumn("Name").AsString(50).Nullable()
                              .WithColumn("NumberOfBrances").AsInt16().Nullable()
                              .WithColumn("HeadQuarterLocation").AsString(200).Nullable()
                              .WithColumn("Telephone").AsString(150).Nullable()
                              .WithColumn("website").AsString(250).Nullable()
                              .WithColumn("CompanyEmail").AsString(250).Nullable()
                              .WithColumn("CompanyTypeID").AsInt32().Nullable()
                              .WithColumn("TradeLicense").AsString(1000).Nullable()
                              .WithColumn("IsActive").AsBoolean().Nullable()
                              .WithColumn("IsDeleted").AsBoolean().Nullable()                           
                              .WithColumn("CreatedOn").AsDateTime().Nullable()
                              .WithColumn("CreatedBy").AsInt64().Nullable()
                              .WithColumn("UpdatedOn").AsDateTime().Nullable()
                              .WithColumn("UpdatedBy").AsInt64().Nullable());
        }
    }
}
