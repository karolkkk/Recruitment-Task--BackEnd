using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Banqsoft__SPA_ReqruitmentTask
{
    public abstract class Loan : ILoan
    {
        private readonly ILoanStrategy strategy;
        private static readonly decimal interest;

        public Loan(ILoanStrategy strategy)
        {
            this.strategy = strategy;
        }

        public List<decimal> GenerateRatesPlan(int years, decimal amount)
        {
            return strategy.GenerateRates(years, amount, interest);
        }

       
    }
}
