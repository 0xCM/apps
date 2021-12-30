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
    [AttributeUsage(AttributeTargets.Struct | AttributeTargets.Delegate | AttributeTargets.Class | AttributeTargets.Field)]
    public class DataTypeAttribute : DataWidthAttribute
    {
        public DataTypeAttribute()
            : base(0)
        {
            NameSyntax = EmptyString;
            Kind = 0ul;
        }

        public DataTypeAttribute(string name)
            : base(0)
        {
            NameSyntax = name;
            Kind = 0ul;
        }

        public DataTypeAttribute(string name,bool @virtual)
            : base(0)
        {
            NameSyntax = name;
            Kind = 0ul;
            Virtual = @virtual;
        }

        public DataTypeAttribute(string name, uint content, uint storage = 0)
            : base(content,storage)
        {
            NameSyntax = name;
            Kind = 0ul;
        }

        public DataTypeAttribute(string name, object kind, uint content = 0, uint storage = 0)
            : base(content,storage)
        {
            NameSyntax = name;
            Kind = kind;
        }

        public string NameSyntax {get;}

        public object Kind {get;}

        public bool Virtual {get;}
    }
}