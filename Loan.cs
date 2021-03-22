using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Banqsoft__SPA_ReqruitmentTask
{
    public class Loan 
    {
        private ILoanStrategy strategy;

        public Loan(ILoanStrategy strategy)
        {
            this.strategy = strategy;
        }

        public decimal executeStrategy(decimal num1, decimal num2)
        {
            return strategy.CalculateMonthlyRates(num1,num2);
        }
    }
}
