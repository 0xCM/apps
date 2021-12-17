//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;

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
    }
}