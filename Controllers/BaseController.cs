using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Enjaz_StackOverFlow.Controllers
{
   
        public class BaseController : Controller
        {
            protected string GetClaim(string claimName)
            {
                var Identity = (User.Identity as ClaimsIdentity);
                var claims = Identity?.Claims;
                return claims.FirstOrDefault(c =>
                    string.Equals(c.Type, claimName, StringComparison.CurrentCultureIgnoreCase))?.Value;
            }
        }


   
}
