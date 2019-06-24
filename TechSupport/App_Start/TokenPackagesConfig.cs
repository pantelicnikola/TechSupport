using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace TechSupport.App_Start
{
    public class TokenPackagesConfig
    {
        private TechSupport20190613121821_dbEntities db = new TechSupport20190613121821_dbEntities();
        public TokenPackagesConfig() {}

        public void EnsureSeedData()
        {
            if (!db.TokenPackages.Any())
            {
                TokenPackage SilverPackage = new TokenPackage
                {
                    Name = "silver",
                    NumTokens = 20,
                    Price = 50
                };

                TokenPackage GoldPackage = new TokenPackage
                {
                    Name = "silver",
                    NumTokens = 50,
                    Price = 100
                };

                TokenPackage PlatinumPackage = new TokenPackage
                {
                    Name = "platinum",
                    NumTokens = 100,
                    Price = 150
                };

                db.TokenPackages.Add(SilverPackage);
                db.TokenPackages.Add(GoldPackage);
                db.TokenPackages.Add(PlatinumPackage);
                db.SaveChangesAsync();
            }
        }
    }
}