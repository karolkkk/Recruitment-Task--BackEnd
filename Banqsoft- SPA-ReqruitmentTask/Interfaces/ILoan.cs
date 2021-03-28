using System.Collections.Generic;

namespace Banqsoft__SPA_ReqruitmentTask
{
    public interface ILoan
    {
        public decimal Interest { get; set; }

        List<PaymentModel> GenerateRatesPlan(int paybackTime, decimal amount);
    }
}