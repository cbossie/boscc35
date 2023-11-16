using Amazon.Lambda.Core;
using Amazon.Lambda.RuntimeSupport;
using Amazon.Lambda.Serialization.SystemTextJson;

// The function handler that will be called for each Lambda event
var handler = async (LambdaSubtractRequest input, ILambdaContext context) =>
{
    
    context.Logger.LogInformation("I am happy to say - we are now in a Lambda Function - Managed Runtime");
    return new LambdaSubtractResponse(input.Minuend - input.Subtrahend);
};

// Build the Lambda runtime client passing in the handler to call for each
// event and the JSON serializer to use for translating Lambda JSON documents
// to .NET types.
await LambdaBootstrapBuilder.Create(handler, new DefaultLambdaJsonSerializer())
        .Build()
        .RunAsync();

public record LambdaSubtractRequest(int Minuend, int Subtrahend);
public record LambdaSubtractResponse(int Difference);