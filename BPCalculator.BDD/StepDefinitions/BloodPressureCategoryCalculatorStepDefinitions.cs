using System;
using Reqnroll;

namespace BPCalculator.BDD.StepDefinitions
{
    [Binding]
    public class BloodPressureCategoryCalculatorStepDefinitions
    {
        [Given("a systolic reading of {int} and a diastolic reading of {int}")]
        public void GivenASystolicReadingOfAndADiastolicReadingOf(int p0, int p1)
        {
            throw new PendingStepException();
        }

        [When("I calculate the blood pressure category")]
        public void WhenICalculateTheBloodPressureCategory()
        {
            throw new PendingStepException();
        }

        [Then("the result should be {string}")]
        public void ThenTheResultShouldBe(string ideal)
        {
            throw new PendingStepException();
        }

    }
}
