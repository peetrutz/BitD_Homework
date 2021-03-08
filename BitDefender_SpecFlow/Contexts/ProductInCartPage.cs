using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contexts
{
    public class ProductInCartPage
    {
        public Dictionary<string, string> selectors = new Dictionary<string, string>()
        {
            { "quantityInput", "[id=\"qty_21642367\"]"},
            { "updateButton","[class=\"grey pointerSpan ng-scope\"]"},
            { "productPriceTimesQuantity", "[class=\"productPrice ng-binding\"]"},
            { "removeItemButton", "[class=\"fa fa-trash-o\"]"}

        };

        public string URL = "https://store.bitdefender.com/order/checkout.php?redirect=0&CART=1&CARD=2&PRODS=21642367&QTY=1&OPTIONS21642367=tsmd-10u-1y&LANG=en&CURRENCY=EUR&DCURRENCY=EUR&CLEAN_CART=ALL&ORDERSTYLE=nLWs5JSpkHE%3D&COUPON=AwardsPS2021&SHORT_FORM=1&adobe_mc=MCMID%3D17473409688342169283148294102175419458%7CMCORGID%3D0E920C0F53DA9E9B0A490D45%2540AdobeOrg%7CTS%3D1615164889&SHOPURL=https%3A%2F%2Fwww.bitdefender.com%2Fsolutions%2F";
    }
}

