using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DENTALMIS.Model.Custom
{
   public class PaymentView
    {
        public string Name { get; set; }
        public int Charge { get; set; }
        public int DiscountAmount { get; set; }
        public int TotalCharge { get; set; }
        public int Due { get; set; }
        public int Paid { get; set; }
        public string PaymentType { get; set; }
    }
}
