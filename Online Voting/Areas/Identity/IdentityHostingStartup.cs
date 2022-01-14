using System;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Online_Voting.Areas.Identity.Data;
using Online_Voting_DAL.Data;

[assembly: HostingStartup(typeof(Online_Voting.Areas.Identity.IdentityHostingStartup))]
namespace Online_Voting.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
                services.AddDbContext<Online_VotingContext>(options =>
                    options.UseSqlServer(
                        context.Configuration.GetConnectionString("Online_VotingContextConnection")));

                services.AddDefaultIdentity<Online_VotingUser>(options => options.SignIn.RequireConfirmedAccount = true)
                    .AddEntityFrameworkStores<Online_VotingContext>();
            });
        }
    }
}