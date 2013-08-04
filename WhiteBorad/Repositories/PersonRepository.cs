using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Hosting;
using System.Xml;
using NHibernate;
using NHibernate.Linq;
using WhiteBorad.DBFactory;
using WhiteBorad.Models;

namespace WhiteBorad.Repositories
{
    public interface IPersonRepository
    {
        Person Add(Person newPerson);
        IEnumerable<Person> LoadAllPersons();
        void Update(Person updatePerson);
    }

//    public class XmlPersonRepository :IPersonRepository
//    {
//        public readonly string _filePath;
//
//        public XmlPersonRepository(string filePath)
//        {
//            _filePath = filePath;
//        }
//        private readonly List<Person> Persons = new List<Person>();
//        public Person Add(Person newPerson)
//        {
//            var xmlDoc = new XmlDocument();
//            xmlDoc.Load(_filePath);
//            var root = xmlDoc.SelectSingleNode("person");
//            var xe1 = xmlDoc.CreateElement("member");
//            var xesub1 = xmlDoc.CreateElement("name");
//            xesub1.InnerText = newPerson.Name;
//            xe1.AppendChild(xesub1);
//            var xesub2 = xmlDoc.CreateElement("age");
//            xesub2.InnerText = newPerson.Age.ToString();
//            xe1.AppendChild(xesub2);
//            var xesub3 = xmlDoc.CreateElement("sex");
//            xesub3.InnerText = newPerson.Sex;
//            xe1.AppendChild(xesub3);
//            var xesub4 = xmlDoc.CreateElement("hometown");
//            xesub4.InnerText = newPerson.Hometown;
//            xe1.AppendChild(xesub4);
//            var xesub5 = xmlDoc.CreateElement("hobby");
//            xesub5.InnerText = newPerson.Hobby;
//            xe1.AppendChild(xesub5);
//            if (root != null)
//                root.AppendChild(xe1);
//            xmlDoc.Save(_filePath);
//            return newPerson;
//        }
//        public IEnumerable<Person> LoadAllPersons()
//        {
//            var xmlDoc = new XmlDocument();
//            xmlDoc.Load(_filePath);
//            var xn = xmlDoc.SelectSingleNode("person");
//            if (xn != null)
//            {
//                var xnChild = xn.ChildNodes;
//                foreach (XmlNode xnChildTemp in xnChild)  
//                {
//                    var person = new Person();
//                    var xe = (XmlElement)xnChildTemp;
//                    var xnList = xe.ChildNodes;
//                    foreach (var xe2 in xnList.Cast<XmlElement>())
//                    {
//                        switch (xe2.Name)
//                        {
//                            case "name":
//                                person.Name = xe2.InnerText;
//                                break;
//                            case "age":
//                                person.Age = Convert.ToUInt16(xe2.InnerText);
//                                break;
//                            case "sex":
//                                person.Sex = xe2.InnerText;
//                                break;
//                            case "hometown":
//                                person.Hometown = xe2.InnerText;
//                                break;
//                            default:
//                                person.Hobby = xe2.InnerText;
//                                break;
//                        }
//                    }
//                    Persons.Add(person);
//                }
//            }
//
//            return Persons.ToList();
//        }
//         
//    }

    public class  DbPersonRepository:IPersonRepository
    {
        private readonly ISession _dbSession = DBfactory.GetSession();

        public Person Add(Person newPerson)
        {
            _dbSession.SaveOrUpdate(newPerson);
            _dbSession.Flush();
            return newPerson;
        }

        public IEnumerable<Person> LoadAllPersons()
        {
            return _dbSession.Query<Person>().ToArray();
        }

        public void Update(Person updatePerson)
        {
            _dbSession.SaveOrUpdate(updatePerson);
            _dbSession.Flush();
        }
    }
}