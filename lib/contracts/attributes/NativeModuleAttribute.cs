//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;

    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Struct)]
    public class NativeModuleAttribute : Attribute
    {
        public NativeModuleAttribute(string name)
        {
            Name = name;
        }

        public string Name {get;}
    }

}