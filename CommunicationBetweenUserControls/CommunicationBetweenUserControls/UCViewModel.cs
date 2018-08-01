using System;
using System.ComponentModel;
using System.Windows.Input;

namespace CommunicationBetweenUserControls
{    
    public class UCViewModel:INotifyPropertyChanged
    {
        public event EventHandler SendWordsEventHandler;

        private ICommand sendWordsCommand;
        public ICommand SendWordsCommand
        {
            get
            {
                if (sendWordsCommand == null)
                    sendWordsCommand = new RelayCommand((o)=>SendWords());
                return sendWordsCommand;
            }
        }

        private void SendWords()
        {
            SendWordsEventHandler(this, new EventArgs());
        }        

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged(string property)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(property));
        }

        private string inputValue;
        public string InputValue
        {
            get
            {
                return inputValue;
            }
            set
            {
                inputValue = value;
                OnPropertyChanged("InputValue");
            }
        }
    }
}
