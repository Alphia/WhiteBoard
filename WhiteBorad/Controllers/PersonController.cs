using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Hosting;
using System.Web.Http;
using System.Xml;
using WhiteBorad.Models;

namespace WhiteBorad.Controllers
{
    public class PersonController : ApiController
    {
        private List<Person> people = new List<Person>();
        public string Filename = HostingEnvironment.MapPath("~/person.xml");

        public Person PostPerson(Person newPerson)
        {
            var person = new Person
                {
                    Name = newPerson.Name,
                    Age = newPerson.Age,
                    Hometown = newPerson.Hometown,
                    Sex = newPerson.Sex,
                    Hobby = newPerson.Hobby
                };
            var xmlDoc = new XmlDocument();
            xmlDoc.Load(Filename); 
            var root = xmlDoc.SelectSingleNode("person");
            var xe1=xmlDoc.CreateElement("member");    
            var xesub1=xmlDoc.CreateElement("name");  
            xesub1.InnerText=newPerson.Name;   
            xe1.AppendChild(xesub1);  
            var xesub2=xmlDoc.CreateElement("age");  
            xesub2.InnerText=newPerson.Age.ToString();  
            xe1.AppendChild(xesub2);
            var xesub3 = xmlDoc.CreateElement("sex");
            xesub3.InnerText = newPerson.Sex;
            xe1.AppendChild(xesub3);
            var xesub4=xmlDoc.CreateElement("hometown");  
            xesub4.InnerText=newPerson.Hometown;  
            xe1.AppendChild(xesub4);
            var xesub5 = xmlDoc.CreateElement("hobby");
            xesub5.InnerText = newPerson.Hobby;
            xe1.AppendChild(xesub5);
            if (root != null) 
                root.AppendChild(xe1); 
            xmlDoc.Save(Filename);
            return person;
        }

        public IEnumerable<Person> GetPerson()
        {
            var xmlDoc = new XmlDocument();
            xmlDoc.Load(Filename);
            var xn=xmlDoc.SelectSingleNode("person");
            if (xn != null)
            { 
                var xnChild=xn.ChildNodes;     
                foreach(XmlNode xnChildTemp in xnChild)//xnf is a member  
                {   var person = new Person();
                    XmlElement xe=(XmlElement)xnChildTemp;      
                    XmlNodeList xnList=xe.ChildNodes;    
                    foreach(XmlNode xnListTemp in xnList)   
                    {
                        var xe2 = (XmlElement)xnListTemp;   
                        if(xe2.Name=="name")    
                        {
                            person.Name = xe2.InnerText;
                        }
                        else if (xe2.Name=="age")
                        {
                            person.Age = Convert.ToUInt16(xe2.InnerText);
                        }
                        else if (xe2.Name == "sex")
                        {
                            person.Sex = xe2.InnerText;
                        }
                        else if (xe2.Name == "hometown")
                        {
                            person.Hometown = xe2.InnerText;
                        }
                        else
                        {
                            person.Hobby = xe2.InnerText;
                        }
                    }
                    people.Add(person);
                }
            }

            return people.ToList();
        }
    }
}
