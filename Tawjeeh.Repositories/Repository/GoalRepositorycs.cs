using Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using Tawjeeh.Entities;
using Tawjeeh.Infrastructure;
using Tawjeeh.Repositories.Interface;

namespace Tawjeeh.Repositories.Repository
{
    public class GoalRepositorycs : BaseRepository<Goal>, 
        IGoalRepository
    {
        public GoalRepositorycs(IConnectionFactory connectionFactory) :
            base(connectionFactory)
        {

        }
        public int CreateGoal(Goal goal)
        {
            goal.CreatedOn = DateTime.Now;
            goal.IsActive = true;
            goal.IsDeleted = false;
            return base.Create(goal);
        }

        public int DeleteGoal(Goal goal)
        {
            goal.UpdatedOn = DateTime.Now;
            goal.IsActive = true;
            goal.IsDeleted = true;
            return base.Update(goal);
        }

        public Goal GetGoalById(long id)
        {
            var query = @"select g.* from tblGoal g where g.Id=@id AND g.IsActive = 1 AND g.IsDeleted=0;";           
            using (var _conn = _connectionFactory.GetConnection)
            {
                return _conn.Query<Goal>(query, new { @id = id}).FirstOrDefault();
            }
        }

        public IList<Goal> GetGoals()
        {
            var query = @"select g.* from tblGoal g where g.IsActive = 1 AND g.IsDeleted=0;";
            using (var _conn = _connectionFactory.GetConnection)
            {
                return _conn.Query<Goal>(query).ToList();
            }
        }

        public int UpdateGoal(Goal goal)
        {
            goal.UpdatedOn = DateTime.Now;           
            goal.IsDeleted = false;
            return base.Update(goal);
        }
    }
}
