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

    public class RenderAttribute<T> : RenderAttribute
        where T : unmanaged
    {
        public RenderAttribute(uint width)
            : base(width,0)
        {
        }

        public RenderAttribute(uint width, T style)
            : base(width, Sized.bw64(style))
        {

        }
    }
}