using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Hosting;
using System.Web.Http;
using System.Xml;
using WhiteBorad.Models;
using WhiteBorad.Repositories;

namespace WhiteBorad.Controllers
{
    public class PersonController : ApiController
    {
        
        public readonly IPersonRepository personRepo;
        public PersonController()
        {
            personRepo = new DbPersonRepository();
        }

        public PersonController(IPersonRepository personRepo)
        {
            this.personRepo = personRepo;
        }

        public Person PostPerson(Person newPerson)
        {
            return personRepo.Add(newPerson);
        }

        public void PutPerson(Person updatePerson)
        {
            personRepo.Update(updatePerson);
        }

        public IEnumerable<Person> GetPerson()
        {
            return personRepo.LoadAllPersons();
        }
    }
}
