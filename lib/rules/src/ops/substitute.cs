//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;

    partial struct RuleModels
    {
        /// <summary>
        /// Defines a <see cref='Substitution{T}'/>
        /// </summary>
        /// <param name="replace">The value to replace</param>
        /// <param name="replacement">The replacement value</param>
        /// <typeparam name="T">The data type</typeparam>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static Substitution<T> substitute<T>(T replace, T replacement)
            => new Substitution<T>(replace, replacement);
    }
}