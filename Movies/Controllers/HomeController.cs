using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Reflection;

namespace Movies.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        private readonly IConfiguration configuration;

        public HomeController(IConfiguration configuration)
        {
            this.configuration = configuration;
        }
        [HttpGet("/about", Name = "GetApiDetails")]
        public ActionResult<ApiInfo> GetApiDetails()
        {
            var assembly = Assembly.GetEntryAssembly();
            var result = new ApiInfo
            {
                // get assembly version
                AssemblyVersion = assembly.GetName().Version.ToString(),
                APIName = assembly.GetCustomAttribute<AssemblyTitleAttribute>().Title,
                APIVersion = assembly.GetCustomAttribute<AssemblyInformationalVersionAttribute>().InformationalVersion,
                Owner = assembly.GetCustomAttribute<AssemblyCompanyAttribute>().Company,
                Summary = assembly.GetCustomAttribute<AssemblyDescriptionAttribute>().Description,
                Support = configuration["Support:Email"]
            };
            return Ok(result);
        }

        [HttpGet("/timeNow", Name = "GetTime")]
        public IActionResult GetTime()
        {
            return Ok(new
            {
                UTCTime = DateTime.UtcNow.ToShortDateString(),
                LocalTime = DateTime.Now.ToString()
            });
        }
    }

    public class ApiInfo
    {

        public string? AssemblyVersion { get; internal set; }
        public string APIName { get; internal set; } = null!;
        public string APIVersion { get; internal set; }
        public string Owner { get; internal set; }
        public string Summary { get; internal set; }
        public string Support { get; internal set; }
    }
}
