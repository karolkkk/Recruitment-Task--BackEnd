using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Banqsoft__SPA_ReqruitmentTask
{
    public abstract class Loan : ILoan
    {
        private readonly ILoanStrategy strategy;
        public decimal Interest { get; set; }
        public Loan(ILoanStrategy strategy)
        {
            this.strategy = strategy;
        }

        public List<PaymentModel> GenerateRatesPlan(int years, decimal amount)
        {
            return strategy.GenerateRates(years, amount, Interest);
        }

       
    }
}
