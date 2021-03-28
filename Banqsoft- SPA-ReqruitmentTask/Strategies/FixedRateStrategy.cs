using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Banqsoft__SPA_ReqruitmentTask
{
    public class FixedRateStrategy : ILoanStrategy
    {
      
        public List<PaymentModel> GenerateRates(int paybackTime, decimal amount, decimal interest)
        {
            int months = CalculateAmountOfMonths(paybackTime);
            decimal setRate = CalculateSetAmountOfRate(amount,months);
            return CalculateMonthlyRates(months, setRate, amount, interest);
        }
        private List<PaymentModel> CalculateMonthlyRates(int months, decimal setRate, decimal amount,decimal interest)
        {
            List<PaymentModel> monthlyPaymentsList = new List<PaymentModel>();
            for (int i = 0; i <= months; i++)
            {
                decimal amountFromWhichToCalculateInterest = amount - (i * setRate);
                decimal monthlyPayment = setRate + CalculateMonthlyInterest(amountFromWhichToCalculateInterest, interest);
                PaymentModel model = new PaymentModel()
                { 
                    Index = i,
                    payment = monthlyPayment
                };
                monthlyPaymentsList.Add(model);
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
        private decimal CalculateSetAmountOfRate(decimal amount,int months)
        {
            decimal rate = amount / months;
            return rate;
        }
       
        
    }
}
