using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace NewsFeed.Models
{
	[DataContract]
	public class NewsItem
	{
		[DataMember(Name = "title")]
		public string Title { get; set; }
	
		[DataMember(Name = "author")]
		public string Author { get; set; }

		[DataMember(Name = "description")]
		public string Description { get; set; }

		[DataMember(Name = "url")]
		public string Url { get; set; }

		[DataMember(Name = "urltoimage")]
		public string UrlToImage { get; set; }

		[DataMember(Name = "publishedat")]
		public string PublishedAt { get; set; }

		[DataMember(Name = "content")]
		public string Content { get; set; }

		public override string ToString()
		{
			return ($"Date: {PublishedAt} Title: {Title}");
		}
	}

	public class NewsItems
	{
		NewsResult Result { get; set; }
		public IEnumerable<NewsItem> Items { get; set; }

		public NewsItems(string json)
		{
			Result = JsonConvert.DeserializeObject<NewsResult>(json);

			Items = Result.Articles;
		}

		public override string ToString()
		{
			string s="";
			foreach( NewsItem i in Result.Articles)
			{
				s += i.ToString() + "\n";
			}
			return s;
		}
	}

	public class NewsResult
	{
		public string Status;
		public int TotalResults;
		public IList<NewsItem> Articles;
	}
	
}

