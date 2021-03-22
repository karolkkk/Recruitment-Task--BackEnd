using System.Collections.Generic;

namespace Banqsoft__SPA_ReqruitmentTask
{
    public interface ILoan
    {
        List<decimal> GenerateRatesPlan(int num1, decimal num2);
    }
}