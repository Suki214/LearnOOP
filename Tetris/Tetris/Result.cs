using System.ComponentModel;

namespace Tetris
{
    //Record for Level & Score
    internal class Result : INotifyPropertyChanged
    {
        private int level;
        public int Level
        {
            get
            {
                return level;
            }
            set
            {
                level = value;
                OnPropertyChanged("Level");
            }
        }

        private int score;
        public int Score
        {
            get
            {
                return score;
            }
            set
            {
                score = value;
                OnPropertyChanged("Score");
            }
        }

        Result()
        {
            Score = 0;
            Level = 1;
        }

        private static Result instance;
        private static readonly object syncObj = new object();
        public static Result GetInstance()
        {
            if (instance == null)
            {
                lock (syncObj)
                {
                    if (instance == null)
                    {
                        instance = new Result();
                    }
                }
            }
            return instance;
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}