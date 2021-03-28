using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Banqsoft__SPA_ReqruitmentTask
{
    public class HousingLoan : Loan
    {

        public HousingLoan(ILoanStrategy strategy) : base(strategy)
        {
            Interest = 0.035m;
        }
    }
}
