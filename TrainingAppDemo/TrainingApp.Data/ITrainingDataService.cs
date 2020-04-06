using System;
using System.Collections.Generic;
using System.Text;

namespace TrainingApp.Data
{
   public interface ITrainingDataService
    {
        IEnumerable<Training> GetTrainingsByName(string name);
        Training GetById(int trainingId);
        Training Update(Training updatedTraining);
        Training Add(Training newTraining);
    }
}
