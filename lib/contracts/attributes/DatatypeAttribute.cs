//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;

    /// <summary>
    /// Applied to a type to denote inclusion as a datatype within the DSL
    /// </summary>
    [AttributeUsage(AttributeTargets.Struct | AttributeTargets.Delegate | AttributeTargets.Class)]
    public class DataTypeAttribute : Attribute
    {
        public DataTypeAttribute()
        {
            Specifiers = Array.Empty<string>();
        }

        public DataTypeAttribute(params string[] specifiers)
        {
            Specifiers = specifiers;
        }

        public string[] Specifiers {get;}
    }
}