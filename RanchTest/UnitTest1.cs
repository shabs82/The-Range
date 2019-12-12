using System;
using Xunit;

namespace RanchTest
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {
            var expect = false;
            var actual = false;
            Assert.Equal(expect, actual);
        }
    }
}
