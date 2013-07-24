using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using WhiteBorad.Models;

namespace WhiteBorad.Controllers
{
    public class ShareController : ApiController
    {
        private static readonly List<Sharing> Sharecontent = new List<Sharing>();
        public IEnumerable<string> Get()
        {
            return Sharecontent.Select(name => name.Name).ToArray();
        }

        public void Put(Sharing input)
        {
            if (Sharecontent.Any(item => item.Name.Equals(input.Name)))
            {
                return;
            }
            Sharecontent.Add(input);
        }

        public HttpResponseMessage Post(Sharing newInput)
        {
            if (string.IsNullOrEmpty(newInput.Name))
            {
                return null;// return Request.CreateResponse(HttpStatusCode.BadRequest);
            }
            Sharecontent.Add(newInput);

            var httpResponseMessage = Request.CreateResponse(HttpStatusCode.Created);
            //httpResponseMessage.Headers.Location = new Uri(Url.Link("DefaultApi", new { id = Sharecontent.Count }));
            return httpResponseMessage;
        }

    }
}
