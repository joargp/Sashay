using System;
using Sashay.Core.OasGen.AzureFunctions.Extensions;
using Xunit;

namespace Sashay.Core.OasGen.Tests.AzureFunctions.StringExtensionTests
{
    public class ContainsParameter
    {
        [Theory]
        [InlineData("{parameter}")]
        [InlineData("{myparameter")]
        [InlineData("myparameter}")]
        [InlineData("/route")]
        [InlineData("/route/{differentParameter}/")]
        [InlineData("{myparameteralpha]}")]
        [InlineData("/{myparameteralpha}")]
        public void WithoutParameterInString_ReturnsFalse(string route)
        {
            Assert.False(route.ContainsParameter("myParameter"));
        }

        [Fact]
        public void WithNullString_ThrowsArgumentNullException()
        {
            string nullString = null;
            Assert.Throws<ArgumentNullException>(() => nullString.ContainsParameter("myParameter"));
        }

        [Fact]
        public void WithNullParameter_ThrowsArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() => "someString".ContainsParameter(null));
        }

        [Theory]
        [InlineData("/{myparameter}")]
        [InlineData("/{myparameter:alpha}")]
        [InlineData("/{myparameter:delta}")]
        [InlineData("/{myparameter:beta}")]
        [InlineData("/someRoute/{myparameter}")]
        [InlineData("someRoute/{myparameter}")]
        public void WithParameterInString_ReturnsTrue(string route)
        {
            Assert.True(route.ContainsParameter("myParameter"));
        }
    }
}