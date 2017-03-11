﻿using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MagicMoq.DAL;
using Moq;
using System.Collections.Generic;

namespace MagicMoq.Tests.DAL
{
    [TestClass]
    public class QuestionsTests
    {
        public Mock<Answers> mock_answers { get; set; }  // Can be public or private

        [TestInitialize]
        public void Setup()  // Name of this method does not matter
        {
            // Runs BEFORE every test
            mock_answers = new Mock<Answers>();
        }

        [TestCleanup]
        public void Cleanup()
        {
            // Runs AFTER every test
            mock_answers = null;
        }

        [TestMethod]
        public void EnsureICanCreateQuestionsInstance()
        {
            Questions questions = new Questions();
            Assert.IsNotNull(questions);
        }

        [TestMethod]
        public void EnsureICanCreateAnswersInstance()
        {
            Answers answers = new Answers();
            Assert.IsNotNull(answers);
        }

        [TestMethod]
        public void EnsureQuestionsReturnsAnswersInstance()
        {
            // Hint: Implement a Constructor (for Questions class)
            Questions questions = new Questions();

            Assert.IsNotNull(questions.Wand);
        }

        [TestMethod]
        public void EnsureQuestionsReturnsInjectedAnswersInstance()
        {

            // Hint 1: Create an instance of your Answers class
            Answers answers = new Answers();

            // Hint 2: Implement another Constructor (for Questions class)
            Questions questions = new Questions(answers);

            Assert.IsNotNull(questions.Wand);
        }

        [TestMethod]
        public void EnsureSayHelloReturnsHelloWorld()
        {
            // Arrange
            
            mock_answers.Setup(a => a.HelloWorld()).Returns("Hello World"); // Tells how to hijack method call; what pattern to look for and what to return
            
            // Add code that mocks the "HelloWorld" method response

            Questions questions = new Questions(mock_answers.Object); //Inject fake answers instance into Questions constructor

            // Act
            string expected_result = "Hello World";
            string actual_result = questions.SayHelloWorld();

            // Assert
            Assert.AreEqual(expected_result, actual_result);
        }

        [TestMethod]
        public void EnsureOneMinusOneReturnsZero()
        {
            // Arrange
            mock_answers.Setup(a => a.Zero()).Returns(0);

            // Add code that mocks the "Zero" method response

            Questions questions = new Questions(mock_answers.Object);

            // Act
            int expected_result = 0;
            int actual_result = questions.OneMinusOne();

            // Assert
            Assert.AreEqual(expected_result, actual_result);

            mock_answers.Verify(a => a.Zero());
        }

        [TestMethod]
        public void EnsureOnePlusOneReturnsTwo()
        {
            // Arrange
            mock_answers.Setup(a => a.One()).Returns(1);

            // Add code that mocks the "Two" method response

            Questions questions = new Questions(mock_answers.Object);

            // Act
            int expected_result = 2;
            int actual_result = questions.OnePlusOne();

            // Assert
            Assert.AreEqual(expected_result, actual_result);
        }

        [TestMethod]
        public void EnsureOnePlusTwoReturnsThree()
        {
            // Arrange
            mock_answers.Setup(a => a.One()).Returns(1);
            mock_answers.Setup(a => a.Two()).Returns(2);
            // Add code that mocks the "Three" method response
            Questions questions = new Questions(mock_answers.Object);

            // Act
            int expected_result = 3;
            int actual_result = questions.OnePlusTwo();

            // Assert
            Assert.AreEqual(expected_result, actual_result);
        }

        [TestMethod]
        public void EnsureThisReturnsTrue()
        {
            // Arrange
            mock_answers.Setup(a => a.True()).Returns(true);
            // Add code that mocks the "True" method response

            Questions questions = new Questions(mock_answers.Object);

            // Act
            bool expected_result = true;
            bool actual_result = questions.ReturnTrue();

            // Assert
            Assert.AreEqual(expected_result, actual_result);
        }

        [TestMethod]
        public void EnsureThisReturnsFalse()
        {
            // Arrange
            mock_answers.Setup(a => a.False()).Returns(false);
            // Add code that mocks the "False" method response
            Questions questions = new Questions(mock_answers.Object);

            // Act
            bool expected_result = false;
            bool actual_result = questions.ReturnFalse();

            // Assert
            Assert.AreEqual(expected_result, actual_result);
        }

        [TestMethod]
        public void EnsureSayNothingReturnsEmptyString()
        {
            // Arrange
            mock_answers.Setup(a => a.EmptyString()).Returns("");
            
            // Add code that mocks the "EmptyString" method response
            Questions questions = new Questions(mock_answers.Object);

            // Act
            string expected_result = "";
            string actual_result = questions.SayNothing();
            
            // Assert
            Assert.AreEqual(expected_result, actual_result);
        }

