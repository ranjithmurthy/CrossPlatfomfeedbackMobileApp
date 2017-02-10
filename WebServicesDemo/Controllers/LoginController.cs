using AutomatedTellerMachine.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WebServicesDemo.Controllers
{
    public class LoginController : ApiController
    {
        public ApplicationDbContext db = new ApplicationDbContext();
        // GET: api/Rest
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Rest/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Rest
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Rest/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Rest/5
        public void Delete(int id)
        {
        }

   


        //[HttpPost]
        //[ActionName("XAMARIN_REG")]
        //// POST: api/Login  
        //public HttpResponseMessage Xamarin_reg(string username, string password)
        //{
        //    Login login = new Login();
        //    login.Username = username;
        //    login.Password = password;
        //    db.Logins.Add(login);
        //    db.SaveChanges();
        //    return Request.CreateResponse(HttpStatusCode.Accepted, "Successfully Created");
        //}



        //[HttpGet]
        //[ActionName("XAMARIN_Login")]
        //// GET: api/Login/5  
        //public HttpResponseMessage Xamarin_login(string username, string password)
        //{
        //    var user = db.Logins.Where(x => x.Username == username && x.Password == password).FirstOrDefault();
        //    if (user == null)
        //    {
        //        return Request.CreateResponse(HttpStatusCode.Unauthorized, "Please Enter valid UserName and Password");
        //    }
        //    else
        //    {
        //        return Request.CreateResponse(HttpStatusCode.Accepted, "Success");
        //    }
        //}

    }
}
