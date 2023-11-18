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

    public Functions(ICodeCampService calculatorService)
    {
        _codeCampService = calculatorService;
    }

    [HttpApi(LambdaHttpMethod.Get, "/CodeCamp/{id}")]
    [LambdaFunction(MemorySize = 1024, ResourceName = "CC35AnnotationsGetCodeCamp")]
    public string GetCodeCamp(int id, ILambdaContext context)
    {
        return _codeCampService.GetCodeCampName(id);
    }


    [HttpApi(LambdaHttpMethod.Get, "/CodeCampSlogan/{id}")]
    [LambdaFunction(MemorySize = 1024, ResourceName = "CC35AnnotationsGetCodeCampSlogan")]
    public string GetCodeCampSlogan(int id, ILambdaContext context)
    {
        return _codeCampService.GetSlogan(id);
    }

    [HttpApi(LambdaHttpMethod.Post, "/CodeCamp")]
    [LambdaFunction(MemorySize = 1024, ResourceName = "CC35AnnotationsPostCodeCamp")]
    public string PostCodeCamp([FromBody] int id, ILambdaContext context)
    {
        return _codeCampService.AddCodeCamp(id);
    }
}