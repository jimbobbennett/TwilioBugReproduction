using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Twilio.Rest.Api.V2010.Account;
using Twilio.Types;

namespace TwilioBugReproduction.Failing
{
    public static class SendMessageFailing
    {
        [FunctionName("SendMessageFailing")]
        public static async Task<IActionResult> Run([HttpTrigger(AuthorizationLevel.Anonymous, "get", "post", Route = null)]HttpRequest req,
                                                    [TwilioSms(AccountSidSetting = "TwilioAccountSid",
                                                     AuthTokenSetting = "TwilioAuthToken",
                                                     From = "<Your Twilio Number>")] ICollector<CreateMessageOptions> messages,
                                                    ILogger log)
        {
            var message = new CreateMessageOptions(new PhoneNumber("<Your mobile number>")) { Body = "Hello" };
            messages.Add(message);

            return new OkResult();
        }
    }
}
