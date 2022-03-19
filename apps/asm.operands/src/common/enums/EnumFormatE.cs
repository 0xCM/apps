//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;

    public readonly struct EnumFormat<E>
        where E : unmanaged, Enum
    {
        readonly E Value;

        public readonly EnumFormatMode Mode;

        [MethodImpl(Inline)]
        public EnumFormat(E src, EnumFormatMode mode = EnumFormatMode.Expr)
        {
            Value = src;
            Mode = mode;
        }

        public string Format()
            => EnumRender<E>.Service.Format(Value,Mode);

        public override string ToString()
            => Format();

        [MethodImpl(Inline)]
        public static implicit operator EnumFormat<E>(E src)
            => new EnumFormat<E>(src);
    }
}