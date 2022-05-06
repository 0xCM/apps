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
    public class DataTypeAttribute : DataWidthAttribute
    {
        public DataTypeAttribute()
            : base(0)
        {
            Name = EmptyString;
            Kind = 0ul;
        }

        public DataTypeAttribute(string name)
            : base(0)
        {
            Name = name;
            Kind = 0ul;
        }

        public DataTypeAttribute(string name, bool @virtual)
            : base(0)
        {
            Name = name;
            Kind = 0ul;
            Virtual = @virtual;
        }

        public DataTypeAttribute(string name, uint packed, uint native = 0)
            : base(packed, native)
        {
            Name = name;
            Kind = 0ul;
        }

        public DataTypeAttribute(string name, object kind, uint packed = 0, uint native = 0)
            : base(packed, native)
        {
            Name = name;
            Kind = kind;
        }

        public string Name {get;}

        public object Kind {get;}

        public bool Virtual {get;}
    }
}