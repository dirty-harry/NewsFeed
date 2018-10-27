using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace NewsFeedClient
{
	public static class HttpClientHelper
	{
		public static async Task<string> HttpGet(string uri, (string, string)[] headers)
		{
			HttpClient client = new HttpClient();
			client.DefaultRequestHeaders.Accept.Clear();
			client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

			foreach (var header in headers)
			{
				client.DefaultRequestHeaders.Add(header.Item1, header.Item2);
			}

			HttpResponseMessage response;
			try
			{
				response = await client.GetAsync(uri);
			}
			catch (Exception e)
			{
				throw new ApplicationException("Failed to connect to API, is it running?");
			}

			if (response.Content == null)
				throw new ApplicationException("Response API contained no content.");

			var jsonResponse = await response.Content.ReadAsStringAsync();

			if (!response.IsSuccessStatusCode)
				throw new ApplicationException($"Request was not successful {jsonResponse}.");

			return jsonResponse;
		}
	}
}
