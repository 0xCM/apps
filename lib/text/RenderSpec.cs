//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [StructLayout(LayoutKind.Sequential,Pack=1)]
    public readonly record struct RenderSpec : IComparable<RenderSpec>
    {
        public readonly int Index;

        public readonly uint Width;

        public readonly ulong Style;

        [MethodImpl(Inline)]
        public RenderSpec(uint width, ulong style)
        {
            Index = -1;
            Width = width;
            Style = style;
        }

        [MethodImpl(Inline)]
        public RenderSpec(int index, uint width, ulong style)
        {
            Index = index;
            Width = width;
            Style = style;
        }

        public bool IsEmpty
        {
            [MethodImpl(Inline)]
            get => Width == 0;
        }

        public bool IsNonEmpty
        {
            [MethodImpl(Inline)]
            get => Width != 0;
        }


        [MethodImpl(Inline)]
        public int CompareTo(RenderSpec src)
            => Index.CompareTo(src.Index);

        public static RenderSpec Empty => default;
    }
}