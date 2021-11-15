//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;

    partial struct asm
    {
        [MethodImpl(Inline), Op]
        public static NativeSizeCode code(BitWidth src)
        {
            if(src != 80)
            {
                var i = Pow2.log(src >> 3);
                return (NativeSizeCode)i;
            }
            else
                return NativeSizeCode.W80;
        }

        [MethodImpl(Inline), Op]
        public static NativeSize asmsize(BitWidth src)
            => code(src);

        [MethodImpl(Inline)]
        public static NativeSize asmsize<W>(W w)
            where W : unmanaged, IDataWidth
                => code((BitWidth)w.BitWidth);

        [MethodImpl(Inline)]
        public static NativeSize asmsize<T>()
            where T : unmanaged
                => asmsize(core.width<T>());
    }
}