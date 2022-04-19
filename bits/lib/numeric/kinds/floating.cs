//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;

    using NK = NumericKind;

    partial class NumericKinds
    {
        /// <summary>
        /// Determines whether a numeric kind designates a floating-point type
        /// </summary>
        /// <param name="T">The type to test</param>
        [MethodImpl(Inline), Op]
        public static bool floating(NumericKind src)
            => (src & NK.Float) != 0;

        /// <summary>
        /// Returns true if a parametric type is of floating-point numeric type, false otherwise
        /// </summary>
        /// <typeparam name="T">The source type</typeparam>
        [MethodImpl(Inline), Op, Closures(AllNumeric)]
        public static bool floating<T>()
            where T : unmanaged
                => typeof(T) == typeof(float)
                || typeof(T) == typeof(double);

        /// <summary>
        /// Returns true if the source type is a primal floating point type, false otherwise
        /// </summary>
        [MethodImpl(Inline), Op]
        public static bool floating(Type t)
            => t == typeof(float)
            || t == typeof(double);

        /// <summary>
        /// Returns true if a value is of floating-point numeric type, false otherwise
        /// </summary>
        [MethodImpl(Inline), Op]
        public static bool floating(object value)
            => value is float || value is double;
    }
}