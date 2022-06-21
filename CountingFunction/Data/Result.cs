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
        #region Properties

        private int _x { get; set; }
        /// <summary>
        /// Данное поле хранит информацию о значении x.
        /// </summary>
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
        /// <summary>
        /// Данное поле хранит информацию о значении y.
        /// </summary>
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
        /// <summary>
        /// Данное поле хранит информацию о значении f(x,y).
        /// </summary>
        public double fxy
        {
            get { return _fxy; }
            set
            {
                _fxy = value;
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
                    FunctionsViewModel.Count(FunctionsViewModel.SelectedFunctionInfoStatic, this);
                }
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
            }
        }

        #endregion
    }
}
