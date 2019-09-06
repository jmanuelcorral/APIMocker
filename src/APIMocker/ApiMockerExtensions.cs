namespace APIMocker
{
    using Microsoft.AspNetCore.Builder;
    using Microsoft.Extensions.DependencyInjection;

    public static class ApiMockerExtensions
    {
        public static IServiceCollection AddApiMocker(this IServiceCollection services)
        {
            ApiMockerDispatcher myDispatcher = new ApiMockerDispatcher(FileScanner.ScanFromMockLibrary());
            services.AddSingleton<ApiMockerDispatcher>(myDispatcher);
            return services;
        }

        public static IApplicationBuilder UseApiMocker(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<ApiMockerMiddleware>();
        }
    }
}