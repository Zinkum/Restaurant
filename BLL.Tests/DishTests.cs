using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using BLL;

namespace BLL.Tests
{
    [TestClass]
    public class DishTests
    {
        Ingredient i1, i2, i3;
        List<Ingredient> list = new List<Ingredient>();
        Ingredient[] array;

        [TestInitialize]
        public void TestInitialize()
        {
            i1 = new Ingredient("i1");
            i2 = new Ingredient("i2");
            i3 = new Ingredient("i3");

            list.Add(i1);
            list.Add(i2);
            list.Add(i3);

            array = new Ingredient[3] { i1, i2, i3 };
        }

        [TestMethod]
        public void ChangeTitle_create_Dish_and_change_name_expect_expectedTitle_equal_actualTitle()
        {
            //arrange
            string title = "dish";
            Dish expected = new Dish();
            expected.Title = title;

            //act
            Dish actual = new Dish();
            actual.ChangeTitle(title);

            //assert
            Assert.AreEqual(expected.Title, actual.Title);
        }

        [TestMethod]
        public void ChangePrice_create_Dish_and_change_price_expect_expectedPrice_equal_actualPrice()
        {
            //arrange
            int price = 5;
            Dish expected = new Dish();
            expected.Price = price;

            //act
            Dish actual = new Dish();
            actual.ChangePrice(price);

            //assert
            Assert.AreEqual(expected.Title, actual.Title);
        }

        [TestMethod]
        public void ChangePreparingTime_create_Dish_and_change_time_expect_expectedTime_equal_actualTime()
        {
            //arrange
            int time = 5;
            Dish expected = new Dish();
            expected.Time = time;

            //act
            Dish actual = new Dish();
            actual.ChangePreparingTime(time);

            //assert
            Assert.AreEqual(expected.Time, actual.Time);
        }

        [TestMethod]
        public void AddIngredient_create_Dish_and_add_i1_i2_and_i3_expect_actualIngredients2_equal_list2()
        {
            //arrange
            Dish actual;

            //act
            actual = new Dish();
            actual.AddIngredient(i1);
            actual.AddIngredient(i2);
            actual.AddIngredient(i3);

            //assert
            Assert.IsTrue(list[2] == actual.Ingredients[2]);
        }

        [TestMethod]
        public void AddIngredient_create_Dish_and_add_i1_i2_and_i3_expect_actualIngredientsArray0_equal_array0()
        {
            //arrange
            Dish actual;

            //act
            actual = new Dish();
            actual.AddIngredient(i1);
            actual.AddIngredient(i2);
            actual.AddIngredient(i3);

            //assert
            Assert.IsTrue(array[0] == actual.IngredientsArray[0]);
        }

        [TestMethod]
        public void RemoveIngredient_create_Dish_and_add_i1_i2_and_i3_then_remove_i2_expect_actualIngredients1_equal_expected1()
        {
            //arrange
            Dish actual;
            List<Ingredient> expected = new List<Ingredient>();

            //act
            expected.Add(i1);
            expected.Add(i3);
            actual = new Dish();
            actual.AddIngredient(i1);
            actual.AddIngredient(i2);
            actual.AddIngredient(i3);
            actual.RemoveIngredient(1);

            //assert
            Assert.IsTrue(expected[1] == actual.Ingredients[1]);
        }
    }
}
