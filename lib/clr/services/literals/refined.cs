//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;

    partial struct ClrLiterals
    {
        /// <summary>
        /// Creates a <see cref='RefinedLiteral{E,T}'/>
        /// </summary>
        /// <param name="value">The numeric value</param>
        /// <param name="t">The primitive value</param>
        /// <typeparam name="E">The enum type</typeparam>
        /// <typeparam name="T">The refined primitive type</typeparam>
        [MethodImpl(Inline)]
        public static RefinedLiteral<E,T> refined<E,T>(T value)
            where E : unmanaged, Enum, IEquatable<E>
            where T : unmanaged, IEquatable<T>
                => new RefinedLiteral<E,T>(Enums.kind<E,T>(value), value);

        /// <summary>
        /// Creates a <see cref='RefinedLiteral{E}'/>
        /// </summary>
        /// <param name="e">The enum literal value</param>
        /// <typeparam name="E">The enumeration type</typeparam>
        [MethodImpl(Inline)]
        public static RefinedLiteral<E> refined<E>(E e)
            where E : unmanaged, Enum, IEquatable<E>
                => new RefinedLiteral<E>(e, Enums.@base<E>());

        /// <summary>
        /// Creates a <see cref='RefinedLiteral{E,T}'/>
        /// </summary>
        /// <param name="e">The enum literal value</param>
        /// <typeparam name="E">The enum type</typeparam>
        /// <typeparam name="T">The refined primitive type</typeparam>
        [MethodImpl(Inline)]
        public static RefinedLiteral<E,T> define<E,T>(E e)
            where E : unmanaged, Enum, IEquatable<E>
            where T : unmanaged, IEquatable<T>
                => new RefinedLiteral<E,T>(e, Enums.scalar<E,T>(e));

        /// <summary>
        /// Creates a <see cref='RefinedLiteral{E,T}'/>
        /// </summary>
        /// <param name="e">The enum literal value</param>
        /// <param name="t">The corresponding primitive value</param>
        /// <typeparam name="E">The enum type</typeparam>
        /// <typeparam name="T">The refined primitive type</typeparam>
        [MethodImpl(Inline)]
        public static RefinedLiteral<E,T> refined<E,T>(E e, T t)
            where E : unmanaged, Enum, IEquatable<E>
            where T : unmanaged, IEquatable<T>
                => new RefinedLiteral<E,T>(e,t);

        /// <summary>
        /// Creates a <see cref='RefinedLiteral{E,T}'/>
        /// </summary>
        /// <param name="value">The numeric value</param>
        /// <param name="t">The primitive value</param>
        /// <typeparam name="E">The enum type</typeparam>
        /// <typeparam name="T">The refined primitive type</typeparam>
        [MethodImpl(Inline)]
        public static RefinedLiteral<E,T> define<E,T>(T value)
            where E : unmanaged, Enum, IEquatable<E>
            where T : unmanaged, IEquatable<T>
                => new RefinedLiteral<E,T>(Enums.kind<E,T>(value), value);
    }
}