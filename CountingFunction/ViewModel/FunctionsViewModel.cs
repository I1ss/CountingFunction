using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Data;

namespace CountingFunction
{
    public class FunctionsViewModel : DependencyObject, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public ICollectionView FunctionsList
        {
            get { return (ICollectionView)GetValue(FunctionsListProperty); }
            set { SetValue(FunctionsListProperty, value); }
        }

        public static readonly DependencyProperty FunctionsListProperty =
            DependencyProperty.Register("FunctionsList", typeof(ICollectionView), typeof(FunctionsViewModel), new PropertyMetadata(null));

        private ObservableCollection<ResultViewModel> _results = new ObservableCollection<ResultViewModel>();
        public ObservableCollection<ResultViewModel> Results
        {
            get { return _results; }
            set { _results = value; }
        }

        private FunctionInfoViewModel _functionViewModel;

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

        public FunctionsViewModel()
        {
            _functionViewModel = new FunctionInfoViewModel();
            _resultViewModel = new ResultViewModel();
            FunctionsList = CollectionViewSource.GetDefaultView(FunctionInfo.GetFunctions());
        }

        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
            {
                Console.WriteLine(prop);
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
            }
        }
    }
}
