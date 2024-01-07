// Startup.cs dosyasında
using FirebaseAdmin;
using Google.Apis.Auth.OAuth2;
using Microsoft.AspNetCore.Builder.Extensions;

public class Startup
{
    public Startup(IConfiguration configuration)
    {
        Configuration = configuration;
    }

    public IConfiguration Configuration { get; }

    public void ConfigureServices(IServiceCollection services)
    {
        // Diğer ConfigureServices işlemleri

        FirebaseApp.Create(new AppOptions
        {
            Credential = GoogleCredential.FromFile("path/to/your/firebase/credentials.json"),
        });

        services.AddControllersWithViews();
    }

    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        // Diğer Configure işlemleri
    }
}
