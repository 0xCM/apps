//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;

    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Struct | AttributeTargets.Enum)]
    public class TypeDefAttribute : Attribute
    {
        public TypeDefAttribute(string descriptor)
        {
            Descriptor = descriptor;
        }

        public string Descriptor {get;}
    }
}