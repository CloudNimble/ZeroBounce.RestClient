using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace ZeroBounce.Tests {
    [TestClass]
    public class ValidateEmailTests : BaseTest {
        [TestMethod]
        public void zerobounce_tests_validateemail_sandbox_valid() {
            var zeroBounce = GetZeroBounceApi();
            var result = zeroBounce.ValidateEmail("valid@example.com");
            if (result.ErrorMessage != null) Console.WriteLine("ErrorMessage: " + result.ErrorMessage);
            Assert.AreEqual("Valid", result.Status);
        }

        [TestMethod]
        public void zerobounce_tests_validateemail_sandbox_invalid() {
            var zeroBounce = GetZeroBounceApi();
            var result = zeroBounce.ValidateEmail("invalid@example.com");
            if (result.ErrorMessage != null) Console.WriteLine("ErrorMessage: " + result.ErrorMessage);
            Assert.AreEqual("Invalid", result.Status);
        }

        [TestMethod]
        public void zerobounce_tests_validateemail_sandbox_catchall() {
            var zeroBounce = GetZeroBounceApi();
            var result = zeroBounce.ValidateEmail("catch_all@example.com");
            if (result.ErrorMessage != null) Console.WriteLine("ErrorMessage: " + result.ErrorMessage);
            Assert.AreEqual("Catch-All", result.Status);
        }

        [TestMethod]
        public void zerobounce_tests_validateemail_sandbox_spamtrap() {
            var zeroBounce = GetZeroBounceApi();
            var result = zeroBounce.ValidateEmail("spamtrap@example.com");
            if (result.ErrorMessage != null) Console.WriteLine("ErrorMessage: " + result.ErrorMessage);
            Assert.AreEqual("Spamtrap", result.Status);
        }

        [TestMethod]
        public void zerobounce_tests_validateemail_sandbox_abuse() {
            var zeroBounce = GetZeroBounceApi();
            var result = zeroBounce.ValidateEmail("abuse@example.com");
            if (result.ErrorMessage != null) Console.WriteLine("ErrorMessage: " + result.ErrorMessage);
            Assert.AreEqual("Abuse", result.Status);
        }

        [TestMethod]
        public void zerobounce_tests_validateemail_sandbox_donotmail() {
            var zeroBounce = GetZeroBounceApi();
            var result = zeroBounce.ValidateEmail("donotmail@example.com");
            if (result.ErrorMessage != null) Console.WriteLine("ErrorMessage: " + result.ErrorMessage);
            Assert.AreEqual("DoNotMail", result.Status);
        }

        [TestMethod]
        public void zerobounce_tests_validateemail_sandbox_unknown() {
            var zeroBounce = GetZeroBounceApi();
            var result = zeroBounce.ValidateEmail("unknown@example.com");
            if (result.ErrorMessage != null) Console.WriteLine("ErrorMessage: " + result.ErrorMessage);
            Assert.AreEqual("Unknown", result.Status);
        }

        [TestMethod]
        public void zerobounce_tests_validateemail_sandbox_timeout() {
            var zeroBounce = GetZeroBounceApi();
            var result = zeroBounce.ValidateEmail("timeout_exceeded@example.com");
            if (result.ErrorMessage != null) Console.WriteLine("ErrorMessage: " + result.ErrorMessage);
            Assert.AreEqual("Unknown", result.Status);
            Assert.AreEqual("timeout_exceeded", result);
        }
    }
}