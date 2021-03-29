using System.Threading.Tasks;
using HttpTrigger.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Extensions.Logging;

namespace HttpTrigger
{
    public class HttpTrigger
    {
        private readonly IUsersBusiness _usersBusiness;
        public HttpTrigger(IUsersBusiness usersBusiness)
        {
            _usersBusiness = usersBusiness;
        }

        [FunctionName("getusers")]
        public async Task<IActionResult> GetUsers(
            [HttpTrigger(AuthorizationLevel.Function, "get", Route = "users")] HttpRequest req,
            ILogger log)
        {
            log.LogInformation("Get Users HTTP trigger function processed a request.");

            var users = _usersBusiness.GetUsers();
            return new OkObjectResult(users);
        }

        [FunctionName("getusersbyid")]
        public async Task<IActionResult> GetUsersById(
            [HttpTrigger(AuthorizationLevel.Function, "get", Route = "users/{id}")] HttpRequest req,
            int id, ILogger log)
        {
            log.LogInformation("Get Users by Id HTTP trigger function processed a request.");

            var users = _usersBusiness.GetUserById(id);
            return new OkObjectResult(users);
        }
    }
}

