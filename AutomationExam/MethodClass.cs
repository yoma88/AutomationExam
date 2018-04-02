using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web;

namespace AutomationExam
{
    public class MethodClass
    {
        public static IWebDriver Driver;

        public static void InitializePage(IWebDriver driver)
        {
            Driver = driver;            
        }

        public static void GoToPage()
        {
            Driver.Navigate().GoToUrl("https://www.ebay.com/");
            Driver.Manage().Window.Maximize();
        }

        public static void SearchShoes()
        {
            Driver.FindElement(By.CssSelector("#gh-ac")).SendKeys("shoes");
            Driver.FindElement(By.CssSelector("#gh-btn")).Submit();
        }

        public static void FilterByBrand()
        {
            Driver.FindElement(By.CssSelector("input[aria-label='PUMA']")).Click();
        }

        public static void FilterBySize()
        {
            Driver.FindElement(By.CssSelector("input[id='e1-27']")).Click();
        }

        public static void GeTotalResults()
        {
            string totalResults = Driver.FindElement(By.ClassName("rcnt")).Text;
            Console.Write("Total Results: " + totalResults + "\n");
        }

        public static void OrderResultsAscendant()
        {
            Driver.FindElement(By.CssSelector("a[aria-labelledby='e1-1']")).Click();
            Thread.Sleep(2000);
            Driver.FindElement(By.CssSelector("#SortMenu")).FindElement(By.CssSelector("a[value='15']")).Click();
        }

        public static List<Product> GetResultsToCompare()
        {
            List<Product> searchResults = new List<Product>();
            IEnumerable<IWebElement> fiveFirstResults = Driver.FindElement(By.CssSelector("#GalleryViewInner")).FindElements(By.CssSelector("li")).Take(5);
            searchResults = Product.ToProductList(fiveFirstResults);

            int index = 0;
            foreach (Product item in searchResults)
            {
                Assert.AreEqual(item.Name, listComparsion[index]);
                Console.Write("Product " + index++ + ": " + "| Name: " + item.Name + "| Price: " + item.Price + "\n");
            }

            return searchResults;
        }

        public static void SortAscendingByName(List<Product> searchResults)
        {
            int index = 0;
            var ascendingSort = searchResults.OrderBy(x => x.Name);
            Console.Write("\nAscendat by Name: \n");
            foreach (Product item in ascendingSort)
            {
                Console.Write("Name: " + item.Name + "| Price: " + item.Price + "\n");
                index++;
            }
        }

        public static void SortDescendingByPrice(List<Product> searchResults)
        {
            int index = 0;
            var descendingSort = searchResults.OrderByDescending(x => x.Price);
            Console.Write("\nDescendant by Price: \n");
            foreach (Product item in descendingSort)
            {
                Console.Write("Name: " + item.Name + "| Price: " + item.Price + "\n");
                index++;
            }
        }

        public static List<string> listComparsion = new List<string>{
            "Puma Para hombres Atlético Sandalias Ojotas de espuma negra Talla 10 & Bolsa",
            "Zapatillas de hombre Puma Stepper X quemar caucho Castlerock Cantera nos griego 10 M",
            "Nuevo Puma Para hombres ketava Duo Sandalias Flip Flop DP - 903",
            "Para Hombre Puma aspecto deportivo tenis Evospeed",
            "Zapatillas para hombre aspecto deportivo Puma Evospeed"
        };

        /*
        //public List<string> listComparsion = new List<string>{
        //    "PUMA Men's Flip Flops Athletic Sandals Black Foam Size 10 & Bag",
        //    "Puma Mens Sneakers Stepper X Burn Rubber Castlerock Quarry Greek US 10 M",
        //    "NEW Puma Men's Ketava Duo Dp Flip Flops Thong Sandals - 903",
        //    "Mens Puma Sporty Look Trainers Evospeed",
        //    "Mens Puma Sporty Look Trainers Evospeed"
        //};
        */
    }
}