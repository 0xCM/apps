//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;

    [AttributeUsage(AttributeTargets.Method)]
    public class TypeFactoryAttribute : OpAttribute
    {
        public TypeFactoryAttribute(string spec)
        {
            Specifier = spec;
        }

        public TypeSpecifier Specifier {get;}
    }
}