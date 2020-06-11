using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tawjeeh.EntityFramework.Interface
{
   public interface IGoalRepository<T> where T:class
    {
        int InsertOrUpdateGoal(T goal);
        int DeleteGoal(T goal);       
        IEnumerable<T> GetGoals();
        T GetGoalById(long id);
    }
}
