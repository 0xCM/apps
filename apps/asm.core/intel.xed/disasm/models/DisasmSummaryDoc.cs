//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static XedDisasm;

    public class DisasmSummaryDoc : TableDoc<AsmDisasmSummary>
    {
        public static DisasmSummaryDoc from(in FileRef src, in FileRef origin, DisasmBlock[] blocks)
            => new DisasmSummaryDoc(src, origin, blocks);

        public DisasmSummaryDoc(in FileRef src, in FileRef origin, DisasmBlock[] blocks)
            : base(src.Path, blocks.Select(x => x.Summary))
        {
            Source = src;
            Origin = origin;
            Blocks = blocks.Sort();
        }

        public readonly FileRef Source;

        public readonly FileRef Origin;

        public readonly Index<DisasmBlock> Blocks;

        public static DisasmSummaryDoc Empty
            => new DisasmSummaryDoc(FileRef.Empty, FileRef.Empty, sys.empty<DisasmBlock>());
    }
}