//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    public readonly struct AsmCodeBlocks : IIndex<AsmCodeBlock>
    {
        readonly Index<AsmCodeBlock> Data;

        public readonly Label Origin;

        public readonly uint LineCount;

        public AsmCodeBlocks(AsmCodeBlock[] data)
        {
            Data = data;
            Origin = EmptyString;
            LineCount = data.Select(x => x.Count).Sum();
        }

        public AsmCodeBlocks(Label origin, AsmCodeBlock[] data)
        {
            Data = data;
            Origin = origin;
            LineCount = data.Select(x => x.Count).Sum();
        }

        public AsmCodeBlock[] Storage
        {
            [MethodImpl(Inline)]
            get => Data;
        }

        public Span<AsmCodeBlock> Edit
        {
            [MethodImpl(Inline)]
            get => Data;
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

        public ref AsmCodeBlock this[uint i]
        {
            [MethodImpl(Inline)]
            get => ref Data[i];
        }

        public ref AsmCodeBlock this[int i]
        {
            [MethodImpl(Inline)]
            get => ref Data[i];
        }


        [MethodImpl(Inline)]
        public static implicit operator AsmCodeBlock[](AsmCodeBlocks src)
            => src.Data;

        [MethodImpl(Inline)]
        public static implicit operator AsmCodeBlocks(AsmCodeBlock[] src)
            => new AsmCodeBlocks(src);

        public static AsmCodeBlocks Empty => new AsmCodeBlocks(sys.empty<AsmCodeBlock>());
    }
}