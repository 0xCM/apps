//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;
    using System.Reflection;
    using System.Runtime.Intrinsics;

    using static Root;
    using static core;
    using static Cells;

    partial struct CellDelegates
    {
        /// <summary>
        /// Creates a fixed 16-bit binary operator from caller-supplied delegate
        /// </summary>
        /// <param name="f">The source delegate</param>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static BinaryOp8 binary<T>(Func<T,T,T> f, W8 dst)
            where T : unmanaged
                => (Cell8 a, Cell8 b) => cell8(f(a.As<T>(),b.As<T>()));

        /// <summary>
        /// Creates a fixed 16-bit binary operator from caller-supplied delegate
        /// </summary>
        /// <param name="f">The source delegate</param>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static BinaryOp16 binary<T>(Func<T,T,T> f, W16 dst)
            where T : unmanaged
                => (Cell16 a, Cell16 b) => cell16(f(a.As<T>(),b.As<T>()));

        /// <summary>
        /// Creates a fixed 32-bit binary operator from caller-supplied delegate
        /// </summary>
        /// <param name="f">The source delegate</param>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static BinaryOp32 binary<T>(Func<T,T,T> f, W32 dst)
            where T : unmanaged
                => (Cell32 a, Cell32 b) => cell32(f(a.As<T>(),b.As<T>()));

        /// <summary>
        /// Creates a fixed 64-bit binary operator from caller-supplied delegate
        /// </summary>
        /// <param name="f">The source delegate</param>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static BinaryOp64 binary<T>(Func<T,T,T> f, W64 dst)
            where T : unmanaged
                => (Cell64 a, Cell64 b) => cell64(f(a.As<T>(),b.As<T>()));

        [MethodImpl(NotInline), Op]
        public static BinaryOp1 binary(BinaryOp<bit> f)
            => (a,b) => f(a,b);

        [MethodImpl(NotInline), Op]
        public static BinaryOp8 binary(BinaryOp<sbyte> f)
            => (a, b) => f((sbyte)a.Content, (sbyte)b.Content);

        [MethodImpl(NotInline), Op]
        public static BinaryOp8 binary(BinaryOp<byte> f)
            => (a, b) => f(a.Content, b.Content);

        [MethodImpl(NotInline), Op]
        public static BinaryOp16 binary(BinaryOp<short> f)
            => (a, b) => f((short)a.Content, (short)b.Content);

        [MethodImpl(NotInline), Op]
        public static BinaryOp16 binary(BinaryOp<ushort> f)
            => (a, b) => f(a.Content, b.Content);

        [MethodImpl(NotInline), Op]
        public static BinaryOp32 binary(BinaryOp<int> f)
            => (a, b) => f((int)a.Content, (int)b.Content);

        [MethodImpl(NotInline), Op]
        public static BinaryOp32 binary(BinaryOp<uint> f)
            => (a, b)  => f(a.Content, b.Content);

        [MethodImpl(NotInline), Op]
        public static BinaryOp64 binary(BinaryOp<long> f)
            => (a, b)  => f((long)a.Content, (long)b.Content);

        [MethodImpl(NotInline), Op]
        public static BinaryOp64 binary(BinaryOp<ulong> f)
            => (a, b)  => f(a.Content, b.Content);

        /// <summary>
        /// Conforms a vectorized <cref='delegate'/> to a <see cref='BinaryOp128'/> <cref='delegate'/>
        /// </summary>
        /// <param name="f">The source delegate</param>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static BinaryOp128 binary<T>(Func<Vector128<T>,Vector128<T>,Vector128<T>> f)
            where T : unmanaged
                => (Cell128 a, Cell128 b) => f(a.ToVector<T>(), b.ToVector<T>()).ToCell();

        /// <summary>
        /// Conforms a vectorized <cref='delegate'/> to a <see cref='BinaryOp256'/> <cref='delegate'/>
        /// </summary>
        /// <param name="f">The source delegate</param>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static BinaryOp256 binary<T>(Func<Vector256<T>,Vector256<T>,Vector256<T>> f)
            where T : unmanaged
                => (Cell256 a, Cell256 b) => f(a.ToVector<T>(), b.ToVector<T>()).ToCell();

        [MethodImpl(Inline), Op, Closures(Closure)]
        internal static BinaryOp<T> binary<T>(MethodInfo src)
            where T : unmanaged
                => Delegates.binary<T>(src);

        [MethodImpl(Inline), Op]
        public static BinaryOp1 binary(W1 w, MethodInfo f)
            => binary(binary<bit>(f));

        [MethodImpl(Inline), Op]
        public static BinaryOp8 binary(W8i w, MethodInfo f)
            => binary(binary<sbyte>(f));

        [MethodImpl(Inline), Op]
        public static BinaryOp8 binary(W8 w, MethodInfo f)
            => binary(binary<byte>(f));

        [MethodImpl(Inline), Op]
        public static BinaryOp16 binary(W16i w, MethodInfo f)
            => binary(binary<short>(f));

        [MethodImpl(Inline), Op]
        public static BinaryOp16 binary(W16 w, MethodInfo f)
            => binary(binary<ushort>(f));

        [MethodImpl(Inline), Op]
        public static BinaryOp32 binary(W32 w, MethodInfo f)
            => binary(binary<uint>(f));

        [MethodImpl(Inline), Op]
        public static BinaryOp32 binary(W32i w, MethodInfo f)
            => binary(binary<int>(f));

        [MethodImpl(Inline), Op]
        public static BinaryOp64 binary(W64 w, MethodInfo f)
            => binary(binary<ulong>(f));

        [MethodImpl(Inline), Op]
        public static BinaryOp64 binary(W64i w, MethodInfo f)
            => binary(binary<long>(f));
    }
}