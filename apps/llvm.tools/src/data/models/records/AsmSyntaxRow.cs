//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.llvm
{
    using System;
    using System.Runtime.InteropServices;

    using Asm;

    [Record(TableId), StructLayout(LayoutKind.Sequential, Pack=1)]
    public struct AsmSyntaxRow
    {
        public const string TableId = "llvm.asm.syntax";

        public const byte FieldCount = 6;

        public uint Seq;

        public LineOffset Location;

        public AsmExpr Expr;

        public string Syntax;

        public AsmHexCode Encoding;

        public FS.FileUri Source;

        public static ReadOnlySpan<byte> RenderWidths => new byte[FieldCount]{8,12,62,120,48,5};
    }
}