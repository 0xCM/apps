//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static XedDisasm;

    public class DisasmSummaryDoc : TableDoc<AsmDisasmSummary>
    {
        public static DisasmSummaryDoc from(in FileRef src, in FileRef origin, DisasmSummaryBlock[] blocks)
            => new DisasmSummaryDoc(src, origin, blocks);

        public DisasmSummaryDoc(in FileRef src, in FileRef origin, DisasmSummaryBlock[] blocks)
            : base(src.Path, blocks.Select(x => x.Summary))
        {


        }

        public DisasmSummaryDoc(FS.FilePath src, AsmDisasmSummary[] rows)
            : base(src,rows)
        {
        }

        public static implicit operator DisasmSummaryDoc((FS.FilePath src, AsmDisasmSummary[] rows) x)
            => new DisasmSummaryDoc(x.src,x.rows);

        public static DisasmSummaryDoc Empty
            => new DisasmSummaryDoc(FS.FilePath.Empty, sys.empty<AsmDisasmSummary>());
    }
}