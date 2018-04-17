using System;
using Microsoft.Azure.WebJobs;
using Sashay.Core.OasGen.AzureFunctions.Extensions;
using Xunit;

namespace Sashay.Core.OasGen.Tests.AzureFunctions.HttpTriggerExtensionsTests
{
    public class GetRouteOrDefault
    {
        [Fact]
        public void WithNoRouteSpecified_ReturnsDefaultRoute()
        {
            var trigger = new HttpTriggerAttribute("get");
            
            Assert.Equal("/", trigger.GetRouteOrDefault());
        }
        
        [Fact]
        public void WithNoRouteSpecified_AndSpecifiedDefault_ReturnsSpecifedDefailtRoute()
        {
            var trigger = new HttpTriggerAttribute("get");
            
            Assert.Equal("/api", trigger.GetRouteOrDefault("api"));
        }

        [Fact]
        public void WithRouteSpecified_ReturnsRouteAsPath()
        {
            var trigger = new HttpTriggerAttribute("get") {Route = "/mypath"};
            
            Assert.Equal("/mypath", trigger.GetRouteOrDefault());
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData("    ")]
        public void WithEmptyDefaultSupplied_Throws(string defaultRoute)
        {
            var trigger = new HttpTriggerAttribute("get");
            
            Assert.Throws<ArgumentException>("defaultRoute", () => trigger.GetRouteOrDefault(defaultRoute));
        }
    }
}
