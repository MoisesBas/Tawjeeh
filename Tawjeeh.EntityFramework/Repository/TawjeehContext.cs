using System;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Reflection;
using Tawjeeh.EntityModel;
using Tawjeeh.EntityFramework.Interface;
using EntityFramework.DynamicFilters;
using Tawjeeh.EntityFramework.Helper;

namespace Tawjeeh.EntityFramework.Repository
{

    [DbConfigurationType(typeof(TawjeehConfiguration))]
    public partial class TawjeehContext : DbContext, IDisposedTracker
    {
        static TawjeehContext()
        {
            Database.SetInitializer<TawjeehContext>(null);
        }
        public TawjeehContext() :
            base("TawjeehConnection")
        {
           

        }
        public virtual DbSet<Article> Article { get; set; }       
        public virtual DbSet<ArticleMultimedia> ArticleMultimedia { get; set; }
        public virtual DbSet<ArticleTrans> ArticleTrans { get; set; }
        public virtual DbSet<Campaign> Campaign { get; set; }
        public virtual DbSet<CampaignDetail> CampaignDetails { get; set; }
        public virtual DbSet<CampaignDocument> CampaignDocument { get; set; }       
        public virtual DbSet<CenterContacts> CenterContacts { get; set; }
        public virtual DbSet<Centers> Centers { get; set; }
        public virtual DbSet<CenterTrans> CenterTrans { get; set; }
        //public DbSet<Company> Company { get; set; }
        public virtual DbSet<ContactType> ContactType { get; set; }
        public virtual DbSet<Country> Country { get; set; }   
        public virtual DbSet<Decision> Decision { get; set; }
        public virtual DbSet<DecisionMultimedia> DecisionMultimedia { get; set; }
        public virtual DbSet<DecisionTrans> DecisionTrans { get; set; }
        public virtual DbSet<Emirates> Emirates { get; set; }
        public virtual DbSet<Goal> Goal { get; set; }
        public virtual DbSet<Initiative> Initiative { get; set; }
        public virtual DbSet<InitiativeCampaign> InitiativeCampaign { get; set; }
        public virtual DbSet<InitiativeType> InitiativeType { get; set; }
        //public virtual DbSet<Lang> Lang { get; set; }
        public virtual DbSet<Law> Law { get; set; }
        public virtual DbSet<LawTrans> LawTrans { get; set; }
        public virtual DbSet<User> Users { get; set; }
        //public DbSet<Menu> Menu { get; set; }
        //public DbSet<MenuAccess> MenuAccess { get; set; }      

        public DbSet<MultimediaType> MultimediaType { get; set; }
        //public DbSet<PushNotificationLogs> PushNotificationLogs { get; set; }
       
        public virtual DbSet<UserType> UserType { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
           
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
           
            modelBuilder.Filter("IsDisabled", (BaseEntity x) => x.IsDeleted, false);
            var typesToRegister = Assembly.GetExecutingAssembly().GetTypes()
           .Where(type => !String.IsNullOrEmpty(type.Namespace))
           .Where(type => type.BaseType != null && type.BaseType.IsGenericType
                && type.BaseType.GetGenericTypeDefinition() == typeof(EntityTypeConfiguration<>));

            foreach (var type in typesToRegister)
            {
                dynamic configurationInstance = Activator.CreateInstance(type);
                modelBuilder.Configurations.Add(configurationInstance);
            }

            //base.OnModelCreating(modelBuilder);

        }
        protected override void Dispose(bool disposing)
        {
            IsDisposed = true;
            base.Dispose(disposing);
        }
        public bool IsDisposed { get; set; }
        public object Configurations { get; internal set; }
    }
}
