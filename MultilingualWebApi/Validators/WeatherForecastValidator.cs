using FluentValidation;
using Microsoft.Extensions.Localization;
using MultilingualWebApi.Models;

namespace MultilingualWebApi.Validators
{
    public class WeatherForecastValidator : AbstractValidator<WeatherForecast>
    {
        public WeatherForecastValidator(IStringLocalizer<WeatherForecast> localizer)
        {
            // Null validation message has been overriden globally in CustomLanguageManager.cs
            // NotNull will use globally overriden message in the appropriate language if not null check fails
            RuleFor(weather => weather.Id)
                .NotNull();

            // Special tags {} are replaced by fluent validation with the appropriate values. More detail can be found at https://docs.fluentvalidation.net/en/latest/built-in-validators.html
            RuleFor(weatherForecast => weatherForecast.Date)
                .NotNull()
                .GreaterThanOrEqualTo(DateTime.Now)
                .WithMessage(localizer["'{PropertyName}' must be greater than or equal to {ComparisonValue}"])
                .LessThan(DateTime.Now.AddDays(30))
                .WithMessage(localizer["'{PropertyName}' must be less than or equal to {ComparisonValue}"]);

            RuleFor(weatherForecast => weatherForecast.TemperatureC)
                .NotNull()
                .InclusiveBetween(-273, 100)
                .WithMessage(localizer["'{PropertyName}' must be between {From} and {To}. You entered {PropertyValue}"]);

            RuleFor(weatherForecast => weatherForecast.TemperatureF)
                .NotNull()
                .InclusiveBetween(-459, 200)
                .WithMessage(localizer["'{PropertyName}' must be between {From} and {To}. You entered {PropertyValue}"]);
        }
    }
}
