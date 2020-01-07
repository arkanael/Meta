using AutoMapper;
using Meta.Application.Contracts;
using Meta.Application.Services;
using Meta.Domain.Contracts.Repositories;
using Meta.Domain.Contracts.Services;
using Meta.Domain.Services;
using Meta.Infraestructure.Data.Context;
using Meta.Infraestructure.Data.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace Meta.CrossCutting.IoC
{
    public class NativeInjectorBootStrapper
    {
        public static void Register(IServiceCollection services, IConfiguration configuration)
        {
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            services.AddTransient<IContatoApplicationService, ContatoApplicationService>();
            services.AddTransient<IContatoDomainService, ContatoDomainService>();
            services.AddTransient<IContatoRepository, ContatoRepository>();

            services.AddTransient<IUnitOfWork, UnitOfWork>();

            services.AddDbContext<DataContext>(options => options.UseSqlServer(configuration.GetConnectionString("Meta")));
            
        }
    }
}
