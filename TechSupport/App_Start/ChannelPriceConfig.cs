using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TechSupport.App_Start
{
    public class ChannelPriceConfig
    {
        private TechSupport20190613121821_dbEntities db = new TechSupport20190613121821_dbEntities();
        public ChannelPriceConfig() { }

        public void EnsureSeedData()
        {
            if (!db.ChannelPrices.Any())
            {
                ChannelPrice ChannelPrice = new ChannelPrice
                {
                    NumTokens = 10
                };

                db.ChannelPrices.Add(ChannelPrice);
                db.SaveChangesAsync();
            }
        }
    }
}