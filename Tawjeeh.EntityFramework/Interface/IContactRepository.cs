using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Tawjeeh.EntityFramework.Interface
{
   public interface IContactRepository<T> where T : class
    {       
        IReadOnlyList<T> GetContactsByUserIds(long[] userIds);
    }
}
