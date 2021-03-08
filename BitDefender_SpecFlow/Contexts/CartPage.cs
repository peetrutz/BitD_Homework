using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contexts
{
    public class CartPage
    {
        public Dictionary<string, string> selectors = new Dictionary<string, string>()
        {
            { "home_solutions", "a[class=\"button-1 d-sm-inline-block d-none\"][href=\'//www.bitdefender.com/solutions/\']"},
            { "business_solutions","a[class=\"button-1 d-sm-inline-block d-none\"][href=\'//www.bitdefender.com/business/\']" },
            { "mainDiv", "#storeApp"}

        };

        public string URL = "https://store.bitdefender.com/order/checkout.php";
    }
}
