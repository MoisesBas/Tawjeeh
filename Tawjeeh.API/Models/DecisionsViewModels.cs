using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Tawjeeh.EntityModel;

namespace Tawjeeh.Api.Models
{
    public class DecisionsViewModels
    {
        public DecisionsViewModels()
        {
            MultimediaDecisions = new List<DecisionMultimedia>();
            DecisionTranslations = new List<DecisionTrans>();
        }
        public string Name { get; set; }
        public string Description { get; set; }
        public string DecisionNo { get; set; }
        public long? ArticleId { get; set; }
        public long? Year { get; set; }
        public Article Articles { get; set; }
        public ICollection<DecisionMultimedia> MultimediaDecisions { get; set; }
        public ICollection<DecisionTrans> DecisionTranslations { get; set; }      
        public  Law Laws { get; set; }
        public long Id { get; set; }
        public bool? IsActive { get; set; }
        public bool? IsDeleted { get; set; }
        public DateTime? CreatedOn { get; set; }
        public long? CreatedBy { get; set; }
        public DateTime? UpdatedOn { get; set; }
        public long? UpdatedBy { get; set; }
    }
}