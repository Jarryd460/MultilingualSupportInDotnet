using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Localization;
using Microsoft.Extensions.Localization;
using Microsoft.Extensions.Options;
using MultilingualWebApi.Models;
using MultilingualWebApi.Validators;
using System.Globalization;

// You need to specify the location of your resources. The resources directory can be set using the below attribute or using options property when calling AddLocalization
[assembly: ResourceLocation("Resources")]
// When the assembly name and namespace name is different, you need to set the root namespace using the below attribute
[assembly: RootNamespace("MultilingualWebApi")]
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services
    .AddControllers()
    // Adds Localization for data annotations/attributes
    .AddDataAnnotationsLocalization()
    // Adds fluent validation to the middleware and gets all the validators (classes that inherit from AbstractValidator) located in the same assembly as the "Program" class
    .AddFluentValidation(c =>
    {
        c.RegisterValidatorsFromAssemblyContaining<Program>();
    });

// Adds global custom messages
// Only messages for NotNull is implemented
ValidatorOptions.Global.LanguageManager = new CustomLanguageManager();

builder.Services.AddLocalization(options =>
{
    //options.ResourcesPath = "Resources";
}).Configure<RequestLocalizationOptions>(options =>
{
    // Retrieves the cultures that are supported from appsettings
    var cultures = builder.Configuration.GetSection(SupportedCulturesOptions.SupportedCultures).Get<List<string>>();
    List<CultureInfo> supportedCultureInfos = new List<CultureInfo>();

    cultures.ForEach(culture =>
    {
        supportedCultureInfos.Add(new CultureInfo(culture));
    });

    // Sets the supported cultures as well as the default when no culture is specified. options.RequestCultureProviders has 3 providers by default with request header (Accept-Language), query string (culture={requestedCulture}&ui-culture={requestedCulture})
    // and cookies which is only appropriate for an application with a UI.
    options.DefaultRequestCulture = new RequestCulture(cultures.First());
    options.SupportedCultures = supportedCultureInfos;
    options.SupportedUICultures = supportedCultureInfos;

    // Adds the language header (Content-Language) to the response
    options.ApplyCurrentCultureToResponseHeaders = true;
});

var app = builder.Build();

// Inserts the request configuration created above to the request middleware pipeline
var localizedOptions = app.Services.GetRequiredService<IOptions<RequestLocalizationOptions>>();
app.UseRequestLocalization(localizedOptions.Value);

// Configure the HTTP request pipeline.

app.UseAuthorization();

app.MapControllers();

app.Run();
