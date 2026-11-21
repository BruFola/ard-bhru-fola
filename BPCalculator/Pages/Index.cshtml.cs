using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.ApplicationInsights;
using System.Collections.Generic;


// page model

namespace BPCalculator.Pages
{
    public class BloodPressureModel : PageModel
    {
        [BindProperty]                              // bound on POST
        public BloodPressure BP { get; set; }

        private readonly TelemetryClient _telemetry;

        public BloodPressureModel(TelemetryClient telemetry)
        {
            _telemetry = telemetry;

        }


        // setup initial data
        public void OnGet()
        {
            BP = new BloodPressure() { Systolic = 100, Diastolic = 60 };
        }

        // POST, validate
        public IActionResult OnPost()
        {
            // extra validation




            if (!(BP.Systolic > BP.Diastolic))
            {
                ModelState.AddModelError("", "Systolic must be greater than Diastolic");
            }

            else if (ModelState.IsValid)
            {

                _telemetry.TrackEvent("BPCalculated", new Dictionary<string, string>
                {
                    ["Category"] = BP.Category.ToString()
                }

                );
            }

            return Page();
        }
    }
}
