/* 
 * Werewolf Engine
 *
 * This is a werewolf game engine for REST access. It is primarily developed for CPE200 class at Computer Engineering, Chiang Mai University.
 *
 * OpenAPI spec version: 0.1.0
 * Contact: pruetboonma@gmail.com
 * Generated by: https://github.com/swagger-api/swagger-codegen.git
 */

using System;
using System.IO;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reflection;
using RestSharp;
using NUnit.Framework;

using WerewolfAPI.Client;
using WerewolfAPI.Api;
using WerewolfAPI.Model;

namespace WerewolfAPI.Test
{
    /// <summary>
    ///  Class for testing ActionApi
    /// </summary>
    /// <remarks>
    /// This file is automatically generated by Swagger Codegen.
    /// Please update the test case below to test the API endpoint.
    /// </remarks>
    [TestFixture]
    public class ActionApiTests
    {
        private ActionApi instance;

        /// <summary>
        /// Setup before each unit test
        /// </summary>
        [SetUp]
        public void Init()
        {
            instance = new ActionApi();
        }

        /// <summary>
        /// Clean up after each unit test
        /// </summary>
        [TearDown]
        public void Cleanup()
        {

        }

        /// <summary>
        /// Test an instance of ActionApi
        /// </summary>
        [Test]
        public void InstanceTest()
        {
            // TODO uncomment below to test 'IsInstanceOfType' ActionApi
            //Assert.IsInstanceOfType(typeof(ActionApi), instance, "instance is a ActionApi");
        }

        
        /// <summary>
        /// Test ActionGet
        /// </summary>
        [Test]
        public void ActionGetTest()
        {
            // TODO uncomment below to test the method and replace null with proper value
            //var response = instance.ActionGet();
            //Assert.IsInstanceOf<List<Action>> (response, "response is List<Action>");
        }
        
        /// <summary>
        /// Test FindActionsByRoleId
        /// </summary>
        [Test]
        public void FindActionsByRoleIdTest()
        {
            // TODO uncomment below to test the method and replace null with proper value
            //long? roleId = null;
            //var response = instance.FindActionsByRoleId(roleId);
            //Assert.IsInstanceOf<List<Role>> (response, "response is List<Role>");
        }
        
        /// <summary>
        /// Test GetActionById
        /// </summary>
        [Test]
        public void GetActionByIdTest()
        {
            // TODO uncomment below to test the method and replace null with proper value
            //long? actionID = null;
            //var response = instance.GetActionById(actionID);
            //Assert.IsInstanceOf<Action> (response, "response is Action");
        }
        
    }

}
