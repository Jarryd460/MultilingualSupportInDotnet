# Multilingual Support in Dotnet

### Description

Enabling multilingual support in .Net applications is quite simple. .Net has multilingual support built into it. By default, it uses .resx files to manage translations with each .resx file containing translations for a specific file.
You could categorize translations further by creating .resx for each controller, model etc.

### Dependencies:

* FluentValidation.AspNetCore

### MultilingualWebApi and MultilingualWebApplication

* To test the display of application in different languages, you can go to Chrome or Edge -> Settings -> Languages and add German (Germany - de-DE) and French (France - fr-FR).
* Select either German or French and restart the browser. This will cause the browser to make requests that append the appropriate culture to the request headers.
* Another alternative is to pass the culture as query parameters eg. ?culture=en-US or ?ui-culture=en-US or ?culture=en-US&ui-culture=en-US.

### References

* https://medium.com/geekculture/multi-language-with-net-6-3dd214ea01fb
* https://www.google.com/amp/s/andrewlock.net/adding-localisation-to-an-asp-net-core-application/amp/
* https://docs.fluentvalidation.net/en/latest/localization.html
* https://docs.fluentvalidation.net/en/latest/configuring.html
* https://docs.fluentvalidation.net/en/latest/built-in-validators.html
* https://www.codemag.com/Article/2009081/A-Deep-Dive-into-ASP.NET-Core-Localization
* https://www.ezzylearning.net/tutorial/building-multilingual-applications-in-asp-net-core

