using AccesoDeDatos.Afiliacion;
using AccesoDeDatos.Configuration;
using LogicaDeNegocios.Afiliacion;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaDeNegocios.Middleware
{
    public static class IoC
    {

        public static IServiceCollection Dependency (IServiceCollection services)
        {
            services.AddScoped<IAfiliacion_LN, Afiliacion_LN>();
            services.AddScoped<IAfiliacion_AD, Afiliacion_AD>();
            services.AddScoped<Properties, Properties>();

            return services;
        }
    }
}
