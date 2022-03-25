//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial struct CellDelegates
    {
        [MethodImpl(NotInline), Op]
        public static Emitter1 emitter(Emitter<bit> f)
            => () => f();

        [MethodImpl(NotInline), Op]
        public static Emitter8 emitter(Emitter<sbyte> f)
            => () => f();

        [MethodImpl(NotInline), Op]
        public static Emitter8 emitter(Emitter<byte> f)
            => () => f();

        [MethodImpl(NotInline), Op]
        public static Emitter16 emitter(Emitter<short> f)
            => () => f();

        [MethodImpl(NotInline), Op]
        public static Emitter16 emitter(Emitter<ushort> f)
            => () => f();

        [MethodImpl(NotInline), Op]
        public static Emitter32 emitter(Emitter<int> f)
            => () => f();

        [MethodImpl(NotInline), Op]
        public static Emitter32 emitter(Emitter<uint> f)
            => () => f();

        [MethodImpl(NotInline), Op]
        public static Emitter64 emitter(Emitter<long> f)
            => () => f();

        [MethodImpl(NotInline), Op]
        public static Emitter64 emitter(Emitter<ulong> f)
            => () => f();
    }
}