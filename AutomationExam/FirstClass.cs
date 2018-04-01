using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using OpenQA.Selenium.Chrome;
using NUnit.Framework;
using System.Collections.ObjectModel;
using OpenQA.Selenium.Support.UI;
using System.Threading;

namespace AutomationExam
{
    public class FirstClass
    {
        IWebDriver driver = new ChromeDriver();
        

        [Test]
        public void SearchShoes()
        {
            //WebDriverWait wait = new WebDriverWait(driver, new TimeSpan(0, 0, 5));
            List<Product> searchResults = new List<Product>();

            driver.Navigate().GoToUrl("https://www.ebay.com/");
            driver.Manage().Window.Maximize();

            driver.FindElement(By.CssSelector("#gh-ac")).SendKeys("shoes");
            driver.FindElement(By.CssSelector("#gh-btn")).Submit();

            driver.FindElement(By.CssSelector("input[aria-label='PUMA']")).Click();
            driver.FindElement(By.CssSelector("input[id='e1-27']")).Click();

            string totalResults = driver.FindElement(By.ClassName("rcnt")).Text;
            Console.Write("Total Results: " + totalResults + "\n");

            driver.FindElement(By.CssSelector("a[aria-labelledby='e1-1']")).Click();
            Thread.Sleep(2000);
            driver.FindElement(By.CssSelector("#SortMenu")).FindElement(By.CssSelector("a[value='15']")).Click();

            IEnumerable<IWebElement> fiveFirstResults = driver.FindElement(By.CssSelector("#GalleryViewInner")).FindElements(By.CssSelector("li")).Take(5);
            searchResults = Product.ToProductList(fiveFirstResults);

            int index = 0;
            foreach (Product item in searchResults)
            {
                Assert.AreEqual(item.Name, listComparsion[index]);
                Console.Write("Product " + index++ + ": " + "| Name: " + item.Name + "| Price: " + item.Price + "\n");                
            }

            //Ascendat by name
            var ascendingSort = searchResults.OrderBy(x => x.Name);
            Console.Write("\nAscendat by Name: \n");
            foreach (Product item in ascendingSort)
            {
                Console.Write("Name: " + item.Name + "| Price: " + item.Price + "\n");
                index++;
            }

            //Descendant by price
            var descendingSort = searchResults.OrderByDescending(x => x.Price);
            Console.Write("\nDescendant by Price: \n");
            foreach (Product item in descendingSort)
            {
                Console.Write("Name: " + item.Name + "| Price: " + item.Price + "\n");
                index++;
            }


        }

        public List<string> listComparsion = new List<string>{
            "Puma Para hombres Atlético Sandalias Ojotas de espuma negra Talla 10 & Bolsa",
            "Zapatillas de hombre Puma Stepper X quemar caucho Castlerock Cantera nos griego 10 M",
            "Nuevo Puma Para hombres ketava Duo Sandalias Flip Flop DP - 903",
            "Para Hombre Puma aspecto deportivo tenis Evospeed",
            "Zapatillas para hombre aspecto deportivo Puma Evospeed"
        };

        //public List<string> listComparsion = new List<string>{
        //    "PUMA Men's Flip Flops Athletic Sandals Black Foam Size 10 & Bag",
        //    "Puma Mens Sneakers Stepper X Burn Rubber Castlerock Quarry Greek US 10 M",
        //    "NEW Puma Men's Ketava Duo Dp Flip Flops Thong Sandals - 903",
        //    "Mens Puma Sporty Look Trainers Evospeed",
        //    "Mens Puma Sporty Look Trainers Evospeed"
        //};

    }
}