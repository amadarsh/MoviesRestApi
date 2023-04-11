using Microsoft.AspNetCore.Http;
using Microsoft.OpenApi.Models;
using Movies.Application;
using Movies.Persistence;
using System.Dynamic;
using System.Reflection;
using System.Text.Json;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers().AddJsonOptions(x =>
                x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles); ;
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1",
    new OpenApiInfo
    {
        Title = "My API - V1",
        Version = "v1",
        Description = "A sample API to demo Swashbuckle",
        TermsOfService = new Uri("http://tempuri.org/terms"),
        Contact = new OpenApiContact
        {
            Name = "Joe Developer",
            Email = "joe.developer@tempuri.org"
        },
        License = new OpenApiLicense
        {
            Name = "Apache 2.0",
            Url = new Uri("http://www.apache.org/licenses/LICENSE-2.0.html")
        }
    }
);

    // Set the comments path for the Swagger JSON and UI.
    var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
    c.IncludeXmlComments(xmlPath);
});

builder.Services.AddApplicationServices();
builder.Services.AddPersistenceServices(builder.Configuration);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


app.UseHttpsRedirection();

app.UseAuthorization();
//app.MapGet("/about", async (HttpResponse response) =>
//{
//    var assembly = Assembly.GetEntryAssembly();
//    dynamic result = new ExpandoObject();
//    // get assembly version
//    result.AssemblyVersion = assembly.GetName().Version.ToString();
//    result.APIName = assembly.GetCustomAttribute<AssemblyTitleAttribute>().Title;
//    result.APIVersion = assembly.GetCustomAttribute<AssemblyInformationalVersionAttribute>().InformationalVersion;
//    result.Owner = assembly.GetCustomAttribute<AssemblyCompanyAttribute>().Company;
//    result.Summary = assembly.GetCustomAttribute<AssemblyDescriptionAttribute>().Description;
//    result.Support = builder.Configuration["Support:Email"];
//    string dsd = JsonSerializer.Serialize(result);
//    await response.WriteAsJsonAsync(dsd);
//});

app.MapControllers();

app.Run();
