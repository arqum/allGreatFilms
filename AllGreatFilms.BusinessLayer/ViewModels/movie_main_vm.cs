using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AllGreatFilms.BusinessObjectLayer;


namespace AllGreatFilms.BusinessLayer.ViewModels
{
    public class movie_main_vm
    {
        public string Poster { get; set; }
        public string Movie_name { get; set; }
        public int Movie_id { get; set; }
        public int lang { get; set; }
        public int country { get; set; }
        public string Director_name { get; set; }
        public string Writer_name { get; set; }
        public List<string> Actor_name { get; set; }
        public bool isFav { get; set; }
        public bool isWatched { get; set; }
        public bool isToWatch { get; set; }
        public decimal GreatnessRating { get; set; }
        public decimal? agfRating { get; set; }
        public decimal? mcRating { get; set; }
        public decimal? rtRating { get; set; }
        public decimal? imdbRating  { get; set; }

        public string agfReview { get; set; }
        public string mcRatingLink { get; set; }
        public string rtRatingLink { get; set; }
        public string imdbRatingLink { get; set; }

        public DateTime Year { get; set; }
        public DateTime DateAdded { get; set; }
        public List<string> Genres { get; set; }
        public List<int> GenresIds { get; set; }
        public string Synopsis { get; set; }
        public List<string> quotes { get; set; }
        public List<string> awards { get; set; }
        public List<string> moods { get; set; }

        public user user { get; set; } 
    }
}
