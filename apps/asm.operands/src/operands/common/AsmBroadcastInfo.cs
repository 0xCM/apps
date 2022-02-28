//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    [StructLayout(LayoutKind.Sequential,Pack=1)]
    public readonly struct AsmBroadcastInfo
    {
        [MethodImpl(Inline)]
        public static AsmBroadcastInfo define(uint5 id, AsmBroadcastClass @class, text15 symbol, byte src, byte dst)
            => new AsmBroadcastInfo(id,@class,symbol, src, dst);

        public readonly uint5 Id;

        public readonly AsmBroadcastClass Class;

        public readonly Ratio<byte> Ratio;

        public readonly text15 Symbol;

        [MethodImpl(Inline)]
        public AsmBroadcastInfo(uint5 id, AsmBroadcastClass @class, text15 symbol, byte src, byte dst)
        {
            Id = id;
            Class = @class;
            Symbol = symbol;
            Ratio = (src,dst);
        }

        public string Format()
            => Symbol.Format();

        public override string ToString()
            => Format();

        public static AsmBroadcastInfo Empty => default;
    }
}