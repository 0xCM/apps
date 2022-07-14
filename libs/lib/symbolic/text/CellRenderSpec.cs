//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [StructLayout(LayoutKind.Sequential,Pack=1)]
    public readonly record struct CellRenderSpec : IComparable<CellRenderSpec>
    {
        [Render(8)]
        public readonly uint Index;

        [Render(8)]
        public readonly uint Width;

        [Ignore]
        readonly IFormatter Formatter;

        [MethodImpl(Inline)]
        public CellRenderSpec(uint index, uint width, IFormatter formatter)
        {
            Index = index;
            Width = width;
            Formatter = formatter;
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
        public string Format<T>(T src)
            => Formatter.Format(src);

        [MethodImpl(Inline)]
        public int CompareTo(CellRenderSpec src)
            => Index.CompareTo(src.Index);
    }
}