using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TimerWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TimerServiceController : ControllerBase
    {
     
        [HttpGet()]
       
        public string Get()
        {
            return System.DateTime.Now.ToString();

        }
    }
}
