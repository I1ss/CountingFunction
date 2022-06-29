using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Data;

namespace CountingFunction
{
    public class FunctionsViewModel : DependencyObject, INotifyPropertyChanged
    {
        #region Properties
        /// <summary>
        /// Данное событие обеспечивает динамическое изменение состояния объекта.
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;
        /// <summary>
        /// Данное поле хранит информацию о списке функций.
        /// </summary>
        public ICollectionView FunctionsList
        {
            get { return (ICollectionView)GetValue(FunctionsListProperty); }
            set { SetValue(FunctionsListProperty, value); }
        }
        /// <summary>
        /// Данное поле содержит и обеспечивает взаимодействие со списком функций.
        /// </summary>
        public static readonly DependencyProperty FunctionsListProperty =
            DependencyProperty.Register("FunctionsList", typeof(ICollectionView), typeof(FunctionsViewModel), new PropertyMetadata(null));

        private ObservableCollection<ResultViewModel> _results = new ObservableCollection<ResultViewModel>();
        /// <summary>
        /// Данное поле хранит информацию о результатах вычислений, то есть о строках в таблице.
        /// </summary>
        public ObservableCollection<ResultViewModel> Results
        {
            get { return _results; }
            set { _results = value; }
        }

        private FunctionInfoViewModel _functionViewModel;
        /// <summary>
        /// Данное поле хранит информацию о ViewModel для списка функций, благодаря которой обеспечивается плавное взаимодействие пользователя с View.
        /// </summary>
        public FunctionInfoViewModel FunctionViewModel
        {
            get { return _functionViewModel; }
            set
            {
                _functionViewModel = value;
                OnPropertyChanged("FunctionViewModel");
            }
        }

        private ResultViewModel _resultViewModel;
        /// <summary>
        /// Данное поле хранит информацию о ViewModel для списка результатов, благодаря которой обеспечивается плавное взаимодействие пользователя с View.
        /// </summary>
        public ResultViewModel ResultViewModel
        {
            get { return _resultViewModel; }
            set
            {
                _resultViewModel = value;
                OnPropertyChanged("ResultViewModel");
            }
        }

        private FunctionInfo _selectedFunctionType;
        /// <summary>
        /// Данное поле хранит информацию о выбранной функции из списка.
        /// </summary>
        public FunctionInfo SelectedFunctionType
        {
            get { return _selectedFunctionType; }
            set
            {
                _selectedFunctionType = value;
                _functionViewModel.Update(value, SelectedResult);
                OnPropertyChanged("SelectedFunctionType");
            }
        }

        private ResultViewModel _selectedResult;
        /// <summary>
        /// Данное поле хранит информацию о выбранном реузльтате из таблицы.
        /// </summary>
        public ResultViewModel SelectedResult
        {
            get { return _selectedResult; }
            set
            {
                if (value == null || SelectedFunctionType == null)
                {
                    return;
                }
                _selectedResult = value;
                _resultViewModel = _selectedResult;
                _resultViewModel.Function = SelectedFunctionType;
                _functionViewModel.Update(SelectedFunctionType, value);
                OnPropertyChanged("SelectedResult");
            }
        }
        #endregion
        #region Methods
        /// <summary>
        /// Конструктор основной ViewModel.
        /// </summary>
        public FunctionsViewModel()
        {
            _functionViewModel = new FunctionInfoViewModel();
            _resultViewModel = new ResultViewModel();
            FunctionsList = CollectionViewSource.GetDefaultView(FunctionInfo.GetFunctions());
        }
        /// <summary>
        /// Функция, изменяющая состояние отображения.
        /// </summary>
        /// <param name="prop">Информация о параметре, который был изменен.</param>
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
            }
        }
        #endregion
    }
}
