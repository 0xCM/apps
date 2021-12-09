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
        public const string TableId = "asm.syntax";

        public uint Seq;

        public LineOffset Location;

        public AsmExpr Expr;

        public string Syntax;

        public FS.FileUri Source;

        public static ReadOnlySpan<byte> RenderWidths => new byte[5]{8,12,62,120,5};
    }
}