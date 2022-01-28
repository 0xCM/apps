//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;
    using static core;

    [Record(TableId)]
    public struct AsmSigTerminal
    {
        public const string TableId = "sdm.sigs.terminals";

        public const byte FieldCount = 3;

        public uint Seq;

        public AsmSigExpr Source;

        public AsmSigRuleExpr Target;

        public static ReadOnlySpan<byte> RenderWidths => new byte[FieldCount]{8,64,1};
    }
}