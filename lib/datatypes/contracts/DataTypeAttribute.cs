//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    /// <summary>
    /// Applied to a type to denote inclusion as a datatype within the DSL
    /// </summary>
    [AttributeUsage(AttributeTargets.Struct | AttributeTargets.Delegate | AttributeTargets.Class | AttributeTargets.Field)]
    public class DataTypeAttribute : Attribute
    {
        public DataTypeAttribute()
        {
            Name = EmptyString;
            Kind = 0ul;
        }

        public DataTypeAttribute(string name)
        {
            Name = name;
            Kind = 0ul;
        }

        public DataTypeAttribute(string name, bool @virtual)
        {
            Name = name;
            Kind = 0ul;
            Virtual = @virtual;
        }

        public string Name {get;}

        public object Kind {get;}

        public bool Virtual {get;}
    }
}