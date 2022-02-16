//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    public readonly struct DecodedAsmBlock
    {
        public readonly LocatedSymbol Label;

        public readonly Index<AsmCode> Statements;

        [MethodImpl(Inline)]
        public DecodedAsmBlock(LocatedSymbol label, AsmCode[] src)
        {
            Label = label;
            Statements = src;
        }
    }
}