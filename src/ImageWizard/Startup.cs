﻿using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Primitives;
using Microsoft.Net.Http.Headers;
using System;
using ImageWizard.MongoDB;
using ImageWizard.Core.ImageCaches;
using ImageWizard.Settings;

namespace ImageWizard
{
    public class Startup
    {
        public Startup(IConfiguration configuration, IHostingEnvironment env)
        {
            Configuration = configuration;
            HostingEnvironment = env;
        }

        public IConfiguration Configuration { get; }

        public IHostingEnvironment HostingEnvironment { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.Configure<ImageWizardSettings>(Configuration.GetSection("General"));
            services.Configure<FileCacheSettings>(Configuration.GetSection("FileCache"));
            services.Configure<MongoDBCacheSettings>(Configuration.GetSection("MongoDBCache"));

            services.AddImageWizard(options =>
                                    {
                                        options.BasePath = "/image";
                                        options.UseETag = true;
                                        options.ResponseCacheTime = TimeSpan.FromDays(90);
                                    })
                        //.AddFileCache(options => options.RootFolder = HostingEnvironment.WebRootPath)
                        .AddMongoDBCache()
                        .AddHttpLoader();

            services.AddHttpsRedirection(x => x.RedirectStatusCode = StatusCodes.Status308PermanentRedirect);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();
            app.UseImageWizard();
        }
    }
}
