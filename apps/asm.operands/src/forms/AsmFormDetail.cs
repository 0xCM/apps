//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using Asm;

    [Record(TableId), StructLayout(LayoutKind.Sequential,Pack=1)]
    public struct AsmFormDetail
    {
        public const string TableId = "sdm.forms.detail";

        public const byte FieldCount = 7;

        public uint Seq;

        public Identifier Name;

        public AsmSig Sig;

        public AsmOpCode OpCode;

        public bit IsRex;

        public bit IsVex;

        public bit IsEvex;

        public static ReadOnlySpan<byte> RenderWidths => new byte[7]{6,32,48,32,6,6,6};
    }
}