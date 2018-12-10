using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMDB.Model
{
    public class MetricModel
    {
        public double TP { get; set; }

        public double FP { get; set; }

        public double TN { get; set; }

        public double FN { get; set; }

        public double[] Predictions { get; set; }
    }
}
