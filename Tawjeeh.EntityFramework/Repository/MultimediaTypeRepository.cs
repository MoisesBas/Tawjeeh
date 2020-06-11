using System.Collections.Generic;
using Tawjeeh.EntityFramework.Interface;
using Tawjeeh.EntityModel;

namespace Tawjeeh.EntityFramework.Repository
{
    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="Tawjeeh.EntityFramework.Repository.RepositoryBase{Tawjeeh.EntityFramework.Repository.TawjeehContext}" />
    /// <seealso cref="Tawjeeh.EntityFramework.Interface.IMultimediaTypeRepository{Tawjeeh.EntityModel.MultimediaType}" />
    public class MultimediaTypeRepository : RepositoryBase<TawjeehContext>,
            IMultimediaTypeRepository<MultimediaType>
    {
        /// <summary>
        /// Gets the type of all multimedia.
        /// </summary>
        /// <returns></returns>
        public IEnumerable<MultimediaType> GetAllMultimediaType()
        {
            return GetListDisposableContext<MultimediaType>();
        }
    }
}
