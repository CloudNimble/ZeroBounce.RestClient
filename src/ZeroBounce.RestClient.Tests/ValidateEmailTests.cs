using FluentAssertions;
using Microsoft.Extensions.Configuration;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading.Tasks;

namespace ZeroBounce.RestClient.Tests
{

    /// <summary>
    /// 
    /// </summary>
    [TestClass]
    public class ValidateEmailTests
    {

        #region Private Members

        private IConfiguration Configuration { get; set; }

        #endregion

        #region Constructors

        public ValidateEmailTests()
        {
            // the type specified here is just so the secrets library can 
            // find the UserSecretId we added in the csproj file
            var builder = new ConfigurationBuilder()
                .AddUserSecrets<ValidateEmailTests>();

            Configuration = builder.Build();
        }

        #endregion

        [TestMethod]
        public async Task Sandbox_Valid()
        {
            var zeroBounce = new ZeroBounceClient(Configuration["ZeroBounceApiKey"]);
            var result = await zeroBounce.ValidateEmailAsync("valid@example.com");
            result.HttpResponseMessage.IsSuccessStatusCode.Should().BeTrue();
            result.Content.Status.Should().Be("valid");
        }

        [TestMethod]
        public async Task sandbox_invalid()
        {
            var zeroBounce = new ZeroBounceClient(Configuration["ZeroBounceApiKey"]);
            var result = await zeroBounce.ValidateEmailAsync("invalid@example.com");
            result.HttpResponseMessage.IsSuccessStatusCode.Should().BeTrue();
            result.Content.Status.Should().Be("invalid");
        }

        [TestMethod]
        public async Task Sandbox_catchall()
        {
            var zeroBounce = new ZeroBounceClient(Configuration["ZeroBounceApiKey"]);
            var result = await zeroBounce.ValidateEmailAsync("catch_all@example.com");
            result.HttpResponseMessage.IsSuccessStatusCode.Should().BeTrue();
            result.Content.Status.Should().Be("catch-all");
        }

        [TestMethod]
        public async Task Sandbox_spamtrap()
        {
            var zeroBounce = new ZeroBounceClient(Configuration["ZeroBounceApiKey"]);
            var result = await zeroBounce.ValidateEmailAsync("spamtrap@example.com");
            result.HttpResponseMessage.IsSuccessStatusCode.Should().BeTrue();
            result.Content.Status.Should().Be("spamtrap");
        }

        [TestMethod]
        public async Task Sandbox_abuse()
        {
            var zeroBounce = new ZeroBounceClient(Configuration["ZeroBounceApiKey"]);
            var result = await zeroBounce.ValidateEmailAsync("abuse@example.com");
            result.HttpResponseMessage.IsSuccessStatusCode.Should().BeTrue();
            result.Content.Status.Should().Be("abuse");
        }

        [TestMethod]
        public async Task Sandbox_donotmail()
        {
            var zeroBounce = new ZeroBounceClient(Configuration["ZeroBounceApiKey"]);
            var result = await zeroBounce.ValidateEmailAsync("donotmail@example.com");
            result.HttpResponseMessage.IsSuccessStatusCode.Should().BeTrue();
            result.Content.Status.Should().Be("do_not_mail");
        }

        [TestMethod]
        public async Task Sandbox_unknown()
        {
            var zeroBounce = new ZeroBounceClient(Configuration["ZeroBounceApiKey"]);
            var result = await zeroBounce.ValidateEmailAsync("unknown@example.com");
            result.HttpResponseMessage.IsSuccessStatusCode.Should().BeTrue();
            result.Content.Status.Should().Be("unknown");
        }

        [TestMethod]
        public async Task Sandbox_timeout()
        {
            var zeroBounce = new ZeroBounceClient(Configuration["ZeroBounceApiKey"]);
            var result = await zeroBounce.ValidateEmailAsync("timeout_exceeded@example.com");
            result.HttpResponseMessage.IsSuccessStatusCode.Should().BeTrue();
            result.Content.Status.Should().Be("unknown");
            //Assert.AreEqual("timeout_exceeded", result);
        }
    }
}