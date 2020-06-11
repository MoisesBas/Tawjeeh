using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using Tawjeeh.Entities;
using Tawjeeh.Infrastructure;
using Tawjeeh.Repositories.Interface;

namespace Tawjeeh.Repositories.Repository
{
    public class InitiativeRepository : BaseRepository<Initiative>, 
        IInitiativeRepository
    {
        public InitiativeRepository(IConnectionFactory connectionFactory)
           : base(connectionFactory)
        {
        }
        public int CreateInitiative(Initiative initiative)
        {
            initiative.IsActive = true;
            initiative.IsDeleted = false;
            initiative.CreatedOn = DateTime.Now;
            return base.Create(initiative);
        }

        public int DeleteInitiative(Int64 iniId)
        {

            using (var _conn = _connectionFactory.GetConnection)
            {
                var result = _conn.Execute("spDeleteInitiative", new { @Id = iniId, @UpdatedBy = 1 },
                    commandType: CommandType.StoredProcedure);
                if (result == -1) result = 1;
                return result;
            }
        }

        public override IList<Initiative> GetAll()
        {
            //return base.GetAllAsync();
            var query = @"SELECT g.* FROM tblInitiative g WHERE g.IsActive = 1 AND g.IsDeleted=0;
                          SELECT ic.* FROM tblInitiativeCampaign ic WHERE ic.IsActive = 1 AND ic.IsDeleted=0;
                          SELECT c.* FROM tblCampaign c inner join tblInitiativeCampaign ic on ic.CampaignId = c.Id
                          WHERE ic.IsActive = 1 AND ic.IsDeleted=0 AND c.IsActive = 1 AND c.IsDeleted=0;";

            var _result = this.GetMultiple(query, false, null,
                                              r => r.Read<Initiative>(),
                                              r => r.Read<InitiativeCampaign>(),
                                              r => r.Read<Campaign>());

            var initiative = _result.Item1.ToList();
            var initiativeCampaign = _result.Item2.ToList();
            var campaign = _result.Item3.ToList();

            var result = (from i in initiative
                          select new Initiative
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
                              InitiativeCampaign = (from ic in initiativeCampaign
                                                    where ic.InitiativeId == i.Id
                                                    select new InitiativeCampaign
                                                    {
                                                        Id = ic.Id,
                                                        CampaignId = ic.CampaignId,
                                                        InitiativeId = ic.InitiativeId,
                                                        StartDate = ic.StartDate,
                                                        EndDate = ic.EndDate,
                                                        Description = ic.Description,
                                                        Result = ic.Result,
                                                        EvidenceName = ic.EvidenceName,
                                                        EvidenceResult = ic.EvidenceResult,
                                                        StartDateTime = ic.StartDateTime,
                                                        Target = ic.Target,
                                                        IsActive = ic.IsActive,
                                                        IsDeleted = ic.IsDeleted,
                                                        CreatedBy = ic.CreatedBy,
                                                        CreatedOn = ic.CreatedOn,
                                                        UpdatedBy = ic.UpdatedBy,
                                                        UpdatedOn = ic.UpdatedOn,
                                                        Campaign = (from c in campaign 
                                                                    where c.Id == ic.CampaignId
                                                                    select new Campaign
                                                                    {
                                                                        Id = c.Id,
                                                                        Title = c.Title,
                                                                        Target = c.Target,
                                                                        CampaignStatus = c.CampaignStatus,
                                                                        Budget = c.Budget,
                                                                        FromDate = c.FromDate,
                                                                        ToDate = c.ToDate,
                                                                        IsActive = c.IsActive,
                                                                        IsDeleted = c.IsDeleted,
                                                                        CreatedBy = c.CreatedBy,
                                                                        CreatedOn = c.CreatedOn,
                                                                        UpdatedBy = c.UpdatedBy,
                                                                        UpdatedOn = c.UpdatedOn
                                                                    }).FirstOrDefault()
                                                    }).ToList()

                          }).ToList();
            return result;
        }

