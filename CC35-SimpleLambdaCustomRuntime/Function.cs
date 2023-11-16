using Amazon.Lambda.Core;
using Amazon.Lambda.RuntimeSupport;
using Amazon.Lambda.Serialization.SystemTextJson;

namespace CC35_SimpleLambdaCustomRuntime;

public class Function
{
    /// <summary>
    /// The main entry point for the custom runtime.
    /// </summary>
    /// <param name="args"></param>
    private static async Task Main(string[] args)
    {
        Func<LambdaSubtractRequest, ILambdaContext, LambdaSubtractResponse> handler = FunctionHandler;
        await LambdaBootstrapBuilder.Create(handler, new DefaultLambdaJsonSerializer())
            .Build()
            .RunAsync();
    }

    /// <summary>
    /// A simple function that takes a string and does a ToUpper
    ///
    /// To use this handler to respond to an AWS event, reference the appropriate package from 
    /// https://github.com/aws/aws-lambda-dotnet#events
    /// and change the string input parameter to the desired event type.
    /// </summary>
    /// <param name="input"></param>
    /// <param name="context"></param>
    /// <returns></returns>
    public static LambdaSubtractResponse FunctionHandler(LambdaSubtractRequest input, ILambdaContext context)
    {
        context.Logger.LogInformation("I am happy to say - we are now in a Lambda Function - .NET8 Custom");
        return new LambdaSubtractResponse(input.Minuend - input.Subtrahend);
    }
}

public record LambdaSubtractRequest(int Minuend, int Subtrahend);
public record LambdaSubtractResponse(int Difference);