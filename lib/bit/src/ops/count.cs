//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;

    partial struct bit
    {
		[MethodImpl(Inline), Op, Closures(Closure)]
		public static uint count<T>(in BitPos<T> src, in BitPos<T> dst)
            where T : unmanaged
			    => (uint)core.abs((long)src.LinearIndex - (long)dst.LinearIndex) + 1;
    }
}