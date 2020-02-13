using System.Threading;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace SelleniumTestCoin
{
    [TestClass]
    public class UnitTest1
    {
        // eventuelt behov for chromedriver download : IWebDriver driver = new ChromeDriver(@"executable-path");
        IWebDriver driver = new ChromeDriver();

        [TestInitialize]
        public void TestSetUp()
        {
            // Er til bilhuset da jeg ikke kan få lov at uploade min data til den rigtige azureapp. Resten er stadig
            // på det dokumenteret i pdfen
            driver.Navigate().GoToUrl("http://bilhuset.azurewebsites.net/");
        }

        [TestMethod]
        public void TestAfCollectEtOrd()
        {
            Thread.Sleep(10);

            IWebElement showButton = driver.FindElement(By.Id("Getallcoins"));
            IWebElement outputElement = driver.FindElement(By.Id("output"));

            showButton.Click();
            string unexpectedOutput = "";
            Assert.AreNotEqual(unexpectedOutput, outputElement.Text);

        }
        public void TestafGetOneCoin()
        {
            Thread.Sleep(10);

            IWebElement showbutton = driver.FindElement(By.Id("Getcoinbyid"));
            IWebElement outputElement = driver.FindElement(By.Id("output"));

            showbutton.Click();
            string unexpectedResult = "";
            Assert.AreNotEqual(unexpectedResult, outputElement.Text);
        }


        [TestCleanup]
        public void TestTearDown()
        {
            driver.Quit();
        }
    }
}
