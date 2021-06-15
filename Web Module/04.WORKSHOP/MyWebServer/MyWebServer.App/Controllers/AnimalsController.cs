﻿namespace MyWebServer.App.Controllers
{
    using MyWebServer.App.Models.Animals;
    using MyWebServer.Controllers;
    using MyWebServer.Http;


    public class AnimalsController : Controller
    {
        public AnimalsController(HttpRequest request) 
            : base(request)
        {
        }

        public HttpResponse Cats()
        {
            const string nameKey = "Name";
            const string ageKey = "Age";
            var query = this.Request.Query;

            var catAge = query.ContainsKey(ageKey)
            ? int.Parse(query[ageKey])
            : 0;

            var catName = query.ContainsKey(nameKey)
            ? query[nameKey]
            : "the cats";
            var viewModel = new CatViewModel
            {
                Name = catName,
                Age = catAge
            };

            return View(viewModel);
        }


        public HttpResponse Dogs() => View(new DogViewModel 
        { 
            Name = "Rex",
            Age = 3,
            Breed = "Street Perfect"  
        }); 

        public HttpResponse Bunnies() => View("Rabbits"); 
        public HttpResponse Turtles() => View("/Animals/Wild/Turtles"); 
    }
}
