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
    public class FunctionsViewModel : INotifyPropertyChanged
    {
        private FunctionInfo _SelectedFunctionInfo;
        public FunctionInfo SelectedFunctionInfo
        {
            get { return _SelectedFunctionInfo; }
            set
            {
                _SelectedFunctionInfo = value;
                SelectedFunctionInfoStatic = value;
                OnPropertyChanged("SelectedFunctionInfo");
            }
        }
        private Result _SelectedTable;
        public static FunctionInfo SelectedFunctionInfoStatic;
        public static Result SelectedTableStatic;
        public Result SelectedTable
        {
            get { return _SelectedTable; }
            set
            {
                _SelectedTable = value;
                SelectedTableStatic = value;
                OnPropertyChanged("SelectedTable");
            }
        }
        public ObservableCollection<FunctionInfo> FunctionInfos { get; set; }
        public ObservableCollection<Result> Results { get; set; }
        public event PropertyChangedEventHandler PropertyChanged;

        public FunctionsViewModel()
        {
            FunctionInfos = FunctionInfo.GetFunctionInfo();
            Results = Result.GetResults();
        }
        public static void Count(FunctionInfo func, Result table)
        {
            if (func == null || table == null)
            {
                return;
            }
            switch (func.FunctionName)
            {
                case ("Линейная"):
                    table.fxy = func.a * table.x + func.b * Math.Pow(table.y, 0) + func.CurrentC;
                    break;
                case ("Квадратичная"):
                    table.fxy = func.a * Math.Pow(table.x, 2) + func.b * Math.Pow(table.y, 1) + func.CurrentC;
                    break;
                case ("Кубическая"):
                    table.fxy = func.a * Math.Pow(table.x, 3) + func.b * Math.Pow(table.y, 2) + func.CurrentC;
                    break;
                case ("4-ой степени"):
                    table.fxy = func.a * Math.Pow(table.x, 4) + func.b * Math.Pow(table.y, 3) + func.CurrentC;
                    break;
                case ("5-ой степени"):
                    table.fxy = func.a * Math.Pow(table.x, 5) + func.b * Math.Pow(table.y, 4) + func.CurrentC;
                    break;
                default:
                    break;
            }
        }
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
            {
                Count(SelectedFunctionInfo, SelectedTable);
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
            }
        }
    }
}