        [TestMethod]
        public void EnsureTwoPlusTwoReturnsFour()
        {
            // Arrange
            mock_answers.Setup(a => a.Two()).Returns(2);

            Questions questions = new Questions(mock_answers.Object);

            int expectedResult = 4;
            int actualResult = questions.TwoPlusTwo();

            Assert.AreEqual(expectedResult, actualResult);


        }

        [TestMethod]
        public void EnsureFourMinusTwoPlusOneReturnsThree()
        {
            // Arrange
            mock_answers.Setup(a => a.Four()).Returns(4);
            mock_answers.Setup(a => a.Two()).Returns(2);
            mock_answers.Setup(a => a.One()).Returns(1);

            Questions questions = new Questions(mock_answers.Object);

            int expectedResult = 3;
            int actualResult = questions.FourMinusTwoPlusOne();

            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestMethod]
        public void EnsureFourMinusTwoReturnsTwo()
        {
            // Write this test
            mock_answers.Setup(a => a.Four()).Returns(4);
            mock_answers.Setup(a => a.Two()).Returns(2);

            Questions questions = new Questions(mock_answers.Object);

            int expectedResult = 2;
            int actualResult = questions.FourMinusTwo();

            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestMethod]
        public void EnsureCountToFiveReturnsListOfFiveInts()
        {
            mock_answers.Setup(a => a.ListOfNInts(It.IsAny<int>())).Returns(new List<int> {1, 2, 3, 4, 5 });
            //More restrictive version
            // mock_answers.Setup(a => a.ListOfNInts(It.Is<int>(i => i == 5))).Returns(new List<int> {1, 2, 3, 4, 5 });

            Questions questions = new Questions(mock_answers.Object);

            var expectedResult = new List<int> { 1, 2, 3, 4, 5 };
            var actualResult = questions.CountToFive();

            CollectionAssert.AreEqual(expectedResult, actualResult);
        }

        [TestMethod]
        public void EnsureFirstThreeEvenIntsReturnsListOfThreeEvenInts()
        {
            // Write this test
            mock_answers.Setup(a => a.ListOfNInts(It.IsAny<int>())).Returns(new List<int> { 2, 4, 6 });
            //mock_answers.Setup(a => a.ListOfNInts(It.IsAny<int>()).Returns(new List<int> {1, 2, 3, 4, 5, 6};

            Questions questions = new Questions(mock_answers.Object);

            var expectedResult = new List<int> {2, 4, 6 };
            var actualResult = questions.FirstThreeEvenInts();

            CollectionAssert.AreEqual(expectedResult, actualResult);

        }

        [TestMethod]
        public void EnsureFirstThreeOddIntsReturnsListOfThreeOddInts()
        {
            // Write this test
            mock_answers.Setup(a => a.One()).Returns(1);
            mock_answers.Setup(a => a.Two()).Returns(2);
            mock_answers.Setup(a => a.Three()).Returns(3);
            //mock_answers.Setup(a => a.ListOfNInts(It.Is<int>(i => i == 10))).Returns(new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 });

            Questions questions = new Questions(mock_answers.Object);

            var expectedResult = new List<int> { 1, 3, 5 };
            var actualResult = questions.FirstThreeOddInts();

            CollectionAssert.AreEqual(expectedResult, actualResult);
        }

        [TestMethod]
        public void EnsureZeroPlusZeroReturnsZero()
        {
            // Write this test
            mock_answers.Setup(a => a.Zero()).Returns(0);

            Questions questions = new Questions(mock_answers.Object);

            int expectedResult = 0;
            int actualResult = questions.ZeroPlusZero();

            Assert.AreEqual(expectedResult, actualResult);

            mock_answers.Verify(a => a.Zero());
        }

        [TestMethod]
        public void EnsureFourPlusZeroReturnsFour()
        {
            // Write this test
            mock_answers.Setup(a => a.Four()).Returns(4);
            mock_answers.Setup(a => a.Zero()).Returns(0);

            Questions questions = new Questions(mock_answers.Object);

            int expectedResult = 4;
            int actualResult = questions.FourPlusZero();

            Assert.AreEqual(expectedResult, actualResult);

            mock_answers.Verify(a => a.Zero());
        }

        [TestMethod]
        public void EnsureTwoMinusZeroReturnsTwo()
        {
            // Write this test
            mock_answers.Setup(a => a.Two()).Returns(2);
            mock_answers.Setup(a => a.Zero()).Returns(0);

            Questions questions = new Questions(mock_answers.Object);

            int expectedResult = 2;
            int actualResult = questions.TwoMinusZero();

            Assert.AreEqual(expectedResult, actualResult);

            mock_answers.Verify(a => a.Zero());
        }

    }
}
