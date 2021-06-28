using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using BLL;

namespace BLL.Tests
{
    [TestClass]
    public class MenuTests
    {
        Ingredient i1, i2, i3, i4;
        Dish d1, d2;

        [TestInitialize]
        public void TestInitialize()
        {
            i1 = new Ingredient("Салямі", 5);
            i2 = new Ingredient("Помідор", 4);
            i3 = new Ingredient("Базилік", 6);
            i4 = new Ingredient("Багет", 3);
            d1 = new Dish("Салат", 25, 5, i2, i3);
            d2 = new Dish("Сендвіч", 25, 5, i4, i1, i3);
        }

        [TestMethod]
        public void Add_add_d1_and_d2_expect_menuMyList1_equal_d2()
        {
            //arrange
            Menu menu = new Menu();

            //act
            menu.Add(d1);
            menu.Add(d2);

            //assert
            Assert.AreEqual(d2, menu[1]);
        }

        [TestMethod]
        public void Remove_delete_d1_expect_menuMyList0_equal_d2()
        {
            //arrange
            Menu menu = new Menu();

            //act
            menu.Add(d1);
            menu.Add(d2);
            menu.Remove(0);

            //assert
            Assert.AreEqual(d2, menu[0]);
        }

        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        [TestMethod]
        public void Add_d1_and_d2_try_to_reference_menuMyList2_catchArgumentOutOfRangeException()
        {
            //arrange
            Menu menu = new Menu();

            //act
            menu.Add(d1);
            menu.Add(d2);

            //assert
            Assert.AreEqual(d2,menu[2]);
        }

        [TestMethod]
        public void Output_expect_menuOutput_equal_menuMyList()
        {
            //arrange
            Menu menu = new Menu();
            List<Dish> expected;

            //act
            menu.Add(d1);
            menu.Add(d2);
            expected = menu.Output();

            //assert
            Assert.AreEqual(expected, menu.MyList);
        }
    }
}
