//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static XedDisasm;

    public class DisasmSummaryDoc
    {
        public static DisasmSummaryDoc create(in FileRef src, in FileRef origin, DisasmSummaryLines[] lines)
        {
            var sorted = lines.Sort();
            return new (src, origin, XedDisasm.resequence(lines.Select(line => line.Summary)), sorted);
        }

        public static DisasmSummaryDoc from(in FileRef src, in FileRef origin, DisasmSummaryLines[] lines)
            => new DisasmSummaryDoc(src, origin, lines);

        public readonly uint RowCount;

        public readonly FileRef Source;

        public readonly FileRef Origin;

        public readonly Index<DisasmSummaryRow> Rows;

        public readonly Index<DisasmSummaryLines> Lines;

        public DisasmSummaryDoc(in FileRef src, in FileRef origin, DisasmSummaryLines[] lines)
        {
            Source = src;
            Origin = origin;
            Rows = lines.Select(x => x.Summary);
            Lines = lines.Sort();
            RowCount = Rows.Count;
        }

        DisasmSummaryDoc(in FileRef src, in FileRef origin, Index<DisasmSummaryRow> rows, DisasmSummaryLines[] lines)
        {
            Source = src;
            Origin = origin;
            Rows = rows;
            Lines = lines;
            RowCount = Rows.Count;
        }

        public ref DisasmSummaryRow this[int i]
        {
            [MethodImpl(Inline)]
            get => ref Rows[i];
        }

        public ref DisasmSummaryRow this[uint i]
        {
            [MethodImpl(Inline)]
            get => ref Rows[i];
        }

        public override int GetHashCode()
            => Source.GetHashCode();

        public static DisasmSummaryDoc Empty
            => new DisasmSummaryDoc(FileRef.Empty, FileRef.Empty, sys.empty<DisasmSummaryLines>());
    }
}