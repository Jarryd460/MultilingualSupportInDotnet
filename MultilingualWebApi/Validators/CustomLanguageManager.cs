using FluentValidation.Resources;

namespace MultilingualWebApi.Validators
{
    public class CustomLanguageManager : LanguageManager
    {
        public CustomLanguageManager()
        {
            // Translations that have the same translation across data annotations (WeatherForecast.cs) and
            // fluent validation (CustomLanguageManager.cs and WeatherForecastValidator.cs) will result in only one instance of the translation
            // being returned when model validation runs
            AddTranslation("af-ZA", "NotNullValidator", "'{PropertyName}' word vereis fluentvalidation");

            AddTranslation("en", "NotNullValidator", "'{PropertyName}' is required");
            AddTranslation("en-US", "NotNullValidator", "'{PropertyName}' is required - us fluentvalidation");
            AddTranslation("en-ZA", "NotNullValidator", "'{PropertyName}' is required - za fluentvalidation");

            AddTranslation("es", "NotNullValidator", "'{PropertyName}' es obligatorio fluentvalidation");
            AddTranslation("es-ES", "NotNullValidator", "'{PropertyName}' es obligatorio - es fluentvalidation");
            AddTranslation("es-MX", "NotNullValidator", "'{PropertyName}' es obligatorio - mx fluentvalidation");
        }
    }
}
