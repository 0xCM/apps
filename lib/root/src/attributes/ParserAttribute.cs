//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;

    [AttributeUsage(AttributeTargets.Struct | AttributeTargets.Class)]
    public class ParserAttribute : Attribute
    {
        public ParserAttribute(params Type[] supported)
        {
            SupportedTypes = supported;
        }

        public ParserAttribute()
        {
            SupportedTypes = new Type[]{typeof(void)};
        }

        public Type[] SupportedTypes {get;}
    }
}