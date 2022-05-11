//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [StructLayout(LayoutKind.Sequential,Pack=1)]
    public readonly record struct RenderSpec : IComparable<RenderSpec>
    {
        public static RenderSpec Default(int index)
            => new RenderSpec(index, 0, 0, FormatterImpl.Default);

        public readonly int Index;

        public readonly uint Width;

        public readonly ushort Selector;

        readonly IFormatter Formatter;

        [MethodImpl(Inline)]
        public RenderSpec(int index, uint width, ulong style, IFormatter formatter)
        {
            Index = index;
            Width = width;
            Selector = (ushort)style;
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
        public int CompareTo(RenderSpec src)
            => Index.CompareTo(src.Index);

        readonly struct FormatterImpl : IFormatter<object>
        {
            [MethodImpl(Inline)]
            static string @default(object src)
                => src?.ToString();

            public static IFormatter Default => new FormatterImpl(@default);

            public RenderDelegate<object> Delegate {get;}

            [MethodImpl(Inline)]
            public FormatterImpl(RenderDelegate<object> f)
            {
                Delegate = f;
            }

            [MethodImpl(Inline)]
            public string Format(object src)
                => Delegate(src);
        }
    }
}