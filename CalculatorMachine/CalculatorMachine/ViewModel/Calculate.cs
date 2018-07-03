using CalculatorMachine.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace CalculatorMachine.ViewModel
{
    class Calculate:INotifyPropertyChanged
    {
        private double inputValue;
        private double leftValue;
        private double rightValue;
        private Elements.Operators operate;
        public ICommand NumberClicked;

        public Calculate(double leftValue, double rightValue, Elements.Operators operate)
        {
            this.leftValue = leftValue;
            this.rightValue = rightValue;
            this.operate = operate;
        }

        public double InputValue
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


    }
}
