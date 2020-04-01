using LibraryApi.Interfaces;
using LibraryApi.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryApi.Controllers
{
    public class OnCallDevelopersController : Controller
    {
        ILookupOnCallDevelopers OnCallLookup;

        public OnCallDevelopersController(ILookupOnCallDevelopers onCallLookup)
        {
            OnCallLookup = onCallLookup ?? throw new ArgumentNullException(nameof(onCallLookup));
        }

        [HttpGet("oncalldeveloper")]
        public async Task<ActionResult<OnCallDeveloperResponse>> GetOnCallDeveloper()
        {    
            //This is for initial tests
            //var response = new OnCallDeveloperResponse {Email = "jaosidfj@aosidfj.com" };
            
            //This is what we want to have
            OnCallDeveloperResponse response = await OnCallLookup.GetOnCallDeveoper();

            return Ok(response);
        }
    }
}
