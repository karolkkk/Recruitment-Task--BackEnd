using Banqsoft__SPA_ReqruitmentTask.Strategies;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Banqsoft__SPA_ReqruitmentTask.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        [HttpGet]
        [Route("RatesPlan")]
        public IActionResult RatesPlan(int paybackTime, decimal amount)
        {
            ILoan loan = new HousingLoan(new FixedRateStrategy());
            Console.WriteLine(loan.Interest);
            Console.WriteLine(paybackTime);
            return Ok(loan.GenerateRatesPlan(paybackTime, amount));
        }
        [HttpGet]
        [Route("Amortized")]
        public IActionResult Amortized(int paybackTime, decimal amount)
        {
            ILoan loan = new HousingLoan(new AmortizedLoanStrategy());
            Console.WriteLine(loan.Interest);
            Console.WriteLine(paybackTime);
            return Ok(loan.GenerateRatesPlan(paybackTime, amount));
        }
    }
}
