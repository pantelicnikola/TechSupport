using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using TechSupport.App_Start;

namespace TechSupport
{
    public partial class Startup
    {
        public void ConfigurTokenPackages()
        {
            TokenPackagesConfig tokenPackagesData = new TokenPackagesConfig();
            tokenPackagesData.EnsureSeedData();
        }
    }
}