//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;

    public struct LegacyPrefix : IAsmPrefix<LegacyPrefix>
    {
        public readonly byte Code;

        [MethodImpl(Inline)]
        public LegacyPrefix(byte code)
        {
            Code = code;
        }

        public byte Encoded
        {
            [MethodImpl(Inline)]
            get => Code;
        }

        public string Format()
            => Code.FormatHex(2);

        public override string ToString()
            => Format();

        [MethodImpl(Inline)]
        public static implicit operator LegacyPrefix(BndPrefix src)
            => new LegacyPrefix(src.Encoded);

        [MethodImpl(Inline)]
        public static implicit operator LegacyPrefix(AdszPrefix src)
            => new LegacyPrefix(src.Encoded);

        [MethodImpl(Inline)]
        public static implicit operator LegacyPrefix(OpszPrefix src)
            => new LegacyPrefix(src.Encoded);

        [MethodImpl(Inline)]
        public static implicit operator LegacyPrefix(EscapePrefix src)
            => new LegacyPrefix(src.Encoded);

        public static LegacyPrefix Empty => default;
    }
}