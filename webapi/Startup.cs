using System;
using System.Data;
using MySql.Data.MySqlClient;

namespace WebApi 
{
    public class Startup 
    {
        public Startup(IConfiguration configuration) 
        {
            Configuration = configuration;
        }
        public IConfiguration Configuration { get; set; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddTransient<MySqlConnection>(_ => new MySqlConnection(Configuration["ConnectionStrings:Default"]));
            services.AddMvc();
            services.AddControllers();
        }
    }
}
