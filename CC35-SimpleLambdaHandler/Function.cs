using Amazon.Lambda.Core;

// Assembly attribute to enable the Lambda function's JSON input to be converted into a .NET class.
[assembly: LambdaSerializer(typeof(Amazon.Lambda.Serialization.SystemTextJson.DefaultLambdaJsonSerializer))]

namespace CC35_SimpleLambdaHandler;

public class Function
{
    

    public LambdaSubtractResponse FunctionHandler(LambdaSubtractRequest input, ILambdaContext context)
    {
        context.Logger.LogInformation("I am happy to say - we are now in a Lambda Function - Managed Runtime");
        return new LambdaSubtractResponse(input.Minuend - input.Subtrahend);
    }
}

public record LambdaSubtractRequest(int Minuend, int Subtrahend);
public record LambdaSubtractResponse(int Difference);