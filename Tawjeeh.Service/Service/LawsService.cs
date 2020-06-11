using log4net;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Tawjeeh.Entities;
using Tawjeeh.Infrastructure;
using Tawjeeh.Repositories.Interface;
using Tawjeeh.Service.Interface;

namespace Tawjeeh.Service.Service
{
    public class LawsService:ILawsService
    {
        private static readonly ILog log = LogManager.GetLogger(typeof(LawsService));
        private ILawRepository _repoLaw;
        private ILawTransRepository _repoTransLaw;
      
        public LawsService(ILawRepository repoLaw, 
                           ILawTransRepository lawTransRepository)
        {
            Guard.NotNull(repoLaw, nameof(repoLaw));
            Guard.NotNull(lawTransRepository, nameof(lawTransRepository));

            _repoLaw = repoLaw;
            _repoTransLaw = lawTransRepository;
        }

        public int CreateLaw(Law laws)
        {            
            Guard.NotNullOrEmpty(laws.Name, "Name of Law is required.,");  

            var law = _repoLaw.GetLawByName(laws.Name);
            if (law == null)
            {
                var lawOut = _repoLaw.CreateLaw(laws);
                if (lawOut == 0)
                    throw new Exception("Unable to Add Laws");
                return lawOut;
            }
            else
            {
                throw new Exception("This Law is already exists.,");
            }           
        }

        public int CreateLawTrans(LawTrans lawtrans)
        {
            var isexists = _repoTransLaw.GetLawTrans(Convert.ToInt64(lawtrans.LawId),Convert.ToInt32(lawtrans.LangId));

            if (isexists != null)
                throw new Exception("Translation for this law is already exists.,");
            return _repoTransLaw.CreateLawTrans(lawtrans);
        }

        public int DeleteLaw(Law laws)
        {            
            return _repoLaw.DeleteLaw(laws);
        }

        public int DeleteLawTrans(LawTrans lawtrans)
        {
            lawtrans.IsActive = true;
            lawtrans.IsDeleted = false;
            return _repoTransLaw.UpdateLawTrans(lawtrans);
        }

        public IList<Law> GetAll()
        {            
            return _repoLaw.GetAllLaws();
        }
        public IEnumerable<Law> GetAll(int langId )
        {
            return _repoLaw.GetAll(langId);
        }
        public Law GetLawById(Int64 id)
        {
            return _repoLaw.GetLawById(id);
        }
       public  Law GetLawByIdAndLangId(Int64 id, int langId)
        {
            return _repoLaw.GetLawByIdAndLangId(id, langId);
        }

        public Task<IEnumerable<LawTrans>> GetLawTransAll()
        {
            return _repoTransLaw.GetLawTransAll();
        }

        public LawTrans GetLawTransId(int id)
        {
            return _repoTransLaw.GetLawTransId(id);
        }

        public LawTrans GetLawTransId(long lawId, int langId)
        {
            return _repoTransLaw.GetLawTransId(lawId, langId);
        }

        public int UpdateLaw(Law laws)
        {
            return _repoLaw.UpdateLaw(laws);
        }

        public int UpdateLawTrans(LawTrans lawtrans)
        {
            return _repoTransLaw.UpdateLawTrans(lawtrans);
        }
    }
}
