using LibraryApi.Interfaces;
using LibraryApi.Models;
using Microsoft.Extensions.Caching.Distributed;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryApi.Services
{
    public class MicrosoftTeamsOncallDevLookup : ILookupOnCallDevelopers
    {
        IDistributedCache Cache;

        public MicrosoftTeamsOncallDevLookup(IDistributedCache cache)
        {
            Cache = cache;
        }

        public async Task<OnCallDeveloperResponse> GetOnCallDeveoper()
        {
            //Call teams API here, put it in a cache
            //return Task.FromResult(new OnCallDeveloperResponse { Email = "test.test.com" });


            var email = await Cache.GetAsync("email");

            string emailAddress = null;
            if (email == null)
            {
                //call teamsAPI, get email and add to cache. 
                //Return email address
                var emailToSave = $"bob-{DateTime.Now.ToLongTimeString()}@aol.com";
                var encodedEmail = Encoding.UTF8.GetBytes(emailToSave);
                var options = new DistributedCacheEntryOptions()
                    .SetAbsoluteExpiration(DateTime.Now.AddSeconds(15));
                await Cache.SetAsync("email", encodedEmail, options);

                emailAddress = emailToSave;
            }
            else { emailAddress = Encoding.UTF8.GetString(email); }

            return new OnCallDeveloperResponse { Email = emailAddress };

        }
    }
}
