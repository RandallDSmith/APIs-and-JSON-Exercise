using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using System.Net.Http;
using RestSharp;

namespace APIsAndJSON
{
    public class OpenWeatherMapAPI
    {
       public static void GetWeather()
        {
            var client = new HttpClient();

            var newKey = new WeatherKey();

            string key = newKey.KeyReturn();

            var city = "Cumberland";

            var weatherURL = $"https://api.openweathermap.org/data/2.5/forecast?q={city}&appid={key}&units=imperial";

            var response = client.GetStringAsync(weatherURL).Result;

            JObject formattedReponse = JObject.Parse(response);

            var temp = formattedReponse["list"][0]["main"]["temp"];

            Console.WriteLine();
            Console.WriteLine($"Cumberland current temp is {temp}");

        }

        public static void CurrentWeather()
        {
            var client = new HttpClient();

            var newKey = new WeatherKey();

            string key = newKey.KeyReturn();

            var checkAns = true;

            while (checkAns == true)
            {
                Console.WriteLine();
                Console.WriteLine("Please enter a the city name: ");
                var city_name = Console.ReadLine();
                Console.WriteLine();
                var weatherURL = $"https://api.openweathermap.org/data/2.5/weather?q={city_name}&units=imperial&appid={key}";
                try
                {               
                    var response = client.GetStringAsync(weatherURL).Result;
                    var formattedResponse = JObject.Parse(response).GetValue("main").ToString();
                    var temp = JObject.Parse(formattedResponse).GetValue("temp");
                    Console.WriteLine($"The current Temperature is {temp} degrees");
                }
               catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }

               
                Console.WriteLine();

                Console.WriteLine("Would you like to exit?  Please enter Yes/No");

                do
                {                   
                    var userInput = Console.ReadLine().ToLower();
                    if (userInput.Trim() == "yes")
                    {
                        checkAns = false;
                        break;
                    }
                    else if( userInput.Trim() != "no")
                    {
                        Console.WriteLine("Please enter Yes/No");
                    }
                    else
                    {
                        break;
                    }
                }while (checkAns = true) ;
                
            }
           
        }

       
        
    }
}
