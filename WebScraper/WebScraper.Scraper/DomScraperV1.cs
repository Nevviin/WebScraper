﻿using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebScraper.Scraper
{
    class DomScraperV1
    {

        const string @AfrDotComUrl = "https://www.afr.com";
        const string StoryStoryHeroStackStoryBasicContent = "story story--hero stack story--basic-content";
        const string StoryStoryBasicContentHasWof = "story story--basic-content has-wof";
        const string StoryStackStoryBasicContent = "story stack  story--basic-content";
        const string StoryHasWof = "story  has-wof";
        const string StoryStoryPremiumContentHasWof = "story story--premium-content has-wof";
        const string ArticleTag = "article";
        /// <summary>
        /// This will add the afr url with https if not present in the url
        /// </summary>
        /// <param name="urlString"></param>
        /// <returns></returns>
        private static string FormatUrl (string urlString)
        {
            string urlReturn = urlString;

            if (!urlString.Contains(@AfrDotComUrl))
            {
                urlReturn = string.Format("{0}{1}", @AfrDotComUrl, urlReturn);
            }

            return urlReturn;
           }



public static List<NewsData> GetHtmlElementByClassNameV1(HtmlDocument htmlDocument)
        {
            List<NewsData> newsDataList = new List<NewsData>();

            GetStoryBasicContentMainHeader(htmlDocument, ArticleTag, StoryStoryHeroStackStoryBasicContent, newsDataList);

            GetStoryPremiumContentHasWof(htmlDocument, ArticleTag, StoryStoryPremiumContentHasWof, newsDataList);

            GetStoryHasWof(htmlDocument, ArticleTag, StoryHasWof, newsDataList);

            GetStoryBasicContentHasWof(htmlDocument, ArticleTag, StoryStoryBasicContentHasWof, newsDataList);
            GetStoryStackStoryBasicContent(htmlDocument, ArticleTag, StoryStackStoryBasicContent, newsDataList);
            return newsDataList;
        }

        public static List<NewsData> GetStoryBasicContentMainHeader(HtmlDocument htmlDocument, string htmlElement, string cssClassName, List<NewsData> newsDataList)
        {
            var htmlNodes = new List<HtmlNode>();
            string elementXPath = string.Format("//{0}[@class='{1}']", htmlElement, cssClassName);
            foreach (HtmlNode htmlNode in htmlDocument.DocumentNode.SelectNodes(elementXPath))
            {
                htmlNodes.Add(htmlNode);
            }

            foreach (HtmlNode node in htmlNodes)
            {
                string url = string.Empty;
                string heading = string.Empty;
                string contentBrief = string.Empty;

                if (
                    (node.SelectSingleNode("//h1[@class='story__headline']") != null)
                    && (node.SelectSingleNode("//ul[@class='byline']") != null)
                    )
                {
                    var headLineNode = node.SelectSingleNode(".//h1[@class='story__headline']");
                    url = headLineNode.Element("a").Attributes["href"].Value;
                    url = FormatUrl(url);

                    heading = headLineNode.Element("a").Element("span").InnerText.Trim();
                    contentBrief = node.SelectSingleNode(".//p").InnerText.Trim();
                }

                var newsData = new NewsData();
                newsData.Url = url;
                newsData.Heading = heading;
                newsData.ContentBrief = contentBrief;
                newsDataList.Add(newsData);
            }
            return newsDataList;
        }


        public static List<NewsData> GetStoryHasWof(HtmlDocument htmlDocument, string htmlElement, string cssClassName, List<NewsData> newsDataList)
        {
            

            var htmlNodes = new List<HtmlNode>();
            string elementXPath = string.Format("//{0}[@class='{1}']", htmlElement, cssClassName);
            if (htmlDocument.DocumentNode.SelectNodes(elementXPath) == null)
                return newsDataList;

            foreach (HtmlNode htmlNode in htmlDocument.DocumentNode.SelectNodes(elementXPath))
            {
                htmlNodes.Add(htmlNode);
            }

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
                    url = headLineNode.Element("a").Attributes["href"].Value;
                    url = FormatUrl(url);
                    heading = headLineNode.Element("a").Element("span").InnerText.Trim();
                    contentBrief = node.SelectSingleNode(".//p").InnerText.Trim();
                }

                var newsData = new NewsData();
                newsData.Url = url;
                newsData.Heading = heading;
                newsData.ContentBrief = contentBrief;
                newsDataList.Add(newsData);
            }
            return newsDataList;
        }


        public static List<NewsData> GetStoryPremiumContentHasWof(HtmlDocument htmlDocument, string htmlElement, string cssClassName, List<NewsData> newsDataList)
        {
            var htmlNodes = new List<HtmlNode>();
            string elementXPath = string.Format("//{0}[@class='{1}']", htmlElement, cssClassName);
            foreach (HtmlNode htmlNode in htmlDocument.DocumentNode.SelectNodes(elementXPath))
            {
                htmlNodes.Add(htmlNode);
            }

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
                    url = headLineNode.Element("a").Attributes["href"].Value;
                    url = FormatUrl(url);
                    heading = headLineNode.Element("a").Element("span").InnerText.Trim();
                    contentBrief = node.SelectSingleNode(".//p").InnerText.Trim();
                }

                var newsData = new NewsData();
                newsData.Url = url;
                newsData.Heading = heading;
                newsData.ContentBrief = contentBrief;
                newsDataList.Add(newsData);
            }
            return newsDataList;
        }


        public static List<NewsData> GetStoryBasicContentHasWof(HtmlDocument htmlDocument, string htmlElement, string cssClassName, List<NewsData> newsDataList)
        {
            var htmlNodes = new List<HtmlNode>();
            string elementXPath = string.Format("//{0}[@class='{1}']", htmlElement, cssClassName);
            foreach (HtmlNode htmlNode in htmlDocument.DocumentNode.SelectNodes(elementXPath))
            {
                htmlNodes.Add(htmlNode);
            }

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
                    url = headLineNode.Element("a").Attributes["href"].Value;
                    url = FormatUrl(url);
                    heading = headLineNode.Element("a").Element("span").InnerText.Trim();
                    contentBrief = node.SelectSingleNode(".//p").InnerText.Trim();
                }

                var newsData = new NewsData();
                newsData.Url = url;
                newsData.Heading = heading;
                newsData.ContentBrief = contentBrief;
                newsDataList.Add(newsData);
            }
            return newsDataList;
        }


        public static List<NewsData> GetStoryStackStoryBasicContent(HtmlDocument htmlDocument, string htmlElement, string cssClassName, List<NewsData> newsDataList)
        {
            var htmlNodes = new List<HtmlNode>();
            string elementXPath = string.Format("//{0}[@class='{1}']", htmlElement, cssClassName);
            foreach (HtmlNode htmlNode in htmlDocument.DocumentNode.SelectNodes(elementXPath))
            {
                htmlNodes.Add(htmlNode);
            }

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
                    url = headLineNode.Element("a").Attributes["href"].Value;
                    url = FormatUrl(url);
                    heading = headLineNode.Element("a").Element("span").InnerText.Trim();
                    contentBrief = node.SelectSingleNode(".//p").InnerText.Trim();
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
