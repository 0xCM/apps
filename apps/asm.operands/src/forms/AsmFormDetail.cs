//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using Asm;

    [Record(TableId), StructLayout(LayoutKind.Sequential,Pack=1)]
    public struct AsmFormDetail : IComparable<AsmFormDetail>
    {
        public const string TableId = "sdm.forms.detail";

        public const byte FieldCount = 9;

        public uint Seq;

        public Hex32 Id;

        public Identifier Name;

        public AsmSig Sig;

        public AsmOpCode OpCode;

        public bit IsRex;

        public bit IsVex;

        public bit IsEvex;

        public @string Description;

        public static ReadOnlySpan<byte> RenderWidths => new byte[FieldCount]{6,12,32,48,32,6,6,6,1};

        public int CompareTo(AsmFormDetail src)
        {
            var result = Sig.Format().CompareTo(src.Sig.Format());
            if(result == 0)
                result = OpCode.Format().CompareTo(src.OpCode.Format());
            return result;
        }
    }
}