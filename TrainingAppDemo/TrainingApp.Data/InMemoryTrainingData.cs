using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TrainingApp.Data
{
    public class InMemoryTrainingData : ITrainingDataService
    {
        List<Training> trainings;
        public InMemoryTrainingData()
        {
            trainings = new List<Training>
            {
                new Training{ Id=1, Title="C#", Trainer="Ankur Pathak", Level=TrainingLevel.Intermediate },
                new Training{ Id=2, Title="Asp.Net Core", Trainer="Ankur Pathak", Level=TrainingLevel.Beginner},
                new Training{ Id=3, Title="Xamarin", Trainer="Ankur Pathak", Level=TrainingLevel.Intermediate },
                new Training{ Id=4, Title="Web Api", Trainer="Ankur Pathak", Level=TrainingLevel.Intermediate }

            };
        }
        public Training Add(Training newTraining)
        {
            newTraining.Id = trainings.Max(x => x.Id) + 1;
            trainings.Add(newTraining);
            return newTraining;
        }

        public Training GetById(int trainingId)
        {
            return trainings.Find(x => x.Id == trainingId);
        }

        public IEnumerable<Training> GetTrainingsByName(string name= null)
        {
            var result = from t in trainings
                         where string.IsNullOrEmpty(name) || t.Title.StartsWith(name)
                         orderby t.Title
                         select t;
            return result;
        }

        public Training Update(Training updatedTraining)
        {
            var res = trainings.SingleOrDefault(x => x.Id == updatedTraining.Id);
            if(res != null)
            {
                res.Title = updatedTraining.Title;
                res.Trainer = updatedTraining.Trainer;
                res.Level = updatedTraining.Level;
            }
            return res;
        }
    }
}
