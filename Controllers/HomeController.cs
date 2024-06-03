using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Weather_Asp.Net.Models;

namespace Weather_Asp.Net.Controllers;

public class HomeController : Controller
{
    public IActionResult Index()
    {
        return View();
    }

    public IActionResult Privacy()
    {
        return View();
    }

    public IActionResult Weather(float? lon, float? lat)
    {
        WeatherJson weatherJson = new WeatherJson();
        weatherJson.Lon = lon;
        weatherJson.Lat = lat;
        if(weatherJson.Lat != null && weatherJson.Lon != null)
        {
            weatherJson.SetLink();
        }
        return View(weatherJson);
    }
}

