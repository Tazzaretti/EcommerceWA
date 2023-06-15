using Model.Services;
using Service.Services;

namespace WebApplication1
{
    public class CompositeRoot
    {
        public static void DependencyInjection(WebApplicationBuilder builder)
        {
            builder.Services.AddScoped<IEnvioService,EnvioService>();
            builder.Services.AddScoped<IProductosService, ProductosService>();
            builder.Services.AddScoped<IUserService, UserService>();
            builder.Services.AddScoped<IVentaService, VentaService>();
            builder.Services.AddScoped<IVarianteService, VarianteService>();

        }
    }
}
