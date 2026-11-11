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
    [InlineData(120, 80, BPCategory.Ideal)]    

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
