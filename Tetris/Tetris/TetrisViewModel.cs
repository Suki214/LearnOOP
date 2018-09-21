using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tetris
{
    class TetrisViewModel
    {
        public RelayCommand StartCommand;
        public RelayCommand StopCommand;
        public RelayCommand TerminateCommand;

        public TetrisViewModel()
        {
            StartCommand = new RelayCommand(OnStartAction);
            StartCommand = new RelayCommand(OnPauseAction);
            StartCommand = new RelayCommand(OnTerminateAction);
        }

        private void OnTerminateAction(object obj)
        {
            throw new NotImplementedException();
        }

        private void OnPauseAction(object obj)
        {
            throw new NotImplementedException();
        }

        private void OnStartAction(object obj)
        {
            throw new NotImplementedException();
        }
    }
}
