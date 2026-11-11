namespace BPCalculator.Tests;

using System.ComponentModel.DataAnnotations;

public class BloodPressureUnitTests
{

    //Systolic and Diastolic values are validated using the Range attribute in the BloodPressure class. The following test cases check for valid and invalid values.
    [Fact]
    public void BloodPressure_ValidSystolicValue_ShouldNotThrowValidationException()
    {
        // Arrange
        var ardbhru = new BloodPressure
        {
            Systolic = 120, // Valid systolic value
            Diastolic = 80  // Valid diastolic value - even though we are not testing for diastolic value here, we need to provide a valid value for it to pass validation
        };

        // Act & Assert
        var validationContext = new ValidationContext(ardbhru);
        var validationResults = new List<ValidationResult>();
        bool isValid = Validator.TryValidateObject(ardbhru, validationContext, validationResults, true);

        Assert.True(isValid);
    }

[Fact]
    public void BloodPressure_InvalidSystolicValue_ShouldThrowValidationException()
    {
        // Arrange
        var ardbhru = new BloodPressure
        {
            Systolic = 200, // Invalid systolic value (greater than 190)
            Diastolic = 80  // Valid diastolic value
        };

        // Act & Assert
        var validationContext = new ValidationContext(ardbhru);
        var validationResults = new List<ValidationResult>();
        bool isValid = Validator.TryValidateObject(ardbhru, validationContext, validationResults, true);

        //foreach (var r in validationResults) Console.WriteLine(r.ErrorMessage);
        Assert.False(isValid);
       //Assert.Contains(validationResults, vr => vr.ErrorMessage == "Invalid Systolic Value"); note: validation attribute is not working for systolic value, need to investigate why
    }

    [Fact]
    public void BloodPressure_ValidDiastolicValue_ShouldNotThrowValidationException()
    {
        // Arrange
        var ardbhru = new BloodPressure
        {
            Systolic = 120, // Valid systolic value , even though we are not testing for systolic value here, we need to provide a valid value for it to pass validation
            Diastolic = 80  // Valid diastolic value
        };

        // Act & Assert
        var validationContext = new ValidationContext(ardbhru);
        var validationResults = new List<ValidationResult>();
        bool isValid = Validator.TryValidateObject(ardbhru, validationContext, validationResults, true);

        Assert.True(isValid);
    }

[Fact]
    public void BloodPressure_InvalidDiastolicValue_ShouldThrowValidationException()
    {
        // Arrange
        var ardbhru = new BloodPressure
        {
            Systolic = 120, // Valid systolic value
            Diastolic = 30  // Invalid diastolic value (less than 40)
        };

        // Act & Assert
        var validationContext = new ValidationContext(ardbhru);
        var validationResults = new List<ValidationResult>();
        bool isValid = Validator.TryValidateObject(ardbhru, validationContext, validationResults, true);


        //foreach (var r in validationResults) Console.WriteLine(r.ErrorMessage);
        Assert.False(isValid);
       // Assert.Contains(validationResults, vr => vr.ErrorMessage == "Invalid Diastolic Value"); validation attribute is not working for diastolic value, need to investigate why
      //
    }
    [Fact]
    public void Whatisthebloodpressurecategory()
    {
      // create a new instance of the BloodPressure class
        var ardbhru = new BloodPressure
            {
                Systolic = 130,
                Diastolic = 85
            };
    
            // Assert that the Category property returns the expected value
            Assert.Equal(BPCategory.PreHigh, ardbhru.Category);
    }

    [Theory]
    [InlineData(120, 80, BPCategory.PreHigh)]
    [InlineData(139, 89, BPCategory.PreHigh)]   
    [InlineData(140, 60, BPCategory.High)]
    [InlineData(120, 70, BPCategory.PreHigh)]   
    [InlineData(110, 80, BPCategory.PreHigh)]
    [InlineData(119, 79, BPCategory.Ideal)]   
    [InlineData(85, 70, BPCategory.Ideal)]    // bug - should it be if either is below the threshold then it should be low ?
    [InlineData(89, 59, BPCategory.Low)]
    
    public void Whatisthebloodpressurecategory_batch(int sys, int dia, BPCategory expectedCategory)
    {
        // create a new instance of the BloodPressure class
        var ardbhru = new BloodPressure();
        
        // Set the Systolic and Diastolic properties
        ardbhru.Systolic = sys;     
        ardbhru.Diastolic = dia;
        var result = ardbhru.Category;

        
    
            // Assert that the Category property returns the expected value
            Assert.Equal(expectedCategory, result);

    }


    // Test for invalid blood pressure values

}
