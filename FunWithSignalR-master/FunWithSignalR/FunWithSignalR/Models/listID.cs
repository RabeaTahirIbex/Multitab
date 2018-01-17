using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FunWithSignalR.Models
{
    public class listID
    {
        public string random { get; set; }
        public string consistentUserID { get; set; }
        public string ConnectionID { get; set; }
        public bool isAlready { get; set; }
    }
}