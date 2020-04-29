using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Xunit;
using Amazon.Lambda.Core;
using Amazon.Lambda.TestUtilities;

using UpdateMutualFundNavData;

namespace UpdateMutualFundNavData.Tests
{
    public class FunctionTest
    {
        // This is a very basic test. More test will be added later
        [Fact]
        public void TestWithRealData()
        {

            // Invoke the lambda function and confirm success.
            var function = new Function();
            var context = new TestLambdaContext();
            var upperCase = function.FunctionHandler(context);

            Assert.Contains("Success", upperCase);
        }
    }
}
