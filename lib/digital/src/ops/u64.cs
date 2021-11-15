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
        public static ulong u64(Base2 @base, char c)
            => (ulong)digit(@base, c);

        [MethodImpl(Inline), Op]
        public static ulong u64(Base8 @base, char c)
            => (ulong)digit(@base, c);

        [MethodImpl(Inline), Op]
        public static ulong u64(Base10 @base, char c)
            => (ulong)digit(@base, c);

        [MethodImpl(Inline), Op]
        public static ulong u64(Base16 @base, char c)
            => (ulong)digit(@base, c);

        [MethodImpl(Inline), Op]
        public static ulong u64(Base16 @base, UpperCased @case, char c)
            => (ulong)digit(@base, @case, c);

        [MethodImpl(Inline), Op]
        public static ulong u64(Base16 @base, LowerCased @case, char c)
            => (ulong)digit(@base, @case, c);
    }
}