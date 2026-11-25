namespace BPCalculator.E2E;
using Microsoft.Playwright;
using Microsoft.Playwright.Xunit;

public class CalculatorPagesTests  : PageTest
{

     private readonly string baseUrl = Environment.GetEnvironmentVariable("BASE_URL") ?? "https://ardbhrufola-quality-e3hqe9bgevaxcgak.spaincentral-01.azurewebsites.net/";

    [Fact]
    public async Task HomePage_Loads_ShowHeadings() 
    {
        await Page.GotoAsync(baseUrl);
        await Expect(Page.Locator("h4")).ToHaveTextAsync("Blood Pressure Category Calculator");
    }


   [Fact]

public async Task ValidBloodPressureInput_Show_IdealCategory()
{
  
   await Page.GotoAsync(baseUrl);

    await Page.Locator("#BP_Systolic").FillAsync("110");
    await Page.Locator("#BP_Diastolic").FillAsync("70");
    await Page.Locator("input[type=submit]").ClickAsync();
    await Expect(Page.Locator("#category")).ToContainTextAsync("Ideal");
}

   [Fact]

public async Task InvalidBloodPressureInput_Shows_Error()


{
    await Page.GotoAsync(baseUrl);
    await Page.Locator("#BP_Systolic").FillAsync("80");
    await Page.Locator("#BP_Diastolic").FillAsync("120");
    await Page.Locator("input[type=submit]").ClickAsync();
    await Expect(Page.GetByText("Invalid Diastolic Value")).ToBeVisibleAsync();
}

}