        public Initiative GetInitiativeById(long id)
        {
            var query = @"SELECT g.* FROM tblInitiative g WHERE g.Id=@id AND g.IsActive = 1 AND g.IsDeleted=0;
                          SELECT ic.* FROM tblInitiativeCampaign ic WHERE ic.InitiativeId=@id AND ic.IsActive = 1 AND ic.IsDeleted=0;
                          SELECT c.* FROM tblCampaign c inner join tblInitiativeCampaign ic on ic.CampaignId = c.Id
                          WHERE ic.InitiativeId = @id AND ic.IsActive = 1 AND ic.IsDeleted=0 AND c.IsActive = 1 AND c.IsDeleted=0;";
            var _result = this.GetMultiple(query, false, new { @id = id },
                                              r => r.Read<Initiative>(),
                                              r => r.Read<InitiativeCampaign>(),
                                              r => r.Read<Campaign>());

            var initiative = _result.Item1.ToList();
            var initiativeCampaign = _result.Item2.ToList();
            var campaign = _result.Item3.ToList();

            var result = (from i in initiative
                          select new Initiative
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
                              InitiativeCampaign = (from ic in initiativeCampaign
                                                    select new InitiativeCampaign
                                                    {
                                                        Id = ic.Id,
                                                        CampaignId = ic.CampaignId,
                                                        InitiativeId = ic.InitiativeId,
                                                        StartDate = ic.StartDate,
                                                        EndDate = ic.EndDate,
                                                        Description = ic.Description,
                                                        Target = ic.Target,
                                                        IsActive = ic.IsActive,
                                                        IsDeleted = ic.IsDeleted,
                                                        CreatedBy = ic.CreatedBy,
                                                        CreatedOn = ic.CreatedOn,
                                                        UpdatedBy = ic.UpdatedBy,
                                                        UpdatedOn = ic.UpdatedOn,
                                                        Campaign = (from c in campaign
                                                                    select new Campaign
                                                                    {
                                                                        Id = c.Id,
                                                                        Title = c.Title,
                                                                        Target = c.Target,
                                                                        CampaignStatus = c.CampaignStatus,
                                                                        Budget = c.Budget,
                                                                        FromDate = c.FromDate,
                                                                        ToDate = c.ToDate,
                                                                        IsActive = c.IsActive,
                                                                        IsDeleted = c.IsDeleted,
                                                                        CreatedBy = c.CreatedBy,
                                                                        CreatedOn = c.CreatedOn,
                                                                        UpdatedBy = c.UpdatedBy,
                                                                        UpdatedOn = c.UpdatedOn
                                                                    }).FirstOrDefault()
                                                    }).ToList()

                          }).FirstOrDefault();
            return result;
        }

        public IList<Initiative> GetInitiativeByCampaignId(long campaignId)
        {
            var query = @"SELECT distinct g.* FROM tblInitiative g inner join tblInitiativeCampaign ic on ic.InitiativeId = g.Id WHERE ic.CampaignId=@id AND g.IsActive = 1 AND g.IsDeleted=0;
                          SELECT ic.* FROM tblInitiativeCampaign ic WHERE ic.CampaignId=@id AND ic.IsActive = 1 AND ic.IsDeleted=0;";
            var _result = this.GetMultiple(query, false, new { @id = campaignId },
                                              r => r.Read<Initiative>(),
                                              r => r.Read<InitiativeCampaign>());

            var initiative = _result.Item1.ToList();
            var initiativeCampaign = _result.Item2.ToList();          

            var result = (from i in initiative
                          select new Initiative
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
                              InitiativeCampaign = (from ic in initiativeCampaign
                                                    where ic.InitiativeId == i.Id 
                                                    select new InitiativeCampaign
                                                    {
                                                        Id = ic.Id,
                                                        CampaignId = ic.CampaignId,
                                                        InitiativeId = ic.InitiativeId,
                                                        StartDate = ic.StartDate,
                                                        EndDate = ic.EndDate,
                                                        Description = ic.Description,
                                                        StartDateTime = ic.StartDateTime,
                                                        Result = ic.Result,
                                                        EvidenceName = ic.EvidenceName,
                                                        EvidenceResult = ic.EvidenceResult,
                                                        Target = ic.Target,
                                                        IsActive = ic.IsActive,
                                                        IsDeleted = ic.IsDeleted,
                                                        CreatedBy = ic.CreatedBy,
                                                        CreatedOn = ic.CreatedOn,
                                                        UpdatedBy = ic.UpdatedBy,
                                                        UpdatedOn = ic.UpdatedOn                                                       
                                                    }).ToList()

                          }).ToList();
            return result;
        }

        public int UpdateInitiative(Initiative initiative)
        {
            initiative.UpdatedOn = DateTime.Now;
            return base.Update(initiative);
        }
    }
}
