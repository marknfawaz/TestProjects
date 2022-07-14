using Modernize.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Modernize.Web.Mvc
{
    public class UtilityClass
    {
        public void MethodReferencingEnum()
        {
            var enumValue = ValuesEnum.Value1;
            Console.WriteLine(enumValue);
        }
        public void MethodInvokingStructMethod()
        {
            var structInstance = new ValuesStruct();
            structInstance.MyMethod();
        }
        public void MethodInvokingRecordMethod()
        {
            var recordInstance = new ValuesRecord();
            recordInstance.MyMethod();
        }
        public void MethodReferencingEnumAsParameter()
        {
            Console.WriteLine(ValuesEnum.Value1);
        }
    }
}