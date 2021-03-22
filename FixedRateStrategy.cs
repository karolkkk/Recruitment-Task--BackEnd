using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Banqsoft__SPA_ReqruitmentTask
{
    public class FixedRateStrategy : ILoanStrategy
    {
      
        public List<decimal> GenerateRates(int paybackTime, decimal amount, decimal interest)
        {
            int months = CalculateAmountOfMonths(paybackTime);
            decimal setRate = CalculateSetAmountOfRate(amount);
            return CalculateMonthlyRates(months, setRate, amount, interest);
        }
        private List<decimal> CalculateMonthlyRates(int months, decimal setRate, decimal amount,decimal interest)
        {
            List<decimal> monthlyPaymentsList = new List<decimal>();
            for (int i = 0; i <= months; i++)
            {
                decimal amountFromWhichToCalculateInterest = amount - (i * setRate);
                decimal monthlyPayment = setRate + CalculateMonthlyInterest(amountFromWhichToCalculateInterest, interest);
                monthlyPaymentsList.Add(monthlyPayment);
            }
            return monthlyPaymentsList;
        }
        private decimal CalculateMonthlyInterest(decimal amount, decimal interest)
        {
            decimal monthlyInterest = amount * (interest/12);
            return monthlyInterest;
        }
        private int CalculateAmountOfMonths(int paybackTime)
        {
            int amountOfMonths = paybackTime * 12;
            return amountOfMonths;
        }
        private decimal CalculateSetAmountOfRate(decimal amount)
        {
            decimal rate = amount / 12;
            return rate;
        }

        
    }
}
