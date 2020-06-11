using System.Collections.Generic;

namespace Tawjeeh.EntityFramework.Interface
{
    public interface IMultimediaTypeRepository<T> where T:class
    {
        IEnumerable<T> GetAllMultimediaType();
    }
}
