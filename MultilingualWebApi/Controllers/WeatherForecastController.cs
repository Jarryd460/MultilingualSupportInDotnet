using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;
using MultilingualWebApi.Models;
using System.ComponentModel.DataAnnotations;

namespace MultilingualWebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private readonly IStringLocalizer<WeatherForecastController> _stringLocalizer;
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        // Because localization was added to the middleware pipeline IStringLocalizer is added to DI container
        // IStringLocalizer is what holds the translations in the language that was specified via header (Accept-Language),
        // query parameters (?culture={language/culture}&ui-culture={language/culture})
        public WeatherForecastController(IStringLocalizer<WeatherForecastController> stringLocalizer)
        {
            _stringLocalizer = stringLocalizer;
        }

        [HttpGet]
        public IEnumerable<WeatherForecast> Get()
        {
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = _stringLocalizer[Summaries[Random.Shared.Next(Summaries.Length)]]
            })
            .ToArray();
        }

        [HttpGet("{id}")]
        public ActionResult<WeatherForecast> Get([FromRoute, Required] long id)
        {
            return Ok(new WeatherForecast()
            {
                Id = id,
                Date = DateTime.Now,
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = _stringLocalizer[Summaries[Random.Shared.Next(Summaries.Length)]]
            });
        }

        [HttpPost]
        public IActionResult Post([FromBody] WeatherForecast weatherForecast)
        {
            // Older versions of web api required developers to manually check the model state but that is
            // no longer needed if [ApiController] attribute is added to controller. The [ApiController] wraps
            // the validation messages into a problem details object as well
            //if (!this.ModelState.IsValid)
            //{
            //    return BadRequest(this.ModelState);
            //}


            return CreatedAtAction(nameof(Get), new { id = weatherForecast.Id }, weatherForecast);
        }
    }
}