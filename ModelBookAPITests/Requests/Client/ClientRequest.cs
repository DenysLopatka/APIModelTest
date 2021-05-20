using Newtonsoft.Json;
using RestSharp;
using System.Collections.Generic;
using System.Net;

namespace ModelBookAPITests
{
    public class ClientRequest
    {
        public static string ChangeEmailRequest(string password, string newEmail, string token)
        {
            var client = new RestClient("https://api.newbookmodels.com/api/v1/client/change_email/");
            var request = new RestRequest(Method.POST);
            var newEmailModel = new Dictionary<string, string>
            {
                { "email", newEmail },
                { "password", password },
            };

            request.AddHeader("content-type", "application/json");
            request.AddHeader("authorization", token);
            request.AddJsonBody(newEmailModel);
            request.RequestFormat = DataFormat.Json;

            var response = client.Execute(request);
            var changeEmailResponse = JsonConvert.DeserializeObject<ChangeEmailResponse>(response.Content);

            return changeEmailResponse.Email;
        }

        public static HttpStatusCode ChangePassword(string oldPassword, string newPassword, string token)
        {
            var client = new RestClient("https://api.newbookmodels.com/api/v1/password/change/");
            var request = new RestRequest(Method.POST);
            var newPasswordModel = new Dictionary<string, string>
            {
                { "old_password", oldPassword},
                { "new_password", newPassword},
            };

            request.AddHeader("content-type", "application/json");
            request.AddHeader("authorization", token);
            request.AddJsonBody(newPasswordModel);
            request.RequestFormat = DataFormat.Json;

            var response = client.Execute(request);
            var changePasswordResponse = JsonConvert.DeserializeObject<ChangePasswordResponse>(response.Content);

            return response.StatusCode;
        }

        public static string ChangePhoneNumber(string password, string newNumber, string token)
        {
            var client = new RestClient("https://api.newbookmodels.com/api/v1/client/change_phone/");
            var request = new RestRequest(Method.POST);
            var newPhoneModel = new Dictionary<string, string>
                    {
                        {"password",password},
                        {"phone_number",newNumber}
                    };

            request.AddHeader("content-type", "application/json");
            request.AddHeader("authorization", token);
            request.AddJsonBody(newPhoneModel);
            request.RequestFormat = DataFormat.Json;

            var response = client.Execute(request);
            var changePhoneResponse = JsonConvert.DeserializeObject<ChangePhoneNumberResponse>(response.Content);

            return changePhoneResponse.PhoneNumber;
        }

        public static string ChangeNameAndLastName(string firstName, string lastName, string token)
        {
            var client = new RestClient("https://api.newbookmodels.com/api/v1/client/self/");
            var request = new RestRequest(Method.PATCH);
            var newNamesModel = new Dictionary<string, string>
            {
                { "first_name", firstName},
                { "last_name", lastName},
            };

            request.AddHeader("content-type", "application/json");
            request.AddHeader("authorization", token);
            request.AddJsonBody(newNamesModel);
            request.RequestFormat = DataFormat.Json;

            var response = client.Execute(request);
            var changeNamesResponse = JsonConvert.DeserializeObject<ChangeSelfResponse>(response.Content);

            return changeNamesResponse.
        }
    }
}