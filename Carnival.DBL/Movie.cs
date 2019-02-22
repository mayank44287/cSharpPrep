using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Carnival.DBL
{
    public class Movie
    {
        public int MovId { get; set; }
        public string MovName { get; set; }
        public string MovDescription { get; set; }
        public int ScreenId { get; set; }
        public int Capacity { get; set; }
        public int SeatsLeft { get; set; }
        public int price { get; set; }
        public DateTime date { get; set; }


    }
}
