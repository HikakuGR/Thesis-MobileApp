using Coordination.Server.ServiceTypes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Services;

namespace Coordination.Server
{
    /// <summary>
    /// Summary description for WebService
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class AndroidService : System.Web.Services.WebService
    {

        [WebMethod]
        public string GetVersion()
        {
            return Assembly.GetExecutingAssembly().GetName().Version.ToString();
        }

        /// <summary>
        /// A Webmethod that the android uses to get the user ID
        /// </summary>
        /// <param name="username">The username</param>
        /// <param name="password">The password</param>
        /// <returns>The ID of the user</returns>
        [WebMethod]
        public int Login(string username, string password)
        {
            using (var dbContext = new Coordination.Model.CoordinationModel())
            {
                var foundUsers = dbContext.Users.Where(user => user.Username == username && user.Password == password);

                if (foundUsers.Count() == 1)
                {
                    Model.User foundUser = foundUsers.FirstOrDefault();
                    return foundUser.ID;
                }
            }

            return -1;
        }

        [WebMethod]
        public int JobAssign(int jobID, int userID)
        {
            using (var db = new Coordination.Model.CoordinationModel())
            {
                Model.Job job = db.Jobs.FirstOrDefault(jb=>jb.ID==jobID);
                Model.User user = db.Users.FirstOrDefault(usr=>usr.ID==userID);
                if (job != null && user != null)
                {
                    user.Jobs.Add(job);                    
                    job.Assigned = true;                    
                    db.SaveChanges();
                    return 0;
                }
                //Steile ston Android User oti tin pire
                return 1;                        
                 
            }
        }

        [WebMethod]
        public int JobComplete(int jobID)
        {
            using (var db = new Coordination.Model.CoordinationModel())
            {
                Model.Job job = db.Jobs.FirstOrDefault(jb => jb.ID == jobID);                
                if (job != null)
                {
                    job.Completed = true;                  
                    db.SaveChanges();
                    return 0;
                }
                return 1;

            }
        }

        [WebMethod]
        public int RequestAssign(int userID,int jobID)
        {
            
            //TODO AlertDialog me ola ta request kai tous users
            using (var db = new Coordination.Model.CoordinationModel())
            {
                
                
                return 1;

            }
        }

        [WebMethod]
        public ServiceJob[] GetJobs()
        {

            using (var db = new Coordination.Model.CoordinationModel())
            {
                List<ServiceJob> serviceJobs = new List<ServiceJob>();
                List<Model.Job> jobs = db.Jobs.Where(job=>job.Completed==false).ToList();

                foreach (Model.Job job in jobs)
                {
                    ServiceJob servicejob = new ServiceJob();

                    servicejob.assigned = job.Assigned == true;
                    servicejob.completed = job.Completed == true;
                    servicejob.description = job.Description;
                    servicejob.ID = job.ID;
                    servicejob.jobName = job.JobName;
                    servicejob.latitude = job.Latitude;
                    servicejob.longitude = job.Longitude;
                    serviceJobs.Add(servicejob);
                }
                return serviceJobs.ToArray();


            }


        }



        private ServiceUser ConvertUser(Model.User user)
        {
                    ServiceUser serviceUser = new ServiceUser();
                    serviceUser.Username = user.Username;
                    serviceUser.Password = user.Password;
                    serviceUser.email = user.Email;
                    serviceUser.ID = user.ID;
                    serviceUser.latitude = user.Latitude;
                    serviceUser.longitude = user.Longitude;                      
                    return serviceUser;
        }

        private ServiceJob ConvertJob(Model.Job job)
        {
            ServiceJob serviceJob = new ServiceJob();
            serviceJob.assigned = job.Assigned == true;
            serviceJob.completed = job.Completed == true;
            serviceJob.description = job.Description;
            serviceJob.ID = job.ID;
            serviceJob.jobName = job.JobName;
            serviceJob.latitude = job.Latitude;
            serviceJob.longitude = job.Longitude;
            return serviceJob;
            
        }

        [WebMethod]
        public ServiceUser[] GetUsers()
        {

            using (var db = new Coordination.Model.CoordinationModel())
            {
                List<ServiceUser> serviceUsers = new List<ServiceUser>();
                List<Model.User> users = db.Users.ToList();
                foreach (Model.User user in users)
                {
                    serviceUsers.Add(ConvertUser(user));   
                }               
                return serviceUsers.ToArray();
            }


        }

        [WebMethod]
        public ServiceUser GetUserByID(int ID)
        {
            using (var db = new Coordination.Model.CoordinationModel())
            {
                Model.User user = db.Users.FirstOrDefault(usr=>usr.ID==ID);
                return ConvertUser(user);
                /*if (user != null)
                {
                   
                }*/
                              
            }
        }

        [WebMethod]
        public ServiceJob GetJobByID(int ID)
        {
            using (var db = new Coordination.Model.CoordinationModel())
            {
                Model.Job job = db.Jobs.FirstOrDefault(jb => jb.ID == ID);
                return ConvertJob(job);
                /*if (job != null)
                {
                   
                }*/

            }
        }

        [WebMethod]
        public int SendLastKnownLocation(String latitude, String longitude, String ID)
        {
            string latitude_ = latitude;
            string longitude_ = longitude;
            int ID_ = int.Parse(ID);


            using (var db = new Coordination.Model.CoordinationModel())
            {
                Model.User user = db.Users.FirstOrDefault(usr => usr.ID == ID_);
                if (user == null)
                {
                    return -1;
                }
                user.Latitude = latitude_;
                user.Longitude = longitude_;
                db.Add(user);
                db.SaveChanges();
                return 0;
            }

        }




        [WebMethod]
        public int Register(string username, string password, string mail)
        {
            try
            {
                using (var db = new Coordination.Model.CoordinationModel())
                {
                    Model.User existingUser = db.Users.FirstOrDefault(user => user.Username == username);
                    if (existingUser == null)
                    {

                        Model.User user = new Model.User();
                        user.Username = username;
                        user.Password = password;
                        user.Email = mail;

                        db.Add(user);
                        db.SaveChanges();
                    }
                    else
                    {
                        return -1;
                    }
                    return 0;
                }

            }
            catch (Exception ex)
            {
                return -2;
            }
        }

    }
}