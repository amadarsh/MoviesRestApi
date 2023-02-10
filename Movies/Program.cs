using Microsoft.AspNetCore.Http;
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
builder.Services.AddSwaggerGen();

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
