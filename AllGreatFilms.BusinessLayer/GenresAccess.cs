using AllGreatFilms.BusinessLayer.ViewModels;
using AllGreatFilms.BusinessObjectLayer;
using AllGreatFilms.DataAcessLayer.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AllGreatFilms.BusinessLayer
{
   public class GenresAccess
    {
        private GenresRepository _genresRepositor;

        public GenresAccess()
        {
            _genresRepositor = new GenresRepository();

        }

        public List<homeList_vm> GetALL()
        {
            List<homeList_vm> vm = new List<homeList_vm>();

            var res = _genresRepositor.GetALL();

            foreach (var genre in res)
            {
                homeList_vm VM = new homeList_vm();
                VM.Genres = new List<string>();
                VM.GenresIds = new List<int>();

                VM.GenresIds.Add(genre.genre_id);
                VM.Genres.Add(genre.name);
                vm.Add(VM);
            }

            return vm.ToList();
        }

        public void AddGenre(genre genre)
        {

            _genresRepositor.Add(genre);

        }
    }
}
