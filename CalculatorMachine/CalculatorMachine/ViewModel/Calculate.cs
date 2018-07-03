using CalculatorMachine.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;

namespace CalculatorMachine.ViewModel
{
    public class Calculate:INotifyPropertyChanged
    {
        private string inputValue;
        private string num1;
        private string num2;
        private double result=0;
        private string operate;
        
        public double GetResult(double num1, double num2, string op)
        {
            double result = 0;
            switch (operate)
            {
                case "Plus":
                     result = PlusMethod(num1, num2);
                    break;
                case "Delete":
                    result = DeleteMethod(num1, num2);
                    break;
                case "Multiply":
                    result = MultiplyMethod(num1, num2);
                    break;
                case "Devide":
                    result = DevideMethod(num1, num2);
                    break;
            }
            return result;
        }

        private double DevideMethod(double num1, double num2)
        {
            return num1 / num2;
        }

        private double MultiplyMethod(double num1, double num2)
        {
            return num1 * num2;
        }

        private double DeleteMethod(double num1, double num2)
        {
            return num1 - num2;
        }

        private double PlusMethod(double num1, double num2)
        {
            return num1 + num2;
        }

        public Calculate()
        {
            inputValue = null;
            NumberClicked = new RelayCommand(OnNumberClicked);
            OperatorClicked = new RelayCommand(OnOperateClicked);
        }

        private void OnOperateClicked(object obj)
        {
            if(string.Equals(obj, "="))
            {
                num2 = inputValue;
                inputValue = GetResult(double.Parse(num1), double.Parse(num2), operate).ToString();
                OnPropertyChanged("InputValue");
            }
            else
            {
                operate = obj.ToString();
                num1 = inputValue;
                inputValue = string.Empty;
            }
        }

        private void OnNumberClicked(object obj)
        {
            inputValue = inputValue + obj; 
            OnPropertyChanged("InputValue");
        }

        public string InputValue
        {
            get
            {
                return inputValue;
            }
            set
            {
                if (value != inputValue)
                {
                    inputValue = value;
                    OnPropertyChanged("InputValue");
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            if(PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        private bool CanClick()
        {
            return true;
        }
        public ICommand NumberClicked { get; set; }
        public ICommand OperatorClicked { get; set; }

        //private void OnNumberClicked(string number)
        //{
        //    inputValue = inputValue + number;
        //}
    }
}
