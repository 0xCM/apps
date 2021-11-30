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
        [MethodImpl(Inline), Op]
        public static NumericKind ToNumericKind(this NumericWidth width, NumericIndicator indicator)
            => NumericKinds.kind(width, indicator);
    }
}