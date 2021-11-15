//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;

    partial class XWidth
    {
        [MethodImpl(Inline)]
        public static string FormatValue(this NativeTypeWidth w)
            => ((uint)w).ToString();

        [MethodImpl(Inline)]
        public static string FormatValue(this DataWidth w)
            => ((uint)w).ToString();

        [MethodImpl(Inline)]
        public static string FormatValue(this NumericWidth w)
            => ((uint)w).ToString();

        [MethodImpl(Inline)]
        public static string FormatValue(this CpuCellWidth w)
            => ((uint)w).ToString();

        [MethodImpl(Inline)]
        public static string FormatValue(this NativeVectorWidth w)
            => ((uint)w).ToString();
    }
}