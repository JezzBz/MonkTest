using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using MonkLab_Test.Common;
using MonkLab_Test.Data;
using MonkLab_Test.Models;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MonkLab_Test.Controllers
{
    

    [Route("api/[controller]")]
    [ApiController]
    public class MainController : ControllerBase
    {
       
        private readonly MainRouteLogic mainLogic = new MainRouteLogic();
        private readonly IConfiguration Config;
        private readonly AppDbContext Context;
        public MainController(IConfiguration config,AppDbContext context)
        {
            Context = context;
            Config = config;
           
        }
        [HttpPost]
        [Route("mails/")]
        public IActionResult Mails(Message message)
        {
            mainLogic.sendMessage(message,Config,Context);
            return Ok();
        }
    }
}
