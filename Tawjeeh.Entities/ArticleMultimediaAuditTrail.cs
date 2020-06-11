using Dapper.Contrib.Extensions;
using System;

namespace Tawjeeh.Entities
{
    [Table("tblArticleMultimedia")]
    public class ArticleMultimediaAuditTrail
    {
        [Key]
        public Int64 Id { get; set; }
        public string DeviceId { get; set; }
        public int Status { get; set; }
        public Int64 ArticleMultimediaId { get; set; }
        public int LangId { get; set; }
        public DateTime? CreadOn { get; set; }
        public Int64? CreatedBy { get; set; }
        public DateTime? UpdateOn { get; set; }
        public Int64? UpdatedBy { get; set; }

    }
}
