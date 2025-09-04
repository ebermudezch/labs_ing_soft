
using backend_lab_B81083.Models;
using backend_lab_B81083.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace backend_lab_B81083.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CountryController : ControllerBase
    {
        private readonly CountryService countryService;
        public CountryController()
        {
            countryService = new CountryService();
        }
        [HttpGet]
        public List<CountryModel> Get()
        {
            var paises = countryService.GetCountries();
            return paises;
        }
    }
}
