using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using MiddleTierApplication_WebAPI.Models;
using System.Configuration;
using static System.Console;

namespace FrondEndApp_Console
{
    class Program
    {
        static void Main(string[] args)
        {
            var httpClient = GetHttpClient();

            WriteLine("*************Get test Start************");
            WriteLine("");
            WriteLine("****Enter customer Id to get  customer data****");
            readdata:

            var input = ReadLine();
            var id = 0;
            int.TryParse(input, out id);

            if (id > 0)
            {

                //To Get customer Data from WebAPI
                var response = httpClient.GetAsync("customer/" + input).Result;

                if (response.StatusCode == HttpStatusCode.OK)
                {
                    WriteLine("****customer data****");
                    WriteLine("");
                    WriteLine(response.Content.ReadAsStringAsync().Result);

                    WriteLine("---------------");
                    WriteLine("");
                }
                else
                {
                    WriteLine("***************Error message*******");
                    WriteLine(response.StatusCode);
                    WriteLine("");
                }
                WriteLine("*************Get test End************");
                WriteLine("");
                WriteLine("***************Save Test start*******");

                var customer = new Customer
                {
                    FirstName = "",
                    LastName = "Reddy",
                    PhoneNumber = "5588996644",
                    Zip = "00000"
                };

                var saveresponse = httpClient.PostAsJsonAsync("customer", customer).Result;

                if (saveresponse.StatusCode == HttpStatusCode.OK)
                {
                    WriteLine("***************Created Customer*******");
                    WriteLine(saveresponse.Content.ReadAsStringAsync().Result);

                    WriteLine("");

                }
                else
                {
                    WriteLine("***************Error message*******");
                    WriteLine("Error code: " + saveresponse.StatusCode +"     Mesage : " + saveresponse.Content.ReadAsStringAsync().Result);
                    WriteLine("");
                }
                WriteLine("***************Save Test end *******");

                ReadLine();
            }
            else
            {
                WriteLine("Invalid Id.Please enter valid Id");
                goto readdata;
            }
            ReadLine();

        }


        private static HttpClient GetHttpClient()
        {
            var httpClient = new HttpClient();

            var baseUrl = ConfigurationManager.AppSettings["BASEADDRESS"];

            if(!string.IsNullOrEmpty(baseUrl))
            {
                httpClient.BaseAddress = new Uri(baseUrl);
            }
            else
            {
                WriteLine("No base url");
                throw new Exception("No base url");
            }
            httpClient.DefaultRequestHeaders.Accept.Clear();

            httpClient.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));

            return httpClient;

        }
    }
}
