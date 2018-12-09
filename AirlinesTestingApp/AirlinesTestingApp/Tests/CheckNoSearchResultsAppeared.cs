using AirlinesTestingApp.Pages;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium.Chrome;

namespace AirlinesTestingApp.Tests
{
    [TestClass]
    public class CheckNoSearchResultsAppeared
    {
        private SearchResultsPage searchResultsPage;

        [TestMethod]
        public void SearchTicketsToMinskAndAssertNoResultsAppeared()
        {
            _1_OpenSearchPageResultsForMinsk();

            _2_AssertSearchResultsText();
        }

        private void _1_OpenSearchPageResultsForMinsk()
        {
            searchResultsPage = new SearchResultsPage(new ChromeDriver());
            searchResultsPage.GoToSearchResultsForSpecifiedWord("Minsk");
        }

        private void _2_AssertSearchResultsText()
        {
            var result = searchResultsPage.GetSearchResultsText();
            Assert.AreEqual("0", result.Substring(0, result.IndexOf("R")).Trim());
        }
    }
}
