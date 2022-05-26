//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public readonly struct MemoryBlocks
    {
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