using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contexts
{
    public class HomeSolutionsPage
    {
        public Dictionary<string, string> selectors = new Dictionary<string, string>()
        {
            { "multiplatform", "[id=\"mp-scroll\"]"},
            { "services","[id=\"sv-scroll\"]"},
            { "multiplatforHighlighted", "[class=\"scrollto  mp--stable products-menu--active\"]"},
            { "multiplatformPremiumSecurity", "#MultiplatformSecurity > div> div > a.buy_elite" }
        };

        public string URL = "https://www.bitdefender.com/solutions/";
        }
    }

