namespace HelmerDemo.SecureWebApi
{
    using IdentityServer4.AccessTokenValidation;

    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Hosting;
    
    /// <summary>
    /// The startup class.
    /// </summary>
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            this.Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        /// <summary>
        /// This method gets called by the runtime. Use this method to add services to the container.
        /// </summary>
        /// <param name="services">
        /// The services.
        /// </param>
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

            services.AddCors();
            services.AddAuthorization();
            services.AddAuthentication(IdentityServerAuthenticationDefaults.AuthenticationScheme)
                .AddIdentityServerAuthentication(
                    options =>
                        {
                            options.Authority = "https://demo.identityserver.io/";
                            options.ApiName = "api";
                        });
            
        }


        /// <summary>
        /// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        /// </summary>
        /// <param name="app">
        /// The app.
        /// </param>
        /// <param name="env">
        /// The env.
        /// </param>
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseCors(
                policy =>
                    {
                        policy.WithOrigins("https://localhost:44300");
                        policy.AllowAnyHeader();
                        policy.AllowAnyMethod();
                        policy.WithExposedHeaders("WWW-Authenticate");
                    });

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
