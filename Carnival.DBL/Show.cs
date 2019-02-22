using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Carnival.DBL
{
    public class Show
    {
        public int ShowId { get; set; }
        public int MovId { get; set; }
        public int ShowTimeId { get; set; }
        public int ScreenId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}
