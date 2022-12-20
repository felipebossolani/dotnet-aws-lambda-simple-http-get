using Amazon.Lambda.Core;
using Amazon.Lambda.APIGatewayEvents;

// Assembly attribute to enable the Lambda function's JSON input to be converted into a .NET class.
[assembly: LambdaSerializer(typeof(Amazon.Lambda.Serialization.SystemTextJson.DefaultLambdaJsonSerializer))]

namespace dotnet_aws_lambda_simple_http_get;

public class Function
{

    public APIGatewayHttpApiV2ProxyResponse FunctionHandler(APIGatewayHttpApiV2ProxyRequest request, ILambdaContext context)
    {
        request.QueryStringParameters.TryGetValue("name", out var name);
        name = name ?? "John Doe";
        var message = $"Hello {name}, from AWS Lambda";
        return new APIGatewayHttpApiV2ProxyResponse
        {
            Body = message,
            StatusCode = 200
        };
    }
}
