using System.ComponentModel.DataAnnotations;

namespace MultilingualWebApi.Models
{
    public class WeatherForecast
    {
        // {0} is the placeholder for the property name
        // Translations are automatically looked for in Resources/Models/WeatherForecast.....resx
        // This is done by linking the namespace of the model with the directory to the resource
        [Required(ErrorMessage = "'{0}' is required")]
        public long? Id { get; init; }
        public DateTime? Date { get; init; }
        [Required(ErrorMessage = "'{0}' is required")]
        // {0} is the placeholder for the property name, {1} for -273 and {2} for 100.
        [Range(-273, 100, ErrorMessage = "'{0}' has to be between {1} and {2} degrees celcius")]
        public int? TemperatureC { get; init; }
        [Required(ErrorMessage = "'{0}' is required")]
        // {0} is the placeholder for the property name, {1} for -459 and {2} for 200.
        [Range(-459, 200, ErrorMessage = "'{0}' has to be between {1} and {2} degrees fahrenheit")]
        public int? TemperatureF => 32 + (int)(TemperatureC / 0.5556);
        [Required(ErrorMessage = "'{0}' is required")]
        // {0} is the placeholder for the property name, {1} for the min/max length.
        [MinLength(1, ErrorMessage = "'{0}' has to contain {1} or more characters")]
        [MaxLength(150, ErrorMessage = "'{0}' has to contain {1} or less characters")]
        public string? Summary { get; init; }
    }
}