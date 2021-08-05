using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using ShopMoto.Data;
using Microsoft.EntityFrameworkCore;
using ShopMoto.Data.Interfaces;
using ShopMoto.Data.Repository;
using Microsoft.AspNetCore.Http;
using ShopMoto.Data.Model;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.OAuth;
using System.Threading.Tasks;
using System;

namespace ShopMoto
{
    public class Startup
    {
        private readonly IConfiguration Configuration;
        private IConfigurationRoot _confString;
        public Startup(IHostEnvironment hostEnv, IConfiguration configuration)
        {
            _confString = new ConfigurationBuilder().SetBasePath(hostEnv.ContentRootPath).AddJsonFile("dbsettings.json").Build();
            Configuration = configuration;
        }
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<AppDBContext>(options => options.UseSqlServer(_confString.GetConnectionString("DefaultConnection"))).AddIdentity<User,AppRole>(opt => 
            {
                opt.Password.RequireDigit = false;
                opt.Password.RequireLowercase = false;
                opt.Password.RequireNonAlphanumeric = false;
                opt.Password.RequireUppercase = false;
                opt.Password.RequiredLength = 6;
            }).AddEntityFrameworkStores<AppDBContext>();
            services.ConfigureApplicationCookie(config =>
            {
                config.LoginPath = "/User/Login";
                config.AccessDeniedPath = "/User/AccessDenied";
            });
            services.AddAuthentication().AddFacebook(config =>
            {
                config.AppId = Configuration["Authentication:Facebook:AppId"];
                config.AppSecret = Configuration["Authentication:Facebook:AppSecret"];
                config.AccessDeniedPath = "/AccessDeniedPathInfo";
            }).AddGoogle(config =>
            {
                config.ClientId = Configuration["Authentication:Google:AppId"];
                config.ClientSecret = Configuration["Authentication:Google:AppSecret"];
            }).AddOAuth("VK", "VKontakte", config =>
            {
                config.ClientId = Configuration["Authentication:VK:AppId"];
                config.ClientSecret = Configuration["Authentication:VK:AppSecret"];
                config.ClaimsIssuer = "VKontakte";
                config.CallbackPath = new PathString("/signin-vkontakte-token");
                config.AuthorizationEndpoint = "https://oauth.vk.com/authorize";
                config.TokenEndpoint = "https://oauth.vk.com/access_token";
                config.Scope.Add("email");
                config.ClaimActions.MapJsonKey(ClaimTypes.NameIdentifier, "user_id");
                config.ClaimActions.MapJsonKey(ClaimTypes.Email, "email");
                config.SaveTokens = true;
                config.Events = new OAuthEvents
                {
                    OnCreatingTicket = context =>
                    {
                        context.RunClaimActions(context.TokenResponse.Response.RootElement);
                        return Task.CompletedTask;
                    },
                    OnRemoteFailure = OnFailure
                };
            });
            services.AddAuthorization(options =>
            {
                options.AddPolicy("Administrator", builder =>
                {
                    builder.RequireClaim(ClaimTypes.Role, "Administrator");
                });
                options.AddPolicy("Manager", builder =>
                {
                    builder.RequireAssertion(x => x.User.HasClaim(ClaimTypes.Role, "Manager") || x.User.HasClaim(ClaimTypes.Role, "Administrator"));
                });
            });
            /*services.AddIdentityCore<IdentityUser>(opt =>
            {
                opt.Password.RequireDigit = false;
                opt.Password.RequireLowercase =false;
                opt.Password.RequireNonAlphanumeric = false;
                opt.Password.RequiredLength = 6;
                opt.Password.RequireUppercase = false;
            }).AddRoles<IdentityRole>().AddEntityFrameworkStores<AppDBContext>().AddDefaultTokenProviders();*/
            services.AddTransient<IAllMoto, MotoRepository>();
            services.AddTransient<IMotoCategory, CategoryRepository>();
            services.AddTransient<IAllOrders, OrdersRepository>();
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddScoped(sp => ShopCart.GetCart(sp));
            services.AddRazorPages();
            services.AddControllers(options => options.EnableEndpointRouting = false);
            services.AddMemoryCache();
            services.AddSession();
        }

        private Task OnFailure(RemoteFailureContext arg)
        {
            Console.WriteLine(arg);
            return Task.CompletedTask;
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseDeveloperExceptionPage();
            app.UseStatusCodePages();
            app.UseStaticFiles();
            app.UseSession();
            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();
            app.UseCors();
            app.UseAuthentication();
            app.UseEndpoints(endpoint => 
            {
                endpoint.MapRazorPages();
                endpoint.MapControllerRoute("default", "{controller=Home}/{action=Index}/{id?}");
                endpoint.MapControllerRoute("categoryFilter", "Moto/{action}/{category?}", defaults: new { Controller = "Moto", action = "List" });
            });
/*            using (var scope = app.ApplicationServices.CreateScope())
            {
                var userManager = scope.ServiceProvider.GetRequiredService<UserManager<User>>();
*//*                DBObjects.Initial(content);*//*
                var user = new User
                {
                    UserName = "likverxmakö",
                    Email = "likverxmaqq@mail.ru",
                    LastName = "Shepetov",
                    FirstName = "Dmitry"
                };
                var result = userManager.CreateAsync(user, "123qwe").GetAwaiter().GetResult();
                if (result.Succeeded)
                {
                    userManager.AddClaimAsync(user, new Claim(ClaimTypes.Role, "Administrator")).GetAwaiter().GetResult();
                }
            }*/
        }
    }
}
