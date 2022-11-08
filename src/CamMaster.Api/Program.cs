using System.Text;
using CamMaster.Api.Server.Authentication;
using CamMaster.Api.Server.GraphQL;
using CamMaster.Api.Server.GraphQL.AirCards;
using CamMaster.Api.Server.GraphQL.Assignments;
using CamMaster.Api.Server.GraphQL.Cameras;
using CamMaster.Api.Server.GraphQL.Common;
using CamMaster.Api.Server.GraphQL.Contacts;
using CamMaster.Api.Server.GraphQL.Incidents;
using CamMaster.Api.Server.GraphQL.Nvrs;
using CamMaster.Api.Server.GraphQL.PoliceDepartment;
using CamMaster.Api.Server.GraphQL.Proposals;
using CamMaster.Api.Server.GraphQL.Routers;
using CamMaster.Api.Server.GraphQL.SIMCards;
using CamMaster.Api.Server.GraphQL.Sites;
using CamMaster.Api.Server.GraphQL.SolarPanels;
using CamMaster.Api.Server.GraphQL.Types.Sites;
using CamMaster.Api.Server.GraphQL.Units;
using CamMaster.Api.Server.GraphQL.Users;
using CamMaster.Api.Server.Models;
using CamMaster.Persistence.Context;
using Hellang.Middleware.ProblemDetails;
using HotChocolate.Types.Pagination;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

namespace CamMaster.Api.Server;

public class Program
{
    public static void Main(string[] args)
    {
        WebApplicationBuilder? builder = WebApplication.CreateBuilder(args);
        ConfigureServices(builder.Services, builder.Configuration);
        WebApplication? app = builder.Build();

        ConfigureMiddleware();
        ConfigureEndpoints();
        app.Run();

        void ConfigureServices(IServiceCollection services, IConfiguration configuration)
        {
            services.AddHttpContextAccessor();
            services.AddScoped<IAuthenticationService<UserAccount?, UserLoginInput>, BCryptAuthenticationService>();

            services.AddScoped<ITokenService, JwtTokenService>();
            services.AddScoped<IIdentityParser<UserAccount>, JwtIdentityParser>();

            services.AddCors();
            services.AddControllers();
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();

            var signingKey = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes("MySuperSecretKey"));

            if (builder.Environment.IsProduction())
            {
                services
                    .AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                    .AddJwtBearer(options =>
                    {
                        //TO DO Set up audience urls for prod
                        options.Audience = "";
                        options.TokenValidationParameters =
                            new TokenValidationParameters
                            {
                                //ToDO set valid issuers
                                ValidIssuer = "",
                                ValidateIssuerSigningKey = true,
                                IssuerSigningKey = signingKey,
                                ValidateIssuer = true,
                                ValidateAudience = true,
                                ValidateLifetime = true,
                                ClockSkew = TimeSpan.FromMinutes(5)
                            };
                    });
            }
            else
            {
                services
                    .AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                    .AddJwtBearer(options =>
                    {
                        options.TokenValidationParameters =
                            new TokenValidationParameters
                            {
                                ValidateIssuerSigningKey = true,
                                IssuerSigningKey = signingKey,
                                ValidateIssuer = false,
                                ValidateAudience = false,
                                ValidateLifetime = true,
                                ClockSkew = TimeSpan.FromMinutes(5)
                            };
                    });
            }

            services.AddAuthorization();

            // Add middleware to automatically map unhandled exceptions to problem details messages.
            services.AddProblemDetails(setup =>
            {
                // Only include exception details when running in Development mode.
                setup.IncludeExceptionDetails = (_, _) => builder.Environment.IsDevelopment();
            });


            services.AddPooledDbContextFactory<CamMasterContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("camMasterDb"), sqlOptions =>
                {
                    sqlOptions.UseNetTopologySuite();
                });
            });

            services
                 .AddGraphQLServer()
                 .AddAuthorization()
                 .SetPagingOptions(new PagingOptions { DefaultPageSize = 100 })
                 .RegisterDbContext<CamMasterContext>(DbContextKind.Pooled)
                 .AddQueryType<Query>()
                 .AddTypeExtension<AirCardQueries>()
                 .AddTypeExtension<AssignmentQueries>()
                 .AddTypeExtension<CameraQueries>()
                 .AddTypeExtension<ContactQueries>()
                 .AddTypeExtension<IncidentQueries>()
                 .AddTypeExtension<NvrQueries>()
                 .AddTypeExtension<PoliceDepartmentQueries>()
                 .AddTypeExtension<ProposalQueries>()
                 .AddTypeExtension<RouterQueries>()
                 .AddTypeExtension<SolarPanelQueries>()
                 .AddTypeExtension<SimCardQueries>()
                 .AddTypeExtension<SiteQueries>()
                 .AddTypeExtension<UnitQueries>()
                 .AddTypeExtension<UserQueries>()
                 .AddTypeExtension<SitesEdgeExtension>()
                 .AddMutationType<Mutation>()
                 .AddTypeExtension<UserMutations>()
                 //.AddSubscriptionType<Subscription>()
                 //.AddTypeExtension<UserSubscriptions>()
                 .AddErrorInterfaceType<IUserError>()
                 .AddProjections()
                 .AddFiltering()
                 .AddSorting();
        }

        void ConfigureMiddleware()
        {
            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment() || app.Environment.IsStaging())
            {
                app.UseSwagger();
                app.UseSwaggerUI();

                // global cors policy
                app.UseCors(x => x
                    .AllowAnyMethod()
                    .AllowAnyHeader()
                    .SetIsOriginAllowed(origin => true) // allow any origin
                    .AllowCredentials());
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

        }

        void ConfigureEndpoints()
        {
            app.MapControllers();

            app.UseEndpoints(endpoints =>
            {
                endpoints
                    .MapGraphQL();
                // Go to https://localhost:7092/ui/voyager for Voyager
                endpoints
                    .MapGraphQLVoyager();
            });
        }

    }
}
