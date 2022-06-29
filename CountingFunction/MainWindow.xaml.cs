using System;
using System.Windows;
using System.Windows.Input;

namespace CountingFunction
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            DataContext = new FunctionsViewModel();
        }

        private void TextBox_PreviewTextInput(object sender, TextCompositionEventArgs textBox)
        {
            textBox.Handled = !(Char.IsDigit(textBox.Text, 0)) && !textBox.Text.Contains(".");
        }
    }
}
