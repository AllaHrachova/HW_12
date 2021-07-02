using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Collections.Generic;


namespace HW_12
{
    public class Tests
    {
        IWebDriver driver = new ChromeDriver(@"E:\Testing automation course\chromedriver_win32");

        [SetUp]
        public void OpenGisMeteo()
        {
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl("https://gismeteo.ua");
        }

        [Test, Order(1)]
        public void FindDivElements()
        {
            IList<IWebElement> divElements = driver.FindElements(By.TagName("div"));
            Assert.That(divElements.Count, Is.EqualTo(277));
        }

        [Test, Order(2)]
        public void FindNewsItems()
        {
            IList<IWebElement> newsItems = driver.FindElements(By.ClassName("readmore_item"));
            Assert.That(newsItems.Count, Is.EqualTo(4)); 
        }

        [Test, Order(3)]
        public void FindLastCitySpan()
        {
            IWebElement lastCity = driver.FindElement(By.XPath("//div[@class='cities_list']//div[@class='cities_item'][last()]"));
            Assert.That(lastCity.Text, Is.EqualTo("Чернигов"));
        }

        [Test, Order(4)]
        public void FindTitles()
        {
            IList<IWebElement> titlesH3 = driver.FindElements(By.TagName("h3"));
            IList<IWebElement> titlesH4 = driver.FindElements(By.TagName("h4"));
            IList<IWebElement> titlesH5 = driver.FindElements(By.TagName("h5"));
            IList<IWebElement> titlesH6 = driver.FindElements(By.TagName("h6"));
            int i = titlesH3.Count + titlesH4.Count + titlesH5.Count + titlesH6.Count;
            Assert.That(i, Is.EqualTo(2));
        }

        [Test, Order(5)]
        public void FindTexKiev()
        {
            IWebElement textKiev = driver.FindElement(By.XPath("//*[@class='cities_name'and text() = 'Киев']"));
            Assert.That(textKiev.Text, Is.EqualTo("Киев"));
        }

        [Test, Order(6)]
        public void FindNextToKiev()
        {
            IWebElement nextToKiev = null;
            IList<IWebElement> Cities = driver.FindElements(By.XPath("//*[@class='cities_name']"));
            for (int i=0; i < Cities.Count; i++)
            {
                if (Cities[i].Text == "Киев")
                {
                    nextToKiev = (Cities[i + 1]);
                }
            }
            Assert.That(nextToKiev.Text, Is.EqualTo("Кривой Рог"));
        }

        [Test, Order(7)]
        public void FindAllTopMenuLinks()
        {
            IList<IWebElement> topMenuLinks = driver.FindElements(By.XPath("//*[@class='nav_item']"));
            Assert.That(topMenuLinks.Count, Is.EqualTo(4));
        }

        [Test, Order(8)]
        public void NavigateToKharkivPage()
        {
            driver.Navigate().GoToUrl("https://www.gismeteo.ua/weather-kharkiv-5053/");
        }

        [Test, Order(9)]
        public void FindThreeWeekdays()
        {
            driver.Navigate().GoToUrl("https://www.gismeteo.ua/weather-kharkiv-5053/");
            IList<IWebElement> threeWeekdays = driver.FindElements(By.XPath("//div[@class='tabs _center']"));
            Assert.That(threeWeekdays.Count, Is.EqualTo(1));
        }

        [Test, Order(10)]
        public void FindCurrentlySelectedWeekday()
        {
            driver.Navigate().GoToUrl("https://www.gismeteo.ua/weather-kharkiv-5053/");
            IWebElement currentlySelectedWeekday = driver.FindElement(By.XPath("//div[@class='tab  tooltip']//div[@class='tab_wrap']"));
            Assert.That(currentlySelectedWeekday.Text, Does.Contain("Сегодня"));
        }

        [Test, Order(11)]
        public void FindCurrentlySelectedWeekdayTemperatures()
        {
            driver.Navigate().GoToUrl("https://www.gismeteo.ua/weather-kharkiv-5053/");
            IList<IWebElement> temperatures = driver.FindElements(By.XPath("//div[@class='tab  tooltip']//*[@class='unit unit_temperature_c']"));
            Assert.That(temperatures.Count, Is.EqualTo(2));
        }

