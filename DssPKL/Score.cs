using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DssPKL
{
    public class Score
    {
        public string criteria { get; set; }
        public string status { get; set; }
        public double [] score {get;set;}
        public double[] tes = new double[2];

        
       
        public double[] setScore()
        {
            for(int i = 0; i < tes.Length; i++)
            {
                tes[i] = 1;
            }
            return tes;
        }
    }
}
