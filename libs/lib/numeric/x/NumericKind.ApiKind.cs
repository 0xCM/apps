//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;

    partial class XNKind
    {
        [MethodImpl(Inline)]
        public static ScalarKind ApiKind(this NumericKind kind)
            => NumericKinds.apikind(kind);
    }
}