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
        #region Properties

        private FunctionInfo _SelectedFunctionInfo;
        /// <summary>
        /// Данное поле хранит информацию о выбранной функции из списка функций.
        /// </summary>
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
        /// <summary>
        /// Данное поле хранит информацию о выбранной функции из списка функций, обеспечивая доступ к ней без объекта класса.
        /// </summary>
        public static FunctionInfo SelectedFunctionInfoStatic;
        /// <summary>
        /// Данное поле хранит информацию о выбранной строке таблицы, обеспечиваю доступ к ней без объекта класса.
        /// </summary>
        public static Result SelectedTableStatic;
        /// <summary>
        /// Данное поле хранит информацию о выбранной строке таблицы.
        /// </summary>
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
        /// <summary>
        /// Данная коллекция содержит список всех функций, которые отображаются в списке.
        /// </summary>
        public ObservableCollection<FunctionInfo> FunctionInfos { get; set; }
        /// <summary>
        /// Данная коллекция содержит список всех строк, которые отображаются в таблице.
        /// </summary>
        public ObservableCollection<Result> Results { get; set; }
        /// <summary>
        /// Данное событие обеспечивает динамическое изменение состояния объекта.
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        #endregion

        #region Methods
        /// <summary>
        /// Конструктор по умолчанию, генерирующий коллекции с определенными по умолчанию функциями и строками таблицы.
        /// </summary>
        public FunctionsViewModel()
        {
            FunctionInfos = FunctionInfo.GetFunctionInfo();
            Results = Result.GetResults();
        }
        /// <summary>
        /// Функция для подсчёта f(x,y).
        /// </summary>
        /// <param name="func">Выбранная функция в приложении.</param>
        /// <param name="table">Выбранная строка таблицы в приложении.</param>
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
        /// <summary>
        /// Функция, изменяющая состояние отображения и вызывающая подсчёт текущего f(x,y).
        /// </summary>
        /// <param name="prop">Информация о параметре, который был изменен.</param>
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
            {
                Count(SelectedFunctionInfo, SelectedTable);
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
            }
        }

        #endregion
    }
}
