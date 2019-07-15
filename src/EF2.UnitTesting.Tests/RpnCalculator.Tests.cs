using System;
using Xunit;
using FluentAssertions;

namespace EF2.UnitTesting.Tests
{
    public class RpnCalculatorTests
    {
        private RpnCalculator calc;

        public RpnCalculatorTests()
        {
            // This constructor is called before every test is executed
            calc = new RpnCalculator();
        }

        [Fact]
        public void Result_EmptyCalc_ShouldReturnZero()
        {
            double result = calc.Result();

            result.Should().Be(0);
        }

        [Fact]
        public void Push_EmptyCalc_ShouldWork()
        {
            calc.Push(0d);
        }

        [Theory]
        [InlineData(0, 0)]
        [InlineData(1, 1)]
        public void Result_WithPushedValue_ShouldReturnSameValue(double v, double expectedValue)
        {
            calc.Push(v);

            double result = calc.Result();

            result.Should().Be(expectedValue);
        }

        [Fact]
        public void Stack_EmptyCalc_ShouldReturnEmtpyArray()
        {
            double[] result = calc.Stack();

            result.Should().BeEmpty();
        }

        [Theory]
        [InlineData(1, 2, 3, 1, 2, 3)]
        [InlineData(4, 5, 6, 4, 5, 6)]
        [InlineData(7, 8, 9, 7, 8, 9)]
        public void Stack_PushedValues_ShouldReturnAnArrayWithThePushedValues(
            double v1, double v2, double v3,
            double expectedV1, double expectedV2, double expectedV3)
        {
            calc.Push(v1);
            calc.Push(v2);
            calc.Push(v3);

            double[] result = calc.Stack();

            result.Should().BeEquivalentTo(expectedV1, expectedV2, expectedV3);
        }

        [Fact]
        public void Pop_WithPushedValue_ShouldDecrementStackSizeByOne()
        {
            calc.Push(1);
            calc.Push(2);

            calc.Pop();

            var stackLength = calc.Stack().Length;
            stackLength.Should().Be(1);
        }

        [Fact]
        public void Pop_WithEmptyCalc_ShouldThrowException()
        {
            Action act = () => calc.Pop();

            act.Should().Throw<InvalidOperationException>();
        }

        [Fact]
        public void Clear_WithPushedValues_ShouldResetStackToEmpty()
        {
            calc.Push(1);
            calc.Push(2);

            calc.Clear();

            calc.Stack().Should().BeEmpty();
        }
        
        [Theory]
        [InlineData(1, 2, 3)]
        [InlineData(-1, -2, -3)]
        [InlineData(0, 0, 0)]
        public void Add_WithTwoPushedValues_ShouldCalculateSum(double v1, double v2, double expectedResult)
        {
            calc.Push(v1);
            calc.Push(v2);
            
            calc.Add();

            calc.Result().Should().Be(expectedResult);
        }

        [Theory]
        [InlineData(2, 1, 1)]
        [InlineData(10, 20, -10)]
        [InlineData(5, 0, 5)]
        public void Sub_WithTwoPushedValues_ShouldCalculateDifference(double v1, double v2, double expectedResult)
        {
            calc.Push(v1);
            calc.Push(v2);
            
            calc.Sub();

            calc.Result().Should().Be(expectedResult);
        }

        [Theory]
        [InlineData(2, 2, 4)]
        [InlineData(0, 5, 0)]
        [InlineData(-5, -5, 25)]
        public void Mul_WithTwoPushedValues_ShouldCalculateProduct(double v1, double v2, double expectedResult)
        {
            calc.Push(v1);
            calc.Push(v2);
            
            calc.Mul();

            calc.Result().Should().Be(expectedResult);
        }

        [Theory]
        [InlineData(2, 2, 1)]
        [InlineData(9, 2, 4.5)]
        [InlineData(-5, 2, -2.5)]
        public void Div_WithTwoPushedValues_ShouldCalculateQuotient(double v1, double v2, double expectedResult)
        {
            calc.Push(v1);
            calc.Push(v2);
            
            calc.Div();

            calc.Result().Should().Be(expectedResult);
        }

        [Theory]
        [InlineData(100, 10)]
        [InlineData(9, 3)]
        [InlineData(0, 0)]
        public void Sqrt_SinglePushedValue_ShouldCalculateSquareRoot(double v, double expectedResult)
        {
            calc.Push(v);

            calc.Sqrt();

            calc.Result().Should().Be(expectedResult);
        }
    }
}
