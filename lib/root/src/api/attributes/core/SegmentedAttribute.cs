//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;

    [AttributeUsage(AttributeTargets.Struct)]
    public class SegmentedAttribute : WidthAttribute
    {
        public SegmentedAttribute(NativeTypeWidth width, bool sequenced, params CpuCellWidth[] widths)
            : base(width)
        {

        }

        public SegmentedAttribute(NativeTypeWidth width, params CpuCellWidth[] cells)
            : this(width, false, cells)
        {
        }

        public SegmentedAttribute(NativeTypeWidth width, SpanBlockKind kind)
            : this(width, false)
        {

        }

    }
}