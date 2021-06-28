using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using BLL;

namespace BLL.Tests
{
    [TestClass]
    public class IngredientServiceTests
    {
        Ingredient i1, i2, i3;

        [TestInitialize]
        public void TestInitialize()
        {
            i1 = new Ingredient("Базилік", 4);
            i2 = new Ingredient("Сир", 6);
            i3 = new Ingredient("Вода");
        }

        [TestMethod]
        public void Add_add_i1_and_i2_expect_serviceMyList1_equal_i2()
        {
            //arrange
            IngredientService service = new IngredientService();

            //act
            service.Add(i1);
            service.Add(i2);

            //assert
            Assert.AreEqual(i2, service.MyList[1]);
        }

        [TestMethod]
        public void Remove_delete_i1_in_service_expect_MyList0_equal_i2()
        {
            //arrange
            IngredientService service = new IngredientService();

            //act
            service.Add(i1);
            service.Add(i2);
            service.Remove(0);

            //assert
            Assert.AreEqual(i2, service.MyList[0]);
        }

        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        [TestMethod]
        public void Add_d1_and_d2_try_to_reference_menuMyList2_catch_ArgumentOutOfRangeException()
        {
            //arrange
            IngredientService service = new IngredientService();

            //act
            service.Add(i1);
            service.Add(i3);

            //assert
            Assert.AreEqual(i3, service[2]);
        }

        [TestMethod]
        public void Search_search_letter_р_in_serviceMyList_expect_expected0_equal_i2()
        {
            //arrange
            IngredientService service = new IngredientService();
            List<Ingredient> list;

            //act
            service.Add(i1);
            service.Add(i2);
            service.Add(i3);
            list = service.Search("р");

            //assert
            Assert.AreEqual(service.MyList[1], list[0]);
        }
    }
}
