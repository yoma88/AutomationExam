using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Web;

namespace AutomationExam
{
    public class Product
    {
        public int Order { get; set; }
        public float Price { get; set; }
        public string Name { get; set; }
        //nueva

        public static List<Product> ToProductList(IEnumerable<IWebElement> list)
        {
            List<Product> products = new List<Product>();
            int nro = 0;
            foreach (var item in list)
            {
                Product productResult = new Product();
                productResult.Order = nro;
                productResult.Name = item.FindElement(By.ClassName("imgWr")).FindElement(By.CssSelector("img")).GetAttribute("alt");
                string price = item.FindElement(By.ClassName("gvprices")).FindElements(By.CssSelector("span")).First().Text.Replace('.',',').Remove(0,4);
                productResult.Price = float.Parse(price);
                products.Add(productResult);
                nro++;
            }
            
            return products;
        }

    }
}