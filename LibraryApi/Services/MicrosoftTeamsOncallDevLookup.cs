using LibraryApi.Interfaces;
using LibraryApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryApi.Services
{
    public class MicrosoftTeamsOncallDevLookup : ILookupOnCallDevelopers
    {
        public Task<OnCallDeveloperResponse> GetOnCallDeveoper()
        {
            //Call teams API here, put it in a cache
            return Task.FromResult(new OnCallDeveloperResponse { Email = "test.test.com" });
            //throw new NotImplementedException();
        }
    }
}
