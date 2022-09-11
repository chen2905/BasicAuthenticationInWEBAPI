using BasicAuthenticationWEBAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Claims;
using System.Threading;
using System.Web.Http;
using System.Web.Http.Cors;

namespace BasicAuthenticationWEBAPI.Controllers
{
    public class EmployeeController : ApiController
        {
        [BasicAuthentication]
        [EnableCorsAttribute("*", "*", "*")]
        [MyAuthorize(Roles = "Admin,Superadmin")]
        [Route("api/Employees")]
        public HttpResponseMessage GetEmployees()
            {
            //var identity = (ClaimsIdentity)User.Identity;
            //var username = identity.Name;
            //OR you can use the below code to get the login username
            string username = Thread.CurrentPrincipal.Identity.Name;
            var EmpList = new EmployeeBL().GetEmployees();
            switch (username.ToLower())
                {
                case "adminuser":
                    return Request.CreateResponse(HttpStatusCode.OK,
                        EmpList.Where(e => e.Gender.ToLower() == "male").ToList());
                case "superadminuser":
                    return Request.CreateResponse(HttpStatusCode.OK,
                        EmpList.Where(e => e.Gender.ToLower() == "female").ToList());
                case "bothuser":
                    return Request.CreateResponse(HttpStatusCode.OK, EmpList);
                default:
                    return Request.CreateResponse(HttpStatusCode.BadRequest);
                }
            }
        }
    }