//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public class AsmDisasmSummaryDoc : TableDoc<AsmDisasmSummary>
    {
        public AsmDisasmSummaryDoc(FS.FilePath src, AsmDisasmSummary[] rows)
            : base(src,rows)
        {
        }

        public static implicit operator AsmDisasmSummaryDoc((FS.FilePath src, AsmDisasmSummary[] rows) x)
            => new AsmDisasmSummaryDoc(x.src,x.rows);

        public static AsmDisasmSummaryDoc Empty
            => new AsmDisasmSummaryDoc(FS.FilePath.Empty, sys.empty<AsmDisasmSummary>());
    }
}