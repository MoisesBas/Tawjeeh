using FluentMigrator;

namespace Tawjeeh.DbMigration
{
    [DbTawjeehMigration(author: "Moises B. Bas", branchNumber: 01, year: 2018, month: 4, day: 17)]
   public class _6_LawTranslationMigration: ForwardOnlyMigration
    {        
            public override void Up()
            {               
                Execute.EmbeddedScript("LawTransMigrateData15042018.sql");
            }
        
    }
}
