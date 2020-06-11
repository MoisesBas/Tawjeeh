using FluentMigrator;

namespace Tawjeeh.DbMigration
{
    [DbTawjeehMigration(author: "Moises B. Bas", branchNumber: 01, year: 2018, month: 4, day: 15)]
    public class _4_DecisionUpgrade : ForwardOnlyMigration
    {
        public override void Up()
        {
            Create.Column("Year").OnTable("tblDecision").AsInt64().Nullable();           
        }
    }
}
