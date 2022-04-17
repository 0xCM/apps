//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static XedDisasm;

    public class DisasmSummaryDoc
    {
        public static DisasmSummaryDoc from(in FileRef src, in FileRef origin, DisasmSummaryLines[] lines)
            => new DisasmSummaryDoc(src, origin, lines);

        public DisasmSummaryDoc(in FileRef src, in FileRef origin, DisasmSummaryLines[] lines)
        {
            Source = src;
            Origin = origin;
            Rows = lines.Select(x => x.Summary);
            Lines = lines.Sort();
            RowCount = Rows.Count;
        }

        public readonly uint RowCount;

        public readonly FileRef Source;

        public readonly FileRef Origin;

        public readonly Index<DisasmSummary> Rows;

        public readonly Index<DisasmSummaryLines> Lines;

        public ref DisasmSummary this[int i]
        {
            [MethodImpl(Inline)]
            get => ref Rows[i];
        }

        public ref DisasmSummary this[uint i]
        {
            [MethodImpl(Inline)]
            get => ref Rows[i];
        }

        public static DisasmSummaryDoc Empty
            => new DisasmSummaryDoc(FileRef.Empty, FileRef.Empty, sys.empty<DisasmSummaryLines>());
    }
}