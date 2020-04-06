using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using TrainingApp.Data;

namespace TrainingAppDemo.Pages.Training
{
    public class EditModel : PageModel
    {
        ITrainingDataService trainingDataService;
        IHtmlHelper htmlHelper;

        [BindProperty]
        public TrainingApp.Data.Training training { get; set; }

        public IEnumerable<SelectListItem> TrainingLevel { get; set; }

        public EditModel(ITrainingDataService trainingDataService, IHtmlHelper htmlHelper)
        {
            this.trainingDataService = trainingDataService;
            this.htmlHelper = htmlHelper;
        }

        public IActionResult OnGet(int? trainingId)
        {
            this.TrainingLevel = htmlHelper.GetEnumSelectList<TrainingLevel>();

            if (trainingId.HasValue)
            {
                this.training = this.trainingDataService.GetById(trainingId.Value);
            }
            else
            {
                this.training = new TrainingApp.Data.Training();
            }
            return Page();

           
        }
        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                this.TrainingLevel = htmlHelper.GetEnumSelectList<TrainingLevel>();
                return Page();
            }
            if (this.training.Id > 0)
            {
                this.training = trainingDataService.Update(this.training);
            }
            else
            {
                trainingDataService.Add(this.training);
            }

            return RedirectToPage("./Detail", new { trainingId = this.training.Id });

        }
    }
}