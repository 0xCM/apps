//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public sealed class DisasmSummaryDocs : ConstLookup<FileRef,DisasmSummaryDoc>
    {
        public DisasmSummaryDocs(Dictionary<FileRef, DisasmSummaryDoc> src)
            : base(src)
        {


        }

        public DisasmSummaryDocs(ConcurrentDictionary<FileRef, DisasmSummaryDoc> src)
            : base(src)
        {


        }

        public static implicit operator DisasmSummaryDocs(Dictionary<FileRef, DisasmSummaryDoc> src)
            => new DisasmSummaryDocs(src);

        public static implicit operator DisasmSummaryDocs(ConcurrentDictionary<FileRef, DisasmSummaryDoc> src)
            => new DisasmSummaryDocs(src);
    }
}