//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public readonly struct CoverFormat<E>
        where E : unmanaged, Enum
    {
        public readonly EnumCover<E> Source;

        public readonly EnumFormatMode Mode;

        [MethodImpl(Inline)]
        public CoverFormat(E src, EnumFormatMode mode)
        {
            Source = src;
            Mode = mode;
        }

        public string Format()
            => CoverFormat.format(this);

        public override string ToString()
            => Format();

        [MethodImpl(Inline)]
        public static implicit operator CoverFormat<E>(E src)
            => new CoverFormat<E>(src, EnumFormatMode.Default);

        [MethodImpl(Inline)]
        public static implicit operator CoverFormat<E>((E src, EnumFormatMode mode) x)
            => new CoverFormat<E>(x.src, x.mode);
    }
}