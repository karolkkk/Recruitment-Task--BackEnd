using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Banqsoft__SPA_ReqruitmentTask
{
    public class HousingLoan : Loan
    {
        private static readonly decimal interest = 0.035m;

        public HousingLoan(ILoanStrategy strategy) : base(strategy)
        {
        }
    }
}
