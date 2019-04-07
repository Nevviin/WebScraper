using HtmlAgilityPack;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebScraper.Scraper
{
    class DomScraper
    {


        public static List<HtmlNode> GetHtmlElementByClassName(HtmlDocument htmlDocument, string htmlElement, string cssClassName)
        {
            var htmlNodes = new List<HtmlNode>();
            string elementXPath = string.Format("//{0}[@class='{1}']",htmlElement,cssClassName);
            foreach (HtmlNode htmlNode in htmlDocument.DocumentNode.SelectNodes(elementXPath))
            {
                htmlNodes.Add(htmlNode);

            }

            var newsDataList = new List<NewsData>();
            foreach (HtmlNode node in htmlNodes)
            {

                
                string url=string.Empty;
                string heading = string.Empty;
                string contentBrief = string.Empty;

                if (
                    (node.SelectSingleNode("h3[@class='story__headline']") !=null)
                    && (node.SelectSingleNode("ul[@class='byline']") != null)
                    )
                { 

                 url = node.ChildNodes[1].Descendants("a").FirstOrDefault().Attributes["href"].Value;
                 heading = node.ChildNodes[1].InnerText.Trim();
                 contentBrief = node.ChildNodes[5].InnerText;

                }
                else if ((node.SelectSingleNode("ul[@class='byline']") == null) && node.ChildNodes.Count == 2)
                {
                    heading = node.ChildNodes[1].Descendants("a").FirstOrDefault().InnerText;
                    url = node.ChildNodes[1].Descendants("a").FirstOrDefault().Attributes["href"].Value;

                }
                else if ((node.SelectSingleNode("ul[@class='byline']") == null) && node.ChildNodes.Count>2)
                {
                    url = node.ChildNodes[1].Descendants("a").FirstOrDefault().Attributes["href"].Value;
                    heading = node.ChildNodes[1].InnerText.Trim();
                    contentBrief = node.ChildNodes[3].InnerText;
                }
                else  if ((node.SelectSingleNode("ul[@class='byline']") == null) && node.ChildNodes.Count < 2)
                {

                    url = node.ChildNodes[1].Descendants("a").FirstOrDefault().Attributes["href"].Value;
                    heading = node.ChildNodes[1].InnerText.Trim();



                }
                else {
                    heading = node.ChildNodes[1].Descendants("a").FirstOrDefault().InnerText;

                    contentBrief = node.ChildNodes[3].InnerText;
                }

                var newsData = new NewsData();
                newsData.Url = url;
                newsData.Heading = heading;
                newsData.ContentBrief = contentBrief;
                newsDataList.Add(newsData);
            }


            string json = JsonConvert.SerializeObject(newsDataList.ToArray());
            System.IO.File.WriteAllText(@"D:\DotNetCode\afr"+ DateTime.Now.ToShortDateString().Replace('/','_')+".json", json);





            return htmlNodes;
        }

        public static List<NewsData> GetHtmlElementByClassNameV1(HtmlDocument htmlDocument, string htmlElement, string cssClassName)
        {
            //var htmlNodes = new List<HtmlNode>();

            List<NewsData> newsDataList = new List<NewsData>();


            string elementXPath = string.Format("//{0}[@class='{1}']", htmlElement, cssClassName);

            //StoryBasicContentHasWof(htmlDocument, "article", "story story--basic-content has-wof", newsDataList);
            StoryStackStoryBasicContent(htmlDocument, "article", "story stack  story--basic-content", newsDataList);


            return newsDataList;
        }


        public static List<NewsData> StoryStackStoryBasicContent(HtmlDocument htmlDocument, string htmlElement, string cssClassName, List<NewsData> newsDataList)
        {
            var htmlNodes = new List<HtmlNode>();
            string elementXPath = string.Format("//{0}[@class='{1}']", htmlElement, cssClassName);
            foreach (HtmlNode htmlNode in htmlDocument.DocumentNode.SelectNodes(elementXPath))
            {
                htmlNodes.Add(htmlNode);

            }

            //var newsDataList = new List<NewsData>();
            foreach (HtmlNode node in htmlNodes)
            {


                string url = string.Empty;
                string heading = string.Empty;
                string contentBrief = string.Empty;

                if (
                    (node.SelectSingleNode("//h3[@class='story__headline']") != null)
                    && (node.SelectSingleNode("//ul[@class='byline']") != null)
                    )
                {
                    var headLineNode = node.SelectSingleNode("//h3[@class='story__headline']");
                    //url = node.ChildNodes[1].Descendants("a").FirstOrDefault().Attributes["href"].Value;
                    //heading = node.ChildNodes[1].InnerText.Trim();
                    url = headLineNode.Element("a").Attributes["href"].Value;
                    heading = headLineNode.Element("a").Element("span").InnerText.Trim();
                    contentBrief = node.SelectSingleNode("//div[@class='story__wof']/p").InnerText.Trim();

                }

                var newsData = new NewsData();
                newsData.Url = url;
                newsData.Heading = heading;
                newsData.ContentBrief = contentBrief;
                newsDataList.Add(newsData);


            }
            return newsDataList;
        }

        public static List<NewsData> StoryBasicContentHasWof(HtmlDocument htmlDocument, string htmlElement, string cssClassName, List<NewsData> newsDataList)
        {
            var htmlNodes = new List<HtmlNode>();
            string elementXPath = string.Format("//{0}[@class='{1}']", htmlElement, cssClassName);
            foreach (HtmlNode htmlNode in htmlDocument.DocumentNode.SelectNodes(elementXPath))
            {
                htmlNodes.Add(htmlNode);

            }

            //var newsDataList = new List<NewsData>();
            foreach (HtmlNode node in htmlNodes)
            {


                string url = string.Empty;
                string heading = string.Empty;
                string contentBrief = string.Empty;

                if (
                    (node.SelectSingleNode("//h3[@class='story__headline']") != null)
                    && (node.SelectSingleNode("//ul[@class='byline']") != null)
                    )
                {
                    var headLineNode = node.SelectSingleNode(".//h3[@class='story__headline']");
                    //url = node.ChildNodes[1].Descendants("a").FirstOrDefault().Attributes["href"].Value;
                    //heading = node.ChildNodes[1].InnerText.Trim();
                    url = headLineNode.Element("a").Attributes["href"].Value;
                    heading = headLineNode.Element("a").Element("span").InnerText.Trim();
                    //contentBrief = node.SelectSingleNode(".//div[@class='story__wof']/p").InnerText.Trim();

                    contentBrief = node.SelectSingleNode(".//p").InnerText;

                }
                
                var newsData = new NewsData();
                newsData.Url = url;
                newsData.Heading = heading;
                newsData.ContentBrief = contentBrief;
                newsDataList.Add(newsData);

                
            }
            return newsDataList;
        }
    }
}
