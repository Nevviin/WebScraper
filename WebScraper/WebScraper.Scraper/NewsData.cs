using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebScraper.Scraper
{
    class NewsData
    {

        public DateTime PublishedDate { get; set; }
        public string NewsSource { get; set; }
        public string Url { get; set; }
        public string Heading { get; set; }
        public string ContentBrief { get; set; }
                                  
    }
}
