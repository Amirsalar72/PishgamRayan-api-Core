using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mime;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration.Json;
using System.Configuration;
using System.Net.Http;
using Common.Definition;
using Common.Logger;
using Newtonsoft.Json;
using System.Configuration.ConfigurationManager;

//using PishgamRayan.ReqResClasses;

namespace PishgamRayan
{
    public class PishgamRayanSender
    {
        public string messageBodies { get; set; }
        public string ApiKey { get; set; }
        public byte encodings { get; set; }
        public string recipientNumbers { get; set; }
        public string senderNumber { get; set; }
        public string userTag { get; set; }

        

        private static PishgamRayanConfigModel GetConfig()
        {
            var configModel = new PishgamRayanConfigModel()
            {
                Token = ConfigurationManager.AppSettings["APIKey"],
                senderNumber = ConfigurationManager.AppSettings["senderNumber"],
                encodings = ConfigurationManager.AppSettings["encodings"],
                userTag = ConfigurationManager.AppSettings["userTag"]
            };
            return configModel;
        }
        private static void SetConfig(string APIKey, string senderNumber, string encodings, string userTag)
        {
            ConfigurationManager.AppSettings["APIKey"] = APIKey;
            ConfigurationManager.AppSettings["senderNumber"] = senderNumber;
            ConfigurationManager.AppSettings["encodings"] = encodings;
            ConfigurationManager.AppSettings["userTag"] = userTag;
        }

        private static string GetTokenFromConfigFile()
        {
            return ConfigurationSettings.AppSettings["APIKey"];
        }
        public static async Task SendSmsAsync(SendRequest request, string apikey)
        {
            HttpRequestMessage requestMessage = new HttpRequestMessage(HttpMethod.Post, "https://api.pishgamrayan.com/send");
            requestMessage.Content = new StringContent(JsonSerializer.Serialize(request), Encoding.UTF8, MediaTypeNames.Application.Json);

            using var client = new HttpClient();

            string token = apikey;
            client.DefaultRequestHeaders.Add("Authorization", token); //افزودن توکن
            var responseMessage = await client.SendAsync(requestMessage);
            var response = await responseMessage.Content.ReadAsStringAsync();
            //وضعیت 200 ارسال موفق یا ناموفق - وضعیت های بازگشتی با تعداد پیام های ارسالی برابر است  
            //وضعیت 400 - ارسال ناموفق - وضعیت بازگشتی، یک مورد
            if (responseMessage.StatusCode == HttpStatusCode.OK || responseMessage.StatusCode == HttpStatusCode.BadRequest)
            {
                var res = JsonSerializer.Deserialize<SendResponse>(response);
                //عملیات پس از ارسال
                //Console.WriteLine($"StatusCode: {(int)responseMessage.StatusCode}");
                //Console.WriteLine($"Result: {string.Join(",", res.result)}");
                //write string to file
                var filePath = (@"G:\path.txt");
                var jsonData = System.IO.File.ReadAllText(filePath);
                await System.IO.File.AppendAllTextAsync(filePath, "SendDate :"+DateTime.Now.ToString()+"\n"+"\n");
                await System.IO.File.AppendAllTextAsync(filePath, requestMessage.ToString() + "\n" + "\n");
                await System.IO.File.AppendAllTextAsync(filePath, responseMessage.ToString() + "\n" + "\n");

                HandledExceptions.WriteLog(MessageType.Information, "Send Content To PishgamRayan Api ", response.ToString());
            }
            else //ارسال ناموفق
            {
                var res = JsonSerializer.Deserialize<ErrorResponse>(response);
                //عملیات پس از ارسال
                //Console.WriteLine($"StatusCode: {(int)responseMessage.StatusCode}");
                System.IO.File.WriteAllText(@"G:\path.txt", responseMessage.ToString());
            }
        }

        public static async Task GetStatusesAsync(StatusRequest request, string apikey)
        {
            HttpRequestMessage requestMessage = new HttpRequestMessage(HttpMethod.Post, "https://api.pishgamrayan.com/status");
            requestMessage.Content = new StringContent(JsonSerializer.Serialize(request), Encoding.UTF8, MediaTypeNames.Application.Json);

            using var client = new HttpClient();
            string token = GetTokenFromConfigFile();
            client.DefaultRequestHeaders.Add("Authorization", token); //افزودن توکن
            var responseMessage = await client.SendAsync(requestMessage);
            var response = await responseMessage.Content.ReadAsStringAsync();
            //عملیات موفق
            if (responseMessage.StatusCode == HttpStatusCode.OK)
            {
                var res = JsonSerializer.Deserialize<StatusResponse>(response);
                //عملیات پس از ارسال
                Console.WriteLine($"Result: {string.Join(",", res.result)}");
            }
            else //ارسال ناموفق
            {
                var res = JsonSerializer.Deserialize<ErrorResponse>(response);
                //عملیات پس از ارسال
                Console.WriteLine($"StatusCode: {(int)responseMessage.StatusCode}");
            }
        }

        public static async Task GetCreditAsync(string apikey)
        {
            HttpRequestMessage requestMessage = new HttpRequestMessage(HttpMethod.Get, "https://api.pishgamrayan.com/credit");

            using var client = new HttpClient();
            string token = GetTokenFromConfigFile();
            client.DefaultRequestHeaders.Add("Authorization", token); //افزودن توکن
            var responseMessage = await client.SendAsync(requestMessage);
            var response = await responseMessage.Content.ReadAsStringAsync();
            //عملیات موفق
            if (responseMessage.StatusCode == HttpStatusCode.OK)
            {
                var res = JsonSerializer.Deserialize<CreditResponse>(response);
                //عملیات پس از ارسال
                Console.WriteLine($"Result: {res.result}");
            }
            else //ارسال ناموفق
            {
                var res = JsonSerializer.Deserialize<ErrorResponse>(response);
                //عملیات پس از ارسال
                Console.WriteLine($"StatusCode: {(int)responseMessage.StatusCode}");
            }
        }

        public static async Task GetMessagesAsync(MessageRequest request, string apikey)
        {
            HttpRequestMessage requestMessage = new HttpRequestMessage(HttpMethod.Post, "https://api.pishgamrayan.com/messages");
            requestMessage.Content = new StringContent(JsonSerializer.Serialize(request), Encoding.UTF8, MediaTypeNames.Application.Json);

            using var client = new HttpClient();
            string token = GetTokenFromConfigFile();
            client.DefaultRequestHeaders.Add("Authorization", token); //افزودن توکن
            var responseMessage = await client.SendAsync(requestMessage);
            var response = await responseMessage.Content.ReadAsStringAsync();
            //عملیات موفق
            if (responseMessage.StatusCode == HttpStatusCode.OK)
            {
                var res = JsonSerializer.Deserialize<MessageResponse>(response);
                //عملیات پس از ارسال
                Console.WriteLine($"Result: {res.result.Length} Message");
            }
            else //ارسال ناموفق
            {
                var res = JsonSerializer.Deserialize<ErrorResponse>(response);
                //عملیات پس از ارسال
                Console.WriteLine($"StatusCode: {(int)responseMessage.StatusCode}");
            }
        }
    }


}
