using Microsoft.Extensions.Options;
using OrchardCore.ResourceManagement;

namespace Etch.OrchardCore.Gallery {

    public class ResourceManagementOptionsConfiguration : IConfigureOptions<ResourceManagementOptions>
    {
        private static ResourceManifest _manifest;

        static ResourceManagementOptionsConfiguration()
        {
            _manifest = new ResourceManifest();

            _manifest
                .DefineStyle("Gallery.Styles")
                .SetUrl("/Etch.OrchardCore.Gallery/Styles/styles.css");

            _manifest
                .DefineScript("Gallery.Scripts")
                .SetUrl("/Etch.OrchardCore.Gallery/Scripts/gallery.js");
        }

        public void Configure(ResourceManagementOptions options)
        {
            options.ResourceManifests.Add(_manifest);
        }
    }
}
