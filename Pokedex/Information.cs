using Pokedex;
using System;
using System.Collections.Generic;
using System.Text;

namespace Pokedex
{
    public class Nom
    {
        public string en { get; set; }
        public string fr { get; set; }
    }

    public class Gen
    {
        public string en { get; set; }
        public string fr { get; set; }
    }

    public class Description { 
        public string en { get; set; }
        public string fr { get; set; }
    }

    public class stats
    {
        public string name { get; set; }
        public int stat { get; set; }
    }

    public class Pokemon
    {
        public int id { get; set; }
        public Nom name { get; set; }
        public List<string> types { get; set; }
        public int height { get; set; }
        public int weight { get; set; }
        public Gen gen { get; set; }
        public Description description { get; set; }
        public List<stats> stats { get; set; }
        public int lastEdit { get; set; }
    }
}