//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;

    public class SegmentAttribute : Attribute
    {
        public uint Width {get;}

        public SegmentAttribute(uint width)
        {
            Width = width;
        }
    }
}