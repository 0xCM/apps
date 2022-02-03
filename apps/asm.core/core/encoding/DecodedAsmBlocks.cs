//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    using static core;

    public readonly struct DecodedAsmBlocks
    {
        readonly Index<DecodedAsmBlock> Data;

        public DecodedAsmBlocks(DecodedAsmBlock[] data)
        {
            Data = data;
        }

        public ReadOnlySpan<DecodedAsmBlock> View
        {
            [MethodImpl(Inline)]
            get => Data;
        }

        public uint Count
        {
            [MethodImpl(Inline)]
            get => Data.Count;
        }

        public static DecodedAsmBlocks Empty => new DecodedAsmBlocks(sys.empty<DecodedAsmBlock>());
    }
}