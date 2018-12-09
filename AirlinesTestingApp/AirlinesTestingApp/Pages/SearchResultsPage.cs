using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Threading;

namespace AirlinesTestingApp.Pages
{
    public class SearchResultsPage
    {
        private IWebDriver driver;
        public const string Url = "https://www.aircaraibes.com/recherche/p/text/";
        private const string Results = " RÉSULTATS";

        By searchBoxResults = By.XPath("//*[@id='block-current-search-standard']/div/div/h3[1]");
        //By oneWayTicketCheckbox = By.Id("departure-only");
        //By leavingTicketDate = By.Id("edit-b-date-1-booking-0");
        //By returnTicketDate = By.Id("edit-b-date-2-booking-0");
        //By returnTicketProximity = By.Id("uniform-edit-date-range-value-2");
        //By departure = By.Id("edit-b-location-1");
        //By arrival = By.Id("edit-b-location-2");
        //By bookingFormSubmitButton = By.Id("edit-submit-booking-home");
        //By dateClosingCross = By.ClassName("ui-datepicker__close");
        //By notificationCross = By.ClassName("acc--closeLink");
        //By errorsMessages = By.ClassName("messages");

        //private void SelectDeparture()
        //{
        //    var placeToLeave = new SelectElement(driver.FindElement(departure));
        //    placeToLeave.SelectByIndex(1);//Because "zero" value is default
        //}

        //private void ChooseValueOfSelectTag(By selector, int index)
        //{
        //    var selectElement = new SelectElement(driver.FindElement(selector));
        //    selectElement.SelectByIndex(index);//Because "zero" value is default
        //}

        //private void CloseDatePicker()
        //{
        //    driver.FindElement(dateClosingCross).Click();
        //}

        public SearchResultsPage(IWebDriver driver)
        {
            this.driver = driver;
        }

        public void OpenSearchResultsPage()
        {
            GoToUrl(Url);
        }

        public void GoToUrl(string url)
        {
            driver.Navigate().GoToUrl(url);
        }

        public void GoToSearchResultsForSpecifiedWord(string word)
        {
            GoToUrl($"{Url}{word}");
        }

        public string GetSearchResultsText()
        {
            var searchResultsBoxElement = driver.FindElement(searchBoxResults);
            var content = searchResultsBoxElement.Text;
            return (content.Substring(content.IndexOf(":")+2));
            //searchBoxResults.
        }
        //public void CloseAds()
        //{
        //    driver.FindElement(advertisementCross).Click();
        //    Thread.Sleep(1000);
        //    driver.FindElement(notificationCross).Click();
        //}

        //public void SelectOneWayTicket()
        //{
        //    driver.FindElement(oneWayTicketCheckbox).Click();
        //}

        //public IWebElement GetReturnTicketDate()
        //{
        //    return driver.FindElement(returnTicketDate);
        //}

        //public IWebElement GetReturnTicketProximity()
        //{
        //    return driver.FindElement(returnTicketProximity);
        //}

        //public void FillInBookingForm()
        //{
        //    ChooseValueOfSelectTag(departure, 1);
        //    ChooseValueOfSelectTag(arrival, 12);

        //    SetDateTime(driver.FindElement(leavingTicketDate), DateTime.Now.ToString("dd'/'MM'/'yyyy"));
        //    SetDateTime(GetReturnTicketDate(), DateTime.Now.ToString("dd'/'MM'/'yyyy"));
        //}

        //public void SetDateTime(IWebElement el, string value)
        //{
        //    el.SendKeys(value);
        //    CloseDatePicker();
        //}

        public IWebElement GetElement(By selector)
        {
            return driver.FindElement(selector);
        }

        //public void SubmitBookingForm()
        //{
        //    driver.FindElement(bookingFormSubmitButton).Click();
        //}

        //public IWebElement GetErrorsMessages()
        //{
        //    return driver.FindElement(errorsMessages);
        //}
    }
}   