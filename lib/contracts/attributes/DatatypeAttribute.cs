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
            NameFormat = EmptyString;
            Kind = 0ul;
        }

        public DataTypeAttribute(string name)
        {
            NameFormat = name;
            Kind = 0ul;
        }

        public DataTypeAttribute(string name, object kind, uint content = 0, uint storage = 0)
        {
            NameFormat = name;
            Kind = kind;
            ContentWidth = content;
            StorageWidth = storage;
        }

        public string NameFormat {get;}

        public object Kind {get;}

        public BitWidth ContentWidth {get;}

        public BitWidth StorageWidth {get;}
    }
}