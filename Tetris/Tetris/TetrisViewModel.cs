using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Windows.Controls;
using System.ComponentModel;

namespace Tetris
{
    class TetrisViewModel:INotifyPropertyChanged
    {
        public ICommand StartCommand { get; set; }
        public ICommand StopCommand { get; set; }
        public ICommand TerminateCommand { get; set; }

        private string startButtonLabel;
        private string stopButtonLabel;
        private string terminateButtonLabel;

        public string StartButtonLabel
        {
            get { return startButtonLabel; }
            set
            {
                startButtonLabel = value;
                OnPropertyChanged("StartButtonLabel");
            }
        }

        public string StopButtonLabel
        {
            get { return startButtonLabel; }
            set
            {
                startButtonLabel = value;
                OnPropertyChanged("StopButtonLabel");
            }
        }

        public string TerminateButtonLabel
        {
            get { return startButtonLabel; }
            set
            {
                startButtonLabel = value;
                OnPropertyChanged("TerminateButtonLabel");
            }
        }

        public TetrisViewModel()
        {
            StartCommand = new RelayCommand(OnStartAction);
            StopCommand = new RelayCommand(OnStopAction);
            TerminateCommand = new RelayCommand(OnTerminateAction);
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            if (propertyName != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        private void OnStartAction(object obj)
        {
            if (Container.ActivityBox == null) Container.NewBoxReadyToDown();
            else
            {
                Container.Pause();
                if(MessageBox.Show("当前游戏正在进行中，您是否重新开始新游戏？","",MessageBoxButton.YesNo)==MessageBoxResult.Yes)
                {
                    Container.Stop();
                    StopButtonLabel = "Pause";
                    Container.NewBoxReadyToDown();
                }
                else
                {
                    if (StopButtonLabel == "Pause") Container.UnPause();
                }
            }
        }

        private void OnStopAction(object obj)
        {
            throw new NotImplementedException();
        }

        private void OnTerminateAction(object obj)
        {
            throw new NotImplementedException();
        }
    }
}
