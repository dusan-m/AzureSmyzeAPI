using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using SmyzeFuncAPI.Managers;

namespace SmyzeFuncAPI
{
    public static class SmyzeMerge
    {
        [FunctionName("SmyzeMerge")]
        public static IActionResult Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = "car/brand={brand}&model={model}&offerNo={offerNo}")] HttpRequest req,
            string brand,
            string model,
            string offerNo,
            ILogger log, 
            ExecutionContext context)
        {
            try
            {
                var offer = OfferManager.GetOffer(context.FunctionAppDirectory, brand, model, offerNo);
                return new OkObjectResult(offer);
            }
            catch (Exception ex)
            {
                return new BadRequestObjectResult("Bad request!" + "\n" + $"Description:{ex.Message}");
            }
        }
    }
}
