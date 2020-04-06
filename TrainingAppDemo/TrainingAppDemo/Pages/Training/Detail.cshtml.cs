using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TrainingApp.Data;

namespace TrainingAppDemo.Pages.Training
{
    public class DetailModel : PageModel
    {
        public ITrainingDataService trainingDataService { get; set; }
        public TrainingApp.Data.Training training { get; private set; }

        public DetailModel(ITrainingDataService trainingDataService)
        {
            this.trainingDataService = trainingDataService;
        }

        public IActionResult OnGet(int trainingId)
        {

            training = this.trainingDataService.GetById(trainingId);
            if(training == null)
            {
                return RedirectToPage("./NotFound");
            }
            return Page();

        }
    }
}

