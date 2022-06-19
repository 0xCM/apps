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
        /// Determines the type identifer of a numeric kind
        /// </summary>
        /// <param name="kind">The source kind</param>
        [MethodImpl(Inline), Op]
        public static ScalarKind apikind(NumericKind kind)
        {
            var noClass = ((uint)kind << 3) >> 3;
            var noWidth = (noClass >> 16) << 16;
            var key = (ScalarKind)noWidth;
            return key;
        }
    }
}