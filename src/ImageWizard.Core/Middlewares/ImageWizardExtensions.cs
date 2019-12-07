﻿using ImageWizard.Core.Middlewares;
using ImageWizard.Core.Settings;
using ImageWizard.Middlewares;
using ImageWizard.Settings;
using ImageWizard.SharedContract;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ImageWizard
{
    public static class ImageWizardExtensions
    {

        public static IEndpointConventionBuilder MapImageWizard(this IEndpointRouteBuilder endpoints)
        {
            return MapImageWizard(endpoints, "/image");
        }

        public static IEndpointConventionBuilder MapImageWizard(this IEndpointRouteBuilder endpoints, string path)
        {
            RequestDelegate pipeline = endpoints.CreateApplicationBuilder()
                                                         .UseMiddleware<ImageWizardMiddleware>()
                                                         .Build();

            return endpoints.Map($"{path}/{{*imagePath}}", pipeline).WithDisplayName("ImageWizard");
        }

        public static IImageWizardBuilder AddImageWizard(this IServiceCollection services)
        {
            return AddImageWizard(services, options => { });
        }

        public static IImageWizardBuilder AddImageWizard(this IServiceCollection services, Action<ImageWizardSettings> settingsSetup)
        {
            services.Configure(settingsSetup);

            ImageWizardBuilder configuration = new ImageWizardBuilder(services);
            configuration.AddDefaultFilters();
            configuration.AddHttpLoader();
            configuration.SetDistributedCache();

            return configuration;
        }   
    }
}
