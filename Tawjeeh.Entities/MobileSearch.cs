using System;

namespace Tawjeeh.Entities
{
    public class MobileSearch
    {       
        public Int64 SearchId { get; set; }
        public string Type { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string FileUrl { get; set; }
        public string VideoUrl { get; set; }
        public string FileType { get; set; }
        public int LangId { get; set; }
    }
}
