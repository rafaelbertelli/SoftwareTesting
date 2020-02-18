using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Demo.Tests
{
    public class StringToolsTests
    {
        [Theory]
        [InlineData("Rafael", "Borges", "Rafael Borges")]
        [InlineData("Monaliza", "Souza", "Monaliza Souza")]
        [InlineData("Andressa", "Godoy", "Andressa Godoy")]
        public void StringTools_Join_ShouldReturnNameAndLastname(string name, string lastname, string fullname)
        {
            // Arrange
            var sut = new StringTools();

            // Act
            var result = sut.Join(name, lastname);

            // Assert
            Assert.Equal(expected: fullname, actual: result);
        }

        [Fact]
        public void StringTools_Join_ShouldIgnoreCase()
        {
            // Arrange
            var sut = new StringTools();

            // Act
            var result = sut.Join(name: "Rafael", lastname: "Borges");

            // Assert
            Assert.Equal(expected: "RAFAEL BORGES", actual: result, ignoreCase: true);
        }

        [Fact]
        public void StringTools_Join_ShouldContainPartialString()
        {
            // Arrange
            var sut = new StringTools();

            // Act
            var result = sut.Join(name: "Rafael", lastname: "Borges");

            // Assert
            Assert.Contains(expectedSubstring: "el Borg", actualString: result);
        }

        [Fact]
        public void StringTools_Join_ShouldStartsWith()
        {
            // Arrange
            var sut = new StringTools();

            // Act
            var result = sut.Join(name: "Rafael", lastname: "Borges");

            // Assert
            Assert.StartsWith(expectedStartString: "Rafa", actualString: result);
        }

        [Fact]
        public void StringTools_Join_ShouldEndsWith()
        {
            // Arrange
            var sut = new StringTools();

            // Act
            var result = sut.Join(name: "Rafael", lastname: "Borges");

            // Assert
            Assert.EndsWith(expectedEndString: "ges", actualString: result);
        }

        [Fact]
        public void StringTools_Join_ValidadeRegex()
        {
            // Arrange
            var sut = new StringTools();

            // Act
            var result = sut.Join(name: "Rafael", lastname: "Borges");

            // Assert
            Assert.Matches(expectedRegexPattern: "[A-Z]{1}[a-z]+ [A-Z]{1}[a-z]+", actualString: result);
        }
    }
}
