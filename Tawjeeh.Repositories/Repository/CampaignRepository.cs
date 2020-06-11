using System;
using System.Collections.Generic;
using Tawjeeh.Entities;
using Tawjeeh.Infrastructure;
using Tawjeeh.Repositories.Interface;
using System.Linq;
using Dapper;
using System.Data;

namespace Tawjeeh.Repositories.Repository
{
    public class CampaignRepository: BaseRepository<Campaign>, 
        ICampaignRepository
    {        
        public CampaignRepository(IConnectionFactory connectionFactory) :
            base(connectionFactory)
        {

        }

        public int CreateCampaign(Campaign camp)
        {
            return base.Create(camp);
        }

        public int DeleteCampaign(Campaign article)
        {
            using (var _conn = _connectionFactory.GetConnection)
            {
                var result = _conn.Execute("spDeleteCampaign", new { @Id = article.Id, @UpdatedBy = article.UpdatedBy },
                    commandType: CommandType.StoredProcedure);
                if (result == -1) result = 1;
                return result;
            }
        }

        public Campaign GetCampaignById(long id)
        {
            var query = @"SELECT c.* FROM tblCampaign c WHERE c.Id = @id AND c.IsActive = 1 AND c.IsDeleted=0;
                          SELECT cd.* FROM tblCampaignDetails cd WHERE cd.CampaignId =@id AND cd.IsActive = 1 AND cd.IsDeleted=0;
                          SELECT g.* FROM tblGoal g WHERE g.CampaignId = @id AND g.IsActive = 1 AND g.IsDeleted=0;
                          SELECT d.* FROM tblCampaignDocument d WHERE d.CampaignId = @id AND d.IsActive = 1 AND d.IsDeleted=0;
                          SELECT ic.* FROM tblInitiativeCampaign ic WHERE ic.CampaignId = @id AND ic.IsActive = 1 AND ic.IsDeleted=0;
                          SELECT TOP 1 i.* FROM tblInitiative i INNER JOIN tblInitiativeCampaign ic on i.Id = ic.InitiativeId
                                            WHERE ic.CampaignId = @id AND ic.IsActive = 1 AND ic.IsDeleted=0;
                         ";

            var result = GetMultiple(query, false, new { @id = id },
                x => x.Read<Campaign>(), 
                x => x.Read<CampaignDetails>(),
                x => x.Read<Goal>(),
                x => x.Read<CampaignDocument>(),
                x => x.Read<InitiativeCampaign>(),
                x => x.Read<Initiative>());                       

            var campaign = result.Item1.ToList();
            var campDetails = result.Item2.ToList();
            var goal = result.Item3.ToList();
            var campDoc = result.Item4.ToList();
            var iniCamp = result.Item5.ToList();
            var initiative = result.Item6.ToList();

            var results = (from c in campaign                              
                           select new Campaign
                           {
                               Id = c.Id,
                               Title = c.Title,
                               FromDate = c.FromDate,
                               ToDate = c.ToDate,
                               Target = c.Target,
                               Budget = c.Budget,
                               CampaignStatus = c.CampaignStatus,
                               CampaignDetails = campDetails.Where(x => x.CampaignId == c.Id).ToList(),
                               Goals = goal.Where(x => x.CampaignId == c.Id).ToList(),
                               CampaignDocument = campDoc.Where(x=>x.CampaignId == c.Id).ToList(),
                               Initiative = (from i in initiative
                                             select new Initiative() {
                                                 Id = i.Id,
                                                 InitiativeTypeId = i.InitiativeTypeId,
                                                 Title = i.Title,
                                                 Description = i.Description,
                                                 IsActive = i.IsActive,
                                                 IsDeleted = i.IsDeleted,
                                                 CreatedBy = i.CreatedBy,
                                                 CreatedOn = i.CreatedOn,
                                                 UpdatedBy = i.UpdatedBy,
                                                 UpdatedOn = i.UpdatedOn,
                                                 InitiativeCampaign = (from ic in iniCamp
                                                                       select ic).ToList()                                                 
                                             }).FirstOrDefault(),
                               IsActive = c.IsActive,
                               IsDeleted = c.IsDeleted,
                               CreatedBy = c.CreatedBy,
                               CreatedOn = c.CreatedOn,
                               UpdatedBy = c.UpdatedBy,
                               UpdatedOn = c.UpdatedOn
                           }).FirstOrDefault();
            return results;

        }

        public IList<Campaign> GetCampaigns()
        {
            var query = @"SELECT c.* FROM tblCampaign c WHERE c.IsActive = 1 AND c.IsDeleted=0;
                          SELECT cd.* FROM tblCampaignDetails cd WHERE cd.IsActive = 1 AND cd.IsDeleted=0;
                          SELECT g.* FROM tblGoal g WHERE g.IsActive = 1 AND g.IsDeleted=0;
                          SELECT d.* FROM tblCampaignDocument d WHERE d.IsActive = 1 AND d.IsDeleted=0;
                          SELECT ic.* FROM tblInitiativeCampaign ic WHERE ic.IsActive = 1 AND ic.IsDeleted=0;
                          SELECT i.* FROM tblInitiative i INNER JOIN tblInitiativeCampaign ic on i.Id = ic.InitiativeId
                                            WHERE ic.IsActive = 1 AND ic.IsDeleted=0;";

            var result = GetMultiple(query, false, null,
                x => x.Read<Campaign>(),
                x => x.Read<CampaignDetails>(),
                x => x.Read<Goal>(),
                x => x.Read<CampaignDocument>(),
                x => x.Read<InitiativeCampaign>(),
                x => x.Read<Initiative>());

            var campaign = result.Item1.ToList();
            var campDetails = result.Item2.ToList();
            var goal = result.Item3.ToList();
            var campDoc = result.Item4.ToList();
            var iniCamp = result.Item5.ToList();
            var initiative = result.Item6.ToList();

            var results = (from c in campaign
                           select new Campaign
                           {
                               Id = c.Id,
                               Title = c.Title,
                               FromDate = c.FromDate,
                               ToDate = c.ToDate,
                               Target = c.Target,
                               Budget = c.Budget,
                               CampaignStatus = c.CampaignStatus,
                               CampaignDetails = campDetails.Where(x => x.CampaignId == c.Id).ToList(),
                               Goals = goal.Where(x => x.CampaignId == c.Id).ToList(),
                               CampaignDocument = campDoc.Where(x => x.CampaignId == c.Id).ToList(),
                               Initiative = (from i in initiative
                                             join ic in iniCamp on i.Id equals ic.InitiativeId
                                             where ic.CampaignId == c.Id
                                             select new Initiative()
                                             {
                                                 Id = i.Id,
                                                 InitiativeTypeId = i.InitiativeTypeId,
                                                 Title = i.Title,
                                                 Description = i.Description,
                                                 IsActive = i.IsActive,
                                                 IsDeleted = i.IsDeleted,
                                                 CreatedBy = i.CreatedBy,
                                                 CreatedOn = i.CreatedOn,
                                                 UpdatedBy = i.UpdatedBy,
                                                 UpdatedOn = i.UpdatedOn,
                                                 InitiativeCampaign = (from ic in iniCamp
                                                                       where ic.InitiativeId == i.Id && ic.CampaignId == c.Id
                                                                       select ic).ToList()
                                             }).FirstOrDefault(),
                               IsActive = c.IsActive,
                               IsDeleted = c.IsDeleted,
                               CreatedBy = c.CreatedBy,
                               CreatedOn = c.CreatedOn,
                               UpdatedBy = c.UpdatedBy,
                               UpdatedOn = c.UpdatedOn
                           }).ToList();
            return results;
        }
        public int UpdateCampaign(Campaign article)
        {
            article.UpdatedOn = DateTime.Now;
            return base.Update(article);
        }
    }
}
