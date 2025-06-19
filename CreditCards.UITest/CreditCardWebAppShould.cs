using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit.Abstractions;

namespace CreditCards.UITest
{

    public class CreditCardWebAppShould
    {
        private const string HomeUrl = "https://localhost:7014/";
        private const string HomePageTitle = "Home Page - Credit Cards";
        private const string AboutUrl = "https://localhost:7014/Home/About";
        private const string ApplyUrl = "https://localhost:7014/Apply";
        private readonly ITestOutputHelper output;

        private ChromeOptions options;

        public CreditCardWebAppShould(ITestOutputHelper testOutputHelper)
        {
            this.output = testOutputHelper;
            options = new ChromeOptions();
            options.AddArgument("--headless"); // Run in headless mode
        }

        [Fact]
        public void LoadApplicationPage()
        {
            using (IWebDriver driver = new ChromeDriver(options))
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
            using (IWebDriver driver = new ChromeDriver(options))
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
            using (IWebDriver driver = new ChromeDriver(options))
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

        //[Fact]
        //public void SelectButton_NewLowRate()
        //{
        //    using (IWebDriver driver = new ChromeDriver(options))
        //    {
        //        driver.Navigate().GoToUrl(HomeUrl);
        //        DemoHelper.Pause();
        //        IWebElement newLowRateButton = driver.FindElement(By.Name("ApplyLowRate"));
        //        newLowRateButton.Click();
        //        DemoHelper.Pause();

        //        string pageTitle = driver.Title;
        //        Assert.Equal("Credit Card Application - Credit Cards", pageTitle);
        //        Assert.Equal(ApplyUrl, driver.Url);
        //    }
        //}


        //[Fact]
        //public void SelectButton_EasyApplyNow()
        //{
        //    using (IWebDriver driver = new ChromeDriver(options))
        //    {
        //        driver.Navigate().GoToUrl(HomeUrl);
        //        DemoHelper.Pause();
        //        IWebElement carouselNext = driver.FindElement(By.CssSelector("[data-slide='next']"));
        //        carouselNext.Click();
        //        DemoHelper.Pause(1000);
        //        IWebElement easyApplyNowButton = driver.FindElement(By.LinkText("Easy: Apply Now!"));
        //        easyApplyNowButton.Click();
        //        DemoHelper.Pause();

        //        Assert.Equal("Credit Card Application - Credit Cards", driver.Title);
        //        Assert.Equal(ApplyUrl, driver.Url);
        //    }

        //}

        //[Fact]
        //public void SelectButton_CustomerService()
        //{
        //    using (IWebDriver driver = new ChromeDriver(options))
        //    {
        //        driver.Navigate().GoToUrl(HomeUrl);
        //        DemoHelper.Pause();
        //        IWebElement carouselNext = driver.FindElement(By.CssSelector("[data-slide='next']"));
        //        carouselNext.Click();
        //        DemoHelper.Pause(1000);
        //        carouselNext.Click();
        //        DemoHelper.Pause(1000);

        //        IWebElement applyLink = driver.FindElement(By.ClassName("customer-service-apply-now"));
        //        applyLink.Click();
        //        DemoHelper.Pause();

        //        Assert.Equal("Credit Card Application - Credit Cards", driver.Title);
        //        Assert.Equal(ApplyUrl, driver.Url);
        //    }

        //}


        [Fact]
        public void Select_FirstRowInTable()
        {
            using (IWebDriver driver = new ChromeDriver(options))
            {
                driver.Navigate().GoToUrl(HomeUrl);
                DemoHelper.Pause();

                //IWebElement firstTableCell = driver.FindElement(By.CssSelector("table tbody tr:first-child td:first-child"));
                //IWebElement firstTableCell = driver.FindElement(By.TagName("td"));
                IWebElement firstTableCell = driver.FindElement(By.XPath("//table/tbody/tr[1]/td[1]"));


                string firstRowText = firstTableCell.Text;
                Assert.Equal("Easy Credit Card", firstRowText);
            }

        }


        //[Fact]
        //public void SelectButton_EasyApplication_PrebuiltCondition()
        //{
        //    using (IWebDriver driver = new ChromeDriver(options))
        //    {
        //        driver.Navigate().GoToUrl(HomeUrl);
        //        DemoHelper.Pause();

        //        WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(11));
        //        IWebElement applyLink = wait.Until(d => d.FindElement(By.LinkText("Easy: Apply Now!")));
        //        applyLink.Click();

        //        DemoHelper.Pause();
        //        Assert.Equal("Credit Card Application - Credit Cards", driver.Title);
        //        Assert.Equal(ApplyUrl, driver.Url);
        //    }

        //}


        //[Fact]
        //public void SubmitForm_WhenValid()
        //{
        //    using (IWebDriver driver = new ChromeDriver(options))
        //    {
        //        driver.Navigate().GoToUrl(ApplyUrl);
        //        DemoHelper.Pause(2000);

        //        driver.FindElement(By.Id("FirstName")).SendKeys("Erick");
        //        DemoHelper.Pause(1000);
        //        driver.FindElement(By.Id("LastName")).SendKeys("Kurniawan");
        //        DemoHelper.Pause(1000);
        //        driver.FindElement(By.Id("FrequentFlyerNumber")).SendKeys("123456-A");
        //        DemoHelper.Pause(1000);
        //        driver.FindElement(By.Id("Age")).SendKeys("30");
        //        DemoHelper.Pause(1000);
        //        driver.FindElement(By.Id("GrossAnnualIncome")).SendKeys("50000");
        //        DemoHelper.Pause(1000);
        //        driver.FindElement(By.Id("Single")).Click();
        //        IWebElement businessSourceSelectElement = driver.FindElement(By.Id("BusinessSource"));
        //        SelectElement businessSourceSelect = new SelectElement(businessSourceSelectElement);

        //        Assert.Equal("I'd Rather Not Say", businessSourceSelect.SelectedOption.Text);
        //        foreach (IWebElement option in businessSourceSelect.Options)
        //        {
        //            output.WriteLine($"Option: {option.Text}");
        //        }
        //        Assert.Equal(5, businessSourceSelect.Options.Count);

        //        //businessSourceSelect.SelectByValue("Email");
        //        businessSourceSelect.SelectByText("Internet Search");

        //        DemoHelper.Pause(1000);
        //        driver.FindElement(By.Id("TermsAccepted")).Click();

        //        DemoHelper.Pause(1000);
        //        driver.FindElement(By.Id("SubmitApplication")).Submit();

        //        Assert.Equal("Credit Card Application - Credit Cards", driver.Title);

        //        Assert.Equal("ReferredToHuman", driver.FindElement(By.Id("Decision")).Text);

        //        DemoHelper.Pause();


        //    }
        //}


        [Theory]
        //[InlineData("Erick", "Kurniawan", "123456-A", "30", "50000", "Single", "Declined To Comment")]
        //[InlineData("John", "Doe", "654321-B", "28", "50000", "Married", "Email")]
        //[InlineData("Jane", "Smith", "789012-C", "35", "70000", "Single", "Internet")]
        //[InlineData("Alice", "Johnson", "345678-D", "40", "80000", "Married", "Word of Mouth")]
        [ClassData(typeof(TestData.StronglyTypeCreditCardApplyTestData))]
        public void SubmitFormMultiData_RefferToHuman(string firstName, string lastName, string frequentFlyerNumber, string age, string grossAnnualIncome, string maritalStatus, string businessSource)
        {
            using (IWebDriver driver = new ChromeDriver(options))
            {
                driver.Navigate().GoToUrl(ApplyUrl);
                DemoHelper.Pause(2000);

                driver.FindElement(By.Id("FirstName")).SendKeys(firstName);
                DemoHelper.Pause(1000);
                driver.FindElement(By.Id("LastName")).SendKeys(lastName);
                DemoHelper.Pause(1000);
                driver.FindElement(By.Id("FrequentFlyerNumber")).SendKeys(frequentFlyerNumber);
                DemoHelper.Pause(1000);
                driver.FindElement(By.Id("Age")).SendKeys(age);
                DemoHelper.Pause(1000);
                driver.FindElement(By.Id("GrossAnnualIncome")).SendKeys(grossAnnualIncome);
                DemoHelper.Pause(1000);
                driver.FindElement(By.Id(maritalStatus)).Click();
                IWebElement businessSourceSelectElement = driver.FindElement(By.Id("BusinessSource"));
                SelectElement businessSourceSelect = new SelectElement(businessSourceSelectElement);

                businessSourceSelect.SelectByValue(businessSource);
                //businessSourceSelect.SelectByText(businessSource);

                DemoHelper.Pause(1000);
                driver.FindElement(By.Id("TermsAccepted")).Click();

                DemoHelper.Pause(1000);
                driver.FindElement(By.Id("SubmitApplication")).Submit();

                DemoHelper.Pause(2000);

                Assert.Equal("ReferredToHuman", driver.FindElement(By.Id("Decision")).Text);
            }
        }

        [Fact]
        public void AlertIfLiveChatClose()
        {
            using (IWebDriver driver = new ChromeDriver(options))
            {
                driver.Navigate().GoToUrl(HomeUrl);
                driver.FindElement(By.Id("LiveChat")).Click();

                WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
                // Replace the deprecated ExpectedConditions usage with a custom wait for alert
                IAlert alert = wait.Until(driver =>
                {
                    try
                    {
                        return driver.SwitchTo().Alert();
                    }
                    catch (NoAlertPresentException)
                    {
                        return null;
                    }
                });
                Assert.Equal("Live chat is currently closed.", alert.Text);

                DemoHelper.Pause();

                alert.Accept(); // Accept the alert to close it
                DemoHelper.Pause();
            }
        }


        [Fact]
        public void AlertAcceptOrDismiss()
        {
            using (IWebDriver driver = new ChromeDriver(options))
            {
                driver.Navigate().GoToUrl(HomeUrl);
                driver.FindElement(By.Id("LearnAboutUs")).Click();

                WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
                // Replace the deprecated ExpectedConditions usage with a custom wait for alert
                IAlert alert = wait.Until(driver =>
                {
                    try
                    {
                        return driver.SwitchTo().Alert();
                    }
                    catch (NoAlertPresentException)
                    {
                        return null;
                    }
                });
                Assert.Equal("Do you want to learn more about us?", alert.Text);

                DemoHelper.Pause();

                alert.Dismiss();
                //alert.Accept(); // Accept the alert to close it
                DemoHelper.Pause();
            }
        }

        [Fact]
        public void ClickOverlayedLink()
        {
            using (IWebDriver driver = new ChromeDriver(options))
            {
                driver.Navigate().GoToUrl("https://localhost:7014/jsoverlay.html");

                DemoHelper.Pause();

                string script = "document.getElementById('HiddenLink').click();";
                IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
                js.ExecuteScript(script);

                //driver.FindElement(By.Id("HiddenLink")).Click();

                DemoHelper.Pause();

                Assert.Equal("https://www.selenium.dev/", driver.Url);
            }
        }


        [Fact]
        public void GetOverlayedLinkText()
        {
            using (IWebDriver driver = new ChromeDriver(options))
            {
                driver.Navigate().GoToUrl("https://localhost:7014/jsoverlay.html");

                DemoHelper.Pause();

                string script = "return document.getElementById('HiddenLink').innerHTML;";

                IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
                string linkText = (string)js.ExecuteScript(script);

                Assert.Equal("Go to Selenium Web Page", linkText);
            }
        }




    }
}

