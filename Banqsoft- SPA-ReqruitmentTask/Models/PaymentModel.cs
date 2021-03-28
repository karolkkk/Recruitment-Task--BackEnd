using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Banqsoft__SPA_ReqruitmentTask
{
    public class PaymentModel
    {
        public int Index { get; set; }
        public decimal payment { get; set; }
        public decimal principal { get; set; }
        public decimal interest { get; set; }
        public decimal balance { get; set; }
    }
}
