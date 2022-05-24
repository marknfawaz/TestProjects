using Modernize.Web.Facade;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Modernize.Web.Mvc
{
    public class SecondExtractedClass
    {
        public SecondExtractedClass()
        {
            Factory.GetFacade<PurchaseFacade>().GetSampleData();
        }
    }
}