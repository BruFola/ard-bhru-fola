namespace BPCalculator.Tests;

public class BloodPressureUnitTests
{
    [Fact]
    public void Whatisthebloodpressurecategory()
    {
      // create a new instance of the BloodPressure class
        var ArdBhru = new BloodPressure
            {
                Systolic = 130,
                Diastolic = 85
            };
    
            // Assert that the Category property returns the expected value
            Assert.Equal(BPCategory.PreHigh, ArdBhru.Category);
    }
}
