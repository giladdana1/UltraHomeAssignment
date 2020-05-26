using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;


namespace UltraHomeAssignment
{
    [TestFixture]
    public class Tests
    {
        IWebDriver driver;
        [OneTimeSetUp]
        public void Setup()
        {
            driver = new ChromeDriver(); 
            driver.Url = "https://www.facebook.com/";
            driver.Manage().Window.Maximize();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            IWebElement loginbutton = driver.FindElement(By.Id("u_0_b"));
            IWebElement email = driver.FindElement(By.Id("email"));
            IWebElement password = driver.FindElement(By.Id("pass"));
            //here you should insert your username and password
            email.SendKeys("my email CHANGEME");
            password.SendKeys("my password CHANGEME");
            loginbutton.Click(); 

        }
        //this test value should have your name as it appears in the profile next to your picture
        [TestCase("Gilad")]
        //invalid data should fail
        [TestCase("1234")]
        [TestCase("!#$!#")]
        [TestCase("Amit")]
        public void CheckedLoggedIn(String name)
        {
            IWebElement userName = driver.FindElement(By.XPath("//*[@id='mount_0_0']/div/div/div[2]/div[4]/div[1]/div[1]/a/span"));          
            Assert.AreEqual(userName.Text, name);
        }
        //first value is the name you search for, second value is the profile name
        [TestCase("gilad dana","Gilad Dana")]
        //invalid data should fail
        [TestCase("amit udai", "Amit Udai")]
        [TestCase("1234", "1234")]
        [TestCase("","")]
        [TestCase("!@$!@%$","!@$!@%$")]
        public void Search(String name, String profileName)
        {
            IWebElement search = driver.FindElement(By.XPath("//*[@id='mount_0_0']/div/div/div[2]/div[2]/div/div/div/div/div[3]/label/input"));
            search.SendKeys(name.ToLower());
            String searchValue = "//*[@id=" + "'" +  name + "'" + "]";
            IWebElement searchButton = driver.FindElement(By.XPath(searchValue));
            searchButton.Click();
            IWebElement userProfile = driver.FindElement(By.CssSelector("#mount_0_0 > div > div > div.rq0escxv.l9j0dhe7.du4w35lb > div > div > div.j83agx80.cbu4d94t.d6urw2fd.dp1hu0rb.l9j0dhe7.du4w35lb > div > div.rq0escxv.l9j0dhe7.du4w35lb.j83agx80.cbu4d94t.d2edcug0.rj1gh0hx.buofh1pr.g5gj957u.hpfvmrgz.dp1hu0rb > div > div > div > div > div > div > div:nth-child(1) > div > div > div > div > div > div > div > div > div > div.hpfvmrgz.g5gj957u.buofh1pr.rj1gh0hx.o8rfisnq > div > div:nth-child(1) > span > div > a"));
            Assert.AreEqual(userProfile.Text, profileName);
        }

        //validating the date of birth as it appears in the "about contact and basic info url"
        //you should insert here your name as it appears in the about url , and date of birth and it should pass
        [TestCase("gilad.dana","April 29")]
        //invalid date should fail
        [TestCase("gilad.dana","29 April")]
        [TestCase("gilad.dana","")]
        public void ValidateBirthDate(String accountName, String birthDate)
        {
            IWebElement userName = driver.FindElement(By.XPath("//*[@id='mount_0_0']/div/div/div[2]/div[4]/div[1]/div[1]/a/span"));
            userName.Click();
            driver.Url = "https://www.facebook.com/" + accountName + "/about/";
            driver.Url = "https://www.facebook.com/" + accountName + "/about_contact_and_basic_info/";
            IWebElement dateOfBirth = driver.FindElement(By.XPath("//*[@id='mount_0_0']/div/div/div[3]/div/div/div[1]/div/div/div/div[4]/div/div[1]/div/div/div/div[2]/div/div/div[3]/div[6]/div/div/div[1]/div/div[2]/div[1]/div[1]/div/div/div[1]/span"));
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            js.ExecuteScript("arguments[0].scrollIntoView(true);", dateOfBirth);
            Assert.AreEqual(dateOfBirth.Text, birthDate);
        }
       
        [OneTimeTearDown]
        public void TearDown()
        {
             driver.Close();
        }

    }
}