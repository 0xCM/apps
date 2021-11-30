//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;

    /// <summary>
    /// Applied to a structural artifact or member field, method or property to indicate that the target provides some sort of literal data
    /// </summary>
    [AttributeUsage(AttributeTargets.Struct)]
    public class LiteralProviderAttribute : Attribute
    {
        public LiteralProviderAttribute()
        {

        }

        public LiteralProviderAttribute(string name)
        {
            Name = name;
        }

        public string Name {get;}
    }
}