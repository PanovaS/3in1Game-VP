using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3in1Game
{
   public class Words
    {
        public string MovieName { get; set; }
        public List<string> movieAssociation { get; set; }
        public Image image { get; set; }
        public Words()
        {
            movieAssociation = new List<string>();
        }
    }
}
