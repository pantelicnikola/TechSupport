using System.Threading.Tasks;
using TechSupport.App_Start;

namespace TechSupport
{
    public partial class Startup
    {
        public async Task ConfigureRole()
        {
            RoleConfig rolesData = new RoleConfig();
            await rolesData.EnsureSeedDataAsync();
        }
    }
}