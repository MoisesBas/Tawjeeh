using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Tawjeeh.EntityFramework.Interface;
using Tawjeeh.EntityModel;
using Tawjeeh.EntityServices.Interface;
using LinqKit;
using Tawjeeh.Infrastructure;

namespace Tawjeeh.EntityServices.Services
{
    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="Tawjeeh.EntityServices.Interface.ICenterService" />
    public class CenterService : ICenterService
    {
        /// <summary>
        /// The repository factory
        /// </summary>
        private IRepositoryFactory _repositoryFactory;
        /// <summary>
        /// Initializes a new instance of the <see cref="CenterService"/> class.
        /// </summary>
        /// <param name="repositoryFactory">The repository factory.</param>
        public CenterService(IRepositoryFactory repositoryFactory)
        {
            Guard.NotNull(repositoryFactory, nameof(repositoryFactory));
            _repositoryFactory = repositoryFactory;
        }
        /// <summary>
        /// Inserts the or update centers.
        /// </summary>
        /// <param name="center">The center.</param>
        /// <returns></returns>
        public int InsertOrUpdateCenters(Centers center)
        {
            return _repositoryFactory.GetCenterRepository.InsertOrUpdateCenters(center);
        }

        /// <summary>
        /// Deletes the center.
        /// </summary>
        /// <param name="center">The center.</param>
        /// <returns></returns>
        public int DeleteCenter(Centers center)
        {
            return _repositoryFactory.GetCenterRepository.DeleteCenter(center);
        }

        /// <summary>
        /// Deletes the center trans.
        /// </summary>
        /// <param name="centerTrans">The center trans.</param>
        /// <returns></returns>
        public int DeleteCenterTrans(CenterTrans centerTrans)
        {
            return _repositoryFactory.GetCenterTransRepository.DeleteCenterTrans(centerTrans);
        }
        /// <summary>
        /// Gets all.
        /// </summary>
        /// <param name="langId">The language identifier.</param>
        /// <returns></returns>
        public IEnumerable<Centers> GetAll(int langId) 
        {
            var centers = new List<Centers>();

            GetAll().ToList().ForEach(c =>
            {
                var cts = new List<CenterTrans>();
                c.CenterTrans.ToList().ForEach(ct=> {
                    if (ct.LangId == langId)
                        cts.Add(ct);
                });
                c.CenterTrans = cts;
                centers.Add(c);
            });         
            return centers.AsEnumerable();
                         
        }


        /// <summary>
        /// Gets all.
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Centers> GetAll()
        {                     
            return _repositoryFactory.GetCenterRepository.GetAll(); 
        }

        /// <summary>
        /// Gets all centers by emirates identifier.
        /// </summary>
        /// <param name="emiratesId">The emirates identifier.</param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public Task<IEnumerable<Centers>> GetAllCentersByEmiratesId(int emiratesId)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Gets all centers by emirates identifier.
        /// </summary>
        /// <param name="emiratesId">The emirates identifier.</param>
        /// <param name="langId">The language identifier.</param>
        /// <returns></returns>
        public Task<IEnumerable<Centers>> GetAllCentersByEmiratesId(int emiratesId, int langId)
        {
            var result = _repositoryFactory.GetCenterRepository.GetAllCentersByEmiratesId(emiratesId).Result.ToList();
            if (result.Count > 0)
            {
                result.ForEach(x =>
                {
                    x.CenterTrans.RemoveAll(y => y.LangId != langId);

                });
            }
            return Task.FromResult(result.AsEnumerable());

            
        }

        /// <summary>
        /// Gets the center by identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        public Centers GetCenterById(long id)
        {
            return _repositoryFactory.GetCenterRepository.GetCenterById(id);
        }

        /// <summary>
        /// Gets the center by identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="langId">The language identifier.</param>
        /// <returns></returns>
        public Centers GetCenterById(int id, int langId)
        {
            var result = _repositoryFactory.GetCenterRepository
                                           .GetCenterById(id);

                result.CenterTrans = result.CenterTrans.Where(x => x.LangId == langId).ToList();
            return result;
        }

        /// <summary>
        /// Inserts the or update center trans.
        /// </summary>
        /// <param name="centerTrans">The center trans.</param>
        /// <returns></returns>
        public int InsertOrUpdateCenterTrans(CenterTrans centerTrans)
        {
            return _repositoryFactory.GetCenterTransRepository
                                     .InsertOrUpdateCenterTrans(centerTrans);
        }

        
    }
   
}
