﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Entities
{
    public class Career
    {
        public int CareerId { get; set; }
        public string Name { get; set; }
        public string Resolution { get; set; }
        public int Duration { get; set; }
    }
}
