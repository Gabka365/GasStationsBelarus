using Microsoft.AspNetCore.Mvc;
using Test_Exercise.Models;
using Test_Exercise.Services;

namespace Test_Exercise.Controllers
{
    public class BaseController : Controller
    {
        private HttpMapDataApi _httpMapDataApi;

        public BaseController(HttpMapDataApi httpMapDataApi) 
        { 
            _httpMapDataApi = httpMapDataApi;
        }

        public async Task<IActionResult> Index()
        {

            var search = "заправки в Беларуси";
            var dtos = await _httpMapDataApi.GetMapDataAsync(search);

            var viewModel = new GasStationsViewModel
            {
                stationDtos = dtos,
            };

            return View(viewModel);
        }
        
    }
}
