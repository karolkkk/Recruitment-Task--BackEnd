using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Banqsoft__SPA_ReqruitmentTask
{
    public abstract class Loan : ILoan
    {
        private ILoanStrategy strategy;
        private static decimal interest;

        public Loan(ILoanStrategy strategy)
        {
            this.strategy = strategy;
        }

        public List<decimal> GenerateRatesPlan(int num1, decimal num2)
        {
            return strategy.GenerateRates(num1, num2);
        }

       
    }
}
