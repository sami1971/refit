using System;
using System.Net.Http;
using System.Collections.Generic;
using System.Linq;
using Castle.DynamicProxy;
using NUnit.Framework;
using System.Threading.Tasks;
using System.Threading;

namespace Refit.Tests
{
    [TestFixture]
    public class RestServiceIntegrationTests
    {
        [Test]
        public void HitTheGitHubUserAPI()
        {
            var fixture = RestService.For<IGitHubApi>("https://api.github.com");
            var result = fixture.GetUser("octocat");

            result.Wait();
            Assert.AreEqual("octocat", result.Result.login);
        }

        [Test]
        public void ShouldRetHttpResponseMessage() 
        {
            var fixture = RestService.For<IGitHubApi>("https://api.github.com");
            var result = fixture.GetIndex();

            result.Wait();
            Assert.IsNotNull(result.Result);
            Assert.IsTrue(result.Result.IsSuccessStatusCode);
        }

        [Test]
        public void PostToRequestBin()
        {
            var fixture = RestService.For<IRequestBin>("http://requestb.in/");
            var result = fixture.Post();

            result.Wait();
        }

        public interface IRequestBin
        {
            [Post("/1h3a5jm1")]
            Task Post();
        }
    }
}