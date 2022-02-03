//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    public readonly struct DecodedAsm
    {
        public readonly Address16 Offset;

        public readonly MemorySeg Encoded;

        public readonly SourceText Decoded;

        [MethodImpl(Inline)]
        public DecodedAsm(Address16 offset, MemorySeg encoded, SourceText decoded)
        {
            Offset = offset;
            Encoded = encoded;
            Decoded = decoded;
        }
    }

    public readonly struct DecodedAsmBlock
    {
        public readonly LocatedSymbol Base;

        public readonly Index<DecodedAsm> Statements;

        [MethodImpl(Inline)]
        public DecodedAsmBlock(LocatedSymbol @base, DecodedAsm[] src)
        {
            Base = @base;
            Statements = src;
        }
    }
}