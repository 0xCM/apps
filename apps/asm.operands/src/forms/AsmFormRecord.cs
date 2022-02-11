//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    [StructLayout(LayoutKind.Sequential), Record(TableId)]
    public struct AsmFormRecord
    {
        public const string TableId = "sdm.forms";

        public const byte FieldCount = 3;

        public uint Seq;

        public AsmSig Sig;

        public AsmOpCode OpCode;

        public static ReadOnlySpan<byte> RenderWidths
            => new byte[FieldCount]{6,48,1};
    }
}