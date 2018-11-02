using MsnCrawler.Common.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace MsnCrawler.Domain
{
    public class Company : BaseEntity, ICreationDate, ISoftDelete
    {
        public Company()
        {
            News = new HashSet<News>();
        }
        public string Name { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdateAt { get; set; }
        public bool Deleted { get; set; }

        public ICollection<News> News { get; set; }
    }
}
