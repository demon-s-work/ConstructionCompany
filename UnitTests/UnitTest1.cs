using System;
using System.Collections;
using System.Collections.Specialized;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using StaemDatabaseApp.Model;

namespace UnitTests
{
    [TestClass]
    public class constructorTests
    {

        [TestMethod]
        public void customerTests()
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

        [TestMethod]
        public void DeveloperTests()
        {
            Developer d1 = new Developer( "1", "name", "contact" );
            Developer d2 = new Developer( "a", "name", "contact" );

            Assert.IsTrue(d1.Id == 1 &&
                            d1.Name.Equals("name") &&
                            d1.Contact.Equals("contact")
                );
            Assert.IsTrue(d2.Id == 0 &&
                            d2.Name.Equals("name") &&
                            d2.Contact.Equals("contact")
                );
        }

        [TestMethod]
        public void SupplierTests()
        {
            Supplier s1 = new Supplier("1", "name", "address", "contact");
            Supplier s2 = new Supplier("a", "name", "address", "contact");

            Assert.IsTrue(s1.Id == 1 &&
                           s1.Name.Equals("name") &&
                           s1.Address.Equals("address") &&
                           s1.Contact.Equals("contact")
               );
            Assert.IsTrue(s2.Id == 0 &&
                           s2.Name.Equals("name") &&
                           s2.Address.Equals("address") &&
                           s2.Contact.Equals("contact")
               );
        }

        [TestMethod]
        public void StatusTests()
        {
            Status s1 = new Status("1", "name", "description", "0.98");
            Status s2 = new Status("2", "name", "description", "asd");

            Assert.IsTrue(s1.Id == 1 &&
                           s1.Name.Equals("name") &&
                           s1.Description.Equals("description") &&
                           s1.PriceMultiplier == 0.98f
               );
            Assert.IsTrue(s2.Id == 2 &&
                           s2.Name.Equals("name") &&
                           s2.Description.Equals("description") &&
                           s2.PriceMultiplier == 1.00f
               );
        }
    }
}
