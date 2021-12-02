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
        }

        public DataTypeAttribute(string name)
        {
            NameFormat = name;
        }

        public string NameFormat {get;}
    }
}