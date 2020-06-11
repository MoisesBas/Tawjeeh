
namespace Tawjeeh.EntityServices.Interface
{
   public interface IServiceFactory
    {       
        ILawsService CreateLawsService { get; }
        IUserService CreateUserService { get; }
        ICenterService CreateCenterService { get; }
        IContactTypeService CreateContactTypeService { get; }
        IEmirateService CreateEmiratesService { get; }
        IArticleService CreateArticleService { get; }
        IDecisionService CreateDecisionService { get; }
        IUtilityService CreateUtilityService { get; }
        ICampaignService CreateCampaignService { get; }

        IInitiativeService CreateInitiativeService { get; }


    }
}
