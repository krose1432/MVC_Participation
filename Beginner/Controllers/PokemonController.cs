using Beginner.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Beginner.Controllers
{
    public class PokemonController : Controller
    {
        public IActionResult Index()
        {
            PokemonAPI allpokemon;

            using (var client = new HttpClient())
            {
                var json = client.GetStringAsync("https://pokeapi.co/api/v2/pokemon").Result;

                allpokemon = JsonConvert.DeserializeObject<PokemonAPI>(json);


            }
            return View(allpokemon.results);
        }

        public ActionResult Info(string id)
        {
            
            PokemonInfo info;

            using (var client = new HttpClient())
            {
                var json = client.GetStringAsync($"https://pokeapi.co/api/v2/pokemon/{id}").Result;

                info = JsonConvert.DeserializeObject<PokemonInfo>(json);


            }
            return View(info);
        }
    }
}
