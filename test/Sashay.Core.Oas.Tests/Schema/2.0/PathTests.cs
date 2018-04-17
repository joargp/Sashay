using System;
using System.Diagnostics;
using Sashay.Core.Oas.Extensions;
using Sashay.Core.Oas.Schema._2._0;
using Xunit;

namespace Sashay.Core.Oas.Tests.Schema._2._0
{
    public class PathTests
    {
        [Theory]
        [InlineData("")]
        [InlineData(null)]
        [InlineData("   ")]
        public void Constructor_WithNullOrEmptyRoute_ThrowsException(string route)
        {
            Assert.Throws<ArgumentException>("route", () => new Path(route));
        }

        [Theory]
        [InlineData("/user")]
        [InlineData("/store/order")]
        [InlineData("pet")]
        [InlineData("store/order")]
        [InlineData("user/")]
        [InlineData("/store/order/")]
        public void Constructor_WithNonNullRoute__StoresRouteAsPath(string route)
        {
            var expectedRoute = route.AsPath();
            var path = new Path(route);

            Assert.Equal(expectedRoute, path.Route);
        }

        [Fact]
        public void AddOperation_WithNewOperation_AddsOperationDetailsToPath()
        {
            var path = new Path("/users");
            var operation = new Operation("get");
            
            path.AddOperation(operation);
            
            Assert.Contains("get", path.Keys);
        }

        [Fact]
        public void AddOperation_WithAlreadyStoredHttpMethod_Throws()
        {
            var path = new Path("/users");
            var getOperation = new Operation("get");
            path.AddOperation(getOperation);
            var secondGetOperation = new Operation("get");


            Assert.Throws<DuplicateOperationException>(() => path.AddOperation(secondGetOperation));
        }
    }
}
