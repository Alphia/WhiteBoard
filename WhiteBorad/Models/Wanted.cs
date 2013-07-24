using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WhiteBorad.Models
{
    public class Wanted
    {
        public int WantedId { get; set; }
        public string What { get; set; }
        public string ByWho { get; set; }

        public Wanted()
        {
        }

        public Wanted(int wantedId, string what, string byWho)
        {
            this.WantedId = wantedId;
            this.What = what;
            this.ByWho = byWho;
        }
    }
}