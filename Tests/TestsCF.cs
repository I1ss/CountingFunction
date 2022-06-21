using NUnit.Framework;

namespace Tests
{
    public class Tests
    {
        [Test]
        public void Count_Line_a5_b5_c5_x5_y5_30returned()
        {
            // arrange
            CountingFunction.FunctionInfo Temp = new CountingFunction.FunctionInfo()
            {
                A = 5,
                B = 5,
                C = new[] { 5.0 },
                CurrentC = 5,
                FunctionName = "Линейная"
            };
            CountingFunction.Result TempR = new CountingFunction.Result() { X = 5, Y = 5 };
            double Fxy = 35;

            // act
            CountingFunction.FunctionsViewModel.Count(Temp, TempR);

            // assert
            Assert.AreEqual(Fxy, TempR.Fxy);
        }

        [Test]
        public void Count_Quadratic_a5_b5_c5_x5_y5_200returned()
        {
            // arrange
            CountingFunction.FunctionInfo Temp = new CountingFunction.FunctionInfo()
            {
                A = 5,
                B = 5,
                C = new[] { 50.0 },
                CurrentC = 50,
                FunctionName = "Квадратичная"
            };
            CountingFunction.Result TempR = new CountingFunction.Result() { X = 5, Y = 5 };
            double Fxy = 200;

            // act
            CountingFunction.FunctionsViewModel.Count(Temp, TempR);

            // assert
            Assert.AreEqual(Fxy, TempR.Fxy);
        }

        [Test]
        public void Count_Cubic_a5_b5_c5_x5_y5_1250returned()
        {
            // arrange
            CountingFunction.FunctionInfo Temp = new CountingFunction.FunctionInfo()
            {
                A = 5,
                B = 5,
                C = new[] { 500.0 },
                CurrentC = 500,
                FunctionName = "Кубическая"
            };
            CountingFunction.Result TempR = new CountingFunction.Result() { X = 5, Y = 5 };
            double Fxy = 1250;

            // act
            CountingFunction.FunctionsViewModel.Count(Temp, TempR);

            // assert
            Assert.AreEqual(Fxy, TempR.Fxy);
        }

        [Test]
        public void Count_4th_a5_b5_c5_x5_y5_8750returned()
        {
            // arrange
            CountingFunction.FunctionInfo Temp = new CountingFunction.FunctionInfo()
            {
                A = 5,
                B = 5,
                C = new[] { 5000.0 },
                CurrentC = 5000,
                FunctionName = "4-ой степени"
            };
            CountingFunction.Result TempR = new CountingFunction.Result() { X = 5, Y = 5 };
            double Fxy = 8750;

            // act
            CountingFunction.FunctionsViewModel.Count(Temp, TempR);

            // assert
            Assert.AreEqual(Fxy, TempR.Fxy);
        }

        [Test]
        public void Count_5th_a5_b5_c5_x5_y5_68750returned()
        {
            // arrange
            CountingFunction.FunctionInfo Temp = new CountingFunction.FunctionInfo()
            {
                A = 5,
                B = 5,
                C = new[] { 50000.0 },
                CurrentC = 50000,
                FunctionName = "5-ой степени"
            };
            CountingFunction.Result TempR = new CountingFunction.Result() { X = 5, Y = 5 };
            double Fxy = 68750;

            // act
            CountingFunction.FunctionsViewModel.Count(Temp, TempR);

            // assert
            Assert.AreEqual(Fxy, TempR.Fxy);
        }

        [Test]
        public void Count_Line_amin5_bmin5_c5_xmin5_ymin5_25returned()
        {
            // arrange
            CountingFunction.FunctionInfo Temp = new CountingFunction.FunctionInfo()
            {
                A = -5,
                B = -5,
                C = new[] { 5.0 },
                CurrentC = 5,
                FunctionName = "Линейная"
            };
            CountingFunction.Result TempR = new CountingFunction.Result() { X = -5, Y = -5 };
            double Fxy = 25;

            // act
            CountingFunction.FunctionsViewModel.Count(Temp, TempR);

            // assert
            Assert.AreEqual(Fxy, TempR.Fxy);
        }

        [Test]
        public void Count_Quadratic_amin5_bmin5_c50_xmin5_ymin5_min50returned()
        {
            // arrange
            CountingFunction.FunctionInfo Temp = new CountingFunction.FunctionInfo()
            {
                A = -5,
                B = -5,
                C = new[] { 50.0 },
                CurrentC = 50,
                FunctionName = "Квадратичная"
            };
            CountingFunction.Result TempR = new CountingFunction.Result() { X = -5, Y = -5 };
            double Fxy = -50;

            // act
            CountingFunction.FunctionsViewModel.Count(Temp, TempR);

            // assert
            Assert.AreEqual(Fxy, TempR.Fxy);
        }

        [Test]
        public void Count_Cubic_amin5_bmin5_c50_xmin5_ymin5_1000returned()
        {
            // arrange
            CountingFunction.FunctionInfo Temp = new CountingFunction.FunctionInfo()
            {
                A = -5,
                B = -5,
                C = new[] { 500.0 },
                CurrentC = 500,
                FunctionName = "Кубическая"
            };
            CountingFunction.Result TempR = new CountingFunction.Result() { X = -5, Y = -5 };
            double Fxy = 1000;

            // act
            CountingFunction.FunctionsViewModel.Count(Temp, TempR);

            // assert
            Assert.AreEqual(Fxy, TempR.Fxy);
        }

        [Test]
        public void Count_4th_amin5_bmin5_c50_xmin5_ymin5_2500returned()
        {
            // arrange
            CountingFunction.FunctionInfo Temp = new CountingFunction.FunctionInfo()
            {
                A = -5,
                B = -5,
                C = new[] { 5000.0 },
                CurrentC = 5000,
                FunctionName = "4-ой степени"
            };
            CountingFunction.Result TempR = new CountingFunction.Result() { X = -5, Y = -5 };
            double Fxy = 2500;

            // act
            CountingFunction.FunctionsViewModel.Count(Temp, TempR);

            // assert
            Assert.AreEqual(Fxy, TempR.Fxy);
        }

        [Test]
        public void Count_5th_amin5_bmin5_c50_xmin5_ymin5_min50returned()
        {
            // arrange
            CountingFunction.FunctionInfo Temp = new CountingFunction.FunctionInfo()
            {
                A = -5,
                B = -5,
                C = new[] { 50000.0 },
                CurrentC = 50000,
                FunctionName = "5-ой степени"
            };
            CountingFunction.Result TempR = new CountingFunction.Result() { X = -5, Y = -5 };
            double Fxy = 62500;

            // act
            CountingFunction.FunctionsViewModel.Count(Temp, TempR);

            // assert
            Assert.AreEqual(Fxy, TempR.Fxy);
        }
    }
}