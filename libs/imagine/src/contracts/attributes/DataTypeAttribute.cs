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
            Group = EmptyString;
            Name = EmptyString;
            Kind = EmptyString;
        }

        public DataTypeAttribute(string group)
        {
            Group = group;
            Name = group;
            Kind = group;
        }

        public DataTypeAttribute(NumericKind closures)
        {
            Group = EmptyString;
            Closures = closures;
            Kind = EmptyString;
            Name = EmptyString;
        }

        public DataTypeAttribute(string group, NumericKind closures)
        {
            Group = group;
            Closures = closures;
            Name = group;
            Kind = group;
        }

        public DataTypeAttribute(string name, bool @virtual)
        {
            Name = name;
            Group = name;
            Kind = EmptyString;
        }

        public string Group {get;}

        public NumericKind Closures {get;}

        public string Name {get;}

        public object Kind {get;}
    }
}