using Api.Jwt;
using Application;
using Application.Commands;
using Application.Queries;
using DataAccess;
using Implementation.Commands;
using Implementation.Faker;
using Implementation.Queries;
using Implementation.Validators;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.Core
{
    public static class ContainerExtensions
    {

        public static void AddUsesCases(this IServiceCollection services)
        {
            services.AddTransient<IGetLoadsQuery, EfGetLoadsQuery>();
            services.AddTransient<IGetSingleLoad, EfGetSingleLoad>();
            services.AddTransient<IDeleteLoadCommand, EfDeleteLoadCommand>();
            services.AddTransient<ICreateLoadCommand, EfCreateLoadCommand>();
            services.AddTransient<IUpdateLoadCommand, EfUpdateLoadCommand>();

            services.AddTransient<IGetTrucksQuery, EfGetTrucksQuery>();
            services.AddTransient<IGetSingleTruck, EfGetSingleTruck>();
            services.AddTransient<IDeleteTruckCommand, EfDeleteTruckCommand>();
            services.AddTransient<ICreateTruckCommand, EfCreateTruckCommand>();
            services.AddTransient<IUpdateTruckCommand, EfUpdateTruckCommand>();

            services.AddTransient<IGetDriversQuery, EfGetDriversQuery>();
            services.AddTransient<IGetSingleDriver, EfGetSingleDriver>();
            services.AddTransient<IDeleteDriverCommand, EfDeleteDriverCommand>();
            services.AddTransient<ICreateDriverCommand, EfCreateDriverCommand>();
            services.AddTransient<IUpdateDriverCommand, EfUpdateDriverCommand>();


            services.AddTransient<IGetModelsQuery, EfGetModelsQuery>();
            services.AddTransient<IGetSingleModel, EfGetSingleModel>();
            services.AddTransient<IDeleteModelCommand, EfDeleteModelCommand>();
            services.AddTransient<ICreateModelCommand, EfCreateModelCommand>();
            services.AddTransient<IUpdateModelCommand, EfUpdateModelCommand>();


            services.AddTransient<IUploadBolCommand, EfUploadBolCommand>();
            services.AddTransient<IGetBolsQuery, EfGetBolsQuery>();
            services.AddTransient<IGetSingleBol, EfGetSingleBol>();

            services.AddTransient<IGetLogsQuery, EfGetLogsQuery>();

            services.AddTransient<IRegisterUserCommand, EfRegisterUserCommand>();
            services.AddTransient<ILoadsFaker, FakeLoads>();
            services.AddTransient<UseCaseExecutor>();


            services.AddTransient<RegisterUserValidator>();

            services.AddTransient<InsertDriverValidator>();
            services.AddTransient<InsertLoadValidator>();
            services.AddTransient<InsertModelValidator>();
            services.AddTransient<InsertTruckValidator>();

            services.AddTransient<UpdateDriverValidator>();
            services.AddTransient<UpdateLoadValidator>();
            services.AddTransient<UpdateModelValidator>();
            services.AddTransient<UpdateTruckValidator>();


            

        }


        public static void AddApplicationActor(this IServiceCollection services)
        {
            services.AddTransient<IApplicationActor>(x =>
            {
                var accessor = x.GetService<IHttpContextAccessor>();
              
                var user = accessor.HttpContext.User;

                if (user.FindFirst("ActorData") == null)
                {
                    return new AnonymousActor();
                }

                var actorString = user.FindFirst("ActorData").Value;

                var actor = JsonConvert.DeserializeObject<JwtActor>(actorString);

                return actor;

            });
        }


        public static void AddJwt(this IServiceCollection services)
            {
                services.AddTransient<JwtManager>(x =>
                {
                    var context = x.GetService<TruckloadContext>();

                    return new JwtManager(context);
                });

                services.AddAuthentication(options =>
                {
                    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                    options.DefaultSignInScheme = JwtBearerDefaults.AuthenticationScheme;
                    options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
                }).AddJwtBearer(cfg =>
                {
                    cfg.RequireHttpsMetadata = false;
                    cfg.SaveToken = true;
                    cfg.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidIssuer = "asp_api",
                        ValidateIssuer = true,
                        ValidAudience = "Any",
                        ValidateAudience = true,
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("ThisIsMyVerySecretKey")),
                        ValidateIssuerSigningKey = true,
                        ValidateLifetime = true,
                        ClockSkew = TimeSpan.Zero
                    };
                });
            }
        
    }
}
