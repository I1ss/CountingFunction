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
    public class FunctionInfo : INotifyPropertyChanged
    {
        private int _a { get; set; }
        public int a
        {
            get { return _a; }
            set
            {
                _a = value;
                OnPropertyChanged("a");
            }
        }

        private int _b { get; set; }
        public int b
        {
            get { return _b; }
            set
            {
                _b = value;
                OnPropertyChanged("b");
            }
        }

        private int[] _c { get; set; }
        public int[] c
        {
            get { return _c; }
            set
            {
                _c = value;
                OnPropertyChanged("c");
            }
        }

        private int _CurrentC { get; set; }
        public int CurrentC
        {
            get { return _CurrentC; }
            set
            {
                _CurrentC = value;
                OnPropertyChanged("CurrentC");
            }
        }

        private string _Function { get; set; }
        public string Function
        {
            get { return _Function; }
            set
            {
                _Function = value;
                OnPropertyChanged("Function");
            }
        }
        private string _FunctionName { get; set; }
        public string FunctionName
        {
            get { return _FunctionName; }
            set
            {
                _FunctionName = value;
                OnPropertyChanged("FunctionName");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
            {
                FunctionsViewModel.Count(this, FunctionsViewModel.SelectedTableStatic);
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
            }
        }

        public static ObservableCollection<FunctionInfo> GetFunctionInfo()
        {
            ObservableCollection<FunctionInfo> result = new ObservableCollection<FunctionInfo>
            {
                new FunctionInfo() { _Function = "f(x,y) = ax¹+by⁰+c", _FunctionName = "Линейная", _a = 1, _b = 1, _c = new int[]{1, 2, 3, 4, 5 }, _CurrentC = 1 },
                new FunctionInfo() { _Function = "f(x,y) = ax²+by¹+c", _FunctionName = "Квадратичная", _a = 2, _b = 2, _c = new int[]{10, 20, 30, 40, 50 }, _CurrentC = 10},
                new FunctionInfo() { _Function = "f(x,y) = ax³+by²+c", _FunctionName = "Кубическая", _a = 3, _b = 3, _c = new int[]{100, 200, 300, 400, 500 }, _CurrentC = 100},
                new FunctionInfo() { _Function = "f(x,y) = ax⁴+by³+c", _FunctionName = "4-ой степени", _a = 4, _b = 4, _c = new int[]{1000, 2000, 3000, 4000, 5000 }, _CurrentC = 1000},
                new FunctionInfo() { _Function = "f(x,y) = ax⁵+by⁴+c", _FunctionName = "5-ой степени", _a = 5, _b = 5, _c = new int[]{10000, 20000, 30000, 40000, 50000 }, _CurrentC = 10000}
            };
            return result;
        }
    }
}
