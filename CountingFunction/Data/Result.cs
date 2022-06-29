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
    public class Result
    {
        private double _X { get; set; }

        public double X
        {
            get { return _X; }
            set
            {
                _X = value;
            }
        }

        private double _Y { get; set; }
        public double Y
        {
            get { return _Y; }
            set
            {
                _Y = value;
            }
        }

        private double _Fxy { get; set; }
        public double Fxy
        {
            get { return _Fxy; }
            set
            {
                _Fxy = value;
            }
        }

        public static ObservableCollection<Result> GetResults()
        {
            ObservableCollection<Result> result = new ObservableCollection<Result>();
            return result;
        }
    }
}
