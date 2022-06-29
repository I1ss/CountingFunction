using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Data;

namespace CountingFunction
{
    public class ResultViewModel : DependencyObject, INotifyPropertyChanged
    {
        private FunctionInfo _function = new FunctionInfo();
        public FunctionInfo Function
        {
            get { return _function; }
            set
            {
                _function = value;
                OnPropertyChanged("Function");
            }
        }

        private Result _self = new Result();
        public Result Self
        {
            get { return _self; }
            set
            {
                _self = value;
                OnPropertyChanged("Self");
            }
        }
        public double X
        {
            get { return Self.X; }
            set
            {
                Self.X = value;
                OnPropertyChanged("X");
            }
        }

        public double Y
        {
            get { return Self.Y; }
            set
            {
                Self.Y = value;
                OnPropertyChanged("Y");
            }
        }

        public double Fxy
        {
            get { return Self.Fxy; }
            set
            {
                Self.Fxy = value;
                OnPropertyChanged("fxy");
            }
        }

        public void Update(ResultViewModel example, FunctionInfo function)
        {
            if (example == null || function == null)
            {
                return;
            }
            Function = function;
            Self = new Result { X = example.X, Y = example.Y, Fxy = example.Fxy };
            this.X = example.X;
            this.Y = example.Y;
            this.Fxy = example.Fxy;
            OnPropertyChanged("Update");
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            Console.WriteLine(prop);
            if (prop != "fxy" && Function != null)
            {
                this.Fxy = Function.Count(Self);
            }
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
            }
        }
    }
}
