using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class Discounts : BaseClass
    {
        public double PercentageProperty { get; set; }
        public string DiscountType { get; set; }
        public DateTime DateCreated  { get; set; }
        public bool IsDeleted  { get; set; }


}
}
