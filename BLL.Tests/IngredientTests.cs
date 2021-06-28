using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BLL;

namespace BLL.Tests
{
    [TestClass]
    public class IngredientTests
    {
        [TestMethod]
        public void ChangeName_create_ingredient_and_change_name_expect_expectedName_equal_actualName()
        {
            //arrange
            string name = "Сир";
            Ingredient expected = new Ingredient(name);

            //act
            Ingredient actual = new Ingredient();
            actual.ChangeName(name);

            //assert
            Assert.AreEqual(expected.Name, actual.Name);
        }

        [TestMethod]
        public void ChangePrice_create_ingredient_and_change_price_expect_expectedPrice_equal_actualPrice()
        {
            //arrange
            int price = 6;
            Ingredient expected = new Ingredient();
            expected.Price = price;

            //act
            Ingredient actual = new Ingredient();
            actual.ChangePrice(price);

            //assert
            Assert.AreEqual(expected.Price, actual.Price);
        }

        [TestMethod]
        public void Change_create_ingredient_and_change_expect_expected_equal_actual()
        {
            //arrange
            string name = "Сир";
            int price = 6;
            Ingredient expected = new Ingredient(name, price);

            //act
            Ingredient actual = new Ingredient();
            actual.Change(name, price);

            //assert
            Assert.IsTrue(expected.Price == actual.Price && expected.Name == actual.Name);
        }
    }
}
