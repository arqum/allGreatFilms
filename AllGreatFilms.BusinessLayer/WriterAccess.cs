using AllGreatFilms.BusinessObjectLayer;
using AllGreatFilms.DataAcessLayer.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AllGreatFilms.BusinessLayer
{
   public class WriterAccess
    {

        private WriterRepository _writerRepository;

            public WriterAccess()
        {
            _writerRepository = new WriterRepository();

        }

        public IEnumerable<writer> GetALL()
        {

            return _writerRepository.GetALL();
        }

        public void AddWriter(writer writer)
        {

            _writerRepository.Add(writer);

        }
    }
}
