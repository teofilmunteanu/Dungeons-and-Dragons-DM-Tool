using System;
using System.Collections.Generic;

namespace Deez_Notes_Dm.Models
{
    public class Tests
    {
        public List<Test> tests { get; set; }
    }
    public class Test
    {
        public int[] ID { get; set; }
        public String Name { get; set; }
    }
}
