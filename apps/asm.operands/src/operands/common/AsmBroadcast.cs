//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    [StructLayout(LayoutKind.Sequential,Pack=1), Record(TableId)]
    public struct AsmBroadcast
    {
        public const byte FieldCount = 3;

        public const string TableId = "asm.broadcast.def";

        [Render(8)]
        public byte Id;

        [Render(8)]
        public Ratio<byte> Ratio;

        [Render(8)]
        public text15 Symbol;

        [MethodImpl(Inline)]
        public AsmBroadcast(byte id, BroadcastClass @class, text15 symbol, byte src, byte dst)
        {
            Id = id;
            Symbol = symbol;
            Ratio = (src,dst);
        }

        public string Format()
            => Symbol.Format();

        public override string ToString()
            => Format();

        public static AsmBroadcast Empty => default;

        public static ReadOnlySpan<byte> RenderWidths => new byte[FieldCount]{8,8,8};
    }
}