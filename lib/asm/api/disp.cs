//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    using System.Runtime.CompilerServices;

    using static Root;

    partial struct asm
    {
        [MethodImpl(Inline), Op]
        public static Disp disp(long value, NativeSize size)
            => new Disp(value,size);

        [MethodImpl(Inline), Op]
        public static Disp disp(long value, BitWidth size)
            => new Disp(value, NativeSize.code(size));
    }
}