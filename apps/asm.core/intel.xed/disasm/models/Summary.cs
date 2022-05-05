//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class XedDisasm
    {
        public class Summary
        {
            public readonly uint RowCount;

            public readonly DataFile DataFile;

            public readonly FileRef Origin;

            public readonly Index<SummaryRow> Rows;

            public readonly Index<SummaryLines> LineIndex;

            internal Summary(in DataFile src, in FileRef origin, Index<SummaryRow> rows, SummaryLines[] lines)
            {
                DataFile = src;
                Origin = origin;
                Rows = rows;
                LineIndex = lines;
                RowCount = Rows.Count;
            }

            public FileRef DataSource
            {
                [MethodImpl(Inline)]
                get => DataFile.Source;
            }

            public ref SummaryRow this[int i]
            {
                [MethodImpl(Inline)]
                get => ref Rows[i];
            }

            public ref SummaryRow this[uint i]
            {
                [MethodImpl(Inline)]
                get => ref Rows[i];
            }

            public override int GetHashCode()
                => DataFile.Source.GetHashCode();

            public static Summary Empty
                => new Summary(DataFile.Empty, FileRef.Empty, sys.empty<SummaryRow>(),  sys.empty<SummaryLines>());
        }
    }
}