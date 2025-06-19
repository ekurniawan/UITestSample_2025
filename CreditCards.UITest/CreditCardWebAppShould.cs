using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreditCards.UITest
{

    public class CreditCardWebAppShould
    {
        private const string HomeUrl = "https://localhost:7014/";
        private const string HomePageTitle = "Home Page - Credit Cards";
        private const string AboutUrl = "https://localhost:7014/Home/About";
        private const string ApplyUrl = "https://localhost:7014/Apply";

        [Fact]
        public void LoadApplicationPage()
        {
            using (IWebDriver driver = new ChromeDriver())
            {
                driver.Navigate().GoToUrl("https://localhost:7014/");

                DemoHelper.Pause();

                string pageTitle = driver.Title;

                Assert.Equal("Home Page - Credit Cards", pageTitle);
            }
        }
        [Fact]
        public void ReloadHomePage()
        {
            using (IWebDriver driver = new ChromeDriver())
            {
                driver.Navigate().GoToUrl(HomeUrl);
                DemoHelper.Pause();

                driver.Navigate().Refresh();

                DemoHelper.Pause();

                string pageTitle = driver.Title;
                Assert.Equal(HomePageTitle, pageTitle);
                Assert.Equal(HomeUrl, driver.Url);
            }
        }
        [Fact]
        public void ReloadHomePageOnBack()
        {
            using (IWebDriver driver = new ChromeDriver())
            {
                driver.Navigate().GoToUrl(HomeUrl);
                DemoHelper.Pause();
                driver.Navigate().GoToUrl(AboutUrl);
                DemoHelper.Pause();
                driver.Navigate().Back();
                DemoHelper.Pause();
                string pageTitle = driver.Title;
                Assert.Equal(HomePageTitle, pageTitle);
                Assert.Equal(HomeUrl, driver.Url);

                string reloadedToken = driver.FindElement(By.Id("GenerationToken")).Text;
                Assert.NotEqual(string.Empty, reloadedToken);
            }
        }

        [Fact]
        public void SelectButton_NewLowRate()
        {
            using (IWebDriver driver = new ChromeDriver())
            {
                driver.Navigate().GoToUrl(HomeUrl);
                DemoHelper.Pause();
                IWebElement newLowRateButton = driver.FindElement(By.Name("ApplyLowRate"));
                newLowRateButton.Click();
                DemoHelper.Pause();

                string pageTitle = driver.Title;
                Assert.Equal("Credit Card Application - Credit Cards", pageTitle);
                Assert.Equal(ApplyUrl, driver.Url);
            }
        }


        [Fact]
        public void SelectButton_EasyApplyNow()
        {
            using (IWebDriver driver = new ChromeDriver())
            {
                driver.Navigate().GoToUrl(HomeUrl);
                DemoHelper.Pause();
                IWebElement carouselNext = driver.FindElement(By.CssSelector("[data-slide='next']"));
                carouselNext.Click();
                DemoHelper.Pause(1000);
                IWebElement easyApplyNowButton = driver.FindElement(By.LinkText("Easy: Apply Now!"));
                easyApplyNowButton.Click();
                DemoHelper.Pause();

                Assert.Equal("Credit Card Application - Credit Cards", driver.Title);
                Assert.Equal(ApplyUrl, driver.Url);
            }

        }

        [Fact]
        public void SelectButton_CustomerService()
        {
            using (IWebDriver driver = new ChromeDriver())
            {
                driver.Navigate().GoToUrl(HomeUrl);
                DemoHelper.Pause();
                IWebElement carouselNext = driver.FindElement(By.CssSelector("[data-slide='next']"));
                carouselNext.Click();
                DemoHelper.Pause(1000);
                carouselNext.Click();
                DemoHelper.Pause(1000);

                IWebElement applyLink = driver.FindElement(By.ClassName("customer-service-apply-now"));
                applyLink.Click();
                DemoHelper.Pause();

                Assert.Equal("Credit Card Application - Credit Cards", driver.Title);
                Assert.Equal(ApplyUrl, driver.Url);
            }

        }

    }
}
