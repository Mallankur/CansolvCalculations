using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Anurgenlib
{
    public  class AggregationModel
    {
        public int  Id { get; set; }

        public string TagName { get; set; } 
        public string EventTime { get; set; }
        public double Average { get; set; }
    }
}
