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
    public class Result : INotifyPropertyChanged
    {
        private int _x { get; set; }
        public int x
        {
            get { return _x; }
            set
            {
                _x = value;
                OnPropertyChanged("x");
            }
        }

        private int _y { get; set; }
        public int y
        {
            get { return _y; }
            set
            {
                _y = value;
                OnPropertyChanged("y");
            }
        }

        private double _fxy { get; set; }
        public double fxy
        {
            get { return _fxy; }
            set
            {
                _fxy = value;
                OnPropertyChanged("fxy");
            }
        }

        public static ObservableCollection<Result> GetResults()
        {
            ObservableCollection<Result> result = new ObservableCollection<Result>();
            return result;
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
            {
                if (prop != "fxy")
                {
                    FunctionsViewModel.Count(FunctionsViewModel.SelectedFunctionInfoStatic, this);
                }
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
            }
        }
    }
}
