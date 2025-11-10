using BibliotecaApp.Frontend.Services;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

namespace BibliotecaApp.Frontend
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("#app");
            builder.RootComponents.Add<HeadOutlet>("head::after");
            var url = "https://localhost:7221";
            builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(url) });

            builder.Services.AddScoped<IEditorialService, EditorialService>();

            await builder.Build().RunAsync();
        }
    }
}
