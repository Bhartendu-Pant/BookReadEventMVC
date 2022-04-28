using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LearningMVC.Data
{
    public class Events
    {
       public int id { get; set; }
        public string Title { get; set; }

        public DateTime Date { get; set; }

        public string Location { get; set; }

      

        public float DurationInHours { get; set; }

        public string Description { get; set; }

        public string OtherDetails { get; set; }

        

        public string InviteOthers { get; set; }


    }
}
