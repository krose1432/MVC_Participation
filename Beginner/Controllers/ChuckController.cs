using Beginner.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Beginner.Controllers
{
    public class ChuckController : Controller
    {
        public IActionResult Index()
        {
            RandomChuckJokeApi joke;

            using (var client = new HttpClient())
            {
                var json = client.GetStringAsync("https://api.chucknorris.io/jokes/random").Result;

                joke = JsonConvert.DeserializeObject<RandomChuckJokeApi>(json);


            }

                return View(joke);
        }
    }
}
