using AllGreatFilms.BusinessObjectLayer;
using AllGreatFilms.DataAcessLayer.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AllGreatFilms.BusinessLayer
{
   public class CountryAccess
    {
         private CountryRepository _countryRepository;

         public CountryAccess()
        {
            _countryRepository = new CountryRepository();

        }

        public IEnumerable<country> GetALL()
        {

            return _countryRepository.GetALL();
        }

        public void AddCountry(country country)
        {

            _countryRepository.Add(country);

        }
    }
}
