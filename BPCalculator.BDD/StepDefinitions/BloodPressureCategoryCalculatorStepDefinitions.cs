using Reqnroll;
using System;

namespace BPCalculator.BDD.StepDefinitions
{
    [Binding]
    public class BloodPressureCategoryCalculatorStepDefinitions
    {

        private BloodPressure bp = null!; // tell compiler that this will be initialized before use - ignore warning.
        private BPCategory results;


        


        [Given("a systolic reading of {int} and a diastolic reading of {int}")]
        public void GivenASystolicReadingOfAndADiastolicReadingOf(int sys, int dia)
        {

           bp = new BloodPressure { Systolic = sys, Diastolic = dia };

        }

        [When("I calculate the blood pressure category")]
        public void WhenICalculateTheBloodPressureCategory()
        {

            results = bp.Category;
           
        }

        [Then("the result should be {string}")]
        public void ThenTheResultShouldBe(string expectedCat)
        {

          
           Assert.Equal(expectedCat, results.ToString());




        }

    }
}
