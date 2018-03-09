using AllGreatFilms.BusinessObjectLayer;
using AllGreatFilms.DataAcessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AllGreatFilms.BusinessLayer
{
    public class ActorAccess
    {

         private ActorRepository _actorRepository;

            public ActorAccess()
        {
            _actorRepository = new ActorRepository();

        }

        public IEnumerable<actor> GetALL()
        {

            return _actorRepository.GetALL();
        }

        public void AddActor(actor actor)
        {

            _actorRepository.Add(actor);

        }
    }
}
