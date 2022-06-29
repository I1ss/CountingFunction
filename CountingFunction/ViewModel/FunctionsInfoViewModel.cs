using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;

namespace CountingFunction
{
    public class FunctionInfoViewModel : DependencyObject, INotifyPropertyChanged
    {
        #region Properties
        private ResultViewModel _result = new ResultViewModel();
        /// <summary>
        /// Данное поле содержит структуру, содержащую информацию о x, y, f(x,y), а также содержит текущий Result.
        /// </summary>
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
        /// <summary>
        /// Данное поле содержит структуру, содержащую информацию об a, b, c, current c (текущее выбранное значение c).
        /// </summary>
        public FunctionInfo Self
        {
            get { return _self; }
            set
            {
                _self = value;
                OnPropertyChanged("Self");
            }
        }
        /// <summary>
        /// Данное поле содержит информацию об a.
        /// </summary>
        public double A
        {
            get { return Self.A; }
            set
            {
                Self.A = value;
                OnPropertyChanged("A");
            }
        }
        /// <summary>
        /// Данное поле содержит информацию о b.
        /// </summary>
        public double B
        {
            get { return Self.B; }
            set
            {
                Self.B = value;
                OnPropertyChanged("B");
            }
        }
        /// <summary>
        /// Данное поле содержит информацию о c.
        /// </summary>
        public double[] C
        {
            get { return Self.C; }
            set
            {
                Self.C = value;
                OnPropertyChanged("C");
            }
        }
        /// <summary>
        /// Данное поле содержит информацию о выбранном на текущем моменте c из всего списка.
        /// </summary>
        public double CurrentC
        {
            get { return Self.CurrentC; }
            set
            {
                Self.CurrentC = value;
                OnPropertyChanged("CurrentC");
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
        /// <param name="example">Структура, содержащая информацию  об a, b, c, current c (текущее выбранное значение c).</param>
        /// <param name="result">Структура, содержащая информацию о x, y, f(x,y).</param>
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
        /// <summary>
        /// Функция, изменяющая состояние отображения и вызывающая подсчёт текущего f(x,y).
        /// </summary>
        /// <param name="prop">Информация о параметре, который был изменен.</param>
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
            {
                Result.Fxy = Self.Count(new Result { X = Result.X, Y = Result.Y, Fxy = Result.Fxy });
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
            }
        }
        #endregion
    }
}
