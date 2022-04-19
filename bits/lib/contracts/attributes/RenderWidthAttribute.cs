//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;

    public class RenderWidthAttribute : Attribute
    {
        public RenderWidthAttribute(RenderWidths width)
        {
            Width = (byte)width;
        }

        public RenderWidthAttribute(byte width)
        {
            Width = (byte)width;
        }

        public byte Width {get;}
    }
}