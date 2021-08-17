using API.Controllers;
using API.Services;
using Application.DTOs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using System;
using System.Net;
using System.Threading.Tasks;
using Xunit;

namespace URLShortenerTest
{
    public class ShortLinkControllerTest
    {
        readonly Mock<IShortLinkService> _shortLinkService;
        readonly Mock<ILogger<ShortLinkController>> _logger;
        readonly ShortLinkController _shortLinkController;

        public ShortLinkControllerTest()
        {
            _shortLinkService = new Mock<IShortLinkService>();

            _logger = new Mock<ILogger<ShortLinkController>>();

            _shortLinkController = new ShortLinkController(_logger.Object, _shortLinkService.Object);
        }


        [Fact]
        public async Task CreatShortUrl_WhenCalled_ReturnsResultAsync()
        {
            //Arrange 
            CreateShortURLRequest request = new CreateShortURLRequest();
            request.Url = "https://www.theguardian.com/world/2021/aug/17/covid-app-pinged-close-contacts-in-prior-five-days-not-two-says-source";
            
            // Assert
            var response = await _shortLinkController.CreateShortURL(request);

            Assert.NotNull(response);
        }

    }
}
