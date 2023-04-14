using Microsoft.AspNetCore.Mvc;
using System;

namespace Task1.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly List<string> Summaries = new()
        {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IActionResult GetAll(int? sortStrategy)
        {
            List<string> result;

            switch (sortStrategy)
            {
                case null:
                    result = Summaries;
                    break;
                case 1:
                    result = Summaries.OrderBy(m => m).ToList();
                    break;
                case -1:
                    result = Summaries.OrderByDescending(m => m).ToList();
                    break;
                default:
                    return BadRequest("Incorrect value of sortStrategy parameter!");
            }

            return Ok(result);
        }

        [HttpPost]
        public IActionResult Add(string name)
        {
            Summaries.Add(name);
            return Ok();
        }

        [HttpPut]
        public IActionResult Update(int index, string name)
        {
            if (index < 0 || index >= Summaries.Count)
                return BadRequest("Wrong index!");

            Summaries[index] = name;
            return Ok();
        }

        [HttpDelete]
        public IActionResult Delete(int index)
        {
            if (index < 0 || index >= Summaries.Count)
                return BadRequest("Wrong index!");

            Summaries.RemoveAt(index);
            return Ok();
        }

        [HttpGet("{index}")]
        public string GetByIndex(int index)
        {
            if (index < 0 || index >= Summaries.Count)
                return "Wrong index!";

            return Summaries[index];
        }

        [HttpGet("find-by-name")]
        public int GetByName(string name)
        {
            int count = 0;

            for (int c = 0; c < Summaries.Count; c++)
            {
                if (Summaries[c] == name)
                    count++;
            }
            return count;
        }
    }
}