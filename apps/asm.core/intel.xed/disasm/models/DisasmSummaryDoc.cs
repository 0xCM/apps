//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static XedDisasm;

    public class DisasmSummaryDoc : TableDoc<DisasmSummary>
    {
        public static DisasmSummaryDoc from(in FileRef src, in FileRef origin, DisasmSummaryLines[] blocks)
            => new DisasmSummaryDoc(src, origin, blocks);

        public DisasmSummaryDoc(in FileRef src, in FileRef origin, DisasmSummaryLines[] blocks)
            : base(src.Path, blocks.Select(x => x.Summary))
        {
            Source = src;
            Origin = origin;
            Blocks = blocks.Sort();
        }

        public readonly FileRef Source;

        public readonly FileRef Origin;

        public readonly Index<DisasmSummaryLines> Blocks;

        public static DisasmSummaryDoc Empty
            => new DisasmSummaryDoc(FileRef.Empty, FileRef.Empty, sys.empty<DisasmSummaryLines>());
    }
}