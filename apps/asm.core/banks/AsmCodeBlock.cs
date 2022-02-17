//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    public readonly struct AsmCodeBlock
    {
        public readonly LocatedSymbol Label;

        public readonly Index<AsmCode> Lines;

        [MethodImpl(Inline)]
        public AsmCodeBlock(LocatedSymbol label, AsmCode[] src)
        {
            Label = label;
            Lines = src;
        }

        public uint LineCount
        {
            [MethodImpl(Inline)]
            get => Lines.Count;
        }

        public ref readonly AsmCode this[uint i]
        {
            [MethodImpl(Inline)]
            get => ref Lines[i];
        }

        public ref readonly AsmCode this[int i]
        {
            [MethodImpl(Inline)]
            get => ref Lines[i];
        }

    }
}