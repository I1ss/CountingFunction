using System;

namespace CountingFunction
{
    public class FunctionInfo
    {
        #region Properties
        private double _a { get; set; }
        /// <summary>
        /// Данное поле хранит информацию о значении а.
        /// </summary>
        public double A
        {
            get { return _a; }
            set
            {
                _a = value;
            }
        }

        private double _b { get; set; }
        /// <summary>
        /// Данное поле хранит информацию о значении b.
        /// </summary>
        public double B
        {
            get { return _b; }
            set
            {
                _b = value;
            }
        }

        private double[] _c { get; set; }
        /// <summary>
        /// Данное поле хранит информацию о значениях c для всего типа функции.
        /// </summary>
        public double[] C
        {
            get { return _c; }
            set
            {
                _c = value;
            }
        }
        private double _currentC { get; set; }
        /// <summary>
        /// Данное поле хранит информацию о значении с, выбранного на данный момент.
        /// </summary>
        public double CurrentC
        {
            get { return _currentC; }
            set
            {
                _currentC = value;
            }
        }

        private string _function { get; set; }
        /// <summary>
        /// Данное поле хранит информацию об аналитическом виде функции.
        /// </summary>
        public string Function
        {
            get { return _function; }
            set
            {
                _function = value;
            }
        }
        private string _functionName { get; set; }
        /// <summary>
        /// Данное поле хранит информацию о названии функции.
        /// </summary>
        public string FunctionName
        {
            get { return _functionName; }
            set
            {
                _functionName = value;
            }
        }

        #endregion

        #region Methods

        /// <summary>
        /// Данная функция подсчитывает значение f(x,y) нашей функции.
        /// </summary>
        /// <param name="table">Структура, содержащая значения x, y функции и f(x,y), куда записывается результат</param>
        /// <returns></returns>
        public double Count(Result table)
        {
            if (this == null || table == null)
            {
                return 0;
            }
            Console.WriteLine("StartCount");
            switch (FunctionName)
            {
                case ("Линейная"):
                    table.Fxy = A * table.X + B * Math.Pow(table.Y, 0) + CurrentC;
                    break;
                case ("Квадратичная"):
                    table.Fxy = A * Math.Pow(table.X, 2) + B * Math.Pow(table.Y, 1) + CurrentC;
                    break;
                case ("Кубическая"):
                    table.Fxy = A * Math.Pow(table.X, 3) + B * Math.Pow(table.Y, 2) + CurrentC;
                    break;
                case ("4-ой степени"):
                    table.Fxy = A * Math.Pow(table.X, 4) + B * Math.Pow(table.Y, 3) + CurrentC;
                    break;
                case ("5-ой степени"):
                    table.Fxy = A * Math.Pow(table.X, 5) + B * Math.Pow(table.Y, 4) + CurrentC;
                    break;
                default:
                    break;
            }
            return table.Fxy;
        }
        /// <summary>
        /// Данная функция возвращает заданные по условию функции и их значения по умолчанию.
        /// </summary>
        /// <returns></returns>
        public static FunctionInfo[] GetFunctions()
        {
            FunctionInfo[] result = new FunctionInfo[]
            {
                new FunctionInfo() { _function = "f(x,y) = ax¹+by⁰+c", _functionName = "Линейная", _a = 1, _b = 1, _c = new double[]{1, 2, 3, 4, 5 }, _currentC = 1 },
                new FunctionInfo() { _function = "f(x,y) = ax²+by¹+c", _functionName = "Квадратичная", _a = 1, _b = 1, _c = new double[]{10, 20, 30, 40, 50 }, _currentC = 10},
                new FunctionInfo() { _function = "f(x,y) = ax³+by²+c", _functionName = "Кубическая", _a = 1, _b = 1, _c = new double[]{100, 200, 300, 400, 500 }, _currentC = 100},
                new FunctionInfo() { _function = "f(x,y) = ax⁴+by³+c", _functionName = "4-ой степени", _a = 1, _b = 1, _c = new double[]{1000, 2000, 3000, 4000, 5000 }, _currentC = 1000},
                new FunctionInfo() { _function = "f(x,y) = ax⁵+by⁴+c", _functionName = "5-ой степени", _a = 1, _b = 1, _c = new double[]{10000, 20000, 30000, 40000, 50000 }, _currentC = 10000}
            };
            return result;
        }

        #endregion
    }
}
