//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.InteropServices;

    [StructLayout(LayoutKind.Sequential), Record(TableId)]
    public struct SymInfo
    {
        public const string TableId = "tokens";

        public const byte FieldCount = 7;

        public Identifier TokenType;

        public SymClass TokenClass;

        public uint Index;

        public SymVal Value;

        public Identifier Name;

        public SymExpr Expr;

        public TextBlock Description;

        public static ReadOnlySpan<byte> RenderWidths
            => new byte[FieldCount]{24,32,8,16,32,32,1};
    }
}