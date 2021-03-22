using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Banqsoft__SPA_ReqruitmentTask
{
    public interface ILoanStrategy
    {
        List<decimal> GenerateRates(int paybackTime, decimal amount);
    }
}
