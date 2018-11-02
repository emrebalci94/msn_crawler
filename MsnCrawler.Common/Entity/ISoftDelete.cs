using System;
using System.Collections.Generic;
using System.Text;

namespace MsnCrawler.Common.Entity
{
    public interface ISoftDelete
    {
         bool Deleted { get; set; }
    }
}
