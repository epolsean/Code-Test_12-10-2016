using Code_Test.Client;
using Code_Test.Client.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Code_Test.Tests
{
    public class DataTests
    {
        [Theory]
        [InlineData("", "", "")]
        [InlineData("1", "", "")]
        [InlineData("", "1", "")]
        [InlineData("", "", "1")]
        [InlineData("1", "1", "")]
        [InlineData("", "1", "1")]
        [InlineData("1", "", "1")]
        [InlineData("1", "a", "1")]
        public void Test_GetUpdatedModelWithoutCompleteInformation(string s1, string s2, string s3)
        {
            UpdateModel um = new UpdateModel();
            bool isEqual = true;

            var actual = um.GetUpdatedModel(s1, s2, s3);

            var expected = new PriceCheckerModel();

            if(expected.ProductQuantity != actual.ProductQuantity || expected.ProductID != actual.ProductID || expected.StateID != actual.StateID)
            {
                isEqual = false;
            }

            Assert.True(isEqual);
        }

        [Theory]
        [InlineData("1", "1", "1")]
        [InlineData("2", "5", "2")]
        [InlineData("5", "1", "4")]
        [InlineData("1", "3", "2")]
        public void Test_GetUpdatedModelWithCorrectInformation(string s1, string s2, string s3)
        {
            UpdateModel um = new UpdateModel();
            PriceCheckerEntities pce = new PriceCheckerEntities();
            bool isEqual = true;

            var actual = um.GetUpdatedModel(s1, s2, s3);

            var expected = new PriceCheckerModel();

            foreach (var item in pce.Products)
            {
                if (item.Id == int.Parse(s1))
                {
                    expected.ProductID = item.Id;
                    expected.ProductName = item.Name;
                    expected.ProductPrice = item.Price;
                    expected.ProductQuantity = int.Parse(s3);
                    expected.ProductDiscounted = item.Discounted;
                }
            }

            foreach (var item in pce.States)
            {
                if (item.Id == int.Parse(s2))
                {
                    expected.StateID = item.Id;
                    expected.StateName = item.Name;
                    expected.StateTax = item.Tax;
                }
            }

            if (expected.ProductQuantity != actual.ProductQuantity || expected.ProductID != actual.ProductID || expected.StateID != actual.StateID)
            {
                isEqual = false;
            }

            Assert.True(isEqual);
        }

        [Theory]
        [InlineData(5, 1, false, 5)]
        [InlineData(5, 2, false, 10)]
        [InlineData(5, 1, true, 4.5)]
        [InlineData(5, 3, true, 13.5)]
        public void Test_GetSubtotal(decimal dec1, int num, bool flag, decimal dec2)
        {
            CalculatePrice cp = new CalculatePrice();

            var actual = cp.GetSubtotal(dec1, num, flag);

            var expected = dec2;

            Assert.Equal(actual, expected);
        }

        [Theory]
        [InlineData(10, 0, 10)]
        [InlineData(10, 0.05, 10.5)]
        [InlineData(4, 0, 4)]
        [InlineData(4, 0.055, 4.22)]
        public void Test_GetTotal(decimal dec1, decimal dec2, decimal dec3)
        {
            CalculatePrice cp = new CalculatePrice();

            var actual = cp.GetTotal(dec1, dec2);

            var expected = dec3;

            Assert.Equal(actual, expected);
        }
    }
}
