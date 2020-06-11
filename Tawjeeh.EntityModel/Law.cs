using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tawjeeh.EntityModel
{
    [Table("tblLaw")]
    public class Law
    {
        public Law()
        {
            this.LawTranslation = new List<LawTrans>();
            this.Articles = new List<Article>();
        }   
        public Int64 Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }       
        public Int64? LangId { get; set; }
        [Write(false)]
        public IList<LawTrans> LawTranslation { get; set; }
        [Write(false)]
        public IList<Article> Articles { get; set; }
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }
        [Write(false)]
        public int DecisionCnt { get; set; }

        [Write(false)]
        public int MultimediaCnt { get; set; }
        public DateTime? CreatedOn { get; set; }
        public Int64? CreatedBy { get; set; }
        public DateTime? UpdatedOn { get; set; }
        public Int64? UpdatedBy { get; set; }


    }
}
