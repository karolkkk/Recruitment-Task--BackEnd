using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Banqsoft__SPA_ReqruitmentTask
{
    public interface ILoanStrategy
    {
        public decimal CalculateMonthlyRates(decimal amount, decimal paybackTime);
        public decimal CalculateWeeklyRates(decimal amount, decimal paybackTime);
    }
}
