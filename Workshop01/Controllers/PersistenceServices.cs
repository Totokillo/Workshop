using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.Extensions.DependencyInjection.Extensions;
using System.Runtime.CompilerServices;
using Workshop01.BackEnd.View.Infrastructure;
using Workshop01.BackEnd.View.Services;

namespace Workshop01.Controllers;

public static class PersistenceServices
{
    public static IServiceCollection GetServices(this IServiceCollection services )
    {
        services.TryAddSingleton<IHttpContextAccessor, HttpContextAccessor>();
        services.AddScoped<IDatabaseService , DatabaseService>();
        services.AddScoped<IManageUser, ManageUserService>();
        services.AddScoped<IPermissionService, PermissionService>();
        return services;
    }
}

