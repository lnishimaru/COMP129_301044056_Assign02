﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace COMP229_301044056_Assign02.Models
{
    public class Recipe
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Category { get; set; }
        public string Cuisine { get; set; }
        public string Ingredients { get; set; }
        public string Instructions { get; set; }
    }
}
