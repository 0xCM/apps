//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    [StructLayout(LayoutKind.Sequential,Pack=1), Record(TableId)]
    public struct AsmBroadcastDef
    {
        public const byte FieldCount = 3;

        public const string TableId = "asm.broadcast.def";

        [MethodImpl(Inline)]
        public static AsmBroadcastDef define(byte id, AsmBroadcastClass @class, text15 symbol, byte src, byte dst)
            => new AsmBroadcastDef(id,@class,symbol, src, dst);

        public byte Id;

        public Ratio<byte> Ratio;

        public text15 Symbol;

        [MethodImpl(Inline)]
        public AsmBroadcastDef(byte id, AsmBroadcastClass @class, text15 symbol, byte src, byte dst)
        {
            Id = id;
            Symbol = symbol;
            Ratio = (src,dst);
        }

        public string Format()
            => Symbol.Format();

        public override string ToString()
            => Format();

        public static AsmBroadcastDef Empty => default;

        public static ReadOnlySpan<byte> RenderWidths => new byte[FieldCount]{8,8,8};
    }
}