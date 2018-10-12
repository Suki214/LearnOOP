using System;
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

        public void CalculateScore(int lines)
        {
            switch(lines)
            {
                case 1:Score += 5;
                    break;
                case 2:Score += 15;
                    break;
                case 3: Score += 30;
                    break;
                case 4:Score += 50;
                    break;
                case 5:Score += 75;
                    break;
                default: Score += 0;
                    break;
            }

            if (Score < 20) Level = 1;
            else if (Score < 100) Level = 2;
            else if (Score < 300) Level = 3;
            else if (Score < 500) Level = 4;
            else if (Score < 1000) Level = 5;
            else if (Score < 3000) Level = 6;
            else if (Score < 5000) Level = 7;
            else Level = 8;
        }
    }
}