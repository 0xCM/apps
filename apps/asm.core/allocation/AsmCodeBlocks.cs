//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    public readonly struct AsmCodeBlocks
    {
        readonly Index<AsmCodeBlock> Data;

        public AsmCodeBlocks(AsmCodeBlock[] data)
        {
            Data = data;
        }

        public ReadOnlySpan<AsmCodeBlock> View
        {
            [MethodImpl(Inline)]
            get => Data;
        }

        public uint Count
        {
            [MethodImpl(Inline)]
            get => Data.Count;
        }

        public static AsmCodeBlocks Empty => new AsmCodeBlocks(sys.empty<AsmCodeBlock>());
    }
}