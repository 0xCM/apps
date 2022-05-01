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

            public const byte CellWidth = 22;

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

            public LayoutCell this[byte i]
            {
                get
                {
                    var dst = LayoutCell.Empty;
                    switch(i)
                    {
                        case 0:
                            dst = Cell0;
                        break;
                        case 1:
                            dst = Cell1;
                        break;

                        case 2:
                            dst = Cell2;
                        break;

                        case 3:
                            dst = Cell3;
                        break;

                        case 4:
                            dst = Cell4;
                        break;

                        case 5:
                            dst = Cell5;
                        break;

                        case 6:
                            dst = Cell6;
                        break;

                        case 7:
                            dst = Cell7;
                        break;

                        case 8:
                            dst = Cell8;
                        break;

                        case 9:
                            dst = Cell9;
                        break;

                        case 10:
                            dst = Cell10;
                        break;
                    };

                    return dst;
                }
            }

            public static string cells(in InstLayout src)
            {
                var dst = text.emitter();
                cells(src,dst);
                return dst.Emit();
            }

            public static void cells(in InstLayout src, ITextEmitter dst)
            {
                for(var i=z8; i<src.Count; i++)
                {
                    dst.AppendFormat("{0} ", src[i]);
                }
            }

            public int CompareTo(InstLayout src)
                => PatternId.CompareTo(src.PatternId);

            public static ReadOnlySpan<byte> RenderWidths => new byte[TotalCount]{
                12,18,18,6,
                CellWidth,CellWidth,CellWidth,CellWidth,
                CellWidth,CellWidth,CellWidth,CellWidth,
                CellWidth,CellWidth,CellWidth,
                };

            public static InstLayout Empty => default;
        }
    }
}