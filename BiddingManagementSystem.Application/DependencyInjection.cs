using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using BiddingManagementSystem.Application.Interfaces;
using BiddingManagementSystem.Application.Services;
using BiddingManagementSystem.Application.Features.Bids.Commands.DeleteBidDocument;
using MediatR;
using BiddingManagementSystem.Infrastructure.Services;

namespace BiddingManagementSystem.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));

            services.AddTransient<IRequestHandler<DeleteBidDocumentCommand, bool>, DeleteBidDocumentCommandHandler>();

            services.AddAutoMapper(Assembly.GetExecutingAssembly());

            services.AddScoped<IRoleService, RoleService>();
            services.AddScoped<ITenderService, TenderService>();
            services.AddScoped<IBidService, BidService>();
            services.AddScoped<IEmailService, SmtpEmailService>();


            return services;
        }
    }
}
