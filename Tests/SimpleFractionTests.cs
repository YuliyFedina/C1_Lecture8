using System;
using Ex1;
using NUnit.Framework;

namespace Tests
{
    public class SimpleFractionTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void SumTest()
        {
            //Arrange
            var left = new SimpleFraction(1, 2);
            var right = new SimpleFraction(1, 2);
            var expectedResult = new SimpleFraction(1, 1);

            //Act
            var result = left + right;

            //Assert
            Assert.AreEqual(expectedResult, result);
        }

        [Test]
        public void MakeSimpleContractedFractionTest()
        {
            //Arrange
            var fraction = new SimpleFraction(3, 6);
            var expectedResult = new SimpleFraction(1, 2);

            //Act

            //Assert
            Assert.AreEqual(expectedResult, fraction);
        }

        [Test]
        public void MakeSimpleNegativeNumeratorAndDenominatorTest()
        {
            //Arrange
            var fraction = new SimpleFraction(-1, -2);
            var expectedResult = new SimpleFraction(1, 2);

            //Act

            //Assert
            Assert.AreEqual(expectedResult, fraction);
        }

        [Test]
        public void MakeSimpleNegativeDenominatorTest()
        {
            //Arrange
            var fraction = new SimpleFraction(1, -2);
            var expectedResult = new SimpleFraction(-1, 2);

            //Act

            //Assert
            Assert.AreEqual(expectedResult, fraction);
        }

        [Test]
        public void AddTest()
        {
            //Arrange
            var fraction = new SimpleFraction(1, 2);
            var addFraction = new SimpleFraction(1, 2);
            var expectedResult = new SimpleFraction(1, 1);

            //Act
            var result = fraction.Add(addFraction);

            //Assert
            Assert.AreEqual(expectedResult, result);
        }

        [Test]
        public void SubtractionTest()
        {
            //Arrange
            var left = new SimpleFraction(1, 1);
            var right = new SimpleFraction(1, 2);
            var expectedResult = new SimpleFraction(1, 2);

            //Act
            var result = left - right;

            //Assert
            Assert.AreEqual(expectedResult, result);
        }

        [Test]
        public void MultiplicationTest()
        {
            //Arrange
            var left = new SimpleFraction(1, 2);
            var right = new SimpleFraction(1, 2);
            var expectedResult = new SimpleFraction(1, 4);

            //Act
            var result = left * right;

            //Assert
            Assert.AreEqual(expectedResult, result);
        }

        [Test]
        public void SegmentationTest()
        {
            //Arrange
            var left = new SimpleFraction(1, 2);
            var right = new SimpleFraction(2, 1);
            var expectedResult = new SimpleFraction(1, 4);

            //Act
            var result = left / right;

            //Assert
            Assert.AreEqual(expectedResult, result);
        }

        [Test]
        public void CompareEqualsTest()
        {
            //Arrange
            var firstFraction = new SimpleFraction(1, 2);
            var secondFraction = new SimpleFraction(1, 2);
            var expectedResult = 0;

            //Act
            var result = firstFraction.CompareTo(secondFraction);

            //Assert
            Assert.AreEqual(expectedResult, result);
        }

        [Test]
        public void CompareNotEqualsTest()
        {
            //Arrange
            var firstFraction = new SimpleFraction(1, 2);
            var secondFraction = new SimpleFraction(1, 4);
            var expectedResult = 1;

            //Act
            var result = firstFraction.CompareTo(secondFraction);

            //Assert
            Assert.AreEqual(expectedResult, result);
        }

        [Test]
        public void ZeroDenumeratorTest()
        {
            try
            {
                SimpleFraction left = new SimpleFraction(1, 0);
                Assert.Fail();
            }
            catch (DivideByZeroException)
            {

            }
        }
    }
}