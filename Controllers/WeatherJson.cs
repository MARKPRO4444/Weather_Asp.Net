using System;
using System.Net;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Weather_Asp.Net.Controllers
{
    //Kº - 273,15 = Cº
    public class WeatherJson
	{
        public float? Lon { get; set; }
        public float? Lat { get; set; }
        public Day Day { get; set; }

        public void SetLink()
        {
            string link = $"https://api.openweathermap.org/data/2.5/forecast?lat={Lat}&lon={Lon}&appid=6b096d3e27f508ad637d6727bc9e9b00";
            Day = SetDay(link);
            Day.Options[0].Main.Temp = Math.Round(Day.Options[0].Main.Temp - 273.15, 2);
        }

        public Day SetDay(string link)
        {
            HttpWebRequest webRequest = (HttpWebRequest)WebRequest.Create(link);

            HttpWebResponse webResponse = (HttpWebResponse)webRequest.GetResponse();

            StreamReader reader = new StreamReader(webResponse.GetResponseStream());

            string message = reader.ReadToEnd();

            Day day = new Day();

            day = JsonSerializer.Deserialize<Day>(message);

            return day;
        }
    }

    public class ListOptions
    {
        [JsonPropertyName("main")]
        public Main Main { get; set; }
        [JsonPropertyName("dt_txt")]
        public string Dt_txt { get; set; }
    }

    public class City
    {
        [JsonPropertyName("name")]
        public string Name { get; set; }
        [JsonPropertyName("country")]
        public string Country { get; set; }
        [JsonPropertyName("sunrise")]
        public int Sunrise { get; set; }
        [JsonPropertyName("sunset")]
        public int Sunset { get; set; }
    }

    public class Main
    {
        [JsonPropertyName("temp")]
        public double Temp { get; set; }
        [JsonPropertyName("sea_level")]
        public double Sea_level { get; set; }
        [JsonPropertyName("feels_like")]
        public double Feels_like { get; set; }
        [JsonPropertyName("temp_min")]
        public double Temp_min { get; set; }
        [JsonPropertyName("temp_max")]
        public double Temp_max { get; set; }
    }

    public class Day
    {
        [JsonPropertyName("list")]
        public List<ListOptions> Options { get; set; }
        [JsonPropertyName("city")]
        public City City { get; set; }
    }
}

