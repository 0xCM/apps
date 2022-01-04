//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static XedModels;

    partial struct XedModels
    {
        public readonly struct DisasmFileBlocks
        {
            public FS.FilePath Source {get;}

            public Index<DisasmLineBlock> LineBlocks {get;}

            public DisasmFileBlocks(FS.FilePath src, DisasmLineBlock[] blocks)
            {
                Source = src;
                LineBlocks = blocks;
            }
        }
    }
}