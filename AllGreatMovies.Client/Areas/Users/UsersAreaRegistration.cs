using System.Web.Mvc;

namespace AllGreatMovies.Client.Areas.Users
{
    public class UsersAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "Users";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "Users_actions",
                "Users/{controller}/{action}/{movie_id}/{UserAction}",
                new { action = "HomeList", movie_id = UrlParameter.Optional, UserAction = UrlParameter.Optional }
            );

            context.MapRoute(
               "Users_default",
               "Users/{controller}/{action}/{id}/",
               new { action = "Index", id = UrlParameter.Optional }
           );
        }
    }
}