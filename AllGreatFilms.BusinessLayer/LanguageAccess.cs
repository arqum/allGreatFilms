using AllGreatFilms.DataAcessLayer.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AllGreatFilms.BusinessObjectLayer;

namespace AllGreatFilms.BusinessLayer
{
    public class LanguageAccess
    {
         private LanguageRepository _languageRepository;

         public LanguageAccess()
        {
            _languageRepository = new LanguageRepository();

        }

        public IEnumerable<language> GetALL()
        {

            return _languageRepository.GetALL();
        }

        public void AddLanguage(language language)
        {

            _languageRepository.Add(language);

        }
    }
}
