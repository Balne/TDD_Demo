
using FluentAssertions;
using System;
using TDDDemoConsole;
using Xunit;

namespace TTDDemoTests
{
    public class CalculatorTests
    {


        /* STEP 1
         * Create a simple method : int Add(string numbers)
         * Method should take upto two numbers in a string seperated by comma as input, should return sum of numbers 
         * for example inputs like "", "3", "2,4" should return 0, 3, 6 respectively
         */
        [Theory]
        [InlineData("", 0)]
        [InlineData("2", 2)]
        [InlineData("3,5", 8)]
        public void Add_UptoTwoNumbers_ForValidString(string numbers, int sum)
        {
            //Arrange
            var sut = new Calculator();

            //Act
            var result = sut.Add_Step1(numbers);

            //Assert
            result.Should().Be(sum);
        }

        /* STEP 2
         * To handle unkown amount of numbers
         */
        [Theory]
        [InlineData("", 0)]
        [InlineData("2", 2)]
        [InlineData("3,5", 8)]
        [InlineData("3,5,3,4", 15)]
        [InlineData("13,15,13,14", 55)]
        public void Add_UptoAnyNumbers_ForValidString(string numbers, int sum)
        {
            //Arrange
            var sut = new Calculator();

            //Act
            var result = sut.Add_Step2(numbers);

            //Assert
            result.Should().Be(sum);
        }


        /*STEP 3
         * Allow different delimiters (, |)
         * for example input like "2,6", "3|6", "2,3|6" should return 8, 9, 11
         */
        [Theory]
        [InlineData("", 0)]
        [InlineData("2", 2)]
        [InlineData("3,5", 8)]
        [InlineData("3,5,3,4", 15)]
        [InlineData("13,15,13,14", 55)]
        [InlineData("3|6", 9)]
        [InlineData("2,3|6", 11)]
        public void Add_UptoAnyNumbers_AnyDelimiters_ForValidString(string numbers, int sum)
        {
            //Arrange
            var sut = new Calculator();

            //Act
            var result = sut.Add_Step3(numbers);

            //Assert
            result.Should().Be(sum);
        }

        /*STEP 4
         * Invalid string throws exception
         * for example input with negative numbers like "-2,6", "-3|-6", should throw exception "negatives not allowed" and display all negative numbers in exception message
         */
        [Theory]
        [InlineData("-2,6", "-2")]
        [InlineData("-3|-6,1|4,-8", "-3,-6,-8")]
        public void Add_ShouldThrowException_ForInvalidString(string numbers, string negativeNumbers)
        {
            //Arrange
            var sut = new Calculator();

            //Act
            Action action = () => sut.Add_Step3(numbers);

            //Assert
            action.Should().Throw<Exception>()
                .WithMessage($"Negatives not allowed: {negativeNumbers}");
        }
    }
}
