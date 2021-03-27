using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Banqsoft__SPA_ReqruitmentTask.Strategies
{
    public class AmortizedLoanStrategy : ILoanStrategy
    {
        /// <summary>
        /// Calculations based on https://www.vertex42.com/ExcelArticles/amortization-calculation.html 
        /// </summary>
        /// <param name="paybackTime"></param>
        /// <param name="amount"></param>
        /// <param name="ineterest"></param>
        /// <returns></returns>
        public List<PaymentModel> GenerateRates(int paybackTime, decimal amount, decimal interest)
        { 
            decimal periodicInterestRate = PeriodicInterestRate(interest);
            decimal numberOfPayments = NumberOfPayments(paybackTime);
            decimal payment = AmortizedLoanFormula(amount, periodicInterestRate, numberOfPayments);

            return GeneratePaymentPlanWithDetails(numberOfPayments,amount,interest,payment);

        }
        private List<PaymentModel> GeneratePaymentPlanWithDetails(decimal numberOfPayments, decimal amount, decimal interest, decimal payment)
        {
            decimal remaining = amount;
            List<PaymentModel> monthlyPaymentsList = new List<PaymentModel>();
            for (int i = 1; i <= numberOfPayments; i++)
            {
                decimal thisMonthPrincipal = Principal(remaining, interest, payment);
                PaymentModel model = new PaymentModel()
                {
                    Index = i,
                    payment = payment,
                    principal = thisMonthPrincipal,
                    interest = MonthlyInterestPaid(remaining, interest),
                    balance = remaining > payment ? remaining - thisMonthPrincipal : 0
                };
                
                remaining = remaining - thisMonthPrincipal;
                monthlyPaymentsList.Add(model);
            }

            return monthlyPaymentsList;
        }
        private decimal PeriodicInterestRate(decimal interest) 
        {
            decimal monthlyInterestRate = interest / 12;
            return monthlyInterestRate;
        }
        private decimal Principal(decimal amount,decimal interest, decimal monthlyPayment) 
        {
            decimal monthlyInterestPaid = MonthlyInterestPaid(amount, interest);
            decimal principal = monthlyPayment - monthlyInterestPaid;
            return Decimal.Round(principal, 2);
        }
        private decimal MonthlyInterestPaid(decimal amount,decimal interest) 
        {
            decimal monthlyInterestPaid = (amount * interest) / 12;
            return Decimal.Round(monthlyInterestPaid,2);
        }
        /// <summary>
        /// 12 monthly payments per year 
        /// </summary>
        private decimal NumberOfPayments(int paybackTime) 
        {
            decimal numberOfPayments = paybackTime * 12;
            return numberOfPayments;
        }
        private decimal AmortizedLoanFormula(decimal amount, decimal monthlyInterestRate,decimal numberOfPayments) 
        {
            //amount/{[(1+monthlyInterestRate)^numberOfPayments]-1}/[monthlyInterestRate(1+monthlyInterestRate)^numberOfPayments]

            decimal numerator = ((decimal)Math.Pow((double)(1 + monthlyInterestRate), (double)numberOfPayments)) * monthlyInterestRate;
            decimal denominator = ((decimal)Math.Pow((double)(1 + monthlyInterestRate), (double)numberOfPayments)) - 1;
            decimal fraction = numerator / denominator;
            decimal formula = amount * fraction;
            return Decimal.Round(formula,2);


        }
    }
}
