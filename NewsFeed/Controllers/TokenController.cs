using Microsoft.AspNetCore.Mvc;
using Redstone.Sdk.Server.Filters;

namespace NewsFeed.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class TokenController : ControllerBase
	{
		[HttpGet]
		[ServiceFilter(typeof(HexResourceFilter))]
		public void Get()
		{
		}
	}
}