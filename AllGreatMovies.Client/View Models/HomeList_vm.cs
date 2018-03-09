using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AllGreatMovies.Client.View_Models
{
    public class HomeList_vm
    {
        public string Movie_name { get; set; }
        public string Actor_name { get; set; }
        public string Director_name { get; set; }
        public string Writer_name { get; set; }
        public decimal agf_rating { get; set; }
        public string Poster { get; set; }


    }
}