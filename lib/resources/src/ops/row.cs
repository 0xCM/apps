//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;

    partial struct Resources
    {
        [MethodImpl(Inline), Op]
        public unsafe static StringResRow row(in StringRes src)
        {
            var dst = new StringResRow();
            dst.Id = src.Source.MetadataToken;
            dst.Address = src.Value;
            dst.Length = (uint)src.Value.Length;
            return dst;
        }
    }
}