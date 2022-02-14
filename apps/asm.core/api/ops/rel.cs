//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    partial struct asm
    {
        [MethodImpl(Inline), Op]
        public static Rel8 rel8(byte src)
            => src;

        [MethodImpl(Inline), Op]
        public static Rel16 rel16(ushort src)
            => src;

        [MethodImpl(Inline), Op]
        public static Rel32 rel32(uint src)
            => src;

        public static Rel rel(AsmRelKind kind, uint value)
            => new Rel(kind, value);
    }
}