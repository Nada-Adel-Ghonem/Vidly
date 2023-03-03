using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;
using Vidly.ViewModels;
using System.Data.Entity;
using AutoMapper;
using Vidly.ViewModels;

namespace Vidly.Controllers
{
    public class MoviesController : Controller
    {
        private ApplicationDbContext _context;

        public MoviesController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        // GET: Movies
        public ViewResult Index()
        {
            if (User.IsInRole(RoleName.canManageMovies))
                return View("List");
            return View("ReadOnlyList");
        }

        [Authorize(Roles = RoleName.canManageMovies)]
        public ActionResult New()
        {
            Movie movie = new Movie();
            var viewModel = new MovieFormViewModel(movie)
            {
                Genres = _context.Genres.ToList()
            };
            return View("MovieForm", viewModel);
        }

        [Authorize(Roles = RoleName.canManageMovies)]
        public ActionResult Edit(int id)
        {
            Movie movie = _context.Movies.Include(m => m.Genre).Single(m => m.Id == id);

            var viewModel = new MovieFormViewModel(movie)
            {
                Genres = _context.Genres.ToList()
            };
            return View("MovieForm", viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(Movie movie)
        {
            if (!ModelState.IsValid)
            {
                var viewModel = new MovieFormViewModel(movie)
                {
                    Genres = _context.Genres.ToList()
                };
                return View("MovieForm", viewModel);
            }

            if (movie.Id == 0)
            {
                movie.DateAdded = DateTime.Now;
                _context.Movies.Add(movie);
            }
            else
            {
                var movieInDb = _context.Movies.Single(m => m.Id == movie.Id);
                
                Mapper.Map(movie, movieInDb);
                //movieInDb.Name = movie.Name;
                //movieInDb.ReleaseDate = movie.ReleaseDate;
                //movieInDb.GenreId = movie.GenreId;
                //movieInDb.NumberInStock = movie.NumberInStock;
            }

            _context.SaveChanges();
            return RedirectToAction("Index", "Movies");
        }

        [Authorize(Roles = RoleName.canManageMovies)]
        public ActionResult Delete(int id)
        {
            var movie = _context.Movies.Single(m => m.Id == id);
            _context.Movies.Remove(movie);
            _context.SaveChanges();
            return RedirectToAction("Index", "Movies");
        }
    }

}