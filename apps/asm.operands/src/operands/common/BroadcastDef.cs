//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    [StructLayout(LayoutKind.Sequential,Pack=1), Record(TableId)]
    public struct BroadcastDef
    {
        [MethodImpl(Inline)]
        public static BroadcastDef define(byte id, BroadcastClass @class, text15 symbol, byte src, byte dst)
            => new BroadcastDef(id,@class,symbol, src, dst);

        public const byte FieldCount = 3;

        public const string TableId = "asm.broadcast.def";

        public byte Id;

        public Ratio<byte> Ratio;

        public text15 Symbol;

        [MethodImpl(Inline)]
        public BroadcastDef(byte id, BroadcastClass @class, text15 symbol, byte src, byte dst)
        {
            Id = id;
            Symbol = symbol;
            Ratio = (src,dst);
        }

        public string Format()
            => Symbol.Format();

        public override string ToString()
            => Format();

        public static BroadcastDef Empty => default;

        public static ReadOnlySpan<byte> RenderWidths => new byte[FieldCount]{8,8,8};
    }
}