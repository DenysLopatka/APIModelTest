using Newtonsoft.Json;
using NUnit.Framework;
using RestSharp;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Net;


namespace ModelBookAPITests
{
    public class APITests
    {
        [Test]
        public void CheckChangeEmail()
        {
            var expectedEmail = $"nice{DateTime.Now:ddyyyymmHHssmmffff}@gmail.com";
            var user = new Dictionary<string, string>
            {
                { "email", $"fenix{DateTime.Now:ddyyyymmHHssmmffff}@gmail.com" },
                { "first_name", "Vasilyi" },
                { "last_name", "Ignat" },
                { "password", "Qweqwe123#" },
                { "phone_number", "5554445555" }
            };

            var newUser = AuthRequest.NewUserRequest(user);

            var changedEmail = ClientRequest.ChangeEmailRequest("Qweqwe123#", expectedEmail, newUser.TokenData.Token);

            Assert.AreEqual(expectedEmail, changedEmail);
        }

        [Test]
        public void ChangePassword()
        {
            var user = new Dictionary<string, string>
            {
                { "email", $"fenix{DateTime.Now:ddyyyymmHHssmmffff}@gmail.com" },
                { "first_name", "Vasilyi" },
                { "last_name", "Ignat" },
                { "password", "Qweqwe123#" },
                { "phone_number", "5554445555" }
            };

            var newUser = AuthRequest.NewUserRequest(user);

            var changedPassword = ClientRequest.ChangePassword(
                    "Qweqwe123#", "Qweqwe123@", newUser.TokenData.Token);

            Assert.AreEqual(HttpStatusCode.OK, changedPassword);
        }

        [Test]
        public void ChangePhone()
        {
            var user = new Dictionary<string, string>
            {
                { "email", $"fenix{DateTime.Now:ddyyyymmHHssmmffff}@gmail.com" },
                { "first_name", "Vasilyi" },
                { "last_name", "Ignat" },
                { "password", "Qweqwe123#" },
                { "phone_number", "5554445555" }
            };

            var newUser = AuthRequest.NewUserRequest(user);

            var changedPhone = ClientRequest.ChangePhoneNumber(
                "Qweqwe123#", "4444444444", newUser.TokenData.Token);

            Assert.AreEqual("4444444444", changedPhone);
        }
    }
}