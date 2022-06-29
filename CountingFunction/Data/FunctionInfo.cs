using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace CountingFunction
{
    public class FunctionInfo
    {
        private double _A { get; set; }
        /// <summary>
        /// Данное поле хранит информацию о значении а.
        /// </summary>
        public double A
        {
            get { return _A; }
            set
            {
                _A = value;
            }
        }

        private double _B { get; set; }
        /// <summary>
        /// Данное поле хранит информацию о значении b.
        /// </summary>
        public double B
        {
            get { return _B; }
            set
            {
                _B = value;
            }
        }

        private double[] _C { get; set; }
        /// <summary>
        /// Данное поле хранит информацию о значениях c для всего типа функции.
        /// </summary>
        public double[] C
        {
            get { return _C; }
            set
            {
                _C = value;
            }
        }
        private double _CurrentC { get; set; }
        /// <summary>
        /// Данное поле хранит информацию о значении с, выбранного на данный момент.
        /// </summary>
        public double CurrentC
        {
            get { return _CurrentC; }
            set
            {
                _CurrentC = value;
            }
        }

        private string _Function { get; set; }
        /// <summary>
        /// Данное поле хранит информацию об аналитическом виде функции.
        /// </summary>
        public string Function
        {
            get { return _Function; }
            set
            {
                _Function = value;
            }
        }
        private string _FunctionName { get; set; }
        /// <summary>
        /// Данное поле хранит информацию о названии функции.
        /// </summary>
        public string FunctionName
        {
            get { return _FunctionName; }
            set
            {
                _FunctionName = value;
            }
        }

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

        public static FunctionInfo[] GetFunctions()
        {
            FunctionInfo[] result = new FunctionInfo[]
            {
                new FunctionInfo() { _Function = "f(x,y) = ax¹+by⁰+c", _FunctionName = "Линейная", _A = 1, _B = 1, _C = new double[]{1, 2, 3, 4, 5 }, _CurrentC = 1 },
                new FunctionInfo() { _Function = "f(x,y) = ax²+by¹+c", _FunctionName = "Квадратичная", _A = 1, _B = 1, _C = new double[]{10, 20, 30, 40, 50 }, _CurrentC = 10},
                new FunctionInfo() { _Function = "f(x,y) = ax³+by²+c", _FunctionName = "Кубическая", _A = 1, _B = 1, _C = new double[]{100, 200, 300, 400, 500 }, _CurrentC = 100},
                new FunctionInfo() { _Function = "f(x,y) = ax⁴+by³+c", _FunctionName = "4-ой степени", _A = 1, _B = 1, _C = new double[]{1000, 2000, 3000, 4000, 5000 }, _CurrentC = 1000},
                new FunctionInfo() { _Function = "f(x,y) = ax⁵+by⁴+c", _FunctionName = "5-ой степени", _A = 1, _B = 1, _C = new double[]{10000, 20000, 30000, 40000, 50000 }, _CurrentC = 10000}
            };
            return result;
        }
    }
}
