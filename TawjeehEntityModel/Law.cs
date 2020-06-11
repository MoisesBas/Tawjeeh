using System.Collections.Generic;

namespace Tawjeeh.EntityModel
{

    public partial class Law: BaseEntity
    {
        public Law()
        {
            Articles = new HashSet<Article>();
            LawTranslations = new HashSet<LawTrans>();
        } 
        public string Name { get; set; }
        public string Description { get; set; }           
        public virtual ICollection<LawTrans> LawTranslations { get; set; }
        public virtual ICollection<Article> Articles { get; set; }        
    }
}
