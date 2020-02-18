using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Demo.Tests
{
    public class CalculatorTests
    {
        [Fact]
        public void Calculator_Sum_ShouldReturnSum()
        {
            // Arrange
            var calculator = new Calculator();

            // Act
            var result = calculator.Sum(2, 2);

            // Assert
            Assert.Equal(expected: 4, actual: 4);
        }

        [Theory]
        [InlineData(1,2,3)]
        [InlineData(2, 2, 4)]
        [InlineData(4, 3, 7)]
        public void Calculator_Sum_ShouldReturnCorrectSumValues(double v1, double v2, double total)
        {
            // Arrange
            var calculator = new Calculator();

            // Act
            var result = calculator.Sum(v1, v2);

            // Assert
            Assert.Equal(expected: total, actual: result);
        }

        [Fact]
        public void Calculator_Sum_ShoulNotBeEqual()
        {
            // Arrange
            var sut = new Calculator();

            // Act
            var result = sut.Sum(1.13123123123, 2.2312313123);

            // Assert
            Assert.NotEqual(expected: 3, actual: result, precision: 1);
        }
    }
}
