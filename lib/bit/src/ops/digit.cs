//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;
    using static core;

    partial struct bit
    {
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static bit element<T>(in bits<T> src, uint index)
            where  T : unmanaged
        {
            var data = bytes(src.Packed);
            ref readonly var cell = ref skip(data,index/8);
            return bit.test(cell, (byte)(index % 8));
        }

        [MethodImpl(Inline), Op]
        public static BinaryDigit digit(bit src)
            => src;

        public static Outcome digit(string src, out BinaryDigit dst)
        {
            var chars = span((src ?? EmptyString).Trim());
            var count = chars.Length;
            dst = default;
            if(count != 1)
                return false;
            ref readonly var c = ref first(chars);
            if(c == Chars.D0)
            {
                dst = BinaryDigitCode.b0;
                return true;
            }
            else if(c == Chars.D1)
            {
                dst = BinaryDigitCode.b1;
                return true;
            }
            return false;
        }
    }
}