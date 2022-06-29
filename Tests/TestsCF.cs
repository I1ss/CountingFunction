using NUnit.Framework;
using CountingFunction;

namespace CountingFunctionTests
{
    public class Tests
    {
        [Test]
        public void TestCountLine1()
        {
            // Arrange
            FunctionInfo templateFunctionType = new FunctionInfo()
            {
                A = 5,
                B = 5,
                C = new[] { 5.0 },
                CurrentC = 5,
                FunctionName = "Линейная"
            };
            Result templateResult = new Result() { X = 5, Y = 5 };
            double fxy = 35;

            // Act
            templateFunctionType.Count(templateResult);

            // Assert
            Assert.AreEqual(fxy, templateResult.Fxy);
        }
        [Test]
        public void TestCountLine2()
        {
            // Arrange
            FunctionInfo templateFunctionType = new FunctionInfo()
            {
                A = -5,
                B = -5,
                C = new[] { 5.0 },
                CurrentC = 5,
                FunctionName = "Линейная"
            };
            Result templateResult = new Result() { X = -5, Y = -5 };
            double fxy = 25;

            // Act
            templateFunctionType.Count(templateResult);

            // Assert
            Assert.AreEqual(fxy, templateResult.Fxy);
        }

        [Test]
        public void TestCountQuadratic1()
        {
            // Arrange
            FunctionInfo templateFunctionType = new FunctionInfo()
            {
                A = 5,
                B = 5,
                C = new[] { 50.0 },
                CurrentC = 50,
                FunctionName = "Квадратичная"
            };
            Result templateResult = new Result() { X = 5, Y = 5 };
            double fxy = 200;

            // Act
            templateFunctionType.Count(templateResult);

            // Assert
            Assert.AreEqual(fxy, templateResult.Fxy);
        }
        [Test]
        public void TestCountQuadratic2()
        {
            // Arrange
            FunctionInfo templateFunctionType = new FunctionInfo()
            {
                A = -5,
                B = -5,
                C = new[] { 50.0 },
                CurrentC = 50,
                FunctionName = "Квадратичная"
            };
            Result templateResult = new Result() { X = -5, Y = -5 };
            double fxy = -50;

            // Act
            templateFunctionType.Count(templateResult);

            // Assert
            Assert.AreEqual(fxy, templateResult.Fxy);
        }

        [Test]
        public void TestCountCubic1()
        {
            // Arrange
            FunctionInfo templateFunctionType = new FunctionInfo()
            {
                A = 5,
                B = 5,
                C = new[] { 500.0 },
                CurrentC = 500,
                FunctionName = "Кубическая"
            };
            Result templateResult = new Result() { X = 5, Y = 5 };
            double fxy = 1250;

            // Act
            templateFunctionType.Count(templateResult);

            // Assert
            Assert.AreEqual(fxy, templateResult.Fxy);
        }
        [Test]
        public void TestCountCubic2()
        {
            // Arrange
            FunctionInfo templateFunctionType = new FunctionInfo()
            {
                A = -5,
                B = -5,
                C = new[] { 500.0 },
                CurrentC = 500,
                FunctionName = "Кубическая"
            };
            Result templateResult = new Result() { X = -5, Y = -5 };
            double fxy = 1000;

            // Act
            templateFunctionType.Count(templateResult);

            // Assert
            Assert.AreEqual(fxy, templateResult.Fxy);
        }

        [Test]
        public void TestCount4th1()
        {
            // Arrange
            FunctionInfo templateFunctionType = new FunctionInfo()
            {
                A = 5,
                B = 5,
                C = new[] { 5000.0 },
                CurrentC = 5000,
                FunctionName = "4-ой степени"
            };
            Result templateResult = new Result() { X = 5, Y = 5 };
            double fxy = 8750;

            // Act
            templateFunctionType.Count(templateResult);

            // Assert
            Assert.AreEqual(fxy, templateResult.Fxy);
        }
        [Test]
        public void TestCount4th2()
        {
            // Arrange
            FunctionInfo templateFunctionType = new FunctionInfo()
            {
                A = -5,
                B = -5,
                C = new[] { 5000.0 },
                CurrentC = 5000,
                FunctionName = "4-ой степени"
            };
            Result templateResult = new Result() { X = -5, Y = -5 };
            double fxy = 2500;

            // Act
            templateFunctionType.Count(templateResult);

            // Assert
            Assert.AreEqual(fxy, templateResult.Fxy);
        }
        [Test]
        public void TestCount5th1()
        {
            // Arrange
            FunctionInfo templateFunctionType = new FunctionInfo()
            {
                A = 5,
                B = 5,
                C = new[] { 50000.0 },
                CurrentC = 50000,
                FunctionName = "5-ой степени"
            };
            Result templateResult = new Result() { X = 5, Y = 5 };
            double fxy = 68750;

            // Act
            templateFunctionType.Count(templateResult);

            // Assert
            Assert.AreEqual(fxy, templateResult.Fxy);
        }
        [Test]
        public void TestCount5th2()
        {
            // Arrange
            FunctionInfo templateFunctionType = new FunctionInfo()
            {
                A = -5,
                B = -5,
                C = new[] { 50000.0 },
                CurrentC = 50000,
                FunctionName = "5-ой степени"
            };
            Result templateResult = new Result() { X = -5, Y = -5 };
            double fxy = 62500;

            // Act
            templateFunctionType.Count(templateResult);

            // Assert
            Assert.AreEqual(fxy, templateResult.Fxy);
        }
    }
}