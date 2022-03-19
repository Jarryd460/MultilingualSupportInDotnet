using Microsoft.AspNetCore.Localization;
using System.Globalization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services
    .AddControllersWithViews()
    // Injects IHtmlLocalizer and IViewLocalizer
    .AddViewLocalization();

builder.Services
    // Injects IStringLocalizer<>
    .AddLocalization(options =>
    {
        // When the resources directory is not set the resources are looked for in the same directory as the executing file (eg. HomeController)
        // options.ResourcesPath = "Resources";
    })
    .Configure<RequestLocalizationOptions>(options =>
    {
        var supportedCultures = new[]
        {
            new CultureInfo("de-DE"),
            new CultureInfo("en-US"),
            new CultureInfo("fr-FR")
        };

        options.DefaultRequestCulture = new RequestCulture("en-US", "en-US");
        options.SupportedCultures = supportedCultures;
        options.SupportedUICultures = supportedCultures;

        options.ApplyCurrentCultureToResponseHeaders = true;
    });

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

// Localization must be configured before any middleware that requires it. locOptions variable does not need to be passed in as UseRequestLocalization
// will automatically use the configured RequestLocalizationOptions above
//var locOptions = app.Services.GetRequiredService<IOptions<RequestLocalizationOptions>>();
app.UseRequestLocalization();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
