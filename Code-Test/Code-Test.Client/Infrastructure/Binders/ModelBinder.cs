using Code_Test.Client.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace Code_Test.Client.Infrastructure.Binders
{
    public class ModelBinder : IModelBinder
    {
        private const string sessionKey = "PCModel";

        public object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
        {
            PriceCheckerModel PCModel = null;
            if (controllerContext.HttpContext.Session != null)
            {
                PCModel = (PriceCheckerModel)controllerContext.HttpContext.Session[sessionKey];
            }
            
            if (PCModel == null)
            {
                PCModel = new PriceCheckerModel();
                if (controllerContext.HttpContext.Session != null)
                {
                    controllerContext.HttpContext.Session[sessionKey] = PCModel;
                }
            }
            
            return PCModel;
        }
    }
}