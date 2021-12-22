//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;

    [DataType("digit<b:16>")]
    public readonly struct HexDigit
    {
        public readonly HexDigitValue Value;

        [MethodImpl(Inline)]
        public HexDigit(HexDigitValue src)
        {
            Value = src;
        }

        [MethodImpl(Inline)]
        public static implicit operator HexDigit(HexDigitValue src)
            => new HexDigit(src);

        [MethodImpl(Inline)]
        public static implicit operator HexDigitValue(HexDigit src)
            => src.Value;
    }
}