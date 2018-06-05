using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace CustomerMaintenance
{
    [TestFixture]
    class ProductTests
    {
        [SetUp]
        public void SetUpTests()
        {

        }

        [Test, Order(1)]
        public void TestConstructors()
        {
            Product p = new Product();
            p.ProductCode = "XYZ1      ";
            p.Description = "test product 1";
            p.Price = 15.00m;
            p.OnHandQuantity = 10;
            Assert.IsTrue(p.ProductCode == "XYZ1      ");
            Assert.IsTrue(p.Description == "test product 1");
            Assert.IsTrue(p.Price == 15.00m);
            Assert.IsTrue(p.OnHandQuantity == 10);
        }

        // Tests to see if the method GetProduct() is actually returning data from the database.
        [Test, Order(3)]
        public void TestGetProduct()
        {
            Product p = ProductDB.GetProduct("XYZ1");
            Assert.IsTrue(p != null);
        }

        // Tests to see if the method UpdateProduct() is actually altering the product record in the database.
        [Test, Order(4)]
        public void TestUpdateProduct()
        {
            Product p = new Product();
            p.ProductCode = "XYZ1      ";
            p.Description = "test product 1";
            p.Price = 15.00m;
            p.OnHandQuantity = 10;

            Product updatedP = new Product();
            updatedP.ProductCode = "XYZ1      ";
            updatedP.Description = "test product 1";
            updatedP.Price = 20.00m;
            updatedP.OnHandQuantity = 5;

            bool isUpdated = ProductDB.UpdateProduct(p, updatedP);
            Assert.IsTrue(isUpdated);
        }

        // Tests to see if the method AddProduct() is actually creating new product records in the database.
        [Test, Order(2)]
        public void TestAddProduct()
        {
            Product p = new Product();
            p.ProductCode = "XYZ1      ";
            p.Description = "test product 1";
            p.Price = 15.00m;
            p.OnHandQuantity = 10;
            int moddedRows = ProductDB.AddProduct(p);
            Product dbP = ProductDB.GetProduct("XYZ1      ");
            Assert.AreEqual(moddedRows, 1);
        }

        // Tests ti see if the method DeleteProduct() is actually deleting a product record from the database.
        [Test, Order(5)]
        public void TestDeleteProduct()
        {
            Product p = new Product();
            p.ProductCode = "XYZ1      ";
            p.Description = "test product 1";
            p.Price = 20.00m;
            p.OnHandQuantity = 5;
            bool isDeleted = ProductDB.DeleteProduct(p);
            Assert.IsTrue(isDeleted);
        }
    }
}
