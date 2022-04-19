//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;

    [AttributeUsage(AttributeTargets.Struct | AttributeTargets.Enum | AttributeTargets.Class)]
    public class DataWidthAttribute : Attribute
    {
        public DataWidthAttribute(uint content, uint storage = 0)
        {
            ContentWidth = content;
            StorageWidth = storage;
        }

        public BitWidth ContentWidth {get;}

        public BitWidth StorageWidth {get;}
    }
}