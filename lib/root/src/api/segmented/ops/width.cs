//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;

    partial class NativeSegKinds
    {
        public static NativeTypeWidth width(Type src)
            => Widths.segmented(src);
    }
}