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

        public const byte FieldCount = 11;

        public uint Seq;

        public Hex32 Id;

        public text47 Name;

        public AsmSig Sig;

        public AsmOpCode OpCode;

        public bit Mode64;

        public bit Mode32;

        public bit IsRex;

        public bit IsVex;

        public bit IsEvex;

        public TextBlock Description;

        public static ReadOnlySpan<byte> RenderWidths => new byte[FieldCount]{8,12,38,48,42,8,8,8,8,8,1};

        public int CompareTo(AsmFormDetail src)
        {
            var result = Sig.Format().CompareTo(src.Sig.Format());
            if(result == 0)
                result = OpCode.Format().CompareTo(src.OpCode.Format());
            return result;
        }
    }
}