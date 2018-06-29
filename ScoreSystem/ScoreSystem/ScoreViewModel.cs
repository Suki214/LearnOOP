using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ScoreSystem
{
   internal class ScoreViewModel
    {
        private List<Score> myScores = new List<Score>();

        public ScoreViewModel()
        {
            myScores =  DatabaseAccessor.GetResult();
            Scores = new ObservableCollection<Score>(myScores);
           ClearAction = new RelayCommand(ClearCommand);
            ResetAction = new RelayCommand(ResetCommand);
            FilterAction = new RelayCommand(FilterCommand);


        }
        public ObservableCollection<Score> Scores { get; set; }

        private void ResetCommand()
        {
            Scores.Clear();
            foreach (var score in myScores)
            {
                Scores.Add(score);
            }
        }
        
        public void ClearCommand()
        {
            Scores.Clear();
        }

        private string myStudentName;
       public string StudentName
        {
            get
            {
                return myStudentName;
            }
            set
            {
                myStudentName = value;
                FilterAction.IsExecutable = (!string.IsNullOrEmpty(value) && Scores.Count != 0);
            }
        }

        public void FilterCommand()
        {
            Scores.Clear();
            foreach (var score in myScores)
            {
                if(score.StudentName== StudentName)
                { 
                    Scores.Add(score);
                }
            }
        }


       
        public ICommand ClearAction { get; set; }
        public ICommand ResetAction { get; set; }
        public RelayCommand FilterAction { get; set; }
    }
}