        [Test, Order(12)]
        public void FindDivElementsCss()
        {
            IList<IWebElement> divElements = driver.FindElements(By.CssSelector("div"));
            Assert.That(divElements.Count, Is.EqualTo(277));
        }

        [Test, Order(13)]
        public void FindNewsItemsCss()
        {
            IList<IWebElement> newsItems = driver.FindElements(By.CssSelector(".readmore_item"));
            Assert.That(newsItems.Count, Is.EqualTo(4));
        }

        [Test, Order(14)]
        public void FindLastCitySpanCss()
        {
             IWebElement lastCity = driver.FindElement(By.CssSelector(".cities_list> .cities_item:last-child"));
             Assert.That(lastCity.Text, Is.EqualTo("Чернигов"));
        }

        [Test, Order(15)]
        public void FindTitlesCss()
        {
            IList<IWebElement> titlesH3 = driver.FindElements(By.CssSelector("h3"));
            IList<IWebElement> titlesH4 = driver.FindElements(By.CssSelector("h4"));
            IList<IWebElement> titlesH5 = driver.FindElements(By.CssSelector("h5"));
            IList<IWebElement> titlesH6 = driver.FindElements(By.CssSelector("h6"));
            int i = titlesH3.Count + titlesH4.Count + titlesH5.Count + titlesH5.Count;
            Assert.That(i, Is.EqualTo(2));
        }

        [Test, Order(16)]
        public void FindTexKievCss()
        {
            IWebElement textKiev = driver.FindElement(By.CssSelector("div.cities_item > a[href*='kyiv']"));
            Assert.That(textKiev.Text, Is.EqualTo("Киев"));
        }

        [Test, Order(17)]
        public void FindNextToKievCSS()
        {
            IWebElement nextToKiev = null;
            IList<IWebElement> Cities = driver.FindElements(By.CssSelector(".cities_name"));
            for (int i = 0; i < Cities.Count; i++)
            {
                if (Cities[i].Text == "Киев")
                {
                    nextToKiev = (Cities[i + 1]);
                }
            }
            Assert.That(nextToKiev.Text, Is.EqualTo("Кривой Рог"));
        }

        [Test, Order(18)]
        public void FindAllTopMenuLinkCss()
        {
            driver.Navigate().GoToUrl("https://www.gismeteo.ua/weather-kharkiv-5053/");
            IList<IWebElement> topMenuLinks = driver.FindElements(By.CssSelector("[class|='nav_item'] > a"));
            Assert.That(topMenuLinks.Count, Is.EqualTo(4));
        }

        [Test, Order(19)]
        public void NavigateToKharkivPageCss()
        {
            driver.Navigate().GoToUrl("https://www.gismeteo.ua/weather-kharkiv-5053/");
        }

        [Test, Order(20)]
        public void FindThreeWeekdaysCss()
        {
            driver.Navigate().GoToUrl("https://www.gismeteo.ua/weather-kharkiv-5053/");
            IList<IWebElement> threeWeekdays = driver.FindElements(By.CssSelector(".center"));
            Assert.That(threeWeekdays.Count, Is.EqualTo(1));
        }

        [Test, Order(20)]
        public void FindCurrentlySelectedWeekdayCss()
        {
            driver.Navigate().GoToUrl("https://www.gismeteo.ua/weather-kharkiv-5053/");
            IWebElement currentlySelectedWeekday = driver.FindElement(By.CssSelector(" div.tab > .tab_wrap"));
            Assert.That(currentlySelectedWeekday.Text, Does.Contain("Сегодня"));
        }

        [Test]
        public void FindCurrentlySelectedWeekdayTemperaturesCss()
        {
            driver.Navigate().GoToUrl("https://www.gismeteo.ua/weather-kharkiv-5053/");
            IList<IWebElement> Temperatures = driver.FindElements(By.CssSelector("div.tab.tooltip span.unit_temperature_c"));
            Assert.That(Temperatures.Count, Is.EqualTo(2));
        }

        [OneTimeTearDown]
        public void TearDown()
        {
            driver.Close();
            driver.Quit();
            driver.Dispose();
        }
    }
}