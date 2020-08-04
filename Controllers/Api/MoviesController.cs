using AutoMapper;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Vidly.Domain;
using Vidly.Dtos;
using Vidly.Models;

namespace Vidly.Controllers.API
{
    public class MoviesController : ApiController
    {
        private DatabaseContext _context;
        public MoviesController()
        {
            _context = new DatabaseContext();
        }

        //GET /API/Movies
        public IEnumerable<MovieDto> GetMovies()
        {
            return _context.Movies
                   .Include(m => m.Genre)
                   .ToList()
                   .Select(Mapper.Map<Movie, MovieDto>); 
        }

        //GET /API/Movies/1
        public IHttpActionResult GetMoviesr(int id)
        {
            var movie = _context.Movies.SingleOrDefault(m => m.ID == id);

            if (movie == null)
                return NotFound();

            return Ok(Mapper.Map<Movie, MovieDto>(movie));
        }

        // POST /API/Movies
        [HttpPost]
        public IHttpActionResult CreateMovie(MovieDto movieDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var movie = Mapper.Map<MovieDto, Movie>(movieDto);

            _context.Movies.Add(movie);
            _context.SaveChanges();

            movieDto.ID = movie.ID;
            return Created(new Uri(Request.RequestUri + "/" + movie.ID), movieDto);
        }

        // PUT /API/Movies
        [HttpPut]
        public IHttpActionResult UpdateMovie(int id, MovieDto movieDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var movieInDB = _context.Movies.SingleOrDefault(m => m.ID == id);

            if (movieInDB == null)
                return NotFound();

            Mapper.Map(movieDto, movieInDB);

            _context.SaveChanges();

            return Ok();
        }

        // DELETE /API/Movies
        [HttpDelete]
        public IHttpActionResult DeleteMovie(int id)
        {

            var movieInDB = _context.Movies.SingleOrDefault(m => m.ID == id);

            if (movieInDB == null)
                return NotFound();

            _context.Movies.Remove(movieInDB);
            _context.SaveChanges();

            return Ok();
        }
    }
}