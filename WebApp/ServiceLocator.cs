using System;
using Application.Products;
using AutoMapper;
using FluentValidation.AspNetCore;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Persistence;

namespace WebApp
{
    public static class ServiceLocator
    {
        private static IServiceProvider _serviceProvider;
        
        public static TService Resolve<TService>()
        {
            if (_serviceProvider == null) ConfigureDependencies(new ServiceCollection());

            return _serviceProvider.GetService<TService>();
        }

        public static TService ResolveRequired<TService>()
        {
            if (_serviceProvider == null) ConfigureDependencies(new ServiceCollection());

            return _serviceProvider.GetRequiredService<TService>();
        }
        public static void ConfigureDependencies(IServiceCollection services)
        {
            services.AddControllers();
            services.AddDbContext<DataContext>(opt =>
            {
                opt.UseInMemoryDatabase(nameof(DataContext));
            });
            services.AddMediatR(typeof(List.Handler).Assembly);
            services.AddAutoMapper(typeof(List.Handler));
            services.AddMvc().AddFluentValidation(cfg =>
            {
                cfg.RegisterValidatorsFromAssemblyContaining<Create>();
            });
            
            _serviceProvider = services.BuildServiceProvider();
        }
    }
}