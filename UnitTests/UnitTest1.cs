using System;
using System.Collections;
using System.Collections.Specialized;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using StaemDatabaseApp.Model;

namespace UnitTests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            Assert.AreEqual(0, 0);
        }

        [TestMethod]
        public void constructorTests()
        {
            // Dane Customera | -> error
            // id ->  auto(0)
            // priceMultiplier-> 1.00f
            // gamesBought -> 0
            // name, surname
            Customer correctCustomer = new Customer("1", "name", "surname", "0.89", "100");
            // Sprawdzenie czy te same dane
            Assert.IsTrue(correctCustomer.Id == 1 &&
                            correctCustomer.Name.Equals("name") &&
                            correctCustomer.Surname.Equals("surname") &&
                            correctCustomer.PriceMultiplier == 0.89f &&
                            correctCustomer.GamesBought == 100
                );
            Customer customer1 = new Customer("1", "name", "surname", "tekst", "100");
            Assert.IsTrue(customer1.Id == 1 &&
                            customer1.Name.Equals("name") &&
                            customer1.Surname.Equals("surname") &&
                            customer1.PriceMultiplier == 1.00f &&
                            customer1.GamesBought == 100
                );
            Customer customer2 = new Customer("1", "name", "surname", "0.89", "tekst");
            Assert.IsTrue(customer2.Id == 1 &&
                            customer2.Name.Equals("name") &&
                            customer2.Surname.Equals("surname") &&
                            customer2.PriceMultiplier == 0.89f &&
                            customer2.GamesBought == 0
                );
            Customer customer3 = new Customer("1", "name", "surname", "tekst", "tekst");
            Assert.IsTrue(customer3.Id == 1 &&
                            customer3.Name.Equals("name") &&
                            customer3.Surname.Equals("surname") &&
                            customer3.PriceMultiplier == 1.00f &&
                            customer3.GamesBought == 0
                );

        }
    }
}
