using Microsoft.EntityFrameworkCore;
using System.Reflection;
using TelephoneStationBLL.Mappings;
using TelephoneStationBLL.MediatR.Calls.GetAll;
using TelephoneStationBLL.Services;
using TelephoneStationDAL;
using TelephoneStationDAL.UoW.Interfaces;
using TelephoneStationDAL.UoW.Realizations;

namespace TelephoneStationAPI.Extentions;
public static class Services
{
    public static void AddCustomServices(this IServiceCollection services)
    {
        services.AddScoped<IRepositoryWrapper, RepositoryWrapper>();

        services.AddSingleton<AuthorizationService>();

        var profileTypes = new List<Assembly>
        {
            typeof(SavedUserProfile).Assembly,
            typeof(CallProfile).Assembly,
            typeof(ReceiptProfile).Assembly,
            typeof(ServiceProfile).Assembly,
            typeof(SubscriptionProfile).Assembly,
            typeof(UserProfile).Assembly,
            typeof(AccountProfile).Assembly
        };

        services.AddAutoMapper(profileTypes);

        services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(typeof(GetAllCallsHandler).Assembly));
    }

    public static void AddApplicationServices(this IServiceCollection services, ConfigurationManager configuration)
    {
        var connectionString = configuration.GetConnectionString("DefaultConnection");
        
        services.AddDbContext<TelephoneStationDbContext>(options =>
        {
            options.UseSqlServer(connectionString);
        });

        services.AddCors(opt =>
        {
            opt.AddDefaultPolicy(policy =>
            {
                policy.AllowAnyOrigin();
                policy.AllowAnyHeader();
                policy.AllowAnyMethod();
                policy.SetPreflightMaxAge(TimeSpan.FromDays(1));
            });
        });

        services.AddHsts(opt =>
        {
            opt.Preload = true;
            opt.IncludeSubDomains = true;
            opt.MaxAge = TimeSpan.FromDays(30);
        });

        services.AddLogging();
        services.AddControllers();
    }
}
