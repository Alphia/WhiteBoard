using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Web.Mvc;
using Xunit;
using WhiteBorad.Models;
using WhiteBorad.Controllers;
using WhiteBorad.Repositories;

namespace WhiteBorad.Tests
{
    public class PersonControllerFact
    {
        [Fact]
        public void number_should_be_2_when_person_repo_has_2_items()
        {
            var baseDirectory = AppDomain.CurrentDomain.BaseDirectory;
            var path = Path.GetFullPath(baseDirectory + "../../../" + "testPerson.xml");
            var pController = new PersonController(path);
            var personsFromGetPerson = (IList<Person>)pController.GetPerson();
            Assert.Equal(2, personsFromGetPerson.Count);

        }
        [Fact]
        public void number_should_plus_one_when_add_person_info()
        {
            var baseDirectory = AppDomain.CurrentDomain.BaseDirectory;
            var path = Path.GetFullPath(baseDirectory + "../../../"+"testPerson.xml");
            var newPerson = new Person
                {
                    Name = "zhangsan",
                    Age = 30,
                    Sex = "female",
                    Hometown = "Sichuan",
                    Hobby = "playing"
                };
            var oldController = new PersonController(path);
            var oldPersons= (IList<Person>)oldController.GetPerson();     
            oldController.PostPerson(newPerson);
            var newController = new PersonController(path);
            var newPersons= (IList<Person>)newController.GetPerson(); 
            Assert.Equal(oldPersons.Count+1,newPersons.Count);
        }


    }

}