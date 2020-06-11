using System.Collections.Generic;
using Tawjeeh.Entities;

namespace Tawjeeh.Repositories.Interface
{
    public interface IMultimediaTypeRepository
    {
        IList<MultimediaType> GetAllMultimediaType();
    }
}
