using System;
using System.Collections.Generic;
using System.Globalization;
using System.Net;
using System.Web.Http;
using System.Xml;
using System.Xml.Serialization;
using WhiteBorad.Models;

namespace WhiteBorad.Controllers
{
    public class WantedController : ApiController
    {
        private string Filepath = AppDomain.CurrentDomain.BaseDirectory + @"\Models\wanted.xml";
        // GET api/<controller>
        public List<Wanted> Get()
        {
            var wantedList = new List<Wanted>();
            foreach (XmlNode xNode in (ReadXmlFromFile().ChildNodes[1].ChildNodes))
            {
                using (var xmlReader = new XmlNodeReader(xNode) )
                {
                    var xmlS = new XmlSerializer(typeof(Wanted));
                    wantedList.Add(xmlS.Deserialize(xmlReader) as Wanted);
                }
            }
            return wantedList;
        }

        // GET api/<controller>/5
        public Wanted Get(int id)
        {
            var root = ReadXmlFromFile().ChildNodes[1];
            var xmlS = new XmlSerializer(typeof(Wanted));
            if (root != null)
            {
                foreach (XmlNode xNode in root.ChildNodes)
                {
                    using (var xmlReader = new XmlNodeReader(xNode))
                    {
                        if(xNode.FirstChild.InnerText == id.ToString(CultureInfo.InvariantCulture))
                            return xmlS.Deserialize(xmlReader) as Wanted;
                    }
                }
            }
            throw new HttpResponseException(HttpStatusCode.NotFound);
        }

        //load wanted xml document from file
        private XmlDocument ReadXmlFromFile()
        {
            var wanted = new XmlDocument();
            wanted.Load(Filepath);
            return wanted;
        }

        // POST api/<controller>
        public void Post([FromBody]string value)
        {
        }

        // PUT api/<controller>/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
        }
    }
}