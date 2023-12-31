using System.Net;
using Amazon.Lambda.Core;
using Amazon.Lambda.APIGatewayEvents;
using AWS.Lambda.Powertools.Logging;
using AWS.Lambda.Powertools.Metrics;
using AWS.Lambda.Powertools.Tracing;

// Assembly attribute to enable the Lambda function's JSON input to be converted into a .NET class.
[assembly: LambdaSerializer(typeof(Amazon.Lambda.Serialization.SystemTextJson.DefaultLambdaJsonSerializer))]

namespace CC35_PowerTools;


public class Functions
{
    [Logging(LogEvent = true, CorrelationIdPath = CorrelationIdPaths.ApiGatewayRest)]
    [Metrics(CaptureColdStart = true)]
    [Tracing(CaptureMode = TracingCaptureMode.ResponseAndError)]
    public async Task<APIGatewayProxyResponse> Get(APIGatewayProxyRequest request, ILambdaContext context)
    {
        int delay = DateTime.Now.Millisecond + 500;
        Logger.LogInformation("Get Request");
        Logger.LogInformation(new InformationalDataToLog("Delay", delay));
        
        // Wait a random number of milliseconds (minimum of .5 s)
        var message = await GetGreeting(delay);

        var response = new APIGatewayProxyResponse
        {
            StatusCode = (int)HttpStatusCode.OK, 
            Body = message,
            Headers = new Dictionary<string, string> { { "Content-Type", "text/plain" } }
        };

        return response;
    }

    [Tracing(SegmentName = "GetGreeting Method")]
    private static async Task<string> GetGreeting(int delay)
    {
        await Task.Delay(delay);
        Metrics.AddMetric("InvocationDelay", delay, MetricUnit.Milliseconds);

        return $"Greetings. Delayed for {delay} milliseconds";
    }

    
    public record InformationalDataToLog(string Parameter1, int Parameter2, bool Parameter3 = false);

}