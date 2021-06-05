using Application.Interfaces;
using Application.Interfaces.API;
using Application.Services;
using Domain.Interfaces;
using Infrastructure.Api;
using Infrastructure.Repositories;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.IoC
{
    public class DependencyContainer
    {
        public static void RegisterServices(IServiceCollection services)
        {
            //CleanArchitecture.Application
            services.AddScoped<IIssueService, IssueService>();
            services.AddScoped<IIssueStatusService, IssueStatusService>();
            services.AddScoped<IIssueSeverityService, IssueSeverityService>();

            services.AddScoped<IAsigneeService, AsigneeService>();

            //CleanArchitecture.Domain.Interfaces | CleanArchitecture.Infra.Data.Repositories
            services.AddScoped<IIssueRepository, IssueRepository>();

            //CleanArchitecture.Application.API
            services.AddScoped<IAsigneeAPI, JsonPlaceHolderTypicodeCom>();
        }
    }
}
