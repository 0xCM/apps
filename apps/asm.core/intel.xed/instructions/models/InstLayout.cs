//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class XedRules
    {
        [Record(TableName), StructLayout(LayoutKind.Sequential,Pack=1)]
        public struct InstLayout : IComparable<InstLayout>
        {
            public const string TableName = "xed.inst.layouts";

            public const byte CellCount = 11;

            const byte HeaderCount = 4;

            const byte TotalCount = HeaderCount + CellCount;

            const byte CellWidth = 22;

            public ushort PatternId;

            public InstClass Instruction;

            public XedOpCode OpCode;

            public byte Count;

            public LayoutCell Cell0;

            public LayoutCell Cell1;

            public LayoutCell Cell2;

            public LayoutCell Cell3;

            public LayoutCell Cell4;

            public LayoutCell Cell5;

            public LayoutCell Cell6;

            public LayoutCell Cell7;

            public LayoutCell Cell8;

            public LayoutCell Cell9;

            public LayoutCell Cell10;

            public int CompareTo(InstLayout src)
                => PatternId.CompareTo(src.PatternId);

            public static ReadOnlySpan<byte> RenderWidths => new byte[TotalCount]{
                12,18,18,6,
                CellWidth,CellWidth,CellWidth,CellWidth,
                CellWidth,CellWidth,CellWidth,CellWidth,
                CellWidth,CellWidth,CellWidth,
                };
        }
    }
}