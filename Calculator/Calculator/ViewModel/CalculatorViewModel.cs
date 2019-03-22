using System.ComponentModel;
using System.Windows.Input;
using Calculator.Annotations;

namespace Calculator.ViewModel
{
    public class CalculatorViewModel : INotifyPropertyChanged
    {
        private string firstValue;
        private string secondValue;
        private string operValue;
        private string result;

        public CalculatorViewModel()
        {
            InitializeCommand();
        }

        private void InitializeCommand()
        {
            NumButtonClickCommand = new RelayCommand(OnNumButtonClicked);
            OperButtonClickCommand = new RelayCommand(OnOperButtonCLicked);
            ClearButtonClickCommand = new RelayCommand(OnClearButtonClicked);
        }

        public ICommand NumButtonClickCommand { get;private set; }
        public ICommand OperButtonClickCommand { get; private set; }
        public ICommand ClearButtonClickCommand { get; private set; }

        public string FirstValue
        {
            get { return firstValue; }
            set
            {
                firstValue = value;
                OnPropertyChanged("FirstValue");
            }
        }

        public string SecondValue
        {
            get { return secondValue; }
            set
            {
                secondValue = value;
                OnPropertyChanged("SecondValue");
            }
        }

        public string OperValue
        {
            get { return operValue; }
            set
            {
                operValue = value;
                OnPropertyChanged("OperValue");
            }
        }

        public string Result
        {
            get { return result; }
            set
            {
                result = value;
                OnPropertyChanged("Result");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnNumButtonClicked(object inputNum)
        {
            var num = inputNum.ToString();
            if (OperValue == null)
            {
                FirstValue = FirstValue + num;
            }
            else
            {
                SecondValue = SecondValue + num;
            }
        }

        private void OnOperButtonCLicked(object inputOper)
        {
            if (inputOper.Equals("="))
            {
                Result = GetResult();
            }
            else
            {
                OperValue = inputOper.ToString();
            }
        }

        private string GetResult()
        {
            switch (OperValue)
            {
                case "+":
                    return (double.Parse(FirstValue) + double.Parse(SecondValue)).ToString();
                case "-":
                    return (double.Parse(FirstValue) - double.Parse(SecondValue)).ToString();
                case "*":
                    return (double.Parse(FirstValue) * double.Parse(SecondValue)).ToString();
                case "/":
                    return (double.Parse(FirstValue) / double.Parse(SecondValue)).ToString();
                default:
                    return string.Empty;
            }
        }

        private void OnClearButtonClicked(object inputOper)
        {
            OperValue = null;
            FirstValue = null;
            SecondValue = null;
            Result = null;
        }

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged(string propertyName)
        {
            var handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
                
            }
        }
    }
}