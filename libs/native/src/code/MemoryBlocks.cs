//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static ExtractTermData;
    using static core;

    public readonly struct MemoryBlocks
    {
        [Op]
        public static MemoryBlock block(in ApiMemberCode src, ExtractTermInfo term)
        {
            if(!term.TerminalFound)
                return MemoryBlock.Empty;

            var kind = term.Kind;
            var size = ByteSize.Zero;
            var modifier = skip(TermModifiers, (byte)kind);
            if(kind == ExtractTermKind.Term5A)
                size = term.Offset + modifier;
            else
                size = term.Offset;

            var origin = new MemoryRange(src.Address, size);
            var data = slice(src.Encoded.Bytes, 0, size);
            return new MemoryBlock(origin, data.ToArray());
        }

        public static unsafe MemoryBlock block(byte* pSrc, ByteSize size)
        {
            var slice = MemorySpan.create(pSrc,size);
            return new MemoryBlock(slice.Origin, slice.Edit.ToArray());
        }

        readonly Index<MemoryBlock> _Blocks;

        [MethodImpl(Inline)]
        public MemoryBlocks(MemoryBlock[] src)
        {
            _Blocks = src;
        }

        public MemoryBlocks Sort()
        {
            _Blocks.Sort();
            return this;
        }

        public ReadOnlySpan<MemoryBlock> View
        {
            [MethodImpl(Inline)]
            get => _Blocks.View;
        }

        public uint Count
        {
            [MethodImpl(Inline)]
            get => _Blocks.Count;
        }

        public static MemoryBlocks Empty
        {
            [MethodImpl(Inline)]
            get => new MemoryBlocks(Index<MemoryBlock>.Empty);
        }

        [MethodImpl(Inline)]
        public static implicit operator MemoryBlocks(MemoryBlock[] src)
            => new MemoryBlocks(src);
    }
}