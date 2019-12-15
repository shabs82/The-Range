using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Final_exam_project.core.ApplicationService;
using Final_exam_project.core.ApplicationService.MensIService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace TheRange.UI.Rest.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SweatshirtsController : ControllerBase
    {
        private readonly ISweatshirtsService _sweatshirtsServiceS;

        public SweatshirtsController(ISweatshirtsService sweatshirtService)
        {
            _sweatshirtsServiceS = sweatshirtService;
        }
    }
}