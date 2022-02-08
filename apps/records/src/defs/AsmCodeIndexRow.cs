//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using Asm;


    [Record(TableId), StructLayout(LayoutKind.Sequential,Pack=1)]
    public struct AsmCodeIndexRow : IComparable<AsmCodeIndexRow>
    {
        public static int compare(in AsmCodeIndexRow a, in AsmCodeIndexRow b)
        {
            var result = a.Mnemonic.Name.CompareTo(b.Mnemonic.Name);
            if(result == 0)
            {
                var left = a.Encoding.Bytes;
                var right = b.Encoding.Bytes;
                result = a.Encoding.CompareTo(b.Encoding);
            }
            return result;
        }

        public const string TableId = "asm.index";

        public const byte FieldCount = 7;

        public uint Seq;

        public uint DocId;

        public uint DocSeq;

        public Address32 IP;

        public CorrelationToken CT;

        public AsmExpr Asm;

        public AsmHexCode Encoding;

        public AsmMnemonic Mnemonic
            => AsmMnemonic.parse(Asm.Content, out _);

        public int CompareTo(AsmCodeIndexRow src)
            => compare(this,src);

        public static ReadOnlySpan<byte> RenderWidths => new byte[FieldCount]{8,8,8,12,12,82,1};
    }
}