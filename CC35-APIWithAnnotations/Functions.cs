using Amazon.Lambda.Core;
using Amazon.Lambda.Annotations;
using Amazon.Lambda.Annotations.APIGateway;

[assembly: LambdaSerializer(typeof(Amazon.Lambda.Serialization.SystemTextJson.DefaultLambdaJsonSerializer))]

namespace CC35_APIWithAnnotations;

/// <summary>
/// A collection of sample Lambda functions that provide a REST api for doing simple math calculations. 
/// </summary>
public class Functions
{
    private ICodeCampService _codeCampService;

    /// <summary>
    /// Default constructor.
    /// </summary>
    /// <remarks>
    /// The <see cref="ICodeCampService"/> implementation that we
    /// instantiated in <see cref="Startup"/> will be injected here.
    /// 
    /// As an alternative, a dependency could be injected into each 
    /// Lambda function handler via the [FromServices] attribute.
    /// </remarks>
    public Functions(ICodeCampService calculatorService)
    {
        _codeCampService = calculatorService;
    }

}