﻿using Microsoft.AspNetCore.Mvc;
using NewsAPI;
using NewsAPI.Constants;
using NewsAPI.Models;
using NewsApp.Models;

namespace NewsApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NewsController : ControllerBase
    {
        [HttpGet]
        public News[] GetNews()
        {
            List<News> news = new List<News>();
            var newsApiClient = new NewsApiClient("3dcd1b23ae1546a5a931fc21c8d646a9"); //Provide the api key in the cons parameter
            var articlesResponse = newsApiClient.GetEverything(new EverythingRequest
            {
                
                Q = "all",
                SortBy = SortBys.Popularity,
                Language = Languages.EN,
                //From = new DateTime(2018, 1, 1)
            });
            if (articlesResponse.Status == Statuses.Ok)
            {                
                foreach (var article in articlesResponse.Articles)
                {
                    news.Add(new News { Title = article.Title, Author = article.Author, URLToImage = article.UrlToImage, PublishedAt = (DateTime)article.PublishedAt });
                   
                }                
            }
            return news.ToArray() ;
        }
    }
}
