//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    [StructLayout(LayoutKind.Sequential,Pack=1), Record(TableId)]
    public struct AsmBroadcast
    {
        [MethodImpl(Inline)]
        public static AsmBroadcast define(byte id, BroadcastClass @class, text15 symbol, byte src, byte dst)
            => new AsmBroadcast(id,@class,symbol, src, dst);

        const string TableId = "asm.broadcasts";

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
    }
}