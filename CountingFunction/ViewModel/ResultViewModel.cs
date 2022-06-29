using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;

namespace CountingFunction
{
    public class ResultViewModel : DependencyObject, INotifyPropertyChanged
    {
        #region Properties
        private FunctionInfo _function = new FunctionInfo();
        /// <summary>
        /// Данное поле содержит структуру, содержащую информацию об a, b, c, current c (текущее выбранное значение c).
        /// </summary>
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
        /// <summary>
        /// Данное поле содержит структуру, содержащую информацию о x, y, f(x,y).
        /// </summary>
        public Result Self
        {
            get { return _self; }
            set
            {
                _self = value;
                OnPropertyChanged("Self");
            }
        }
        /// <summary>
        /// Данное поле содержит информацию о x.
        /// </summary>
        public double X
        {
            get { return Self.X; }
            set
            {
                Self.X = value;
                OnPropertyChanged("X");
            }
        }
        /// <summary>
        /// Данное поле содержит информацию о y.
        /// </summary>
        public double Y
        {
            get { return Self.Y; }
            set
            {
                Self.Y = value;
                OnPropertyChanged("Y");
            }
        }
        /// <summary>
        /// Данное поле содержит информацию о f(x,y).
        /// </summary>
        public double Fxy
        {
            get { return Self.Fxy; }
            set
            {
                Self.Fxy = value;
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
        /// Данная функция будет обновлять значения используемых/выбранных таблицы и списка и на основе этого рассчитывать f(x,y).
        /// </summary>
        /// <param name="example">Данное поле содержит структуру, содержащую информацию о x, y, f(x,y), а также содержит текущий Result.</param>
        /// <param name="result">Данное поле содержит структуру, содержащую информацию об a, b, c, current c (текущее выбранное значение c).</param>
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
        /// <summary>
        /// Функция, изменяющая состояние отображения и вызывающая подсчёт текущего f(x,y).
        /// </summary>
        /// <param name="prop">Информация о параметре, который был изменен.</param>
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (prop != "fxy" && Function != null)
            {
                this.Fxy = Function.Count(Self);
            }
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
            }
        }
        #endregion
    }
}
