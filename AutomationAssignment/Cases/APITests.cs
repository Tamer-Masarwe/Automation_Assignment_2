using Newtonsoft.Json;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace AutomationAssignment.Cases
{
    class APITests
    {
        
        [Test, Category("Get API Tests")]
        public void GetAccountByID_APITest_ReturnTrue()
        {
            string AccountsTest_URL = ((dynamic)JsonConvert.DeserializeObject(File.ReadAllText("config_File.json"))).AccountsTest_URL;
            List<dynamic> usersId = JsonConvert.DeserializeObject<List<dynamic>>(File.ReadAllText("accounts_Id.json"));

            foreach (dynamic user in usersId)
            {
                var request = (HttpWebRequest)WebRequest.Create(AccountsTest_URL + user.Id);
                request.Method = "GET";
                request.ContentType = "application/JSON";
                request.ContentLength = 0;

                var response = (HttpWebResponse)request.GetResponse();

                if (response.StatusCode != HttpStatusCode.OK)
                    Assert.Fail();               
            }
            Assert.Pass();
        }

        [Test, Category("GET API Tests")]
        public void GetCustomersByID_APITest_ReturnTrue()
        {
            string CustomrtsTest_URL = ((dynamic)JsonConvert.DeserializeObject(File.ReadAllText("config_File.json"))).CustomrtsTest_URL;
            List<dynamic> customersId = JsonConvert.DeserializeObject<List<dynamic>>(File.ReadAllText("customers_Id.json"));

            foreach (dynamic user in customersId)
            {
                var request = (HttpWebRequest)WebRequest.Create(CustomrtsTest_URL + user.Id);
                request.Method = "GET";
                request.ContentType = "application/JSON";
                request.ContentLength = 0;

                var response = (HttpWebResponse)request.GetResponse();

                if (response.StatusCode != HttpStatusCode.OK)
                    Assert.Fail();
            }
            Assert.Pass();
        }



    }
}
