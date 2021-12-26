//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using static Root;

    /// <summary>
    /// Applied to a type to denote inclusion as a datatype within the DSL
    /// </summary>
    [AttributeUsage(AttributeTargets.Struct | AttributeTargets.Delegate | AttributeTargets.Class)]
    public class DataTypeAttribute : Attribute
    {
        public DataTypeAttribute()
        {
            NameSyntax = EmptyString;
            Kind = 0ul;
        }

        public DataTypeAttribute(string name)
        {
            NameSyntax = name;
            Kind = 0ul;
        }

        public DataTypeAttribute(string name,bool @virtual)
        {
            NameSyntax = name;
            Kind = 0ul;
            Virtual = @virtual;
        }

        public DataTypeAttribute(string name, uint content, uint storage = 0)
        {
            NameSyntax = name;
            Kind = 0ul;
            ContentWidth = content;
            StorageWidth = storage;
        }

        public DataTypeAttribute(string name, object kind, uint content = 0, uint storage = 0)
        {
            NameSyntax = name;
            Kind = kind;
            ContentWidth = content;
            StorageWidth = storage;
        }

        public string NameSyntax {get;}

        public object Kind {get;}

        public BitWidth ContentWidth {get;}

        public BitWidth StorageWidth {get;}

        public bool Virtual {get;}
    }
}