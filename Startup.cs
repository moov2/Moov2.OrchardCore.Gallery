using Etch.OrchardCore.Gallery.Drivers;
using Etch.OrchardCore.Gallery.Models;
using Etch.OrchardCore.Gallery.Settings;
using Etch.OrchardCore.Gallery.ViewModels;
using Fluid;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using OrchardCore.ContentManagement;
using OrchardCore.ContentManagement.Display.ContentDisplay;
using OrchardCore.ContentTypes.Editors;
using OrchardCore.Data.Migration;
using OrchardCore.Modules;
using OrchardCore.ResourceManagement;

namespace Etch.OrchardCore.Gallery
{
    public class Startup : StartupBase
    {
        public override void ConfigureServices(IServiceCollection services)
        {
            services.AddTransient<IConfigureOptions<ResourceManagementOptions>, ResourceManagementOptionsConfiguration>();

            services.AddContentPart<GalleryPart>()
                .UseDisplayDriver<GalleryPartDisplay>();

            services.AddScoped<IContentTypePartDefinitionDisplayDriver, GalleryPartSettingsDriver>();

            services.AddScoped<IDataMigration, Migrations>();

            services.Configure<TemplateOptions>(o =>
            {
                o.MemberAccessStrategy.Register<GalleryPartDisplayViewModel>();
                o.MemberAccessStrategy.Register<GalleryPartItemViewModel>();
                o.MemberAccessStrategy.Register<GalleryPartItem>();
            });
        }
    }
}
