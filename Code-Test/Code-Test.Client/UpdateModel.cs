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
            int pid = 0;
            int sid = 0;
            int quantity = 0;

            if (!string.IsNullOrEmpty(Product) && !string.IsNullOrEmpty(State) && !string.IsNullOrEmpty(Quantity))
            {
                if (int.TryParse(Product, out pid) && int.TryParse(State, out sid) && int.TryParse(Quantity, out quantity))
                {
                    foreach (var item in db.Products)
                    {
                        if (item.Id == pid)
                        {
                            PCModel.ProductID = item.Id;
                            PCModel.ProductName = item.Name;
                            PCModel.ProductPrice = item.Price;
                            PCModel.ProductQuantity = quantity;
                            PCModel.ProductDiscounted = item.Discounted;
                        }
                    }

                    foreach (var item in db.States)
                    {
                        if (item.Id == sid)
                        {
                            PCModel.StateID = item.Id;
                            PCModel.StateName = item.Name;
                            PCModel.StateTax = item.Tax;
                        }
                    }
                }
            }

            return PCModel;
        }
    }
}