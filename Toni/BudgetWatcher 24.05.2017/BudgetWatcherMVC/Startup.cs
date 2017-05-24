using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(BudgetWatcherMVC.Startup))]
namespace BudgetWatcherMVC
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
