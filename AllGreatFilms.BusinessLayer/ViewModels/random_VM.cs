using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AllGreatFilms.BusinessLayer.ViewModels
{
    public class random_VM
    {
        public string title  { get; set; }
        public DateTime year { get; set; }
        public string poster { get; set; }
        public string synopses { get; set; }
        public string Director_name { get; set; }
        public bool isFav { get; set; }
        public bool isWatched { get; set; }
        public bool isToWatch { get; set; }
        public string GRating { get; set; }
        public decimal GreatnessRating { get; set; }
        public int Movie_id { get; set; }


    }
}
