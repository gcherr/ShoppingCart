using Microsoft.VisualStudio.TestTools.UnitTesting;
using ShoppingCartLib;

namespace UnitTestProject1
{
    [TestClass]
    public class ShoppingCartTest
    {
        ShoppingCart sc;
        

        [TestInitialize]
        public void Initialize()
        {
            Product prod_a = new Product("A", 2.00M);
            Product prod_b = new Product("B", 12.00M);
            Product prod_c = new Product("C", 1.25M);
            Product prod_d = new Product("D", 0.15M);

            Inventory inv = new Inventory();
            inv.AddProduct(prod_a.GetCode(), prod_a);
            inv.AddProduct(prod_b.GetCode(), prod_b);
            inv.AddProduct(prod_c.GetCode(), prod_c);
            inv.AddProduct(prod_d.GetCode(), prod_d);

            Discounts disc = new Discounts();
            disc.SetDiscount(prod_a.GetCode(), 4, 7.00M);
            disc.SetDiscount(prod_c.GetCode(), 6, 6.00M);

            DiscountCalculator dc = new DiscountCalculator(inv, disc);

            sc = new ShoppingCart(dc);
        }


        [TestMethod]
        public void TestCase1()
        {
            string case1 = "ABCDABAA";
            decimal expectedPrice = 32.40M;

            sc.Scan(case1);
            Assert.IsTrue(sc.Total() == expectedPrice);
        }

        [TestMethod]
        public void TestCase2()
        {
            string case2 = "CCCCCCC";
            decimal expectedPrice = 7.25M;
            
            sc.Scan(case2);
            Assert.IsTrue(sc.Total() == expectedPrice);
        }

        [TestMethod]
        public void TestCase3()
        {
            string case3 = "ABCD";
            decimal expectedPrice = 15.40M;
            
            sc.Scan(case3);
            Assert.IsTrue(sc.Total() == expectedPrice);
        }


    }
}
