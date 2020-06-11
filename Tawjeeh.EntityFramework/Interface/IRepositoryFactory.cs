
using Tawjeeh.EntityModel;

namespace Tawjeeh.EntityFramework.Interface
{
    public interface IRepositoryFactory
    {
        ILawRepository<Law> GetLawRepository { get; }
        ILawTransRepository<LawTrans> GetLawTransRepository { get; }
        IUserRepository<User> GetUserRepository { get; }
        ICenterRepository<Centers> GetCenterRepository { get; }
        IArticleRepository<Article> GetArticleRepository { get; }
        IArticleMultimediaRepository<ArticleMultimedia> GetArticleMultimediaRepository { get; }
        IContactTypeRepository<ContactType> GetContactTypeRepository { get; }
        IContactRepository<CenterContacts> GetContactRepository { get; }
        IEmiratesRepository<Emirates>  GetEmiratesRepository { get; }
        ICenterTransRepository<CenterTrans> GetCenterTransRepository { get; }
        IArticleTransRepository<ArticleTrans> GetArticleTransRepository { get; }
        IDecisionRepository<Decision> GetDecisionRepository { get; }
        IDecisionTransRepository<DecisionTrans> GetDecisionTransRepository { get; }
        ICountryRepository<Country> GetCountryRepository { get; }
        IDecisionMultimediaRepository<DecisionMultimedia> GetDecisionMultimediaRepository { get; }
        ICampaignRepository<Campaign> GetCampaignRepository { get; }
        IInitiativeTypeRepository<InitiativeType> GetInitiativeTypeRepository { get; }
        IInitiativeRepository<Initiative> GetInitiativeRepository { get; } 
        IInitiativeCampaignRepository<InitiativeCampaign> GetInitiativeCampaignRepository { get; }
        ICampaignDetailsRepository<CampaignDetail> GetCampaignDetailsRepository { get; }
        ICampaignDocumentRepository<CampaignDocument> GetCampaignDocumentRepository { get; }
        IMultimediaTypeRepository<MultimediaType> GetMultimediaTypeRepository { get; }

    }
}
