﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ORM
{
    public class Rate
    {
        public int Id { get; set; }
        public int Rating { get; set; }
        public int UserId { get; set; }
        public int TaskId { get; set; }
        public virtual User User { get; set; }
        public virtual Task Task { get; set; }
    }
}
