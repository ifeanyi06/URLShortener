using API.Services;
using Application.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShortLinkController : ControllerBase
    {
        private readonly IShortLinkService _shortLinkService;
        private readonly ILogger<ShortLinkController> _logger;

        public ShortLinkController(ILogger<ShortLinkController> logger,IShortLinkService shortLinkService )
        {
            _shortLinkService = shortLinkService;
            _logger = logger;
        }


        [HttpPost("CreateShortURL")]
        public async Task<string> CreateShortURL([FromBody] CreateShortURLRequest request)
        {
            return await _shortLinkService.CreateShortLink(request);
        }

        [HttpGet]
        [Route("GetRedirectURL")]
        public async Task<string> GetRedirectURL([FromQuery] string shortUrl)
        {
            var response = await _shortLinkService.GetRedirectLink(shortUrl);

            return response;

        }
    }
}
