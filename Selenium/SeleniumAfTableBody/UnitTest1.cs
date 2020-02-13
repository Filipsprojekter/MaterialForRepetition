using System.Threading;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace SeleniumTestAfTableBody
{
    [TestClass]
    public class UnitTest1
    {
        IWebDriver driver = new ChromeDriver(@"C:\Users\fdh_0\Documents\EksamensForbederelse\chromedriver_win32");

        [TestInitialize]
        public void Setup()
        {
            driver.Navigate().GoToUrl("localhost:3000");
        }
        [TestMethod]
        public void TestMethod1()
        {
            Thread.Sleep(10);

            IWebElement tableElement = driver.FindElement(By.Id("tbody"));
            IWebElement clickButton = driver.FindElement(By.Id("Getall"));

            clickButton.Click();
            Thread.Sleep(3000);
            string unexpectedOutput = "";
            Assert.AreNotEqual(unexpectedOutput, tableElement.Text);
        }

        [TestCleanup]
        public void CleanUp()
        {
            driver.Close();
        }
    }
}
