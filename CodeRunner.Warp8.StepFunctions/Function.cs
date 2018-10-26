using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Amazon.Lambda.Core;

// Assembly attribute to enable the Lambda function's JSON input to be converted into a .NET class.
[assembly: LambdaSerializer(typeof(Amazon.Lambda.Serialization.Json.JsonSerializer))]

namespace CodeRunner.Warp8.StepFunctions
{
    public class Function
    {
        
        /// <summary>
        /// A simple function that takes a string and does a ToUpper
        /// </summary>
        /// <param name="input"></param>
        /// <param name="context"></param>
        /// <returns></returns>
        public string FunctionHandler(string input, ILambdaContext context)
        {
            return input?.ToUpper();
        }

        public Content SayHello(Content input, ILambdaContext context)
        {
            context.Logger.LogLine(input.Value);
            input.Value = $"Hello {input.Value}.";
            context.Logger.LogLine(input.Value);
            return input;
        }

        public Content SayHowAreYouToday(Content input, ILambdaContext context)
        {
            context.Logger.LogLine(input.Value);
            input.Value = $"{input.Value} How are you today?";
            context.Logger.LogLine(input.Value);
            return input;
        }
    }

    public class Content
    {
        public string Value { get; set; }
    }
}
