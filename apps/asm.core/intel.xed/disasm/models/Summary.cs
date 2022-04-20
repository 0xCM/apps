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

            public readonly DataFile File;

            public readonly FileRef Origin;

            public readonly Index<SummaryRow> Rows;

            public readonly Index<SummaryLines> Lines;

            internal Summary(in DataFile src, in FileRef origin, Index<SummaryRow> rows, SummaryLines[] lines)
            {
                File = src;
                Origin = origin;
                Rows = rows;
                Lines = lines;
                RowCount = Rows.Count;
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
                => File.Source.GetHashCode();

            public static Summary Empty
                => new Summary(DataFile.Empty, FileRef.Empty, sys.empty<SummaryRow>(),  sys.empty<SummaryLines>());
        }
    }
}