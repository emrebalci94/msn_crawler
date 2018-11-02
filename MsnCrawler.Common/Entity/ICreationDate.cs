using System;
using System.Collections.Generic;
using System.Text;

namespace MsnCrawler.Common.Entity
{
    public interface ICreationDate
    {
        DateTime? CreatedAt { get; set; }
        DateTime? UpdateAt { get; set; }
    }
}
