using log4net;
using System.Collections.Generic;
using System.Threading.Tasks;
using Tawjeeh.Entities;
using Tawjeeh.Infrastructure;
using Tawjeeh.Repositories.Interface;
using Tawjeeh.Service.Interface;

namespace Tawjeeh.Service.Service
{
    public class EmirateService : IEmirateService
    {
        private static readonly ILog log = LogManager.GetLogger(typeof(EmirateService));
        private IEmiratesRepository _emirateRepo;
        public EmirateService(IEmiratesRepository emirateRepo)
        {
            Guard.NotNull(emirateRepo, nameof(emirateRepo));
            _emirateRepo = emirateRepo;
        }
        public int CreateEmirates(Emirates emirates)
        {
            return _emirateRepo.CreateEmirates(emirates);
        }
        public int DeleteEmirates(Emirates emirates)
        {
            return _emirateRepo.DeleteEmirates(emirates);
        }
        public Task<IEnumerable<Emirates>> GetAll()
        {
            return _emirateRepo.GetAll();
        }
        public Emirates GetEmiratesById(int id)
        {
            return _emirateRepo.GetEmiratesById(id);
        }
        public int UpdateEmirates(Emirates emirates)
        {
            return _emirateRepo.UpdateEmirates(emirates);
        }
    }
}
