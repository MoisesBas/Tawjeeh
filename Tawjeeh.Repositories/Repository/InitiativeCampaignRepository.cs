using Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tawjeeh.Entities;
using Tawjeeh.Infrastructure;
using Tawjeeh.Repositories.Interface;

namespace Tawjeeh.Repositories.Repository
{
    public class InitiativeCampaignRepository : BaseRepository<InitiativeCampaign>,
        IInitiativeCampaignRepository
    {
        public InitiativeCampaignRepository(IConnectionFactory connectionFactory)
              : base(connectionFactory)
        {
        }
        public int CreateInitiativeCampaign(InitiativeCampaign initiativeCampaign)
        {
            initiativeCampaign.IsActive = true;
            initiativeCampaign.IsDeleted = false;
            initiativeCampaign.CreatedOn = DateTime.Now;
            return base.Create(initiativeCampaign);
        }

        public int DeleteInitiativeCampaign(InitiativeCampaign initiativeCampaign)
        {
            initiativeCampaign.IsActive = true;
            initiativeCampaign.IsDeleted = true;
            initiativeCampaign.UpdatedOn = DateTime.Now;
            return base.Update(initiativeCampaign);
        }

        public Task<IEnumerable<InitiativeCampaign>> GetAll()
        {
            return base.GetAllAsync();
        }

        public IList<InitiativeCampaign> GetInitiativeCampaignByCampaignId(int campId)
        {
            var query = @"select g.* from tblInitiativeCampaign g where g.CampaignId=@id AND g.IsActive = 1 AND g.IsDeleted=0;
                          select i.* from tblInitiative i inner join tblInitiativeCampaign ic on i.Id = ic.InitiativeId
                          where ic.CampaignId=@id AND i.IsActive = 1 AND i.IsDeleted=0 AND ic.IsActive = 1 AND ic.IsDeleted=0;
                          select c.* from tblCampaign c where c.Id = @id AND c.IsActive = 1 AND c.IsDeleted=0;";

            var result = this.GetMultiple(query, false, new { @id = campId },
                r=>r.Read<InitiativeCampaign>(),
                r=>r.Read<Initiative>(),
                r=>r.Read<Campaign>());

            var initiativeCamp = result.Item1 ?? new List<InitiativeCampaign>();
            var initiative = result.Item2 ?? new List<Initiative>();
            var campaign = result.Item3 ?? new List<Campaign>();
            var _results = (from ic in initiativeCamp
                            select new InitiativeCampaign {
                                Id = ic.Id,
                                CampaignId = ic.CampaignId,
                                InitiativeId = ic.InitiativeId,
                                StartDate = ic.StartDate,
                                EndDate = ic.EndDate,
                                Description = ic.Description,
                                Target = ic.Target,
                                IsDeleted = ic.IsDeleted,
                                EvidenceName = ic.EvidenceName,
                                EvidenceResult = ic.EvidenceResult,
                                Result = ic.Result,
                                IsActive = ic.IsActive,
                                CreatedBy = ic.CreatedBy,
                                CreatedOn = ic.CreatedOn,
                                UpdatedBy = ic.UpdatedBy,
                                UpdatedOn = ic.UpdatedOn,
                                StartDateTime = ic.StartDateTime,
                                Campaign = (from c in campaign
                                            where c.Id == ic.CampaignId
                                           select c).FirstOrDefault(),
                                Initiative = (from i in initiative
                                              where i.Id == ic.InitiativeId
                                              select i).FirstOrDefault()
                            }).ToList();

            return _results ?? new List<InitiativeCampaign>();

        }

        public InitiativeCampaign GetInitiativeCampaignById(int id)
        {
            var query = @"select g.* from tblInitiativeCampaign g where g.Id=@id AND g.IsActive = 1 AND g.IsDeleted=0;";
            using (var _conn = _connectionFactory.GetConnection)
            {
                return _conn.Query<InitiativeCampaign>(query, new { @id = id }).FirstOrDefault();
            }
        }

        public int UpdateInitiativeCampaign(InitiativeCampaign initiativeCampaign)
        {            
            initiativeCampaign.UpdatedOn = DateTime.Now;
            return base.Update(initiativeCampaign);
        }
    }
}
