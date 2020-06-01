using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VcsWebdriver.Pages;

namespace VcsWebdriver.Tests
{
    class SeleniumCheckBoxPageObject 
    {
        public static SeleniumCheckBoxPage _driver;

        [OneTimeSetUp]
        public static void SetUpChrome()
        {
            var driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);

            _driver = new SeleniumCheckBoxPage(driver);
        }
        [Order(1)]
        [TestCase(true, "Success - Check box is checked", TestName = "Pazymime varnele ir patikriname uzrasa")]
        public static void EnterMessageTest(bool pazymeta, string tiketinasUzrasas)
        {
            _driver
                .VarnelesLaukas(pazymeta)
                .TikrintiRezultata(tiketinasUzrasas);
        }
        [Order(2)]
        [TestCase(true, "Uncheck All", TestName = "Pazymime visas varneles, patikriname kad mygtukas pakeicia pavadinima")]

        public static void PazymetiVisasVarneles(bool pazymeti, string tiketinasUzrasas)
        {
            _driver
                .VarnelesLaukai(pazymeti)
                .PatikrinameRezultata(tiketinasUzrasas);
        }

        [Order(3)]
        [TestCase(false, TestName = "Paslaudziame Uncheck all, patikriname kad visos varneles atzymetos")]
        public static void PatikrintiKadVarnelesAtzymetos(bool atzymetiLaukai)
        {
            _driver
                .AtzymetiLaukai(atzymetiLaukai);
                
        }



        [OneTimeTearDown]
        public static void CloseBrowser()
        {
            _driver.CloseBrowser();
        }

    }
}
