using Code_Test.Client.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Code_Test.Client
{
    public class UpdateModel
    {
        public PriceCheckerModel GetUpdatedModel(string Product, string State, string Quantity)
        {
            PriceCheckerEntities db = new PriceCheckerEntities();
            PriceCheckerModel PCModel = new PriceCheckerModel();

            if (Product != string.Empty && State != string.Empty && Quantity != string.Empty)
            {
                foreach (var item in db.Products)
                {
                    if (item.Id == int.Parse(Product))
                    {
                        PCModel.ProductID = item.Id;
                        PCModel.ProductName = item.Name;
                        PCModel.ProductPrice = item.Price;
                        PCModel.ProductQuantity = int.Parse(Quantity);
                        PCModel.ProductDiscounted = item.Discounted;
                    }
                }

                foreach (var item in db.States)
                {
                    if (item.Id == int.Parse(State))
                    {
                        PCModel.StateID = item.Id;
                        PCModel.StateName = item.Name;
                        PCModel.StateTax = item.Tax;
                    }
                }
            }

            return PCModel;
        }
    }
}