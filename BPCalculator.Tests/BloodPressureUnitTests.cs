namespace BPCalculator.Tests;

public class BloodPressureUnitTests
{
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
}
