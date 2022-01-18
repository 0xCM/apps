//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.InteropServices;

    using Asm;

    [Record(TableId), StructLayout(LayoutKind.Sequential, Pack=1)]
    public struct AsmSyntaxRow : ISequential
    {
        public const string TableId = "asm.syntax";

        public const byte FieldCount = 8;

        public uint Seq;

        public uint DocId;

        public uint DocSeq;

        public LineOffset Location;

        public AsmExpr Expr;

        public @string Syntax;

        public AsmHexCode HexCode;

        public FS.FileUri Source;

        uint ISequential.Seq
            => Seq;

        public string SyntaxContent
        {
            get
            {
                if(text.fenced(Syntax, RenderFence.Paren))
                    return text.trim(text.despace(text.unfence(Syntax,RenderFence.Paren)));
                else
                    return text.trim(text.despace(Syntax.Format()));
            }
        }

        public static ReadOnlySpan<byte> RenderWidths => new byte[FieldCount]{8,8,8,12,62,120,48,5};
    }
}