//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    using Asm;

    using static XedRules;
    using static XedModels;

    partial class XedDisasm
    {
        public class DetailBlock : IComparable<DetailBlock>
        {
            public DetailBlockRow DetailRow;

            public readonly SummaryLines SummaryLines;

            [MethodImpl(Inline)]
            public DetailBlock(DetailBlockRow detail, SummaryLines block)
            {
                DetailRow = detail;
                SummaryLines = block;
            }

            public DetailBlock WithRow(in DetailBlockRow src)
                => new DetailBlock(src,SummaryLines);

            public ref readonly SummaryRow Summary
            {
                [MethodImpl(Inline)]
                get => ref SummaryLines.Summary;
            }

            public ref readonly Hex32 OriginId
            {
                [MethodImpl(Inline)]
                get => ref Summary.OriginId;
            }

            public ref readonly @string OriginName
            {
                [MethodImpl(Inline)]
                get => ref Summary.OriginName;
            }

            public ref readonly uint Seq
            {
                [MethodImpl(Inline)]
                get => ref Summary.Seq;
            }

            public ref readonly uint DocSeq
            {
                [MethodImpl(Inline)]
                get => ref Summary.DocSeq;
            }

            public ref readonly InstructionId Id
            {
                [MethodImpl(Inline)]
                get => ref Summary.InstructionId;
            }

            public ref readonly LineBlock Lines
            {
                [MethodImpl(Inline)]
                get => ref SummaryLines.Lines;
            }

            public ReadOnlySpan<TextLine> OpLines
            {
                [MethodImpl(Inline)]
                get => Lines.Ops;
            }

            public ref readonly TextLine PropsLine
            {
                [MethodImpl(Inline)]
                get => ref Lines.Props;
            }

            public ref readonly TextLine YDisLine
            {
                [MethodImpl(Inline)]
                get  => ref Lines.YDis;
            }

            public ref readonly TextLine XDisLine
            {
                [MethodImpl(Inline)]
                get  => ref Lines.XDis;
            }

            public ref readonly FS.FileUri SourceFile
            {
                [MethodImpl(Inline)]
                get => ref Summary.Source;
            }

            public SizeOverride SZOV
            {
                [MethodImpl(Inline)]
                get => DetailRow.SZOV;
            }

            public ref readonly NativeSize EASZ
            {
                [MethodImpl(Inline)]
                get => ref DetailRow.EASZ;
            }

            public ref readonly NativeSize EOSZ
            {
                [MethodImpl(Inline)]
                get => ref DetailRow.EOSZ;
            }

            public ref readonly AsmExpr Asm
            {
                [MethodImpl(Inline)]
                get => ref DetailRow.Asm;
            }

            public ref readonly MemoryAddress IP
            {
                [MethodImpl(Inline)]
                get => ref DetailRow.IP;
            }

            public ref readonly AsmHexCode Encoded
            {
                [MethodImpl(Inline)]
                get => ref DetailRow.Encoded;
            }

            public ref readonly EncodingOffsets Offsets
            {
                [MethodImpl(Inline)]
                get => ref DetailRow.Offsets;
            }

            public ref readonly InstClass InstClass
            {
                [MethodImpl(Inline)]
                get => ref DetailRow.InstClass;
            }

            public ref readonly InstForm InstForm
            {
                [MethodImpl(Inline)]
                get => ref DetailRow.InstForm;
            }

            public ref readonly byte Size
            {
                [MethodImpl(Inline)]
                get => ref Summary.Size;
            }

            public ref readonly Hex8 OpCode
            {
                [MethodImpl(Inline)]
                get => ref DetailRow.OpCode;
            }

            public ref readonly byte PSZ
            {
                [MethodImpl(Inline)]
                get => ref DetailRow.PSZ;
            }

            public ref readonly RexPrefix Rex
            {
                [MethodImpl(Inline)]
                get => ref DetailRow.Rex;
            }

            public ref readonly VexPrefix Vex
            {
                [MethodImpl(Inline)]
                get => ref DetailRow.Vex;
            }

            public ref readonly EvexPrefix Evex
            {
                [MethodImpl(Inline)]
                get => ref DetailRow.Evex;
            }

            public int CompareTo(DetailBlock src)
                => DetailRow.CompareTo(src.DetailRow);

            public static DetailBlock Empty => new DetailBlock(DetailBlockRow.Empty, SummaryLines.Empty);
        }
    }
}