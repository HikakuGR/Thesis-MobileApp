using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Coordination.Server.ServiceTypes
{
    public class ServiceJob 
    {
        //
        // GET: /Jobs/
        public int ID{set;get;}
        public string description{set;get;}
        public string latitude{set;get;}
        public string longitude{set;get;}
        public string jobName{set;get;}
        public bool completed{set;get;}
        public bool assigned{set;get;}       
             
       

    }

    public class ServiceUser
    {
        //
        // GET: /Users/
        public int ID { set; get; }
        public string Username { set; get; }
        public string latitude { set; get; }
        public string longitude { set; get; }
        public string Password { set; get; }
        public string email { set; get; }     



    }
}
