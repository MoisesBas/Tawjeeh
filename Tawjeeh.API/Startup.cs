using System.Web.Http;
using Microsoft.Owin;
using Owin;
using Swashbuckle.Application;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using Tawjeeh.Api.Plugins;
using System.Configuration;
using System;

[assembly: log4net.Config.XmlConfigurator(Watch = true)]
[assembly: OwinStartup(typeof(Tawjeeh.Api.Startup))]

namespace Tawjeeh.Api
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
            app.Use(typeof(Logging));
            var config = new HttpConfiguration();
            InitAutoMapper();
            var kernel = ConfigureNinject(config);
            config.DependencyResolver = new NinjectResolver(kernel);

            //ConfigureComposition(config);            
            ConfigureWebApi(config);
            app.UseWebApi(config);

            config.EnableSwagger(c =>
            {
                c.RootUrl(req => ConfigurationManager.AppSettings["SwaggerURL"]);
                c.SchemaId(x => x.FullName);
                c.SingleApiVersion("1", "Tawjeeh Web API");
                c.IncludeXmlComments(System.Web.Hosting.HostingEnvironment.MapPath(ConfigurationManager.AppSettings["SwaggerParam"].ToString() + "/Tawjeeh.Api.xml"));
            }).EnableSwaggerUi();

            var settings = new JsonSerializerSettings();

            settings.PreserveReferencesHandling = PreserveReferencesHandling.None;

            settings.ContractResolver = new CamelCasePropertyNamesContractResolver();

            config.Formatters.JsonFormatter.SerializerSettings = settings;

            config.Formatters.Remove(config.Formatters.XmlFormatter);

            config.Formatters.JsonFormatter.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;


        }

        private void InitAutoMapper()
        {
            AutoMapper.Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<EntityModel.ContactType, Models.AddUpdateContactType>();
                cfg.CreateMap<Models.AddUpdateContactType, EntityModel.ContactType>()
                  .ForMember(d => d.IsActive, opt => opt.MapFrom(x => true))
                  .ForMember(d => d.IsDeleted, opt => opt.MapFrom(x => false))
                  .ForAllMembers(opts => opts.Condition((src, dest, sourceMember, destMember) => (sourceMember != null && Convert.ToString(sourceMember) != "" && Convert.ToString(sourceMember) != "0")));

                cfg.CreateMap<EntityModel.User, Models.UpdateUserViewModel>();
                cfg.CreateMap<Models.UpdateUserViewModel, EntityModel.User>()
                  .ForMember(d => d.IsActive, opt => opt.MapFrom(x => true))
                  .ForMember(d => d.IsDeleted, opt => opt.MapFrom(x => false))
                .ForAllMembers(opts => opts.Condition((src, dest, sourceMember, destMember) => (sourceMember != null && Convert.ToString(sourceMember) != "" && Convert.ToString(sourceMember) != "0")));

                cfg.CreateMap<Models.AddUpdateCenterTransViewModel, EntityModel.CenterTrans>()
                  .ForMember(d => d.IsActive, opt => opt.MapFrom(x => true))
                  .ForMember(d => d.IsDeleted, opt => opt.MapFrom(x => false))
                .ForAllMembers(opts => opts.Condition((src, dest, sourceMember, destMember) => (sourceMember != null && Convert.ToString(sourceMember) != "" && Convert.ToString(sourceMember) != "0")));

                cfg.CreateMap<EntityModel.User, Models.AddUpdateCenterUser>();
                cfg.CreateMap<Models.AddUpdateCenterUser, EntityModel.User>()
                  .ForMember(d => d.UserName, opt => opt.MapFrom(x => x.Email))
                  .ForMember(d => d.IsActive, opt => opt.MapFrom(x => true))
                  .ForMember(d => d.IsDeleted, opt => opt.MapFrom(x => false))
                  .ForAllMembers(opts => opts.Condition((src, dest, sourceMember, destMember) => (sourceMember != null && Convert.ToString(sourceMember) != "" && Convert.ToString(sourceMember) != "0")));

                cfg.CreateMap<EntityModel.User, Models.ResetPasswordConfirmationViewModel>();
                cfg.CreateMap<Models.ResetPasswordConfirmationViewModel, EntityModel.User>()
                .ForAllMembers(opts => opts.Condition((src, dest, sourceMember, destMember) => (sourceMember != null && Convert.ToString(sourceMember) != "" && Convert.ToString(sourceMember) != "0")));

                cfg.CreateMap<EntityModel.User, Models.ResetPasswordConfirmationViewModel>();
                cfg.CreateMap<Models.ResetPasswordConfirmationViewModel, EntityModel.User>()
                .ForAllMembers(opts => opts.Condition((src, dest, sourceMember, destMember) => (sourceMember != null && Convert.ToString(sourceMember) != "" && Convert.ToString(sourceMember) != "0")));

                cfg.CreateMap<Models.RegisterUserViewModel, EntityModel.User>()
                .ForMember(d => d.CreatedOn, opt => opt.MapFrom(x => DateTime.Now))
                .ForMember(d => d.CountryId, opt => opt.MapFrom(x => x.Nationality))
                .ForMember(d => d.IsActive, opt => opt.MapFrom(x => true))
                .ForMember(d => d.IsDeleted, opt => opt.MapFrom(x => false))
                .ForAllMembers(opts => opts.Condition((src, dest, sourceMember, destMember) => (sourceMember != null && Convert.ToString(sourceMember) != "" && Convert.ToString(sourceMember) != "0")));

                cfg.CreateMap<EntityModel.User, Models.RegisterUserViewModel>()
                .ForAllMembers(opts => opts.Condition((src, dest, sourceMember, destMember) => (sourceMember != null && Convert.ToString(sourceMember) != "" && Convert.ToString(sourceMember) != "0")));

                cfg.CreateMap<Models.VerifyOTPViewModel, EntityModel.User>()
                  .ForMember(d => d.Email, opt => opt.MapFrom(x => x.Email))
                  .ForMember(d => d.UserName, opt => opt.MapFrom(x => x.Email))
                  .ForMember(d => d.MobileNo, opt => opt.MapFrom(x => x.MobileNo))
                  .ForMember(d => d.OTP, opt => opt.MapFrom(x => x.OTP))
                  .ForAllMembers(opts => opts.Condition((src, dest, sourceMember, destMember) => (sourceMember != null && Convert.ToString(sourceMember) != "" && Convert.ToString(sourceMember) != "0")));
                cfg.CreateMap<Models.AddUpdateLawViewModel, EntityModel.LawTrans>()
                   .ForAllMembers(opts => opts.Condition((src, dest, sourceMember, destMember) => (sourceMember != null && Convert.ToString(sourceMember) != "" && Convert.ToString(sourceMember) != "0")));

                cfg.CreateMap<Models.AddUpdateLawViewModel, EntityModel.Law>()
                .ForAllMembers(opts => opts.Condition((src, dest, sourceMember, destMember) => (sourceMember != null && Convert.ToString(sourceMember) != "" && Convert.ToString(sourceMember) != "0")));

                cfg.CreateMap<Models.AddUpdateArticle, EntityModel.Article>()
                  .ForMember(d => d.IsActive, opt => opt.MapFrom(x => true))
                  .ForMember(d => d.IsDeleted, opt => opt.MapFrom(x => false))
                .ForAllMembers(opts => opts.Condition((src, dest, sourceMember, destMember) => (sourceMember != null && Convert.ToString(sourceMember) != "" && Convert.ToString(sourceMember) != "0")));
                
                cfg.CreateMap<Models.AddUpdateLawTranslationViewModel, EntityModel.LawTrans>()
                  .ForMember(d => d.IsActive, opt => opt.MapFrom(x => true))
                  .ForMember(d => d.IsDeleted, opt => opt.MapFrom(x => false))
                   .ForAllMembers(opts => opts.Condition((src, dest, sourceMember, destMember) => (sourceMember != null && Convert.ToString(sourceMember) != "" && Convert.ToString(sourceMember) != "0")));

                cfg.CreateMap<Models.AddUpdateArticleMultimedia, EntityModel.ArticleMultimedia>()
                   .ForAllMembers(opts => opts.Condition((src, dest, sourceMember, destMember) => (sourceMember != null && Convert.ToString(sourceMember) != "" && Convert.ToString(sourceMember) != "0")));
                
                cfg.CreateMap<Models.AddUpdateDecisionViewModel, EntityModel.Decision>()
                   .ForAllMembers(opts => opts.Condition((src, dest, sourceMember, destMember) => (sourceMember != null && Convert.ToString(sourceMember) != "" && Convert.ToString(sourceMember) != "0")));

                cfg.CreateMap<Models.AddUpdateDecisionTranslationViewModel, EntityModel.DecisionTrans>()
                   .ForAllMembers(opts => opts.Condition((src, dest, sourceMember, destMember) => (sourceMember != null && Convert.ToString(sourceMember) != "" && Convert.ToString(sourceMember) != "0")));

                cfg.CreateMap<Models.AddUpdateDecisionMultimediaViewModel, EntityModel.DecisionMultimedia>()
          .ForAllMembers(opts => opts.Condition((src, dest, sourceMember, destMember) => (sourceMember != null && Convert.ToString(sourceMember) != "" && Convert.ToString(sourceMember) != "0")));

                cfg.CreateMap<EntityModel.Decision, Models.DecisionsViewModels>()
             .ForAllMembers(opts => opts.Condition((src, dest, sourceMember, destMember) => (sourceMember != null && Convert.ToString(sourceMember) != "" && Convert.ToString(sourceMember) != "0")));

                cfg.CreateMap<Models.AddUpdateCampaignViewModel, EntityModel.Campaign>()
                   .ForAllMembers(opts => opts.Condition((src, dest, sourceMember, destMember) => (sourceMember != null && Convert.ToString(sourceMember) != "" && Convert.ToString(sourceMember) != "0")));

                cfg.CreateMap<Models.CampaignMultimediaViewModel, EntityModel.CampaignDocument>()
                   .ForMember(d => d.CampaignId, opt => opt.MapFrom(x => x.CampaignId))
                   .ForMember(d => d.CreatedOn, opt => opt.MapFrom(x => DateTime.Now))
                   .ForMember(d => d.IsActive, opt => opt.MapFrom(x => true))
                   .ForMember(d => d.IsDeleted, opt => opt.MapFrom(x => false))
                   .ForAllMembers(opts => opts.Condition((src, dest, sourceMember, destMember) => (sourceMember != null && Convert.ToString(sourceMember) != "" && Convert.ToString(sourceMember) != "0")));

                cfg.CreateMap<Models.CampaignMultimediaViewModel, EntityModel.CampaignDetail>()
                   .ForMember(d => d.CampaignId, opt => opt.MapFrom(x => x.CampaignId))
                   .ForMember(d => d.Type, opt => opt.MapFrom(x => x.Type))
                   .ForMember(d => d.SubTypeId, opt => opt.MapFrom(x => x.SubTypeId))
                   .ForMember(d => d.MultimediaId, opt => opt.MapFrom(x => 0))
                   .ForMember(d => d.Others, opt => opt.MapFrom(x => 0))
                   .ForMember(d => d.CreatedOn, opt => opt.MapFrom(x => DateTime.Now))
                   .ForMember(d => d.IsActive, opt => opt.MapFrom(x => true))
                   .ForMember(d => d.IsDeleted, opt => opt.MapFrom(x => false))
                 .ForAllMembers(opts => opts.Condition((src, dest, sourceMember, destMember) => (sourceMember != null && Convert.ToString(sourceMember) != "" && Convert.ToString(sourceMember) != "0")));

            });

            //AutoMapper.Mapper.Initialize(cfg =>
            //{
            //    #region User
            //    cfg.CreateMap<Entities.CenterContacts, Models.AddCenterContactViewModel>();
            //    cfg.CreateMap<Models.AddCenterContactViewModel, Entities.CenterContacts>()
            //    .ForAllMembers(opts => opts.Condition((src, dest, sourceMember, destMember) => (sourceMember != null && Convert.ToString(sourceMember) != "" && Convert.ToString(sourceMember) != "0")));

            //    cfg.CreateMap<Entities.User, Models.AddContactsViewModel>();
            //    cfg.CreateMap<Models.AddContactsViewModel, Entities.User>()
            //      .ForMember(d => d.UserName, opt => opt.MapFrom(x => x.Email))
            //      .ForAllMembers(opts => opts.Condition((src, dest, sourceMember, destMember) => (sourceMember != null && Convert.ToString(sourceMember) != "" && Convert.ToString(sourceMember) != "0")));



            //    cfg.CreateMap<Entities.User, Models.UpdateUserViewModel>();
            //    cfg.CreateMap<Models.UpdateUserViewModel, Entities.User>()
            //    .ForMember(d => d.UpdatedOn, opt => opt.MapFrom(x => DateTime.Now))
            //    .ForAllMembers(opts => opts.Condition((src, dest, sourceMember, destMember) => (sourceMember != null && Convert.ToString(sourceMember) != "" && Convert.ToString(sourceMember) != "0")));

            //    cfg.CreateMap<Entities.User, Models.AddUserViewModel>();
            //    cfg.CreateMap<Models.AddUserViewModel, Entities.User>()
            //    .ForMember(d => d.CreatedOn, opt => opt.MapFrom(x => DateTime.Now))
            //    .ForMember(d => d.IsActive, opt => opt.MapFrom(x => true))
            //    .ForMember(d => d.IsDeleted, opt => opt.MapFrom(x => false))
            //    .ForAllMembers(opts => opts.Condition((src, dest, sourceMember, destMember) => (sourceMember != null && Convert.ToString(sourceMember) != "" && Convert.ToString(sourceMember) != "0")));

            //    cfg.CreateMap<Entities.User, Models.UpdateUserViewModel>();
            //    cfg.CreateMap<Models.UpdateUserViewModel, User>()
            //       .ForAllMembers(opts => opts.Condition((src, dest, sourceMember, destMember) => (sourceMember != null && Convert.ToString(sourceMember) != "" && Convert.ToString(sourceMember) != "0")));


            //    cfg.CreateMap<Models.RegisterUserViewModel, Entities.User>()                   
            //       .ForMember(d => d.CreatedOn, opt => opt.MapFrom(x => DateTime.Now))
            //       .ForMember(d=>d.CountryId, opt=>opt.MapFrom(x=>x.Nationality))
            //       .ForMember(d => d.IsActive, opt => opt.MapFrom(x => true))
            //       .ForMember(d => d.IsDeleted, opt => opt.MapFrom(x => false))
            //       .ForAllMembers(opts => opts.Condition((src, dest, sourceMember, destMember) => (sourceMember != null && Convert.ToString(sourceMember) != "" && Convert.ToString(sourceMember) != "0")));

            //    cfg.CreateMap<Models.ResendOTPViewModel, Entities.User>()
            //      .ForMember(d => d.Email, opt => opt.MapFrom(x => x.Email))
            //      .ForMember(d => d.UserName, opt => opt.MapFrom(x => x.Email))
            //      .ForMember(d => d.MobileNo, opt => opt.MapFrom(x=>x.MobileNo))    
            //      .ForAllMembers(opts => opts.Condition((src, dest, sourceMember, destMember) => (sourceMember != null && Convert.ToString(sourceMember) != "" && Convert.ToString(sourceMember) != "0")));

            //    cfg.CreateMap<Models.VerifyOTPViewModel, Entities.User>()
            //      .ForMember(d => d.Email, opt => opt.MapFrom(x => x.Email))
            //      .ForMember(d => d.UserName, opt => opt.MapFrom(x => x.Email))
            //      .ForMember(d => d.MobileNo, opt => opt.MapFrom(x => x.MobileNo))
            //      .ForMember(d => d.OTP, opt => opt.MapFrom(x => x.OTP))
            //      .ForAllMembers(opts => opts.Condition((src, dest, sourceMember, destMember) => (sourceMember != null && Convert.ToString(sourceMember) != "" && Convert.ToString(sourceMember) != "0")));

            //    cfg.CreateMap<Entities.User, Models.RegisterUserViewModel>()
            //    .ForAllMembers(opts => opts.Condition((src, dest, sourceMember, destMember) => (sourceMember != null && Convert.ToString(sourceMember) != "" && Convert.ToString(sourceMember) != "0")));

            //    cfg.CreateMap<Entities.MenuAccess, Models.AddUserAccess>();
            //    cfg.CreateMap<Models.AddUserAccess, Entities.MenuAccess>()
            //       .ForAllMembers(opts => opts.Condition((src, dest, sourceMember, destMember) => (sourceMember != null && Convert.ToString(sourceMember) != "" && Convert.ToString(sourceMember) != "0")));
            //    #endregion

            //    #region Center              

            //    cfg.CreateMap<Models.AddContactsViewModel, Entities.CenterContacts>()
            //   .ForMember(d => d.ContactTypeId, opt => opt.MapFrom(x => x.ContactTypeId));

            //    cfg.CreateMap<Entities.Centers, Models.AddUpdateCenterViewModel>();
            //    cfg.CreateMap<Models.AddUpdateCenterViewModel, Entities.Centers>()               
            //    .ForAllMembers(opts => opts.Condition((src, dest, sourceMember, destMember) => (sourceMember != null && Convert.ToString(sourceMember) != "" && Convert.ToString(sourceMember) != "0")));

            //    cfg.CreateMap<Entities.Centers, Models.UpdateCenterViewModel>();
            //    cfg.CreateMap<Models.UpdateCenterViewModel, Entities.Centers>()
            //    .ForMember(d => d.UpdatedOn, opt => opt.MapFrom(x => DateTime.Now))
            //    .ForMember(d => d.IsActive, opt => opt.MapFrom(x => true))
            //    .ForMember(d => d.IsDeleted, opt => opt.MapFrom(x => false))
            //           .ForAllMembers(opts => opts.Condition((src, dest, sourceMember, destMember) => (sourceMember != null && Convert.ToString(sourceMember) != "" && Convert.ToString(sourceMember) != "0")));
            //    #endregion

            //    #region Menu Access
            //    cfg.CreateMap<Entities.MenuAccess, Models.AddUpdateMenuAccess>();
            //    cfg.CreateMap<Models.AddUpdateMenuAccess, Entities.MenuAccess>()
            //       .ForAllMembers(opts => opts.Condition((src, dest, sourceMember, destMember) => (sourceMember != null && Convert.ToString(sourceMember) != "" && Convert.ToString(sourceMember) != "0")));
            //    #endregion 

            //    cfg.CreateMap<Entities.User, Entities.CenterContacts>()
            //    .ForMember(d => d.CenterId, opt => opt.MapFrom(x => x.CenterId))
            //    .ForMember(d => d.UserId, opt => opt.MapFrom(x => x.Id))
            //    .ForMember(d => d.ContactTypeId, opt => opt.MapFrom(x => x.ContactTypeId))
            //    .ForMember(d => d.CenterId, opt => opt.MapFrom(x => x.CenterId))
            //    .ForMember(d => d.CreatedOn, opt => opt.MapFrom(x => DateTime.Now))
            //    .ForMember(d => d.IsActive, opt => opt.MapFrom(x => true))
            //    .ForMember(d => d.IsDeleted, opt => opt.MapFrom(x => false));       


            //    cfg.CreateMap<Models.AddUpdateCenterTransViewModel, Entities.CenterTrans>()
            //    .ForAllMembers(opts => opts.Condition((src, dest, sourceMember, destMember) => (sourceMember != null && Convert.ToString(sourceMember) != "" && Convert.ToString(sourceMember) != "0")));

            //    cfg.CreateMap<Entities.Centers, Entities.CenterTrans>()
            //    .ForMember(d => d.CreatedOn, opt => opt.MapFrom(x => DateTime.Now))
            //    .ForMember(d => d.IsActive, opt => opt.MapFrom(x => true))
            //    .ForMember(d => d.IsDeleted, opt => opt.MapFrom(x => false))
            //    .ForAllMembers(opts => opts.Condition((src, dest, sourceMember, destMember) => (sourceMember != null && Convert.ToString(sourceMember) != "" && Convert.ToString(sourceMember) != "0")));


            //    cfg.CreateMap<Entities.Law, Entities.LawTrans>()
            //   .ForMember(d => d.CreatedOn, opt => opt.MapFrom(x => DateTime.Now))
            //   .ForMember(d => d.IsActive, opt => opt.MapFrom(x => true))
            //   .ForMember(d => d.IsDeleted, opt => opt.MapFrom(x => false))
            //   .ForAllMembers(opts => opts.Condition((src, dest, sourceMember, destMember) => (sourceMember != null && Convert.ToString(sourceMember) != "" && Convert.ToString(sourceMember) != "0")));

            //    cfg.CreateMap<Models.AddLawViewModel, Entities.Law>()
            //    .ForMember(d => d.CreatedOn, opt => opt.MapFrom(x => DateTime.Now))
            //    .ForMember(d => d.IsActive, opt => opt.MapFrom(x => true))
            //    .ForMember(d => d.IsDeleted, opt => opt.MapFrom(x => false))
            //    .ForAllMembers(opts => opts.Condition((src, dest, sourceMember, destMember) => (sourceMember != null && Convert.ToString(sourceMember) != "" && Convert.ToString(sourceMember) != "0")));

            //    cfg.CreateMap<Models.AddUpdateLawViewModel, Entities.Law>()
            //    .ForAllMembers(opts => opts.Condition((src, dest, sourceMember, destMember) => (sourceMember != null && Convert.ToString(sourceMember) != "" && Convert.ToString(sourceMember) != "0")));

            //    cfg.CreateMap<Models.AddUpdateArticle, Entities.Article>()
            //    .ForAllMembers(opts => opts.Condition((src, dest, sourceMember, destMember) => (sourceMember != null && Convert.ToString(sourceMember) != "" && Convert.ToString(sourceMember) != "0")));


            //    cfg.CreateMap<Models.AddUpdateArticleTrans, Entities.ArticleTrans>()
            //       .ForAllMembers(opts => opts.Condition((src, dest, sourceMember, destMember) => (sourceMember != null && Convert.ToString(sourceMember) != "" && Convert.ToString(sourceMember) != "0")));



            //    cfg.CreateMap<Models.AddUpdateDecisionTranslationViewModel, Entities.DecisionTrans>()
            //       .ForAllMembers(opts => opts.Condition((src, dest, sourceMember, destMember) => (sourceMember != null && Convert.ToString(sourceMember) != "" && Convert.ToString(sourceMember) != "0")));

       

            //    cfg.CreateMap<Models.AddUpdateArticleMultimedia, Entities.ArticleMultimedia>()
            //       .ForAllMembers(opts => opts.Condition((src, dest, sourceMember, destMember) => (sourceMember != null && Convert.ToString(sourceMember) != "" && Convert.ToString(sourceMember) != "0")));


            //    cfg.CreateMap<Models.AddUpdateLawTranslationViewModel, Entities.LawTrans>()
            //       .ForMember(d => d.CreatedOn, opt => opt.MapFrom(x => DateTime.Now))
            //       .ForMember(d => d.IsActive, opt => opt.MapFrom(x => true))
            //       .ForMember(d => d.IsDeleted, opt => opt.MapFrom(x => false))
            //       .ForAllMembers(opts => opts.Condition((src, dest, sourceMember, destMember) => (sourceMember != null && Convert.ToString(sourceMember) != "" && Convert.ToString(sourceMember) != "0")));

            //    cfg.CreateMap<Models.UpdateLawTranslationViewModel, Entities.LawTrans>()
            //       .ForMember(d => d.UpdatedOn, opt => opt.MapFrom(x => DateTime.Now))
            //       .ForMember(d => d.IsActive, opt => opt.MapFrom(x => true))
            //       .ForMember(d => d.IsDeleted, opt => opt.MapFrom(x => false))
            //       .ForAllMembers(opts => opts.Condition((src, dest, sourceMember, destMember) => (sourceMember != null && Convert.ToString(sourceMember) != "" && Convert.ToString(sourceMember) != "0")));


            //    cfg.CreateMap<Models.AddUpdateCampaignViewModel, Entities.Campaign>()
            //       .ForAllMembers(opts => opts.Condition((src, dest, sourceMember, destMember) => (sourceMember != null && Convert.ToString(sourceMember) != "" && Convert.ToString(sourceMember) != "0")));

            //    cfg.CreateMap<Models.AddUpdateInitiativeViewModel, Entities.Initiative>()
            //       .ForMember(d=>d.InitiativeType,opt=> opt.Ignore())
            //       .ForAllMembers(opts => opts.Condition((src, dest, sourceMember, destMember) => (sourceMember != null && Convert.ToString(sourceMember) != "" && Convert.ToString(sourceMember) != "0")));

            //    cfg.CreateMap<Models.CampaignMultimediaViewModel, Entities.CampaignDocument>()
            //       .ForMember(d => d.CampaignId, opt => opt.MapFrom(x => x.CampaignId))               
            //       .ForMember(d => d.CreatedOn, opt => opt.MapFrom(x => DateTime.Now))
            //       .ForMember(d => d.IsActive, opt => opt.MapFrom(x => true))
            //       .ForMember(d => d.IsDeleted, opt => opt.MapFrom(x => false))
            //       .ForAllMembers(opts => opts.Condition((src, dest, sourceMember, destMember) => (sourceMember != null && Convert.ToString(sourceMember) != "" && Convert.ToString(sourceMember) != "0")));

            //    cfg.CreateMap<Models.CampaignMultimediaViewModel, Entities.CampaignDetails>()
            //       .ForMember(d => d.CampaignId, opt => opt.MapFrom(x => x.CampaignId))
            //       .ForMember(d => d.Type, opt => opt.MapFrom(x => x.Type))
            //       .ForMember(d => d.SubTypeId, opt => opt.MapFrom(x => x.SubTypeId))
            //       .ForMember(d => d.MultimediaId, opt => opt.MapFrom(x => 0))
            //       .ForMember(d => d.Others, opt => opt.MapFrom(x => 0))
            //       .ForMember(d => d.CreatedOn, opt => opt.MapFrom(x => DateTime.Now))
            //       .ForMember(d => d.IsActive, opt => opt.MapFrom(x => true))
            //       .ForMember(d => d.IsDeleted, opt => opt.MapFrom(x => false))
            //     .ForAllMembers(opts => opts.Condition((src, dest, sourceMember, destMember) => (sourceMember != null && Convert.ToString(sourceMember) != "" && Convert.ToString(sourceMember) != "0")));

            //    cfg.CreateMap<Models.AddUpdateCampaignDetails, Entities.CampaignDetails>()
            //       .ForAllMembers(opts => opts.Condition((src, dest, sourceMember, destMember) => (sourceMember != null && Convert.ToString(sourceMember) != "" && Convert.ToString(sourceMember) != "0")));
            //});
        }
    }
}
