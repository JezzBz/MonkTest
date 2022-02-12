using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using MonkLab_Test.Common;
using MonkLab_Test.Data;
using MonkLab_Test.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;

using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Controllers
{

    [Route("api/")]
    [ApiController]
    public class MainController : ControllerBase
    {

        private readonly MainRouteLogic mainLogic = new MainRouteLogic();
        private readonly IConfiguration Config;
        private readonly AppDbContext Context;
        public MainController(IConfiguration config, AppDbContext context)
        {
            Context = context;
            Config = config;

        }
        [HttpPost]
        [Route("mails/")]
        public void SendMails(Message message)
        {
            Debug.WriteLine(message.Body);
            mainLogic.sendMessage(message, Config, Context);
            
        }
        [HttpGet]
        [Route("mails/")]
        public IActionResult GetMails()
        {
            return Ok(mainLogic.GetMessages(Context));
        }
    }
}
