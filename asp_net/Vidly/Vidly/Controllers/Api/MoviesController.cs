using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using AutoMapper;
using Vidly.Dtos;
using Vidly.Models;

namespace Vidly.Controllers.Api
{
    public class MoviesController : ApiController
    {
        private ApplicationDbContext _context;

        public MoviesController()
        {
            _context = new ApplicationDbContext();
        }
        
        // GET api/Movies
        public IEnumerable<MoviesDto> Get()
        {
            return _context.Movies
                .Include(m => m.Genre)
                .ToList()
                .Select(m => Mapper.Map<Movie, MoviesDto>(m));
        }

        // GET api/Movies/5
        public IHttpActionResult  Get(int id)
        {
            var movie = _context.Movies.SingleOrDefault(m => m.Id == id);
            if (movie == null)
            {
                return NotFound();
            }

            return Ok(movie);
        }

        // POST api/<controller>
        [HttpPost]
        public IHttpActionResult Post(MoviesDto movieDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            
            var movie = Mapper.Map<MoviesDto, Movie>(movieDto);
            
            _context.Movies.Add(movie);
            _context.SaveChanges();

            movieDto.Id = movie.Id;
            return Created(new Uri(Request.RequestUri + "/" + movieDto.Id), movieDto);

        }

        // PUT api/<controller>/5
        public IHttpActionResult Put(int id, MoviesDto moviesDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            
            var movie = _context.Movies.SingleOrDefault(m => m.Id == id);

            if (movie == null)
            {
                return NotFound();
            }

            Mapper.Map(moviesDto, movie);
            _context.SaveChanges();

            return Ok();
        }

        // DELETE api/<controller>/5
        public IHttpActionResult Delete(int id)
        {
            var movie = _context.Movies.SingleOrDefault(m => m.Id == id);

            if (movie == null)
            {
                return NotFound();
            }

            _context.Movies.Remove(movie);
            _context.SaveChanges();
            return Ok();
        }
    }
}