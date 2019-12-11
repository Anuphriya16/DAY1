using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin;
using MVCexample.Models;
using Owin;

[assembly: OwinStartupAttribute(typeof(MVCexample.Startup))]
namespace MVCexample
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
            //CreateRoles();
        }
        //public async void CreateRoles()
        //{
        //    var roleStore = new RoleStore<IdentityRole>(new ApplicationDbContext());
        //    var roleManager = new RoleManager<IdentityRole>(roleStore);

        //    await roleManager.CreateAsync(new IdentityRole("Admin"));
        //    await roleManager.CreateAsync(new IdentityRole("Manager"));
        //    await roleManager.CreateAsync(new IdentityRole("Teller"));

        //}
    }
}
