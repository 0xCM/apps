//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;

    [AttributeUsage(AttributeTargets.Field)]
    public class RenderSlotAttribute : Attribute
    {
        public byte Position {get;}

        public string SlotContent {get;}

        public RenderSlotAttribute(byte position, string content)
        {
            Position = position;
            SlotContent = content;
        }
    }
}