using Microsoft.AspNetCore.Mvc;
using NewsFeed.Models;
using Redstone.Sdk.Server.Filters;
using System.Collections.Generic;
using System.Net;

namespace NewsFeed.Controllers
{
	[Route("api/[controller]")]
	//[ServiceFilter(typeof(TokenResourceFilter))]
	[ApiController]
	public class NewsController : ControllerBase
	{
		// GET: api/News
		[HttpGet]
		//public IEnumerable<NewsItem> Get()
		public string Get()
		{
			var url = "https://newsapi.org/v2/everything?" +
				"q=Stratis&" +
				"from=2018-10-01&" +
				"sortyBy=polularity&" +
				"apiKey=9ab44fc284d34acd87fe7cc363a75dd6";

			var json = new WebClient().DownloadString(url);

			return new NewsItems(json).ToString();
		}

		// GET: api/News/5
		[HttpGet("{id}", Name = "Get")]
		public string Get(int id)
		{
			return "value";
		}
	}
}
