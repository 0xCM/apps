//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    public readonly struct DecodedAsm
    {
        public readonly Address16 Offset;

        public readonly AsmHexRef Encoded;

        public readonly SourceText Decoded;

        [MethodImpl(Inline)]
        public DecodedAsm(Address16 offset, AsmHexRef encoded, SourceText decoded)
        {
            Offset = offset;
            Encoded = encoded;
            Decoded = decoded;
        }

        public string Format()
            => string.Format("{0,-46} # {1} | {2,-3} | {3}", Decoded, Offset, Encoded.Size, Encoded);

        public override string ToString()
            => Format();

        public static DecodedAsm Empty => default;
    }
}