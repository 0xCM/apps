//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Vdsl
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;

    partial struct Intrinsics
    {
        public static string format<T>(in m128i<T> src, NumericBaseKind @base)
            where T : unmanaged
        {
            switch(@base)
            {
                case NumericBaseKind.Base10:
                    return string.Format("<{0}>", src.Data.ToVector().Format());
                case NumericBaseKind.Base16:
                    return string.Format("<{0}>", src.Data.ToVector().FormatHex());
            }
            return EmptyString;
        }
    }
}
