using LibraryApi.Controllers;
using LibraryApi.Interfaces;
using LibraryApi.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace LibraryApiIntegrationTests
{
    public class FakeTeamsDeveloperLookup : ILookupOnCallDevelopers
    {
        public Task<OnCallDeveloperResponse> GetOnCallDeveoper()
        {
            return Task.FromResult(new OnCallDeveloperResponse { Email = "testing@test.com" });
        }
    }
}
