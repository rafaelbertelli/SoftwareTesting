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

        [Theory]
        [InlineData(500.00)]
        [InlineData(1500.00)]
        [InlineData(1999.99)]
        [InlineData(2000.00)]
        [InlineData(7500.00)]
        [InlineData(7999.99)]
        [InlineData(8000.00)]
        [InlineData(8500.00)]
        [InlineData(15000.00)]
        public void Employee_Payment_ShouldRespectSeniority(double payment)
        {
            // Arrange & Act
            var sut = new Employee("Rafael", payment);

            // Assert
            if (sut.Seniority == Seniority.Junior)
                Assert.InRange(actual: sut.Payment, low: 500, high: 1999.99);

            if (sut.Seniority == Seniority.Specialist)
                Assert.InRange(actual: sut.Payment, low: 2000, high: 7999.99);

            if (sut.Seniority == Seniority.Senior)
                Assert.InRange(actual: sut.Payment, low: 8000, high: double.MaxValue);

            Assert.NotInRange(actual: sut.Payment, low: 0, high: 499.99);
        }

        [Fact]
        public void Employee_Payment_ShouldReturnErrorOnLessThanAllowedPayments()
        {
            // Arrange & Act & Assert
            var sut =
                Assert.Throws<Exception>(testCode: () => EmployeeFactory.Create("Rafa", 499.99));

            Assert.Equal(expected: "Less than allowed payment", actual: sut.Message);


        }

        [Fact]
        public void EmployeeFactory_Create_ShouldReturnTypeEmployee()
        {
            // Arrange & Act
            var employee = EmployeeFactory.Create("Borgera", 2000);

            // Assert
            Assert.IsType<Employee>(employee);
        }

        [Fact]
        public void EmployeeFactory_Create_ShouldReturnDerivatedTypeFromPerson()
        {
            // Arrange & Act
            var employee = EmployeeFactory.Create("Borgera", 2000);

            // Assert
            Assert.IsAssignableFrom<Person>(employee);
        }

        [Fact]
        public void Employee_Skills_ShouldNotHaveEmptySkills()
        {
            // Arrange & Act
            var employee = EmployeeFactory.Create("Borgera", 2000);

            // Assert
            Assert.All(
                collection: employee.Skills,
                action: skill => Assert.False(string.IsNullOrWhiteSpace(skill))
            );
        }

        [Fact]
        public void Employee_Skill_JuniorSeniorityShouldHaveBasicSkills()
        {
            // Arrange & Act
            var employee = EmployeeFactory.Create("Borgera", 1000);

            // Assert
            Assert.Contains(expected: "OOP", collection: employee.Skills);
        }

        [Fact]
        public void Employee_Skill_JuniorSeniorityShouldNotHaveAdvancedSkills()
        {
            // Arrange & Act
            var employee = EmployeeFactory.Create("Borgera", 1000);

            // Assert
            Assert.DoesNotContain(expected: "Tests", collection: employee.Skills);
        }

        [Fact]
        public void Employee_Skill_SeniorSeniorityShouldHaveAllSkills()
        {
            // Arrange & Act
            var employee = EmployeeFactory.Create("Borgera", 15000);

            var skills = new[]
            {
                "Programming logic",
                "OOP",
                "Tests",
                "Microservices"
            };

            // Assert
            Assert.Equal(expected: skills, actual: employee.Skills);
        }
    }
}
