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
            public static Summary create(in DataFile file, DisasmSummaryLines[] lines)
            {
                var sorted = lines.Sort();
                return new (file, file.Origin, XedDisasm.resequence(lines.Select(line => line.Summary)), sorted);
            }

            public readonly uint RowCount;

            public readonly DataFile File;

            public readonly FileRef Origin;

            public readonly Index<DisasmSummaryRow> Rows;

            public readonly Index<DisasmSummaryLines> Lines;

            Summary(in DataFile src, in FileRef origin, Index<DisasmSummaryRow> rows, DisasmSummaryLines[] lines)
            {
                File = src;
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
                => File.Source.GetHashCode();

            public static Summary Empty
                => new Summary(DataFile.Empty, FileRef.Empty, sys.empty<DisasmSummaryRow>(),  sys.empty<DisasmSummaryLines>());
        }
    }
}