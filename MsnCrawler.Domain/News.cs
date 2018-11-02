using MsnCrawler.Common.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace MsnCrawler.Domain
{
    public class News : BaseEntity, ICreationDate, ISoftDelete
    {
        public string Title { get; set; }
        public int CompanyId { get; set; }
        public int SameCount { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdateAt { get; set; }
        public bool Deleted { get; set; }

        public Company Company { get; set; }
    }
}
