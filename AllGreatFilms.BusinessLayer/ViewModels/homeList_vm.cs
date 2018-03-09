using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AllGreatFilms.BusinessObjectLayer;

namespace AllGreatFilms.BusinessLayer.ViewModels
{
   public class homeList_vm
    {
        public string Poster { get; set; }
        public string Movie_name { get; set; }
        public int Movie_id { get; set; }
        public string Director_name { get; set; }
        public string Writer_name { get; set; }
        public List<string> Actor_name { get; set; }
        public List<int> Fav_movies { get; set; }
        public List<int> Watched_movies { get; set; }
        public List<int> To_watch_movies { get; set; }
        public bool isFav { get; set; }
        public bool isWatched { get; set; }
        public bool isToWatch { get; set; }
        public string GRating { get; set; }
        public decimal GreatnessRating { get; set; }

        public DateTime Year { get; set; }
        public DateTime DateAdded { get; set; }
        public List<string> Genres { get; set; }
        public List<int> GenresIds { get; set; }
        public string Synopsis { get; set; }

        public List<string> Moods { get; set; }

        public user user { get; set; }




    }
    
}
