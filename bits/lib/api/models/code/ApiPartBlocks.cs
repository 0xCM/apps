//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;

    public readonly struct ApiPartBlocks : IIndex<ApiHostBlocks>
    {
        public PartId PartId {get;}

        public Index<ApiHostBlocks> Blocks {get;}

        [MethodImpl(Inline)]
        public ApiPartBlocks(PartId part, Index<ApiHostBlocks> blocks)
        {
            PartId = part;
            Blocks = blocks;
        }

        public ApiHostBlocks[] Storage
        {
            [MethodImpl(Inline)]
            get => Blocks.Storage;
        }

        public uint Count
        {
            [MethodImpl(Inline)]
            get => Blocks.Count;
        }

        public int Length
        {
            [MethodImpl(Inline)]
            get => Blocks.Length;
        }

        public ReadOnlySpan<ApiHostBlocks> View
        {
            [MethodImpl(Inline)]
            get => Blocks.View;
        }
    }
}