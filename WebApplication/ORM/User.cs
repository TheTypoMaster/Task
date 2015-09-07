﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ORM
{
    public  class User
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public virtual ICollection<Authorization> Authorizations { get; set; }
        public virtual ICollection<Rate> Rates { get; set; }
        public virtual ICollection<ORM.Сomment> Comments { get; set; }
    }
}
