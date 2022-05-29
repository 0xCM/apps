//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    using static core;

    partial struct asm
    {
        [MethodImpl(Inline)]
        public static AsmBroadcast broadcast(byte id, BroadcastClass @class, text15 symbol, byte src, byte dst)
            => new AsmBroadcast(id,@class,symbol, src, dst);

    }
}