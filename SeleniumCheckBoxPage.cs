using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VcsWebdriver.Pages
{
    class SeleniumCheckBoxPage : PageBase

    {
        private IWebElement varnelesLaukas => Driver.FindElement(By.Id("isAgeSelected"));
        private IWebElement varnelesLaukoRezultatas => Driver.FindElement(By.Id("txtAge"));
        private ReadOnlyCollection<IWebElement> varnelesLaukai => Driver.FindElements(By.XPath("//*[@id='easycont']/div/div[2]/div[2]/div[2]/div/label/input"));
        private IWebElement mygtukolangelis => Driver.FindElement(By.Id("check1"));
        
        public SeleniumCheckBoxPage(IWebDriver inputDriver) : base(inputDriver)
        {
            Driver.Url = "https://www.seleniumeasy.com/test/basic-checkbox-demo.html";
        }

        public SeleniumCheckBoxPage VarnelesLaukas(bool pazymeta)
        {
            if (varnelesLaukas.Selected != pazymeta)
                varnelesLaukas.Click();

            return this;
        }
        public void TikrintiRezultata(string tiketinasUzrasas)
        {
            string zinute = varnelesLaukoRezultatas.Text;
            Assert.AreEqual(tiketinasUzrasas, zinute, "Uzrasas nesutrampa");
            varnelesLaukas.Click();
        }

        public SeleniumCheckBoxPage VarnelesLaukai(bool pazymeti)
        {
            foreach (var laukas in varnelesLaukai)
            {
                if (laukas.Selected != pazymeti)
                    laukas.Click();
            }
            return this;
        }
       

        public void PatikrinameRezultata(string tiketinasUzrasas)
        {
            
            string message = mygtukolangelis.GetAttribute("value");
            Assert.AreEqual(tiketinasUzrasas, message, "Uzrasas nesutampa");
        }


        public SeleniumCheckBoxPage AtzymetiLaukai(bool atzymetiLaukai)
        {
            mygtukolangelis.Click();
            foreach (var laukas in varnelesLaukai)
            {
                if (laukas.Selected != atzymetiLaukai)
                    laukas.Click();
            }
            Assert.False(atzymetiLaukai, "Laukai neatzymeti");

            return this;
        }


    }
}
