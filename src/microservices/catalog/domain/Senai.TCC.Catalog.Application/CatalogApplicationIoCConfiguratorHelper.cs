using Microsoft.Extensions.DependencyInjection;

namespace Senai.TCC.Catalog.Application;

public static class CatalogApplicationIoCConfiguratorHelper
{
    public static IServiceCollection AddCatalogApplication(this IServiceCollection services)
    {
        services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(CatalogMediatrConfiguration).Assembly));
        return services;
    }
}