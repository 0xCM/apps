//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public sealed class AsmDisasmSummaryDocs : ConstLookup<FileRef,AsmDisasmSummaryDoc>
    {
        public AsmDisasmSummaryDocs(Dictionary<FileRef, AsmDisasmSummaryDoc> src)
            : base(src)
        {


        }

        public static implicit operator AsmDisasmSummaryDocs(Dictionary<FileRef, AsmDisasmSummaryDoc> src)
            => new AsmDisasmSummaryDocs(src);
    }
}