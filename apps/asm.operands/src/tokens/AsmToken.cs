//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [Record(TableId)]
    public struct AsmToken
    {
        public const string TableId = "asm.tokens";

        [Render(12)]
        public uint Seq;

        [Render(12)]
        public uint Index;

        [Render(16)]
        public string Group;

        [Render(12)]
        public uint KindIndex;

        [Render(24)]
        public string KindName;

        [Render(24)]
        public string Name;

        [Render(16)]
        public SymVal Value;

        [Render(16)]
        public SymExpr Expr;
    }
}