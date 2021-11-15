//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;
    using System.Runtime.Intrinsics;

    using static Root;

    partial struct cpu
    {
        /// <summary>
        /// Creates a 128-bit vector with all bits enabled
        /// </summary>
        /// <param name="n">The vector width selector</param>
        /// <typeparam name="T">The primal component type</typeparam>
        [MethodImpl(Inline)]
        public static Vector128<T> vones<T>(W128 w)
            where T : unmanaged
                => gcpu.vones<T>(w);

        /// <summary>
        /// Creates a 256-bit vector with all bits enabled
        /// </summary>
        /// <param name="n">The vector width selector</param>
        /// <typeparam name="T">The primal component type</typeparam>
        [MethodImpl(Inline)]
        public static Vector256<T> vones<T>(W256 w)
            where T : unmanaged
                => gcpu.vones<T>(w);

        /// <summary>
        /// Creates a 512-bit vector with all bits enabled
        /// </summary>
        /// <param name="n">The vector width selector</param>
        /// <typeparam name="T">The primal component type</typeparam>
        [MethodImpl(Inline)]
        public static Vector512<T> vones<T>(W512 w)
            where T : unmanaged
                => gcpu.vones<T>(w);
    }

    partial struct gcpu
    {
        /// <summary>
        /// Creates a 128-bit vector with all bits enabled
        /// </summary>
        /// <param name="n">The vector width selector</param>
        /// <typeparam name="T">The primal component type</typeparam>
        [MethodImpl(Inline), Ones, Closures(AllNumeric)]
        public static Vector128<T> vones<T>(W128 n, T t = default)
            where T : unmanaged
                => gcpu.veq(default(Vector128<T>), default(Vector128<T>));

        /// <summary>
        /// Creates a 256-bit vector with all bits enabled
        /// </summary>
        /// <param name="n">The vector width selector</param>
        /// <typeparam name="T">The primal component type</typeparam>
        [MethodImpl(Inline), Ones, Closures(AllNumeric)]
        public static Vector256<T> vones<T>(W256 n, T t = default)
            where T : unmanaged
                => gcpu.veq(default(Vector256<T>), default(Vector256<T>));

        /// <summary>
        /// Creates a 512-bit vector with all bits enabled
        /// </summary>
        /// <param name="n">The vector width selector</param>
        /// <typeparam name="T">The primal component type</typeparam>
        [MethodImpl(Inline), Ones, Closures(AllNumeric)]
        public static Vector512<T> vones<T>(W512 n, T t = default)
            where T : unmanaged
                => gcpu.veq(default(Vector512<T>), default(Vector512<T>));
    }
}