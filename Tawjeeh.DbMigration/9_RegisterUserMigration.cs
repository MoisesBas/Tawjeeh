using FluentMigrator;

namespace Tawjeeh.DbMigration
{
    [DbTawjeehMigration(author: "Moises B. Bas", branchNumber: 03, year: 2018, month: 4, day: 17)]
    public class _9_RegisterUserMigration : Migration
    {
        public override void Down()
        {
            Delete.Column("IsOTP").FromTable("tblUser").InSchema("dbo");
            Delete.Column("OTP").FromTable("tblUser").InSchema("dbo");
            Delete.Column("LangId").FromTable("tblUser").InSchema("dbo");
            Delete.Column("CountryId").FromTable("tblUser").InSchema("dbo");
        }

        public override void Up()
        {
            Alter.Table("tblUser").InSchema("dbo")
                 .AddColumn("IsOTP").AsBoolean().NotNullable().WithDefaultValue(false)
                 .AddColumn("OTP").AsString(10).Nullable()
                 .AddColumn("LangId").AsInt32().Nullable()
                 .AddColumn("CountryId").AsInt32().Nullable();          
        }
    }
}
