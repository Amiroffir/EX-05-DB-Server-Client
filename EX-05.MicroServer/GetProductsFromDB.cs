using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System.Text.Json;
using Newtonsoft.Json;
using EX_05.Entities;
using EX_05.Model;
using System.Collections.Generic;

namespace EX_05.MicroServer
{
    public static class GetProductsFromDB
    {
        [FunctionName("GetProductsFromDB")]
        public static async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", "post", Route = null)] HttpRequest req,
            ILogger log)
         
        {
            string responseMessage = "";
            log.LogInformation("C# HTTP trigger function processed a request.");
            log.LogInformation(req.ContentType);
            
         
            if (req.Method == "GET")
            {
                MainManager.Instance.products.GetProductsFromDB();
                responseMessage = System.Text.Json.JsonSerializer.Serialize(MainManager.Instance.ProductsList);
            }
            if (req.Method == "POST")
            {
             
                string requestBody = await new StreamReader(req.Body).ReadToEndAsync();
               
                //string requestBody = await req.ReadAsStringAsync();
                dynamic data = JsonConvert.DeserializeObject(requestBody);

                Model.ContactUs contact = new Model.ContactUs();
                contact.Name = data.Name;
                contact.Email = data.Email;
                contact.Message = data.Message;


                MainManager.Instance.contactUs.AddContactUsToDB(contact);
                responseMessage = "inquiry added";
            }



            //  string requestBody = await new StreamReader(req.Body).ReadToEndAsync();



            return new OkObjectResult(responseMessage);
        }
    }
}
