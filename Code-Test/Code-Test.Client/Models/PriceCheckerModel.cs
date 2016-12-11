using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Code_Test.Client.Models
{
    public class PriceCheckerModel
    {
        private int _ProductID = 0;
        private string _ProductName = "";
        private decimal _ProductPrice = 0;
        private int _ProductQuantity = 0;
        private bool _ProductDiscounted = false;
        private int _StateID = 0;
        private string _StateName = "";
        private decimal _StateTax = 0;

        public int ProductID { get { return _ProductID; } set { _ProductID = value; } }
        public string ProductName { get { return _ProductName; } set { _ProductName = value; } }
        public decimal ProductPrice { get { return _ProductPrice; } set { _ProductPrice = value; } }
        public int ProductQuantity { get { return _ProductQuantity; } set { _ProductQuantity = value; } }
        public bool ProductDiscounted { get { return _ProductDiscounted; } set { _ProductDiscounted = value; } }
        public int StateID { get { return _StateID; } set { _StateID = value; } }
        public string StateName { get { return _StateName; } set { _StateName = value; } }
        public decimal StateTax { get { return _StateTax; } set { _StateTax = value; } }
    }
}