//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;

    partial struct expr
    {
        /// <summary>
        /// Creates a global scope
        /// </summary>
        /// <param name="name">The scope name</param>
        [MethodImpl(Inline), Op]
        public static ExprScope scope(string name)
            => new ExprScope(EmptyString, name);

        /// <summary>
        /// Creates a child scope
        /// </summary>
        /// <param name="name">The scope name</param>
        [MethodImpl(Inline), Op]
        public static ExprScope scope(string parent, string name)
            => new ExprScope(parent,name);
    }
}