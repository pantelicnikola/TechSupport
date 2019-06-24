using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TechSupport.App_Start;

namespace TechSupport
{
    public partial class Startup
    {
        public void ConfigureChannelPrice()
        {
            ChannelPriceConfig channelPriceData = new ChannelPriceConfig();
            channelPriceData.EnsureSeedData();
        }
    }
}