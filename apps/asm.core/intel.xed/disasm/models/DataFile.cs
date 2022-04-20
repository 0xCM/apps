//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class XedDisasm
    {
        public readonly struct DataFile : IComparable<DataFile>
        {
            public readonly FileRef Origin;

            public readonly FileRef Source;

            public readonly Index<DisasmLineBlock> Lines;

            [MethodImpl(Inline)]
            public DataFile(in FileRef origin, in FileRef src, DisasmLineBlock[] lines)
            {
                Origin = origin;
                Source = src;
                Lines = lines;
            }

            public uint Seq
            {
                [MethodImpl(Inline)]
                get => Source.Seq;
            }

            public Hex32 DocId
            {
                [MethodImpl(Inline)]
                get => Source.DocId;
            }

            public uint LineCount
            {
                [MethodImpl(Inline)]
                get => Lines.Count;
            }

            public ref readonly DisasmLineBlock this[int i]
            {
                [MethodImpl(Inline)]
                get => ref Lines[i];
            }

            public ref readonly DisasmLineBlock this[uint i]
            {
                [MethodImpl(Inline)]
                get => ref Lines[i];
            }

            public int CompareTo(DataFile src)
                => Seq.CompareTo(src.Seq);

            public static DataFile Empty => new DataFile(FileRef.Empty, FileRef.Empty, sys.empty<DisasmLineBlock>());
        }
    }
}