using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApplication3.Models;

namespace WebApplication3.Controllers
{
    public class MovieController : ApiController
    {
        [HttpGet]
        public List<Movy> GetMovies()
        {
            MovieDBEntities ORM = new MovieDBEntities();

            return ORM.Movies.ToList();
        }

        [HttpGet]
        public List<Movy> GetMoviesByCategory(string Category)
        {
            MovieDBEntities ORM = new MovieDBEntities();

            List<Movy> movies = ORM.Movies.Where(x => x.Category.ToLower() == Category.ToLower()).ToList();

            return movies;
        }

        [HttpGet]
        public Movy GetRandomMovie()
        {
            MovieDBEntities ORM = new MovieDBEntities();
            Random rand = new Random();

            return ORM.Movies.ToList()[rand.Next(ORM.Movies.Count())];
        }

        [HttpGet]
        public Movy GetRandomMovieByCategory(string Category)
        {
            MovieDBEntities ORM = new MovieDBEntities();

            Random rand = new Random();

            return ORM.Movies.Where(x => x.Category.ToLower() == Category.ToLower()).ToList()[rand.Next(4)];
        }

        [HttpGet]
        public List<Movy> GetRandomMovies(string Number)
        {
            MovieDBEntities ORM = new MovieDBEntities();

            List<Movy> movies = new List<Movy>();

            if (!int.TryParse(Number, out int num))
            {
                return movies;
            }
            else
            {
                Random rand = new Random();
                List<int> pickedNum = new List<int>();
                for (int i = 0; i < num; i++)
                {
                    int n = rand.Next(ORM.Movies.Count());

                    while (pickedNum.Contains(n))
                    {
                        n = rand.Next(ORM.Movies.Count());
                    }

                    pickedNum.Add(n);
                    movies.Add(ORM.Movies.ToList()[n]);
                }

                return movies;
            }
        }

        [HttpGet]
        public List<string> GetMovieCategories()
        {
            MovieDBEntities ORM = new MovieDBEntities();

            List<string> categories = ORM.Movies.Select(x => x.Category).Distinct().ToList();

            return categories;
        }

        [HttpGet]
        public string GetDirector(string Name)
        {
            MovieDBEntities ORM = new MovieDBEntities();

            return ORM.Movies.Where(x => x.Name.ToLower() == Name.ToLower()).ToList()[0].Director;
        }

        [HttpGet]
        public List<Movy> GetMoviesByKeyword(string Keyword)
        {
            MovieDBEntities ORM = new MovieDBEntities();

            return ORM.Movies.Where(x => x.Name.ToLower().Contains(Keyword.ToLower())).ToList();
        }
    }
}
