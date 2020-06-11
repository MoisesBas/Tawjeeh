using System;
using System.Collections.Generic;
using Tawjeeh.EntityFramework.Helper;
using Tawjeeh.EntityFramework.Interface;
using Tawjeeh.EntityModel;

namespace Tawjeeh.EntityFramework.Repository
{
    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="Tawjeeh.EntityFramework.Repository.RepositoryBase{Tawjeeh.EntityFramework.Repository.TawjeehContext}" />
    /// <seealso cref="Tawjeeh.EntityFramework.Interface.IGoalRepository{Tawjeeh.EntityModel.Goal}" />
    public class GoalRepository : RepositoryBase<TawjeehContext>,
          IGoalRepository<Goal>
    {
        /// <summary>
        /// Deletes the goal.
        /// </summary>
        /// <param name="goal">The goal.</param>
        /// <returns></returns>
        public int DeleteGoal(Goal goal)
        {
            return DeleteRecord(goal);
        }
        /// <summary>
        /// Gets the goal by identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        public Goal GetGoalById(long id)
        {
            var search = Query<Goal>.Create(x => x.Id == id);
            return FirstOrDefaultDisposable(search);
        }
        /// <summary>
        /// Gets the goals.
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Goal> GetGoals()
        {
            return GetListDisposableContext<Goal>();
        }
        /// <summary>
        /// Inserts the or update goal.
        /// </summary>
        /// <param name="goal">The goal.</param>
        /// <returns></returns>
        public int InsertOrUpdateGoal(Goal goal)
        {
            return InsertOrUpdate(goal);
        }
    }
}
