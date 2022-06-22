using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace CountingFunction
{
    public class Result : INotifyPropertyChanged
    {
        #region Properties

        private double _X { get; set; }
        /// <summary>
        /// Данное поле хранит информацию о значении x.
        /// </summary>
        public double X
        {
            get { return _X; }
            set
            {
                _X = value;
                OnPropertyChanged("x");
            }
        }

        private double _Y { get; set; }
        /// <summary>
        /// Данное поле хранит информацию о значении y.
        /// </summary>
        public double Y
        {
            get { return _Y; }
            set
            {
                _Y = value;
                OnPropertyChanged("y");
            }
        }

        private double _Fxy { get; set; }
        /// <summary>
        /// Данное поле хранит информацию о значении f(x,y).
        /// </summary>
        public double Fxy
        {
            get { return _Fxy; }
            set
            {
                _Fxy = value;
                OnPropertyChanged("fxy");
            }
        }
        /// <summary>
        /// Данное событие обеспечивает динамическое изменение состояния объекта.
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        #endregion

        #region Methods
        /// <summary>
        /// Метод, генерирующий список с заполненными по умолчанию элементами.
        /// </summary>
        /// <returns>Возвращает список с заполненными по умолчанию элементами.</returns>
        public static ObservableCollection<Result> GetResults()
        {
            ObservableCollection<Result> result = new ObservableCollection<Result>();
            return result;
        }

        /// <summary>
        /// Функция, изменяющая состояние отображения и вызывающая подсчёт текущего f(x,y).
        /// </summary>
        /// <param name="prop">Информация о параметре, который был изменен.</param>
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
            {
                if (prop != "fxy")
                {
                    FunctionsViewModel.Count(FunctionsViewModel.GetSelectedFunctionInfoStatic(), this);
                }
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
            }
        }

        #endregion
    }
}
