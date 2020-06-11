
using Ninject;
using Tawjeeh.EntityFramework.Helper;
using Tawjeeh.EntityFramework.Interface;
using Tawjeeh.EntityModel;

namespace Tawjeeh.EntityFramework.Repository
{
    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="Ninject.Modules.NinjectModule" />
    /// <seealso cref="Tawjeeh.EntityFramework.Interface.IRepositoryFactory" />
    public class RepositoryFactory :  Ninject.Modules.NinjectModule, 
        IRepositoryFactory
    {
        /// <summary>
        /// The kernel
        /// </summary>
        IKernel _kernel;
        /// <summary>
        /// Initializes a new instance of the <see cref="RepositoryFactory"/> class.
        /// </summary>
        /// <param name="kernel">The kernel.</param>
        public RepositoryFactory(IKernel kernel)
        {
            _kernel = kernel;
        }
        /// <summary>
        /// Gets the get law repository.
        /// </summary>
        /// <value>
        /// The get law repository.
        /// </value>
        public ILawRepository<Law> GetLawRepository => _kernel.Get<ILawRepository<Law>>();
        /// <summary>
        /// Gets the get user repository.
        /// </summary>
        /// <value>
        /// The get user repository.
        /// </value>
        public IUserRepository<User> GetUserRepository => _kernel.Get<IUserRepository<User>>();
        /// <summary>
        /// Gets the get center repository.
        /// </summary>
        /// <value>
        /// The get center repository.
        /// </value>
        public ICenterRepository<Centers> GetCenterRepository => _kernel.Get<ICenterRepository<Centers>>();
        /// <summary>
        /// Gets the get article repository.
        /// </summary>
        /// <value>
        /// The get article repository.
        /// </value>
        public IArticleRepository<Article> GetArticleRepository => _kernel.Get<IArticleRepository<Article>>();
        /// <summary>
        /// Gets the get article trans repository.
        /// </summary>
        /// <value>
        /// The get article trans repository.
        /// </value>
        public IArticleTransRepository<ArticleTrans> GetArticleTransRepository => _kernel.Get<IArticleTransRepository<ArticleTrans>>();
        /// <summary>
        /// Gets the get article multimedia repository.
        /// </summary>
        /// <value>
        /// The get article multimedia repository.
        /// </value>
        public IArticleMultimediaRepository<ArticleMultimedia> GetArticleMultimediaRepository => _kernel.Get<IArticleMultimediaRepository<ArticleMultimedia>>();
        /// <summary>
        /// Gets the get contact type repository.
        /// </summary>
        /// <value>
        /// The get contact type repository.
        /// </value>
        public IContactTypeRepository<ContactType> GetContactTypeRepository => _kernel.Get<IContactTypeRepository<ContactType>>();
        /// <summary>
        /// Gets the get contact repository.
        /// </summary>
        /// <value>
        /// The get contact repository.
        /// </value>
        public IContactRepository<CenterContacts> GetContactRepository => _kernel.Get<IContactRepository<CenterContacts>>();
        /// <summary>
        /// Gets the get emirates repository.
        /// </summary>
        /// <value>
        /// The get emirates repository.
        /// </value>
        public IEmiratesRepository<Emirates> GetEmiratesRepository => _kernel.Get<IEmiratesRepository<Emirates>>();
        /// <summary>
        /// Gets the get center trans repository.
        /// </summary>
        /// <value>
        /// The get center trans repository.
        /// </value>
        public ICenterTransRepository<CenterTrans> GetCenterTransRepository => _kernel.Get<ICenterTransRepository<CenterTrans>>();
        /// <summary>
        /// Gets the get decision repository.
        /// </summary>
        /// <value>
        /// The get decision repository.
        /// </value>
        public IDecisionRepository<Decision> GetDecisionRepository => _kernel.Get<IDecisionRepository<Decision>>();
        /// <summary>
        /// Gets the get law trans repository.
        /// </summary>
        /// <value>
        /// The get law trans repository.
        /// </value>
        public ILawTransRepository<LawTrans> GetLawTransRepository => _kernel.Get<ILawTransRepository<LawTrans>>();
        /// <summary>
        /// Gets the get country repository.
        /// </summary>
        /// <value>
        /// The get country repository.
        /// </value>
        public ICountryRepository<Country> GetCountryRepository => _kernel.Get<ICountryRepository<Country>>();
        /// <summary>
        /// Gets the get decision trans repository.
        /// </summary>
        /// <value>
        /// The get decision trans repository.
        /// </value>
        public IDecisionTransRepository<DecisionTrans> GetDecisionTransRepository => _kernel.Get<IDecisionTransRepository<DecisionTrans>>();
        /// <summary>
        /// Gets the get decision multimedia repository.
        /// </summary>
        /// <value>
        /// The get decision multimedia repository.
        /// </value>
        public IDecisionMultimediaRepository<DecisionMultimedia> GetDecisionMultimediaRepository => _kernel.Get<IDecisionMultimediaRepository<DecisionMultimedia>>();
        /// <summary>
        /// Gets the get campaign repository.
        /// </summary>
        /// <value>
        /// The get campaign repository.
        /// </value>
        public ICampaignRepository<Campaign> GetCampaignRepository => _kernel.Get<ICampaignRepository<Campaign>>();
        /// <summary>
        /// Gets the get initiative type repository.
        /// </summary>
        /// <value>
        /// The get initiative type repository.
        /// </value>
        public IInitiativeTypeRepository<InitiativeType> GetInitiativeTypeRepository => _kernel.Get<IInitiativeTypeRepository<InitiativeType>>();
        /// <summary>
        /// Gets the get initiative repository.
        /// </summary>
        /// <value>
        /// The get initiative repository.
        /// </value>
        public IInitiativeRepository<Initiative> GetInitiativeRepository => _kernel.Get<IInitiativeRepository<Initiative>>();
        /// <summary>
        /// Gets the get initiative campaign repository.
        /// </summary>
        /// <value>
        /// The get initiative campaign repository.
        /// </value>
        public IInitiativeCampaignRepository<InitiativeCampaign> GetInitiativeCampaignRepository => _kernel.Get<IInitiativeCampaignRepository<InitiativeCampaign>>();
        /// <summary>
        /// Gets the get campaign details repository.
        /// </summary>
        /// <value>
        /// The get campaign details repository.
        /// </value>
        public ICampaignDetailsRepository<CampaignDetail> GetCampaignDetailsRepository => _kernel.Get<ICampaignDetailsRepository<CampaignDetail>>();
        /// <summary>
        /// Gets the get campaign document repository.
        /// </summary>
        /// <value>
        /// The get campaign document repository.
        /// </value>
        public ICampaignDocumentRepository<CampaignDocument> GetCampaignDocumentRepository => _kernel.Get<ICampaignDocumentRepository<CampaignDocument>>();
        /// <summary>
        /// Gets the get multimedia type repository.
        /// </summary>
        /// <value>
        /// The get multimedia type repository.
        /// </value>
        public IMultimediaTypeRepository<MultimediaType> GetMultimediaTypeRepository => _kernel.Get<IMultimediaTypeRepository<MultimediaType>>();

        /// <summary>
        /// Loads the module into the kernel.
        /// </summary>
        public override void Load()
        {
            _kernel.Bind(typeof(IQuery<>)).To(typeof(Query<>));
            _kernel.Bind(typeof(ICenterRepository<Centers>)).To(typeof(CenterRepository));
            _kernel.Bind(typeof(IArticleRepository<Article>)).To(typeof(ArticleRepository));
            _kernel.Bind(typeof(ILawRepository<Law>)).To(typeof(LawRepository));
            _kernel.Bind(typeof(ILawTransRepository<LawTrans>)).To(typeof(LawTransRepository));
            _kernel.Bind(typeof(IUserRepository<User>)).To(typeof(UserRepository));
            _kernel.Bind(typeof(IArticleMultimediaRepository<ArticleMultimedia>)).To(typeof(ArticleMultimediaRepository));
            _kernel.Bind(typeof(IContactTypeRepository<ContactType>)).To(typeof(ContactTypeRepository));
            _kernel.Bind(typeof(IContactRepository<CenterContacts>)).To(typeof(CenterContactRepository));
            _kernel.Bind(typeof(IEmiratesRepository<Emirates>)).To(typeof(EmiratesRepository));
            _kernel.Bind(typeof(ICenterTransRepository<CenterTrans>)).To(typeof(CenterTransRepository));
            _kernel.Bind(typeof(IArticleTransRepository<ArticleTrans>)).To(typeof(ArticleTransRepository));
            _kernel.Bind(typeof(IDecisionRepository<Decision>)).To(typeof(DecisionRepository));         
            _kernel.Bind(typeof(ICountryRepository<Country>)).To(typeof(CountryRepository));
            _kernel.Bind(typeof(IDecisionTransRepository<DecisionTrans>)).To(typeof(DecisionTransRepository));
            _kernel.Bind(typeof(IDecisionMultimediaRepository<DecisionMultimedia>)).To(typeof(DecisionMultimediaRepository));
            _kernel.Bind(typeof(ICampaignRepository<Campaign>)).To(typeof(CampaignRepository));
            _kernel.Bind(typeof(IInitiativeTypeRepository<InitiativeType>)).To(typeof(InitiativeTypeRepository));
            _kernel.Bind(typeof(IInitiativeRepository<Initiative>)).To(typeof(InitiativeRepository));
            _kernel.Bind(typeof(IInitiativeCampaignRepository<InitiativeCampaign>)).To(typeof(InitiativeCampaignRepository));
            _kernel.Bind(typeof(ICampaignDetailsRepository<CampaignDetail>)).To(typeof(CampaignDetailsRepository));
            _kernel.Bind(typeof(ICampaignDocumentRepository<CampaignDocument>)).To(typeof(CampaignDocumentRepository));
            _kernel.Bind(typeof(IMultimediaTypeRepository<MultimediaType>)).To(typeof(MultimediaTypeRepository));
        }
    }
}
