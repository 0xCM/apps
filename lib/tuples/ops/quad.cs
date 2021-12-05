//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;

    partial class Tuples
    {
        /// <summary>
        /// Creates an immutable homogenous 4-tuple
        /// </summary>
        /// <param name="a">The first member</param>
        /// <param name="b">The second member</param>
        /// <param name="c">The third member</param>
        /// <param name="d">The fourth member</param>
        /// <typeparam name="T">The member type</typeparam>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static ConstQuad<T> quad<T>(T a, T b, T c, T d)
            => new ConstQuad<T>(a,b,c,d);
    }
}