﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace ZeroBounce.RestClient.Tests
{

    /// <summary>
    /// 
    /// </summary>
    [TestClass]
    public class GetCreditsTests
    {

        /// <summary>
        /// 
        /// </summary>
        [TestMethod]
        public void zerobounce_tests_getcredits_happypath()
        {
            //var zeroBounce = GetZeroBounceApi();
            //var result = zeroBounce.GetCredits();
            //if (result.ErrorMessage != null) Console.WriteLine("ErrorMessage: " + result.ErrorMessage);
            //Console.WriteLine("Credits: " + result.Credits);
            //Assert.IsTrue(result.Credits >= 0);
        }

        /// <summary>
        /// 
        /// </summary>
        [TestMethod]
        public void zerobounce_tests_getcredits_invalid_api_key()
        {
            //var zeroBounce = GetZeroBounceApi("bad_api_key");
            //var result = zeroBounce.GetCredits();
            //if (result.ErrorMessage != null) Console.WriteLine("ErrorMessage: " + result.ErrorMessage);
            //Assert.AreEqual(-1, result.Credits);
        }
    }
}