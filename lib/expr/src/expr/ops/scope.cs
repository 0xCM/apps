//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using Expr;

    using static Root;

    partial struct expr
    {
        /// <summary>
        /// Creates a global scope
        /// </summary>
        /// <param name="name">The scope name</param>
        [MethodImpl(Inline), Op]
        public static ExprScope scope(Label name)
            => new ExprScope(Label.Empty, name);

        /// <summary>
        /// Creates a child scope
        /// </summary>
        /// <param name="name">The scope name</param>
        [MethodImpl(Inline), Op]
        public static ExprScope scope(Label parent, Label name)
            => new ExprScope(parent,name);
    }
}