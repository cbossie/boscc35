using Microsoft.Extensions.DependencyInjection;

namespace CC35_APIWithAnnotations;

[Amazon.Lambda.Annotations.LambdaStartup]
public class Startup
{
    public void ConfigureServices(IServiceCollection services)
    {
        // Here we'll add an instance of our calculator service that will be used by each function
        services.AddSingleton<ICodeCampService>(new CodeCampService());
    }
}
