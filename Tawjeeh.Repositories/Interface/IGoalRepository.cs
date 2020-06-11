using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tawjeeh.Entities;

namespace Tawjeeh.Repositories.Interface
{
    public interface IGoalRepository
    {
        int CreateGoal(Goal goal);
        int DeleteGoal(Goal goal);
        int UpdateGoal(Goal goal);
        IList<Goal> GetGoals();
        Goal GetGoalById(long id);
    }
}
