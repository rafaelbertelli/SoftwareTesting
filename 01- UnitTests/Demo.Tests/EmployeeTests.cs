using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Demo.Tests
{
    public class EmployeeTests
    {
        [Fact]
        public void Employee_Name_ShouldNotBeNullOrEmpty()
        {
            // Arrange & Act
            var sut = new Employee("", 3500.00);

            // Assert
            Assert.False(string.IsNullOrEmpty(sut.Name));
        }

        [Fact]
        public void Employee_Nickname_ShouldBeEmpty()
        {
            // Arrange & Act
            var sut = new Employee("Glauberson", 3500.00);

            // Assert
            Assert.True(string.IsNullOrEmpty(sut.Nickname));
            Assert.Null(sut.Nickname);
        }

        [Fact]
        public void Employee_Name_ShouldBeDefaultName()
        {
            // Arrange & Act
            var sut = new Employee("", 1000);

            // Assert
            Assert.Equal(expected: "Fulano", actual: sut.Name);
        }

        
    }
}
