//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public class RenderWidthAttribute : Attribute
    {
        public RenderWidthAttribute(uint width)
        {
            Width = width;
        }

        public readonly uint Width;
    }

    public class RenderAttribute : Attribute
    {
        public RenderAttribute(uint width)
        {
            Width = width;
            Style = 0;
        }

        public RenderAttribute(uint width, ulong style)
        {
            Width = width;
            Style = style;
        }

        public readonly uint Width;

        public readonly ulong Style;

        public RenderSpec Spec => new RenderSpec(Width, Style);
    }
}