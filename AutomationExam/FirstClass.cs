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
        public void TestCaseExam()
        {
            MethodClass.InitializePage(driver);

            MethodClass.GoToPage();

            //search shoes
            MethodClass.SearchShoes();

            //filter by brand and size
            MethodClass.FilterByBrand();
            MethodClass.FilterBySize();

            //get total results
            MethodClass.GeTotalResults();

            //order ascendant 
            MethodClass.OrderResultsAscendant();

            //get resuts to compare
            var searchResults = MethodClass.GetResultsToCompare();

            //Ascendat by name
            MethodClass.SortAscendingByName(searchResults);

            //Descendant by price
            MethodClass.SortDescendingByPrice(searchResults);            
        }
        
    }
}