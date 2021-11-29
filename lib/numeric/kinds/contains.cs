//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;

    partial class NumericKinds
    {
        /// <summary>
        /// Tests whether an identified type is of specified numeric kind
        /// </summary>
        /// <param name="kind">The source kind</param>
        /// <param name="id">The kind to match</param>
        [MethodImpl(Inline), Op]
        public static bool contains(NumericKind kind, ScalarKind id)
            => ((uint)kind & (uint)id) != 0;
    }
}