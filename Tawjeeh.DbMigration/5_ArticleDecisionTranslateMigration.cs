using FluentMigrator;
namespace Tawjeeh.DbMigration
{
    [DbTawjeehMigration(author: "Moises B. Bas", branchNumber: 01, year: 2018, month: 4, day: 16)]
    public class _5_ArticleDecisionTranslateMigration : ForwardOnlyMigration
    {
        public override void Up()
        {
            Execute.EmbeddedScript("ArticleMigrateData15042018.sql");
            Execute.EmbeddedScript("DecisionMigrateData15042018.sql");           
        }
    }
}
