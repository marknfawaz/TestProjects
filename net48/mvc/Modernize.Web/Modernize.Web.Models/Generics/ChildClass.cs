using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modernize.Web.Models.Generics
{
    public class ChildClass<ObjectType> : ParentClass<ObjectType> where ObjectType : class, IObjectType
    {

    }

    public class ParentClass<T>
    {

    }

    public class ObjectType : IObjectType
    {

    }

    public interface IObjectType
    {

    }
}
