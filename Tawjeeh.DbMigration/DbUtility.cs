using FluentMigrator;
using FluentMigrator.Builders.Create.Table;
using FluentMigrator.Builders.Execute;
using FluentMigrator.Infrastructure;
using System;

namespace Tawjeeh.DbMigration
{
    public static class DbUtility
    {
        public static IFluentSyntax CreateTableIfNotExists(this MigrationBase self, string tableName, Func<ICreateTableWithColumnOrSchemaOrDescriptionSyntax, IFluentSyntax> constructTableFunction, string schemaName = "dbo")
        {
            if (!self.Schema.Schema(schemaName).Table(tableName).Exists())
            {
                
                return constructTableFunction(self.Create.Table(tableName));
            }
            else
                return null;
        }
        public static void DropTableIfExists(this IExecuteExpressionRoot execute, string tableName)
        {
            execute.Sql(string.Format("IF (EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = '{0}')) BEGIN DROP TABLE [{0}] END", tableName));
        }
        public static void DropSPIfExists(this IExecuteExpressionRoot execute, string sp)
        {
            execute.Sql(string.Format("IF (EXISTS (SELECT * FROM INFORMATION_SCHEMA.ROUTINES WHERE ROUTINE_NAME = '{0}')) BEGIN DROP PROCEDURE [{0}] END", sp));
        }
        public static void DropViewsIfExists(this IExecuteExpressionRoot execute, string views)
        {
            execute.Sql(string.Format("IF (EXISTS (SELECT * FROM INFORMATION_SCHEMA.VIEWS WHERE TABLE_NAME = '{0}')) BEGIN DROP VIEW [{0}] END", views));
        }

    }
}
