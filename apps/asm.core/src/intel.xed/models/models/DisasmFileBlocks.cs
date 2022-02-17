//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial struct XedModels
    {
        public readonly struct DisasmFileBlocks
        {
            public FileRef Source {get;}

            public Index<DisasmLineBlock> LineBlocks {get;}

            [MethodImpl(Inline)]
            public DisasmFileBlocks(FileRef src, DisasmLineBlock[] blocks)
            {
                Source = src;
                LineBlocks = blocks;
            }
        }
    }
}