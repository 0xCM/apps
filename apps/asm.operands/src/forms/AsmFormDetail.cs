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
        const string TableId = "sdm.forms.detail";

        public const byte FieldCount = 11;

        [Render(8)]
        public uint Seq;

        [Render(12)]
        public Hex32 Id;

        [Render(38)]
        public text47 Name;

        [Render(48)]
        public AsmSig Sig;

        [Render(42)]
        public AsmOpCode OpCode;

        [Render(8)]
        public bit Mode64;

        [Render(8)]
        public bit Mode32;

        [Render(8)]
        public bit IsRex;

        [Render(8)]
        public bit IsVex;

        [Render(8)]
        public bit IsEvex;

        [Render(1)]
        public TextBlock Description;

        //public static ReadOnlySpan<byte> RenderWidths => new byte[FieldCount]{8,12,38,48,42,8,8,8,8,8,1};

        public int CompareTo(AsmFormDetail src)
        {
            var result = Sig.Format().CompareTo(src.Sig.Format());
            if(result == 0)
                result = OpCode.Format().CompareTo(src.OpCode.Format());
            return result;
        }
    }
}