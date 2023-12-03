using ConvertTypesUtil;
using FluentAssertions;

namespace ConvertUnitsTests
{
    public class UnitTest1
    {
        [Theory]
        [InlineData("1234567", 1234567)]
        //[InlineData("1 234 567", 1234567)]
        [InlineData("1234567,1234567", 1234567.1234567)]
        [InlineData("1234567.1234567", 1234567.1234567)]
        [InlineData("1 234 567,1234567", 1234567.1234567)]
        [InlineData("1 234 567.1234567", 1234567.1234567)]
        public void ToDecimal_CorrectValue_Expected(string source, decimal expected)
        {
            var act = source.ToDecimal();

            act.Should().Be(expected);
        }

        [Theory]
        [InlineData(null)]
        [InlineData("string")]
        [InlineData("123 123,123.123")]

        public void ToDecimal_InCorrectValue_Exception(string source)
        {
            Action act = () => source.ToDecimal();

            act.Should().Throw<ArgumentException>();
        }
    }
}