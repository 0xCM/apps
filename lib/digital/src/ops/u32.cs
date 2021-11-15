//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;

    partial struct Digital
    {
        [MethodImpl(Inline), Op]
        public static uint u32(Base2 @base, char c)
            => (uint)digit(@base, c);

        [MethodImpl(Inline), Op]
        public static uint u32(Base8 @base, char c)
            => (uint)digit(@base, c);

        [MethodImpl(Inline), Op]
        public static uint u32(Base10 @base, char c)
            => (uint)digit(@base, c);

        [MethodImpl(Inline), Op]
        public static uint u32(Base16 @base, char c)
            => (uint)digit(@base, c);

        [MethodImpl(Inline), Op]
        public static uint u32(Base16 @base, UpperCased @case, char c)
            => (uint)digit(@base, @case, c);

        [MethodImpl(Inline), Op]
        public static uint u32(Base16 @base, LowerCased @case, char c)
            => (uint)digit(@base, @case, c);
    }
}