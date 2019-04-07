using System;
using System.Collections.Generic;
using System.Linq;
using ScrapySharp.Network;
using HtmlAgilityPack;
using Newtonsoft.Json;
using WebScraper.Scraper.DataModel;
using System.Data.Entity.Core;

namespace WebScraper.Scraper
{
    class Program
    {
        static void Main(string[] args)
        {
            ScrapingBrowser browser = new ScrapingBrowser();
            browser.AllowAutoRedirect = true;
            browser.AllowMetaRedirect = true;

            //WebPage pageResult = browser.NavigateToPage(new Uri("https://www.fool.com.au/"));


            WebPage pageResult = browser.NavigateToPage(new Uri(" https://www.afr.com/markets/equity-markets"));
            //HtmlNode titleNOde = pageResult.Html.ChildNodes[]

            var weGet = new HtmlWeb();


            HtmlDocument htmlDocument1 = weGet.Load("https://www.afr.com/markets/equity-markets");

            if (weGet.Load("https://www.afr.com/markets/equity-markets") is HtmlDocument htmlDocument)
            {
                //var nodes = htmlDocument.DocumentNode.CssSelect("#strap__body div").ToList();
                foreach (HtmlNode htmlNode in htmlDocument.DocumentNode.SelectNodes("//div[@class='" + "strap__body" + "']"))
                {
                    var htmlNodeData = htmlNode;

                }


                List<HtmlNode> htmlNodes = new List<HtmlNode>();

                foreach (HtmlNode htmlNode in htmlDocument.DocumentNode.SelectNodes("//div[@class='" + "story__wof" + "']"))
                {
                    htmlNodes.Add(htmlNode);

                }

                //var newHtmlNodes = DomScraper.GetHtmlElementByClassName(htmlDocument1, "div", "story__wof");

                //var newHtmlNodes = DomScraper.GetHtmlElementByClassName(htmlDocument1, "article", "story stack  story--basic-content");
                List<NewsData> newsDataList = new List<NewsData>();
                //newsDataList = DomScraperV1.GetHtmlElementByClassNameV1(htmlDocument1);
                newsDataList = DomScraperV2.GetHtmlElementByClassNameV1(htmlDocument1); 


                string json = JsonConvert.SerializeObject(newsDataList.ToArray());
                System.IO.File.WriteAllText(@"D:\DotNetCode\afr" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".json", json);

                var businessHeadlineList = newsDataList.Select(a => new BuisnessHeadLine()
                {
                    PublishedDate = a.PublishedDate,
                    NewsSource = a.NewsSource,
                    Url = a.Url,
                    Heading = a.Heading,
                    ContentBrief = a.ContentBrief
                }).ToList<BuisnessHeadLine>(); ;

                var buisnessHeadLineList = new List<BuisnessHeadLine>();

                var businessHeadLineSample = new BuisnessHeadLine();
                

                foreach (NewsData a in newsDataList)
                {
                    
                    var buisnessHeadLine = new BuisnessHeadLine()
                    {
                        PublishedDate = a.PublishedDate,
                        NewsSource = a.NewsSource,
                        Url = a.Url,
                        Heading = a.Heading,
                        ContentBrief = a.ContentBrief
                    };
                    buisnessHeadLineList.Add(buisnessHeadLine);

                    businessHeadLineSample = buisnessHeadLine;
                }

                var businessHeadLineSample2 =  new BuisnessHeadLine()
                {
                    PublishedDate = DateTime.Today,
                    NewsSource = "AFR",
                    Url = "Test URL",
                    Heading = "Heading",
                    ContentBrief = "ContentBrief"
                };




               
                using (WebScraperDBEntities1 entityFrame = new WebScraperDBEntities1())
                {
                    entityFrame.BuisnessHeadLines.AddRange(buisnessHeadLineList);
                    entityFrame.SaveChanges();
                };

            }

            //parsys parsys-desktop - content - lhr

        }
    }
}
