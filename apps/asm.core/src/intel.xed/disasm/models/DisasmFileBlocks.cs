//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    partial struct XedModels
    {
        public readonly struct DisasmFileBlocks
        {
            public readonly FileRef Source;

            public readonly Index<DisasmLineBlock> LineBlocks;

            [MethodImpl(Inline)]
            public DisasmFileBlocks(FileRef src, DisasmLineBlock[] blocks)
            {
                Source = src;
                LineBlocks = blocks;
            }
        }
    }
}