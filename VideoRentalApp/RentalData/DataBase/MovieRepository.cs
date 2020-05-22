﻿using sedc.videorental.data.Enums;
using sedc.videorental.data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace sedc.videorental.data.DataBase
{
    public class MovieRepository : InMemoryDatabase
    {
        public List<Movie> GetAllMovies()
        {
            return Movies;
        }

        public List<Movie> GetPremiers()
        {
            return Premieres;
        }

        public List<Movie> GetDiscountMovies()
        {
            return DiscountsMovies;
        }

        public List<Movie> GetbyGenre(Genre genre)
        {
            return Movies.Where(_movie => _movie.Genre == genre).ToList();
        }
        public List<Movie> OrderByGenre()
        {
            return Movies.OrderBy(_movie => _movie.Genre).ToList();
        }
        public List<Movie> OrderByReleaseDate(bool desc = false)
        {
            if (desc)
            {
                return Movies.OrderByDescending(_movie => _movie.ReleaseDate)
                    .ToList();
            }
            return Movies.OrderBy(_movie => _movie.ReleaseDate)
                .ToList();
        }

        public List<Movie> GetByYear(int year)
        {
            return Movies.Where(_movie => _movie.ReleaseDate.Year == year)
                .ToList();
        }

        public List<Movie> OrderByAvaibility(bool desc = false)
        {
            if (desc)
            {
                return Movies.OrderByDescending(_movie => _movie.IsAviable)
                    .ToList();
            }
            return Movies.OrderBy(_movie => _movie.IsAviable)
                .ToList();
        }

        public List<Movie> GetAvaiableMovies()
        {
            return Movies.Where(_movie => _movie.IsAviable)
              .ToList();
        }

        public List<Movie> SearchMoviesbyTitle(string titlePart)
        {
            return Movies.Where(_movie => _movie.Title
                .Contains(titlePart,StringComparison.InvariantCultureIgnoreCase))
                .ToList();

        }

        public Movie GetMovieById(int id)
        {
            return Movies.FirstOrDefault(_movie => +_movie.Id == id);

        }

        public Movie GetMovieByIDPremiers(int id)
        {
            return Premieres.FirstOrDefault(_movie => +_movie.Id == id);
        }

        public Movie GetMoviesByIDDiscounts(int id)
        {
            return DiscountsMovies.FirstOrDefault(_movie => + _movie.Id == id);
        }


    }
}
