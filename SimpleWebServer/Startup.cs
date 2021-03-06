﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using LiteDB;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using SimpleWebServer.Db.SQL;
using SimpleWebServer.Middlewares;
using SimpleWebServer.Repositories.Interfaces;
using SimpleWebServer.Services;
using SimpleWebServer.Services.Interfaces;

namespace SimpleWebServer
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors();

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

            services.AddAutoMapper();

            string dataSource = Configuration.GetValue<string>("DataSource:Current");

            if (dataSource.Equals(Consts.Consts.SQLServer, StringComparison.OrdinalIgnoreCase))
            {

                services.AddDbContext<SimpleSQLServerDb>(opt => opt.UseSqlServer(Configuration.GetConnectionString("SQLServerConnection")));

                services.AddScoped<ISimpleMessageRepository, Repositories.SQL.SimpleMessageRepository>();

            }
            else if (dataSource.Equals(Consts.Consts.LiteDb, StringComparison.OrdinalIgnoreCase))
            {

                services.AddScoped<LiteDatabase>(opt => new LiteDatabase($@"{Directory.GetCurrentDirectory()}\SimpleLiteDb.db"));

                services.AddScoped<ISimpleMessageRepository, Repositories.NOSQL.SimpleMessageRepository>();

            }

            services.AddScoped<ISimpleMessageService, SimpleMessageService>();
            
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.UseMiddleware<RequestLoggingMiddleware>();

            app.UseMiddleware<ExceptionHandlingMiddleware>();

            app.UseStaticFiles();

            app.UseCors(builder => builder
                .AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader()
                .AllowCredentials());

            app.UseMvc();
        }
    }
}
