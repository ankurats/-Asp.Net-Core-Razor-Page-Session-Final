using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration;
using TrainingApp.Data;

namespace TrainingAppDemo.Pages.Training
{
    public class ListModel : PageModel
    {

        [BindProperty(SupportsGet =true)]
        public string searchTerm { get; set; }

        public IConfiguration configuration { get; set; }
        public ITrainingDataService TrainingData { get; set; }

        public IEnumerable<TrainingApp.Data.Training> Trainings { get; private set; }

        public ListModel(IConfiguration config, ITrainingDataService TrainingData )
        {
            this.configuration = config;
            this.TrainingData = TrainingData;
        }
        public string Message { get; set; }
        public void OnGet()
        {
            //Message = "Hello World !";
            Message = configuration["Message"];
            this.Trainings = TrainingData.GetTrainingsByName(searchTerm);
        }
    }
}