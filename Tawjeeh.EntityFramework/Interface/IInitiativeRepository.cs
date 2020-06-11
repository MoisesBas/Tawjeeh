using System;
using System.Collections.Generic;

namespace Tawjeeh.EntityFramework.Interface
{
    public interface IInitiativeRepository<T> where T:class
    {
        int InsertOrUpdateInitiative(T initiative);
        int DeleteInitiative(T initiative);       
        IEnumerable<T> GetAll();        
        T GetInitiativeById(long id);        
    }
}
