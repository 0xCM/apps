//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.alg
{
    using System;
    using System.Runtime.CompilerServices;

    using Z0;

    using static Z0.Root;

    /// <summary>
    /// Computes the FNV-1a hash of various things
    /// See http://en.wikipedia.org/wiki/Fowler%E2%80%93Noll%E2%80%93Vo_hash_function
    /// </summary>
    /// <param name="src">The data source</param>
    /// <remarks>Adapted from the .Net core type System.Reflection.Internal.Hash</remarks>
    [ApiHost("alg.hash")]
    public readonly partial struct hash
    {
        const uint K = 0xA5555529;

        const uint FnvOffsetBias = 2166136261;

        const uint FnvPrime = 16777619;

        const NumericKind Closure = UnsignedInts;

        [MethodImpl(Inline), Op]
        public static uint calc(Type src)
            => (uint)src.MetadataToken;

        [MethodImpl(Inline)]
        public static uint calc(string src)
            => (uint)(src?.GetHashCode() ?? 0);

        [MethodImpl(Inline)]
        public static uint combine(uint x, uint y)
            => FastHash.combine(x,y);

        [MethodImpl(Inline)]
        public static uint combine(int x, int y)
            => FastHash.combine(x,y);

        [MethodImpl(Inline)]
        public static uint combine(ulong x, ulong y)
            => FastHash.combine(x,y);

        [MethodImpl(Inline)]
        public static ulong combine(Type a, Type b)
            => FastHash.combine(a, b);

        [MethodImpl(Inline)]
        static unsafe int i32(float src)
            => (*((int*)(&src)));

        [MethodImpl(Inline)]
        static unsafe ulong u64(double src)
            => (*((ulong*)(&src)));

        [MethodImpl(Inline)]
        static unsafe ulong u64(decimal src)
            => (*((ulong*)(&src)));
    }
}