using Microsoft.AspNetCore.Mvc;
using Urlite.Application.Dtos;
using Urlite.Application.Services;

namespace Urlite.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ShortUrlController : ControllerBase
    {
        private readonly IUrlService _urlService;

        public ShortUrlController(IUrlService urlService)
        {
            _urlService = urlService;
        }

        [HttpGet("{shortCode}")]
        public ActionResult<ShortUrlResponse> GetShortUrl(string shortCode)
        {
            var response = _urlService.GetShortUrl(shortCode);

            return response is null ? NotFound() : Ok(response);
        }

        [HttpPost]
        public ActionResult<ShortUrlResponse> Create(ShortUrlRequest request)
        {
            var response = _urlService.CreateShortUrl(request);

            return CreatedAtAction(nameof(GetShortUrl), new { shortCode = response.ShortCode }, response);
        }
    }
}