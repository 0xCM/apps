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
            public DetailBlockRow Detail;

            public readonly DisasmSummaryLines Block;

            [MethodImpl(Inline)]
            public DetailBlock(DetailBlockRow detail, DisasmSummaryLines block)
            {
                Detail = detail;
                Block = block;
            }

            public DetailBlock WithRow(in DetailBlockRow src)
                => new DetailBlock(src,Block);

            public ref readonly DisasmSummary Summary
            {
                [MethodImpl(Inline)]
                get => ref Block.Summary;
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

            public ref readonly DisasmLineBlock Lines
            {
                [MethodImpl(Inline)]
                get => ref Block.Lines;
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
                get => Detail.SZOV;
            }

            public ref readonly NativeSize EASZ
            {
                [MethodImpl(Inline)]
                get => ref Detail.EASZ;
            }

            public ref readonly NativeSize EOSZ
            {
                [MethodImpl(Inline)]
                get => ref Detail.EOSZ;
            }

            public ref readonly AsmExpr Asm
            {
                [MethodImpl(Inline)]
                get => ref Detail.Asm;
            }

            public ref readonly MemoryAddress IP
            {
                [MethodImpl(Inline)]
                get => ref Detail.IP;
            }

            public ref readonly AsmHexCode Encoded
            {
                [MethodImpl(Inline)]
                get => ref Detail.Encoded;
            }

            public ref readonly EncodingOffsets Offsets
            {
                [MethodImpl(Inline)]
                get => ref Detail.Offsets;
            }

            public ref readonly InstClass InstClass
            {
                [MethodImpl(Inline)]
                get => ref Detail.InstClass;
            }

            public ref readonly InstForm InstForm
            {
                [MethodImpl(Inline)]
                get => ref Detail.InstForm;
            }

            public ref readonly byte Size
            {
                [MethodImpl(Inline)]
                get => ref Summary.Size;
            }

            public ref readonly Hex8 OpCode
            {
                [MethodImpl(Inline)]
                get => ref Detail.OpCode;
            }

            public ref readonly byte PSZ
            {
                [MethodImpl(Inline)]
                get => ref Detail.PSZ;
            }

            public ref readonly RexPrefix Rex
            {
                [MethodImpl(Inline)]
                get => ref Detail.Rex;
            }

            public ref readonly VexPrefix Vex
            {
                [MethodImpl(Inline)]
                get => ref Detail.Vex;
            }

            public ref readonly EvexPrefix Evex
            {
                [MethodImpl(Inline)]
                get => ref Detail.Evex;
            }

            public ref readonly DisasmOpDetails Ops
            {
                [MethodImpl(Inline)]
                get => ref Detail.Ops;
            }

            public int CompareTo(DetailBlock src)
                => Detail.CompareTo(src.Detail);

            public static DetailBlock Empty => new DetailBlock(DetailBlockRow.Empty, DisasmSummaryLines.Empty);
        }
    }
}