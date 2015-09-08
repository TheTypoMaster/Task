﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ORM
{
    public class Answer
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public int TaskId { get; set; }
        public virtual ORM.Task Task { get; set; }
       
    }
}
