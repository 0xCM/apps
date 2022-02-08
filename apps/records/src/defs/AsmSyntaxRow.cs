//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using Asm;

    [Record(TableId), StructLayout(LayoutKind.Sequential, Pack=1)]
    public struct AsmSyntaxRow : ISequential
    {
        public const string TableId = "asm.syntax";

        public const byte FieldCount = 9;

        public uint Seq;

        public uint DocId;

        public uint DocSeq;

        public LineOffset Location;

        public AsmMnemonic Mnemonic;

        public AsmExpr Expr;

        public @string Syntax;

        public AsmHexCode HexCode;

        public FS.FileUri Source;

        uint ISequential.Seq
            => Seq;

        public static ReadOnlySpan<byte> RenderWidths => new byte[FieldCount]{8,8,8,12,16,62,120,48,5};
    }
}