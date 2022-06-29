using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Data;

namespace CountingFunction
{
    public class FunctionInfoViewModel : DependencyObject, INotifyPropertyChanged
    {
        private ResultViewModel _result = new ResultViewModel();
        public ResultViewModel Result
        {
            get { return _result; }
            set
            {
                _result = value;
                OnPropertyChanged("Result");
            }
        }
        private FunctionInfo _self = new FunctionInfo();
        public FunctionInfo Self
        {
            get { return _self; }
            set
            {
                _self = value;
                OnPropertyChanged("Self");
            }
        }

        public double A
        {
            get { return Self.A; }
            set
            {
                Self.A = value;
                OnPropertyChanged("A");
            }
        }

        public double B
        {
            get { return Self.B; }
            set
            {
                Self.B = value;
                OnPropertyChanged("B");
            }
        }

        public double[] C
        {
            get { return Self.C; }
            set
            {
                Self.C = value;
                OnPropertyChanged("C");
            }
        }
        public double CurrentC
        {
            get { return Self.CurrentC; }
            set
            {
                Self.CurrentC = value;
                OnPropertyChanged("CurrentC");
            }
        }

        public void Update(FunctionInfo example, ResultViewModel result)
        {
            if (result != null)
            {
                Result = result;
            }
            Self = example;
            this.A = example.A;
            this.B = example.B;
            this.C = example.C;
            this.CurrentC = example.CurrentC;
            OnPropertyChanged("Update");
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
            {
                Console.WriteLine(prop);
                Result.Fxy = Self.Count(new Result { X = Result.X, Y = Result.Y, Fxy = Result.Fxy });
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
            }
        }
    }
}
