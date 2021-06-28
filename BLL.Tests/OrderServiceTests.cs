using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using BLL;

namespace BLL.Tests
{
    [TestClass]
    public class OrderServiceTests
    {
        Ingredient i1, i2, i3, i4, i5, i6;
        Dish d1, d2, d3;

        [TestInitialize]
        public void TestInitialize()
        {
            i1 = new Ingredient("Салямі", 5);
            i2 = new Ingredient("Помідор", 4);
            i3 = new Ingredient("Базилік", 6);
            i4 = new Ingredient("Багет", 3);
            i5 = new Ingredient("Тісто", 3);
            i6 = new Ingredient("Сир", 6);
            d1 = new Dish("Салат", 25, 5, i2, i6, i3);
            d2 = new Dish("Сендвіч", 25, 5, i4, i1, i3);
            d3 = new Dish("Піца Маргарита", 99, 25, i5, i6, i2, i3);

        }

        [TestMethod]
        public void Add_add_order1_and_order2_expect_service1_equal_order2()
        {
            //arrange
            OrderService service = new OrderService();
            Order order1 = new Order();
            Order order2 = new Order();
            int table1 = 1;
            int table2 = 3;

            //act
            order1.ChangeTable(table1);
            order2.ChangeTable(table2);

            order1.AddDish(d1);
            order1.AddDish(d2);
            order2.AddDish(d3);
            order2.AddDish(d1);

            service.Add(order1);
            service.Add(order2);

            //assert
            Assert.AreEqual(order2, service[1]);
        }

        [TestMethod]
        public void Remove_remove_service0_expect_service0_equal_order2()
        {
            //assert
            OrderService service = new OrderService();
            Order order1 = new Order();
            Order order2 = new Order();
            int table1 = 1;
            int table2 = 4;

            //act
            order1.ChangeTable(table1);
            order2.ChangeTable(table2);

            order1.AddDish(d1);
            order1.AddDish(d2);
            order2.AddDish(d3);
            order2.AddDish(d1);

            service.Add(order1);
            service.Add(order2);
            service.Remove(0);

            //assert
            Assert.AreEqual(order2, service[0]);
        }

        [TestMethod]
        public void Search_search_by_table2_expect_expected0_equal_service1()
        {
            //assert
            OrderService service = new OrderService();
            List<Order> expected;
            Order order1 = new Order();
            Order order2 = new Order();
            int table1 = 1;
            int table2 = 4;

            //act
            order1.ChangeTable(table1);
            order2.ChangeTable(table2);

            order1.AddDish(d1);
            order1.AddDish(d2);
            order2.AddDish(d3);
            order2.AddDish(d1);

            service.Add(order1);
            service.Add(order2);
            expected = service.Search(table2);

            //assert
            Assert.AreEqual(expected[0], service[1]);
        }

        [TestMethod]
        public void Search_search_by_string_expect_expected0_equal_service0()
        {
            //assert
            OrderService service = new OrderService();
            List<Order> expected;
            Order order1 = new Order();
            Order order2 = new Order();
            int table1 = 1;
            int table2 = 4;

            //act
            order1.ChangeTable(table1);
            order2.ChangeTable(table2);

            order1.AddDish(d1);
            order1.AddDish(d2);
            order2.AddDish(d3);
            order2.AddDish(d1);

            service.Add(order1);
            service.Add(order2);
            expected = service.Search("енд");

            //assert
            Assert.AreEqual(expected[0], service[0]);
        }
    }
}
