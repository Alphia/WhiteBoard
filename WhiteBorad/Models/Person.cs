﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WhiteBorad.Models
{
    public class Person
    {
        public virtual Guid Id { get; set; }
        public virtual string Name { get; set; }
        public virtual string Description { get; set; }
        public virtual string Image { get; set; }
    }
}