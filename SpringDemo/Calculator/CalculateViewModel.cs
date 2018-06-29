using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;

namespace Calculator
{
    class CalculateViewModel :INotifyPropertyChanged
    {
        Operation oper;
        public enum Operators { Add, Delete, Multiple, Devide }

        private double _number;

        private string _numberString;
        public double Number
        {
            get
            {
                return _number;
            }
            set
            {
                _number = value;
                OnPropertyChanged("Number");
            }
        }
        public RelayCommand NumberClickCommand { get; set; }
        public ICommand OperateClickCommand { get; set; }
        public RelayCommand ClearAllClickCommand { get; set; }
        public RelayCommand EqualClickCommand { get; set; }

        public List<double> NumberLists { get; set; }
        public string Operator { get; set; }
        public CalculateViewModel()
        {
            NumberLists = new List<double>();
            ClearAllClickCommand = new RelayCommand(ClearAllAction);
            OperateClickCommand = new RelayCommand(OperateAction);
            NumberClickCommand = new RelayCommand(NumberAction);
            EqualClickCommand = new RelayCommand(EqualAction);
        }

        private void EqualAction(object obj)
        {
            
            oper = OperateFactory.CreateOperate(Operator);
            oper.NumA = NumberLists[0];
            oper.NumB = NumberLists[1];
            Number = oper.GetResult();
            _numberString = null;
            NumberLists[0] = Number;
            NumberLists.RemoveAt(1);
        }

        //private double Calculate(List<double> numberLists, string oper)
        //{
        //    switch (oper)
        //    { 
        //        case "+":
        //            return numberLists[0] + numberLists[1];
        //        case "-":
        //            return numberLists[0] - numberLists[1];
        //        case "*":
        //            return numberLists[0] * numberLists[1];
        //        case "/":
        //            return numberLists[0] / numberLists[1];

        //        default:
        //            return 0;
        //    }
        //}

        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged(string property)
        {
            if (PropertyChanged !=null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(property));
            }
        }


        private void NumberAction(object obj)
        {
            
            if (Operator == null)
            {
                _numberString = _numberString + obj;
                NumberLists.Clear();
                NumberLists.Add(double.Parse(_numberString.ToString()));
                Number = NumberLists[0];
            }
            else
            {
                if (NumberLists.Count==1)
                {
                    _numberString = obj.ToString();
                }
                else
                {
                    _numberString = _numberString + obj;
                    NumberLists.RemoveAt(1);                    
                }

                NumberLists.Add(double.Parse(_numberString.ToString()));
                Number = NumberLists[1];
            }
                
        }

        private void OperateAction(object obj)
        {
            Operator = obj.ToString();
        }

        private void ClearAllAction(object obj)
        {
            NumberLists.Clear();
            Operator = null;
            Number = 0;
        }


    }
}
