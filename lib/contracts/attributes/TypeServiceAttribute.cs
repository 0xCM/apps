//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;


    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Struct)]
    public class TypeServiceAttribute : Attribute
    {
        public TypeServiceAttribute(Type target)
        {
            Target = target;
        }

        public Type Target {get;}
    }
}