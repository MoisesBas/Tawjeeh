using System;
using System.Data.Entity.Core.Common.CommandTrees;
using System.Data.Entity.Core.Metadata.Edm;
using System.Data.Entity.Infrastructure.Interception;
using System.Linq;

namespace Tawjeeh.EntityFramework.Helper
{
    public class CreatedAndModifiedDateInterceptor : IDbCommandTreeInterceptor
    {
        public const string CreatedColumnName = "CreatedOn";
        public const string ModifiedColumnName = "UpdatedOn";
        public const string IsActiveColumnName = "IsActive";
        public const string IsDeletedColumnName = "IsDeleted";

        public void TreeCreated(DbCommandTreeInterceptionContext interceptionContext)
        {
            if (interceptionContext.OriginalResult.DataSpace != DataSpace.SSpace)
            {
                return;
            }

            var insertCommand = interceptionContext.Result as DbInsertCommandTree;
            if (insertCommand != null)
            {
                interceptionContext.Result = HandleInsertCommand(insertCommand);
            }

            var updateCommand = interceptionContext.OriginalResult as DbUpdateCommandTree;
            if (updateCommand != null)
            {
                interceptionContext.Result = HandleUpdateCommand(updateCommand);
            }
        }

        private static DbCommandTree HandleInsertCommand(DbInsertCommandTree insertCommand)
        {
            var now = DateTime.Now;

            var setClauses = insertCommand.SetClauses
                .Select(clause => clause.UpdateIfMatch(CreatedColumnName, DbExpression.FromDateTime(now)))
                .Select(clause => clause.UpdateIfMatch(ModifiedColumnName, DbExpression.FromDateTime(now)))
                .Select(clause => clause.UpdateIfMatch(IsActiveColumnName, true))
                .Select(clause => clause.UpdateIfMatch(IsDeletedColumnName, false))
                .ToList();

            return new DbInsertCommandTree(
                insertCommand.MetadataWorkspace,
                insertCommand.DataSpace,
                insertCommand.Target,
                setClauses.AsReadOnly(),
                insertCommand.Returning);
        }

        private static DbCommandTree HandleUpdateCommand(DbUpdateCommandTree updateCommand)
        {
            var now = DateTime.Now;

            var setClauses = updateCommand.SetClauses
                .Select(clause => clause.UpdateIfMatch(ModifiedColumnName, DbExpression.FromDateTime(now)))
                .Select(clause => clause.UpdateIfMatch(IsActiveColumnName, true))
                .Select(clause => clause.UpdateIfMatch(IsDeletedColumnName, false))
                .ToList();

            return new DbUpdateCommandTree(
                updateCommand.MetadataWorkspace,
                updateCommand.DataSpace,
                updateCommand.Target,
                updateCommand.Predicate,
                setClauses.AsReadOnly(), null);
        }
    }
}
