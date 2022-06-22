using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;

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
        
        private static FunctionInfo SelectedFunctionInfoStatic;
        
        private static Result SelectedTableStatic;
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
                    table.Fxy = func.A * table.X + func.B * Math.Pow(table.Y, 0) + func.CurrentC;
                    break;
                case ("Квадратичная"):
                    table.Fxy = func.A * Math.Pow(table.X, 2) + func.B * Math.Pow(table.Y, 1) + func.CurrentC;
                    break;
                case ("Кубическая"):
                    table.Fxy = func.A * Math.Pow(table.X, 3) + func.B * Math.Pow(table.Y, 2) + func.CurrentC;
                    break;
                case ("4-ой степени"):
                    table.Fxy = func.A * Math.Pow(table.X, 4) + func.B * Math.Pow(table.Y, 3) + func.CurrentC;
                    break;
                case ("5-ой степени"):
                    table.Fxy = func.A * Math.Pow(table.X, 5) + func.B * Math.Pow(table.Y, 4) + func.CurrentC;
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
        /// <summary>
        /// Данная функция возвращает информацию о выбранной функции из списка функций, обеспечивая доступ к ней без объекта класса.
        /// </summary>
        public static FunctionInfo GetSelectedFunctionInfoStatic()
        {
            return SelectedFunctionInfoStatic;
        }
        /// <summary>
        /// Данная функция хранит информацию о выбранной строке таблицы, обеспечиваю доступ к ней без объекта класса.
        /// </summary>
        public static Result GetSelectedTableStatic()
        {
            return SelectedTableStatic;
        }

        #endregion
    }
}
