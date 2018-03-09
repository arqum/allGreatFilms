using AllGreatFilms.BusinessObjectLayer;
using AllGreatFilms.DataAcessLayer.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AllGreatFilms.BusinessLayer
{
    public class DirectorAccess
    {
        private DirectorRepository _directorRepository;

            public DirectorAccess()
        {
            _directorRepository = new DirectorRepository();

        }

        public IEnumerable<director> GetALL()
        {

            return _directorRepository.GetALL();
        }

        public void AddDirector(director director)
        {

            _directorRepository.Add(director);

        }
    }
}
