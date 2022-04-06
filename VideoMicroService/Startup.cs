/*
 * By: voidotexe
 * https://www.github.com/voidotexe
*/

using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using VideoMicroService.Data;
using VideoMicroService.Services;

namespace VideoMicroService
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
            services.AddControllers();

            services.AddDbContext<VideoContext>(options =>
                options.UseSqlServer(Environment.GetEnvironmentVariable("SelfLanguage__ConnectionString"))
            );

            services.AddScoped<IVideoService, VideoService>();
            services.AddScoped<ITranscriptionService, TranscriptionService>();
            services.AddScoped<ISubtitleService, SubtitleService>();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
