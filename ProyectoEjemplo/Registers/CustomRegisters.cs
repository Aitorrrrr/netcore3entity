using Microsoft.Extensions.DependencyInjection;
using System.Linq;

namespace ProyectoEjemplo.Registers
{
    public static class CustomRegisters
    {
        public static IServiceCollection addCustomRegisters(this IServiceCollection services)
        {
            //services.AddTransient(typeof(UserRepository));
            //services.AddTransient<UserRepository>();
            //services.AddTransient(typeof(UserProfileRepository));

            var allProviderTypes = System.Reflection.Assembly.GetExecutingAssembly()
                                                             .GetTypes()
                                                             .Where(t => t.Namespace != null && t.Namespace.Contains("Repositories"));

            foreach (var clases in allProviderTypes.Where(x => x.IsClass).Where(x => x.Name.Contains("Repository")))
            {
                services.AddTransient(clases);
            }

            // Código original héroe GitHub Interfaz/Implementación
            //var allProviderTypes = System.Reflection.Assembly.GetExecutingAssembly()
            //    .GetTypes().Where(t => t.Namespace != null && t.Namespace.Contains("Providers"));

            //foreach (var intfc in allProviderTypes.Where(t => t.IsInterface))
            //{
            //    var impl = allProviderTypes.FirstOrDefault(c => c.IsClass && intfc.Name.Substring(1) == c.Name);
            //    if (impl != null) services.AddScoped(intfc, impl);
            //}

            return services;
        }
    }
}
